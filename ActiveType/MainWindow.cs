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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Threading;

using ActiveType.Properties;
using ActiveType.Settings;

namespace ActiveType
{
    public delegate void PractiseWindowClosedEventHandler();
    public delegate void EditorWindowClosedEventHandler();
    public delegate void CourseAddedOrRemovedEventHandler(bool realod);
    public delegate void SessionCourseChangedEventHandler(Course newCourse);

    public partial class MainWindow : Form
    {
        private bool settingsSaved;

        private bool practiseWindowOpened;

        private bool editorWindowOpened;

        private string rootCategoryFilePath;

        private Course currentCourse = null;

        private CourseCategoryCollection courseCategories = new CourseCategoryCollection();

        private CourseCollection tmpCollection = new CourseCollection();

        private Session currentSession = null;

        public PractiseWindowClosedEventHandler PractiseWindowClosedDelegate;

        public PractiseWindowClosedEventHandler EditorWindowClosedDelegate;

        public CourseAddedOrRemovedEventHandler CourseAddedOrRemovedDelegate;

        public SessionCourseChangedEventHandler SessionCourseChangedDelegate;

        private CultureInfo m_EnglishCulture = new CultureInfo("en-US");
        private CultureInfo m_TurkishCulture = new CultureInfo("tr-TR");

        public MainWindow(string username)
        {
            InitializeComponent();

            // this delegate is used when the practise window is closed
            // only one practise window should be opened at the same time
            PractiseWindowClosedDelegate = new PractiseWindowClosedEventHandler(this.PractiseWindowClosed);

            // this delegate is used when a new course is added or removed
            // changes must be reflected to the toolstripmenu immediately
            CourseAddedOrRemovedDelegate = new CourseAddedOrRemovedEventHandler(this.BindLessonsToMenu);

            // this delegate is used when the editor window is closed
            // only one editor window should be opened at the same time
            EditorWindowClosedDelegate = new PractiseWindowClosedEventHandler(this.EditorWindowClosed);

            // if user loads a session and then opens the practise window this delagate is used
            // when the current course is changed. It resets the current session's course property
            SessionCourseChangedDelegate = new SessionCourseChangedEventHandler(this.SessionCourseChanged);

            // Load settings for this username
            Utilities.LoadSettings(username);
            ActiveType.Settings.Log.AddtoLogFile("Settings sucessfully loaded for user " + username);

            if (Constants.currentLanguage == 0)
            {
                Thread.CurrentThread.CurrentCulture = m_EnglishCulture;
                Thread.CurrentThread.CurrentUICulture = m_EnglishCulture;
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = m_TurkishCulture;
                Thread.CurrentThread.CurrentUICulture = m_TurkishCulture;
            }

            // Set current username
            if (!Utilities.SetCurrentUser(username))
            {
                // STRING LITERAL //
                MessageBox.Show("ActiveType cannot set current user! Application will now shut down!", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error,
                                 MessageBoxDefaultButton.Button1);

                ActiveType.Settings.Log.AddtoLogFile("ActiveType cannot set current user! Application shut down! - " + username);

                this.Close();
            }

            // login user
            Utilities.CurentUser.Login();
            ActiveType.Settings.Log.AddtoLogFile("Login process was sucessfull for the user " + username);

            if (!Utilities.CurentUser.Rights.CanEditLessons)
                this.courseEditorToolStripMenuItem.Enabled = false;

            // initialize root path, first get keyboard layout
            // this part must be called after loadsettings method
            // because we cannot decide the keyboard properties without loading the settings for the current user
            // get root lessons category file in order to load categories
            rootCategoryFilePath = Utilities.GetLessonsCategoryFile();

            if (this.courseCategories.LoadCourseCategories(rootCategoryFilePath))
            {
                // set keyboard layout name as text
                this.Text = "ActiveType - " + Utilities.Settings[Constants.propKeyboardLayout].ToString();

                // bind lessons to current menu item, this method must be called after the lessonRootPath variable is set
                // and also user settings must be set and user must loaded to call this method
                BindLessonsToMenu(false);
            }
            else
            {
                // STRING LITERAL //
                MessageBox.Show("ActiveType cannot load course categories! Please user course editor to create new categories and courses", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error,
                                 MessageBoxDefaultButton.Button1);
            }
        }

        private void BindLessonsToMenu(bool reload)
        {
            if (reload)
                this.courseCategories.LoadCourseCategories(rootCategoryFilePath);

            if (this.courseCategories != null)
            {
                this.courseToolStripMenuItem.DropDownItems.Clear();

                foreach (CourseCategory cat in this.courseCategories)
                {
                    DirectoryInfo d = new DirectoryInfo(cat.Path);

                    if (d != null)
                    {
                        CourseCollection tmpCollection = new CourseCollection();

                        FileInfo[] subCourses = d.GetFiles("*.les", SearchOption.TopDirectoryOnly);

                        // bind root category
                        ToolStripMenuItem rootMenuItem = new ToolStripMenuItem(cat.Name);

                        // add courses to a temporary collection
                        foreach (FileInfo f in subCourses)
                        {
                            Course tmpCourse = new Course(f.FullName);

                            if (tmpCourse.Status == CourseStatus.LOADED)
                                tmpCollection.Add(tmpCourse);
                        }

                        // sort courses
                        tmpCollection.Sort();

                        // bind courses
                        foreach (Course itm in tmpCollection)
                        {
                            ToolStripMenuItem subMenuItem = new ToolStripMenuItem(itm.Name);

                            // set toolstripmenuitem tag to course tag in order to load it when it is clicked
                            subMenuItem.Tag = itm.Path;

                            subMenuItem.Click += new EventHandler(lessonToolStripMenuItem_Click);

                            rootMenuItem.DropDownItems.Add(subMenuItem);
                        }

                        this.courseToolStripMenuItem.DropDownItems.Add(rootMenuItem);
                    }
                    else
                    {
                        // STRING LITERAL //
                        MessageBox.Show("ActiveType cannot get category information. Invalid path [" + cat.Path + "]", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            settingsSaved = false;          
        }

        private void toolTipStripExit_Click(object sender, EventArgs e)
        {
            SaveCurrentSettingsAndUser();

            ActiveType.Settings.Log.AddtoLogFile("Exit program!");
            this.Close();
        }

        private void SaveCurrentSettingsAndUser()
        {
            // Save current users
            Utilities.SaveCurrentUsers();

            // Save settings for current user
            Utilities.SaveSettings(Utilities.CurentUser);

            settingsSaved = true;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!settingsSaved)
                SaveCurrentSettingsAndUser();

            if (this.currentSession != null)
                this.currentSession.UnloadSession();

            // logout user
            Utilities.CurentUser.Logout();
        }

        private void lessonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!practiseWindowOpened)
            {
                PractiseWindowOpened();

                ToolStripItem curItem = (ToolStripItem)sender;

                if (curItem != null)
                {
                    if (curItem.Tag != null)
                    {
                        Course selCourse = new Course(curItem.Tag.ToString());

                        if (selCourse.Status == CourseStatus.LOADED)
                        {
                            // set current course (is used in statistics window)
                            this.currentCourse = selCourse;

                            // open the practise window
                            Practice prcForm = new Practice(selCourse);

                            prcForm.Show(this);
                        }
                    }
                }
            }
            else
            {
                // STRING LITERAL //
                MessageBox.Show("There is already an open practise window. You can not open another practise window!", "ActiveType - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EditorWindowClosed()
        {
            this.editorWindowOpened = false;

            // reflect menu changes
            this.BindLessonsToMenu(true);
        }

        private void PractiseWindowClosed()
        {
            this.practiseWindowOpened = false;
        }

        private void PractiseWindowOpened()
        {
            this.practiseWindowOpened = true;
        }
        
        private void SessionCourseChanged(Course newCourse)
        {
            if (this.currentSession != null)
            {
                this.currentSession.Course = newCourse;

                // if not exists in the session completed courses then add it
                if (!this.currentSession.CompletedCourses.Contains(newCourse))
                    this.currentSession.CompletedCourses.Add(newCourse);

                this.currentSession.SaveSession();
            }

            // set current course (is used in statistics window)
            this.currentCourse = newCourse;
        }

        private void CloseChildrens()
        {
            foreach (Form f in this.MdiChildren)
                f.Close();
        }

        private void HideChildrens()
        {
            foreach (Form f in this.MdiChildren)
                f.Hide();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppSettings setForm = new AppSettings();

            if (setForm.ShowDialog() == DialogResult.OK)
            {
                Utilities.LoadSettings(Utilities.CurentUser);

                BindLessonsToMenu(true);
            }
        }

        private void courseEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!editorWindowOpened)
            {
                this.editorWindowOpened = true;

                CourseEditor editorForm = new CourseEditor();

                editorForm.Show(this);
            }
            else
            {
                // STRING LITERAL //
                MessageBox.Show("There is already an open editor window. You can not open another editor window!", "ActiveType - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bilgisayarkorsanicomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWebSite();
        }

        private void OpenWebSite()
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "iexplore";
            proc.StartInfo.Arguments = "http://www.ahmetbutun.net/";
            proc.Start();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();

            aboutForm.Show();
        }

        private void openSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openSessionDialog.ShowDialog() == DialogResult.OK)
            {
                string path = this.openSessionDialog.FileName;

                Session tmpSession = new Session(Utilities.CurentUser, path);

                if (tmpSession.Status == SessionStatus.LOADED)
                {
                    this.saveSessionToolStripMenuItem.Enabled = true;

                    this.saveSessionAsToolStripMenuItem.Enabled = true;

                    this.closeSessionToolStripMenuItem.Enabled = true;

                    this.currentSession = tmpSession;

                    if (this.currentSession.Course != null)
                    {
                        // STRING LITERAL //
                        if (MessageBox.Show("Session has been loaded successfully.\nWould you like to jump the current course in the session?", "ActiveType - Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Practice prcForm = new Practice(this.currentSession.Course);

                            prcForm.Show(this);
                        }
                    }
                }
                else
                {
                    // STRING LITERAL //
                    MessageBox.Show("ActiveType cannot able to load selected session!", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void closeSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.currentSession != null)
            {
                if (this.currentSession.UnloadSession())
                {
                    this.saveSessionToolStripMenuItem.Enabled = false;

                    this.saveSessionAsToolStripMenuItem.Enabled = false;

                    this.closeSessionToolStripMenuItem.Enabled = false;

                    this.currentSession = null;
                }
                else
                {
                    // STRING LITERAL //
                    MessageBox.Show("ActiveType cannot able to close current session!", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void newSessonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.saveSessionDialog.ShowDialog() == DialogResult.OK)
            {
                string path = this.saveSessionDialog.FileName;

                this.currentSession = new Session(Utilities.CurentUser);
                this.currentSession.Path = path;
                this.currentSession.Name = this.saveSessionDialog.FileName.GetHashCode().ToString();

                if (this.currentSession.SaveSession())
                {
                    this.saveSessionToolStripMenuItem.Enabled = true;

                    this.saveSessionAsToolStripMenuItem.Enabled = true;
                }
                else
                {
                    // STRING LITERAL //
                    MessageBox.Show("ActiveType cannot able to create a new session!", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.currentSession = null;
                }
            }
        }

        private void saveSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.currentSession != null)
                this.currentSession.SaveSession();
        }

        private void saveSessionAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.saveSessionDialog.ShowDialog() == DialogResult.OK)
            {
                string path = this.saveSessionDialog.FileName;

                Session tmpSession = new Session(Utilities.CurentUser, path);

                if (!tmpSession.SaveSession())
                {
                    // STRING LITERAL //
                    MessageBox.Show("ActiveType cannot able to save session!", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    this.currentSession = tmpSession;
            }
        }

        private void keyResponseTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserStats statsForm = new UserStats(this.currentSession, this.currentCourse);

            statsForm.Show();
        }
    }
}