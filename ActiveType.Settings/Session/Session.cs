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
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ActiveType.Settings
{
    [Serializable]
    public class Session
    {
        private string innerName_;
        private string innerPath_;

        private CourseCollection innerCourseCollection_ = new CourseCollection();

        private User innerUser_ = null;
        private Course innerCourse_ = null;
        private SessionStatus innerStatus_ = SessionStatus.NONE;

        private DateTime createDate_;
        private DateTime lastLoadDate_;
        private DateTime lastUnloadDate_;

        private int totalLoadCout_ = 0;

        private TimeSpan totalTimeSpent_ = new TimeSpan(0);

        public Session()
        {
            this.createDate_ = DateTime.Now;

            this.lastLoadDate_ = DateTime.Now;
        }

        public Session(User user)
        {
            this.innerUser_ = user;

            this.createDate_ = DateTime.Now;

            this.lastLoadDate_ = DateTime.Now;
        }

        public Session(User user, string path)
        {
            this.innerUser_ = user;

            if (path != "")
            {
                if (this.innerPath_ != "")
                {
                    // path changed so save current session with the new path value
                    if (this.innerPath_ != path)
                    {
                        this.innerPath_ = path;

                        SaveSession();
                    }
                }

                this.innerPath_ = path;

                if (!this.LoadSession(this.Path))
                {
                    // STRING LITERAL //
                    MessageBox.Show("ActiveType cannot load session information. Invalid path [" + this.Path + "]", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public string Name
        {
            get
            {
                return this.innerName_;
            }
            set
            {
                this.innerName_ = value;
            }
        }

        public string Path
        {
            get
            {
                return this.innerPath_;
            }
            set
            {
                this.innerPath_ = value;
            }
        }

        public CourseCollection CompletedCourses
        {
            get
            {
                return this.innerCourseCollection_;
            }
        }

        public User User
        {
            get
            {
                return this.innerUser_;
            }
        }

        public Course Course
        {
            get
            {
                return this.innerCourse_;
            }
            set
            {
                this.innerCourse_ = value;
            }
        }

        public SessionStatus Status
        {
            get
            {
                return this.innerStatus_;
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return this.createDate_;
            }
        }

        public DateTime LastLoadDate
        {
            get
            {
                return this.lastLoadDate_;
            }
        }

        public DateTime LastUnLoadDate
        {
            get
            {
                return this.lastUnloadDate_;
            }
        }

        public int TotalLoadCount
        {
            get
            {
                return this.totalLoadCout_;
            }
        }

        public TimeSpan TotalTimeSpent
        {
            get
            {
                return this.totalTimeSpent_;
            }
        }

        private bool LoadSession(string path)
        {
            if (Utilities.CurentUser != null)
            {
                Session tmpSession = new Session();

                if (File.Exists(path))
                {
                    try
                    {
                        BinaryFormatter bf = new BinaryFormatter();

                        FileStream SessionFile = new FileStream(path, FileMode.Open, FileAccess.Read);

                        tmpSession = (Session)bf.Deserialize(SessionFile);

                        if (tmpSession.User.Username.ToLower() == this.User.Username.ToLower())
                        {
                            this.innerCourse_ = tmpSession.Course;
                            this.innerName_ = tmpSession.Name;
                            this.innerPath_ = tmpSession.Path;
                            this.innerStatus_ = tmpSession.Status;
                            this.innerUser_ = tmpSession.User;
                            this.lastLoadDate_ = DateTime.Now;
                            this.lastUnloadDate_ = tmpSession.lastUnloadDate_;
                            this.totalLoadCout_ = tmpSession.TotalLoadCount;
                            this.totalTimeSpent_ = tmpSession.TotalTimeSpent;

                            SessionFile.Close();

                            this.innerStatus_ = SessionStatus.LOADED;

                            this.totalLoadCout_++;

                            return true;
                        }
                        else
                        {
                            // STRING LITERAL //
                            MessageBox.Show("This session belongs someone else. Please select sessions that belong to you!", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        // STRING LITERAL //
                        MessageBox.Show("Cannot load session", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                }
                else
                    return false;
            }
            else
                return false;
        }

        public bool UnloadSession()
        {
            // set last unload date
            this.lastUnloadDate_ = DateTime.Now;

            // get time spent
            this.totalTimeSpent_.Add(this.LastUnLoadDate.Subtract(this.LastLoadDate));

            // save session
            return this.SaveSession();
        }

        public bool SaveSession()
        {
            if (this.Path != "")
            {
                if (Utilities.CurentUser != null)
                {
                    try
                    {
                        FileStream SessionFile = new FileStream(this.Path, FileMode.OpenOrCreate, FileAccess.Write);

                        BinaryFormatter bf = new BinaryFormatter();

                        bf.Serialize(SessionFile, this);

                        SessionFile.Close();

                        this.innerStatus_ = SessionStatus.SAVED;

                        return true;
                    }
                    catch (Exception ex)
                    {
                        // STRING LITERAL //
                        MessageBox.Show("Cannot save session", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                }
                else
                    return false;
            }
            else
                return false;
        }

        public bool RefreshSession()
        {
            if (this.LoadSession(this.Path))
                return true;
            else
                return false;
        }

        public bool DeleteSession()
        {
            if (this.Path != "")
            {
                if (Utilities.CurentUser != null)
                {
                    try
                    {
                        File.Delete(this.Path);

                        this.innerStatus_ = SessionStatus.DELETED;

                        return true;
                    }
                    catch (Exception ex)
                    {
                        // STRING LITERAL //
                        MessageBox.Show("Cannot delete session", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}
