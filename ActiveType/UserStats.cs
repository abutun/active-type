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

using ActiveType.Settings;
using ActiveType.CustomControls;

namespace ActiveType
{
    public partial class UserStats : Form
    {
        private CourseCategoryCollection courseCategories = new CourseCategoryCollection();

        private Session currentSession = null;

        private Course currentCourse = null;

        private string rootCategoryFilePath;

        public UserStats(Session curSession, Course curCourse)
        {
            InitializeComponent();

            this.currentSession = curSession;

            this.currentCourse = curCourse;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserStats_Load(object sender, EventArgs e)
        {
            if (Utilities.CurentUser != null)
            {
                // get root lessons category file in order to load categories
                rootCategoryFilePath = Utilities.GetLessonsCategoryFile();

                if (this.courseCategories.LoadCourseCategories(rootCategoryFilePath))
                {
                    PopulateCourses();

                    GetGeneralInformation();

                    GetAccuracyInformation();

                    GetTimeTakenInformation();

                    GetKeyStats();
                }
                else
                {
                    // STRING LITERAL //
                    MessageBox.Show("ActiveType cannot get category information. Invalid path [" + rootCategoryFilePath + "]", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // STRING LITERAL //
                MessageBox.Show("ActiveType cannot load user.", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetKeyStats()
        {
            if (this.currentCourse != null)
            {
                KeyStatsPanel keyResponsePanel = new KeyStatsPanel(this.currentCourse);
                keyResponsePanel.Location = new Point(0, 0);

                this.keyResponseTab.Controls.Add(keyResponsePanel);
            }
        }

        private void GetTimeTakenInformation()
        {
            TimeSpan overallTimeTaken = new TimeSpan(0);

            int courseStatIndex = -1;

            for (int i = 0; i < Utilities.CurentUser.Statistics.Count; i++)
            {
                overallTimeTaken.Add(Utilities.CurentUser.Statistics[i].TimeTaken);

                if (this.currentCourse != null)
                {
                    if (Utilities.CurentUser.Statistics[i].Course.Path.ToUpper() == this.currentCourse.Path.ToUpper())
                        courseStatIndex = i;
                }
            }

            // STRING LITERAL //
            this.overallTimeTakenLabel.Text = overallTimeTaken.Days.ToString() + " d " + Utilities.PadZero(overallTimeTaken.Hours) + ":" + Utilities.PadZero(overallTimeTaken.Minutes) + ":" + Utilities.PadZero(overallTimeTaken.Seconds);

            if (courseStatIndex != -1)
            {
                Statistics courseStats = Utilities.CurentUser.Statistics[courseStatIndex];

                this.currentCourseName2Label.Name = ": " + courseStats.Course.Name;

                this.selectedCourseTimeTakenLabel.Text = courseStats.TimeTaken.Days.ToString() + " d " + Utilities.PadZero(courseStats.TimeTaken.Hours) + ":" + Utilities.PadZero(courseStats.TimeTaken.Minutes) + ":" + Utilities.PadZero(courseStats.TimeTaken.Seconds);
            }
            else
            {
                this.currentCourseName2Label.Name = ": -";

                this.selectedCourseTimeTakenLabel.Text = "-";
            }
        }

        private void GetGeneralInformation()
        {
            TimeSpan diff;

            if (Utilities.CurentUser != null)
            {
                // load session information
                if (this.currentSession != null)
                {
                    this.currentSessionNameLabel.Text = ": " + this.currentSession.Name;

                    this.currentSessionPathLabel.Text = ": " + this.currentSession.Path;

                    // STRING LITERAL //
                    this.totalCompletedCoursesLabel.Text = ": " + this.currentSession.CompletedCourses.Count.ToString() + " course(s) completed.";
                }
                else
                {
                    this.userCoursesTree.Enabled = false;

                    // STRING LITERAL //
                    this.currentSessionNameLabel.Text = ": Session is not loaded";

                    this.currentSessionPathLabel.Text = ": -";

                    this.totalCompletedCoursesLabel.Text = ": 0";
                }

                //load user information
                this.userFirstNameLabel.Text = ": " + Utilities.CurentUser.FirstName;

                this.userLastNameLabel.Text = ": " + Utilities.CurentUser.LastName;

                this.userUsernameLabel.Text = ": " + Utilities.CurentUser.Username;

                this.userLastLogin.Text = Utilities.CurentUser.LastLogin.ToLongDateString();

                diff = DateTime.Now.Subtract(Utilities.CurentUser.CreateDate);

                // STRING LITERAL //
                this.userTotalTimeSpentLabel.Text = diff.Days.ToString() + " day(s) " + Utilities.PadZero(diff.Hours) + ":" + Utilities.PadZero(diff.Minutes) + ":" + Utilities.PadZero(diff.Seconds);
            }
            else
            {
                // STRING LITERAL //
                MessageBox.Show("ActiveType cannot load user.", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void GetAccuracyInformation()
        {
            int overallAccuracy = 0;

            int courseStatIndex = -1;

            for (int i=0; i<Utilities.CurentUser.Statistics.Count;i++)
            {
                overallAccuracy += Utilities.CurentUser.Statistics[i].Accuracy;

                if (this.currentCourse != null)
                {
                    if (Utilities.CurentUser.Statistics[i].Course.Path.ToUpper() == this.currentCourse.Path.ToUpper())
                        courseStatIndex = i;
                }
            }

            if (Utilities.CurentUser.Statistics.Count!=0)
                overallAccuracy = overallAccuracy / Utilities.CurentUser.Statistics.Count;

            // set overall accuracy
            this.overallCourseAccuracyLabel.Text = overallAccuracy.ToString() + " %";

            if (courseStatIndex != -1)
            {
                this.currentCourseName1Label.Name = ": " + Utilities.CurentUser.Statistics[courseStatIndex].Course.Name;

                this.selectedCourseAccuracyLabel.Text = Utilities.CurentUser.Statistics[courseStatIndex].Accuracy.ToString() + " %";
            }
            else
            {
                this.currentCourseName1Label.Name = ": -";

                this.selectedCourseAccuracyLabel.Text = "-";
            }
        }

        private void PopulateCourses()
        {
            if (this.courseCategories != null)
            {
                this.userCoursesTree.Nodes.Clear();

                foreach (CourseCategory cat in this.courseCategories)
                {
                    int rootIndex;

                    DirectoryInfo d = new DirectoryInfo(cat.Path);

                    if (d != null)
                    {
                        CourseCollection tmpCollection = new CourseCollection();

                        FileInfo[] subCourses = d.GetFiles("*.les", SearchOption.TopDirectoryOnly);

                        // Add root category
                        rootIndex = this.userCoursesTree.Nodes.Add(new TreeNode(cat.Name));

                        // mark it as root
                        this.userCoursesTree.Nodes[rootIndex].Tag = "-1";

                        // add courses to a temporary collection
                        foreach (FileInfo f in subCourses)
                        {
                            Course tmpCourse = new Course(f.FullName);

                            if (tmpCourse.Status == CourseStatus.LOADED)
                                tmpCollection.Add(tmpCourse);
                        }

                        // sort the courses by course number and then add them to the treeview
                        tmpCollection.Sort();

                        foreach (Course itm in tmpCollection)
                        {
                            int subRootIndex;

                            // add it
                            subRootIndex = this.userCoursesTree.Nodes[rootIndex].Nodes.Add(new TreeNode(itm.Name));

                            // mark it as a course item
                            this.userCoursesTree.Nodes[rootIndex].Nodes[subRootIndex].Tag = itm.Path;
                        }
                    }
                    else
                    {
                        // STRING LITERAL //
                        MessageBox.Show("ActiveType cannot get category information. Invalid path [" + cat.Path + "]", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}