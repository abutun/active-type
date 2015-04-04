/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*																		*
*	Copyright (C) 2007  Ahmet BUTUN (butun180@hotmail.com)				*
*	http://www.ahmetbutun.net									        *
*																		*
*	This program is free software; you can redistribute it and/or		*
*	modify it under the terms of the GNU General Public License as		*
*	published by the Free Software Foundation; either version 2 of		*
*	the License, or (at your option) any later version.					*
*																		*
*	This program is distributed in the hope that it will be useful,		*
*	but WITHOUT ANY WARRANTY; without even the implied warranty of		*
*	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU	*
*	General Public License for more details.							*
*																		*
*	You should have received a copy of the GNU General Public License	*
*	along with this program; if not, write to the Free Software			*
*	Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.			*
*																		*
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  */

using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Media;

namespace ActiveType.Settings
{
    public class Utilities
    {
        private static Settings Settings_;
        private static UserCollection Users_;
        private static User currentUser_;

        private static bool soundsLoaded_ = false;
        private static bool playSounds_ = true;

        private static SoundPlayer correctKeyPlayer_ = new SoundPlayer();
        private static SoundPlayer wrongKeyPlayer_ = new SoundPlayer();

        /// <summary>
        /// current user
        /// </summary>
        public static User CurentUser
        {
            get
            {
                return currentUser_;
            }
        }

        /// <summary>
        /// are sounds allowed ? 
        /// </summary>
        public static bool PlaySounds
        {
            get
            {
                return playSounds_;
            }
            set
            {
                playSounds_ = value;
            }
        }

        /// <summary>
        /// settings for the current user
        /// </summary>
        public static Settings Settings
        {
            get
            {
                return Settings_;
            }
        }

        /// <summary>
        /// users collection
        /// </summary>
        public static UserCollection Users
        {
            get
            {
                return Users_;
            }
        }

        /// <summary>
        /// changes the current user
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool SetCurrentUser(string username)
        {
            ActiveType.Settings.Log.AddtoLogFile("Setting current user to " + username + " ...");
            if (Users.Contains(username))
            {
                User tempUser = Users.Find(username);
                if (tempUser != null)
                {
                    currentUser_ = tempUser;
                    ActiveType.Settings.Log.AddtoLogFile("     User sucessfully set");
                    return true;
                }
                else
                {
                    ActiveType.Settings.Log.AddtoLogFile("     Failure! User can not be found!");
                    return false;
                }
            }
            else
            {
                ActiveType.Settings.Log.AddtoLogFile("     Failure! User not found!");
                return false;
            }
        }

        public static void SafeCheckDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public static bool LoadSettings(string username)
        {
            User tmpUser = Users.Find(username);

            return LoadSettingsAux(tmpUser);
        }

        public static bool LoadSettings(User currentUser)
        {
            return LoadSettingsAux(currentUser);
        }

        public static bool SaveSettings(User currentUser)
        {
            return SaveSettingsAux(currentUser);
        }

        public static string GetLessonsRootPath()
        {
            string res = "";

            if (Utilities.Settings != null)
            {
                Keyboard keyboardLayout = (Keyboard)Utilities.Settings[Constants.propKeyboardLayout];

                if (keyboardLayout.Code != "")
                    res = AppDomain.CurrentDomain.BaseDirectory + "lessons\\" + keyboardLayout.Code.ToLower() + "\\";

                if (keyboardLayout.KeyboardType != "")
                    res = res + keyboardLayout.KeyboardType.ToLower() + "\\";
            }
            else
            {
                // STRING LITERAL //
                MessageBox.Show("Cannot get lessons path. Setting are not implemented yet", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return res;
        }

        public static string GetLessonsCategoryFile()
        {
            string res = "";

            if (Utilities.Settings != null)
            {
                Keyboard keyboardLayout = (Keyboard)Utilities.Settings[Constants.propKeyboardLayout];

                if (keyboardLayout.Code != "")
                    res = AppDomain.CurrentDomain.BaseDirectory + "lessons\\" + keyboardLayout.Code.ToLower() + "\\";

                if (keyboardLayout.KeyboardType != "")
                    res = res + keyboardLayout.KeyboardType.ToLower() + "\\";

                res = res + "lessons.cat";
            }
            else
            {
                // STRING LITERAL //
                MessageBox.Show("Cannot get lessons categories. Setting are not implemented yet", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return res;
        }

        private static bool LoadSettingsAux(User currentUser)
        {
            ActiveType.Settings.Log.AddtoLogFile("Loading settings for current user...");

            Settings_ = new Settings();

            if (currentUser != null)
            {
                string FilePath = AppDomain.CurrentDomain.BaseDirectory + Constants.settingsDirectory + "/" + currentUser.Username + ".bin";

                if (File.Exists(FilePath))
                {
                    try
                    {
                        BinaryFormatter bf = new BinaryFormatter();

                        FileStream SettingFile = new FileStream(FilePath, FileMode.Open, FileAccess.Read);

                        Settings curSettings = (Settings)bf.Deserialize(SettingFile);

                        Settings_ = curSettings;

                        SettingFile.Close();

                        ActiveType.Settings.Log.AddtoLogFile("     Settings sucessfully loaded!");

                        LoadGlobalProperties();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        ExceptionUtilities.ShowException(ex, MessageBoxButtons.OK);
                        return false;
                    }
                }
                else
                {
                    ActiveType.Settings.Log.AddtoLogFile("     " + currentUser.Username + ".bin file not found!");
                    return false;
                }
            }
            else
            {
                ActiveType.Settings.Log.AddtoLogFile("     User object is null!");
                return false;
            }
        }

        private static void LoadGlobalProperties()
        {
            // LANGUAGE
            if (Utilities.Settings.Contains(Constants.propLanguage))
                Constants.currentLanguage = int.Parse(Utilities.Settings[Constants.propLanguage].ToString());
        }

        private static bool SaveSettingsAux(User currentUser)
        {
            ActiveType.Settings.Log.AddtoLogFile("Saving settings for current user...");

            SafeCheckDirectory(AppDomain.CurrentDomain.BaseDirectory + Constants.settingsDirectory);

            if (currentUser != null)
            {
                string FilePath = AppDomain.CurrentDomain.BaseDirectory + Constants.settingsDirectory + "/" + currentUser.Username + ".bin";

                try
                {
                    FileStream SettingFile = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Write);

                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(SettingFile, Settings_);

                    SettingFile.Close();

                    ActiveType.Settings.Log.AddtoLogFile("     Settings sucessfully saved!");

                    return true;
                }
                catch (Exception ex)
                {
                    ExceptionUtilities.ShowException(ex, MessageBoxButtons.OK);
                    return false;
                }
            }
            else
            {
                ActiveType.Settings.Log.AddtoLogFile("     User object is null!");
                return false;
            }
        }

        public static void LoadUsers()
        {
            ActiveType.Settings.Log.AddtoLogFile("Loading current users...");

            Utilities.SafeCheckDirectory(AppDomain.CurrentDomain.BaseDirectory + Constants.usersDirectory);

            string FilePath = AppDomain.CurrentDomain.BaseDirectory + Constants.usersDirectory + "/users.bin";

            if (File.Exists(FilePath))
            {
                BinaryFormatter bf = new BinaryFormatter();

                FileStream UsersFile = new FileStream(FilePath, FileMode.Open, FileAccess.Read);

                Users_ = (UserCollection)bf.Deserialize(UsersFile);

                UsersFile.Close();
            }
            else
                Users_ = new UserCollection();
        }

        public static void SaveCurrentUsers()
        {
            ActiveType.Settings.Log.AddtoLogFile("Saving current users...");

            Utilities.SafeCheckDirectory(AppDomain.CurrentDomain.BaseDirectory + Constants.usersDirectory);

            string FilePath = AppDomain.CurrentDomain.BaseDirectory + Constants.usersDirectory + "/users.bin";

            BinaryFormatter bf = new BinaryFormatter();

            FileStream UsersFile = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Write);

            bf.Serialize(UsersFile, Users);

            UsersFile.Close();
        }

        // MEDIA
        public static void LoadSounds()
        {
            // if user presses the correct key, use this sound ?
            correctKeyPlayer_.SoundLocation = @"sounds\good.wav";

            // if user presses the wrong key, use this sound ?
            wrongKeyPlayer_.SoundLocation = @"sounds\bad.wav";

            // play it 
            if (File.Exists(@"sounds\good.wav"))
                correctKeyPlayer_.LoadAsync();

            // play it
            if (File.Exists(@"sounds\bad.wav"))
                wrongKeyPlayer_.LoadAsync();

            soundsLoaded_ = true;
        }

        public static void PlayCorrectSound()
        {
            if (PlaySounds)
            {
                if (!soundsLoaded_)
                    LoadSounds();

                correctKeyPlayer_.Play();
            }
        }

        public static void PlayWrongSound()
        {
            if (PlaySounds)
            {
                if (!soundsLoaded_)
                    LoadSounds();

                wrongKeyPlayer_.Play();
            }
        }

        public static string PadZero(int val)
        {
            if (val < 10)
                return "0" + val.ToString();
            else
                return val.ToString();
        }
    }

    public class ExceptionUtilities
    {
        public static void ShowException(Exception ex, MessageBoxButtons defButton)
        {
            MessageBox.Show("Message:" + ex.Message + "\n" + "Source:" + ex.Source + "\n" + "StackTrace:" + ex.StackTrace + "\n",
                            "Exception", defButton, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
        }
    }
}
