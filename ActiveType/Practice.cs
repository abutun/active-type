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
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using ActiveType.Settings;

namespace ActiveType
{
    public partial class Practice : Form
    {
        private DateTime lessonStartTime;

        private int keyProgressValue = 0;
        private int prevUserInputLength = 0;

        private bool courseStarted = false;
        private bool canBeStarted = false;

        private int totalCourses = 0;

        Course firstCourse = null;
        Course currentCourse = null;

        Statistics currentStats = null;

        public Practice(Course selCourse)
        {
            InitializeComponent();

            // load key codes
            this.keyboardLayout.LoadKeyCodes();

            this.firstCourse = selCourse;
        }

        private void ChangeCurrentCourse(Course newCourse)
        {
            // first save user statistics
            if (this.currentStats != null)
                Utilities.SaveCurrentUsers();

            this.currentCourse = newCourse;

            this.currentCourse.RefreshCourse();

            this.currentStats = new Statistics(Utilities.CurentUser, this.currentCourse);
        }

        private void Practice_Load(object sender, EventArgs e)
        {
            // first set current course
            ChangeCurrentCourse(this.firstCourse);

            // Get total lesson count for the current category (beginner, intermedita etc.)
            SetLessonNumber();

            // Load the lesson text to the current LessonOutputBox object
            userLessonOutput.Text = LoadLessonText(false);

            if (userLessonOutput.Text != "")
            {
                // set key progressbar properties for the current lesson
                CalculateKeyProgressValue();

                // does the current LetterInputBox object allow backspace ?
                this.allowBackspaces.Checked = this.userLetterInput.AllowBackSpace;

                // reset current keyboarlayout object (initialize it and load the layout)
                // with the specified language
                keyboardLayout.ResetKeyboardStats();

                // our lesson is ready to be started by the user
                canBeStarted = true;
            }
        }

        private void SetLessonNumber()
        {
            string rootPath = currentCourse.Category.Path;

            try
            {
                DirectoryInfo dInfo = new DirectoryInfo(rootPath); ;

                if (dInfo != null)
                {
                    FileInfo[] fInfo = dInfo.GetFiles("*.les");

                    this.totalCourses = this.lessonProgress.Maximum  = fInfo.Length;

                    this.lessonProgress.Value = 1;
                }
            }
            catch
            {
                // STRING LITERAL //
                MessageBox.Show("ActiveType cannot get lesson information. Invalid path [" + rootPath + "]", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateKeyProgressValue()
        {
            keyProgressValue = userLessonOutput.Text.Length / 100;

            if (keyProgressValue == 0)
                keyProgressValue = 1;

            keyProgress.Maximum = userLessonOutput.Text.Length * keyProgressValue;

            this.lessonNumberLabel.Text = (this.currentCourse.No+1).ToString() + " / " + totalCourses.ToString();
        }

        private void Practice_FormClosing(object sender, FormClosingEventArgs e)
        {
            // kill all used threads
            this.keyboardLayout.KillThreads();

            // unload key codes
            this.keyboardLayout.UnloadKeyCodes();

            ((MainWindow)this.Owner).PractiseWindowClosedDelegate.Invoke();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartStopLessonAux();
        }

        private void userLetterInput_TextChanged(object sender, EventArgs e)
        {
            // get the current length of the LetterInputBox object on the page
            // we will use this value to find the current value of the LetterInputBox
            // notice that LetterInputBox object has a public property named "TotalTextLength"
            // which is used to get the total length of the current LetterInputBox
            // if we had used TextBox object's Text property, the lesson would enter an infinite loop and would never finish!!!
            int curLength = userLetterInput.TotalTextLength;

            // calculate the current value (character index)
            int tmpValue = keyProgress.Value + (curLength - prevUserInputLength) * keyProgressValue;

            // is the curent lesson finished ?
            if (tmpValue >= keyProgress.Maximum)
            {
                // add this completed course to the current session
                ((MainWindow)this.Owner).SessionCourseChangedDelegate.Invoke(this.currentCourse);

                // stop statistics timer first
                this.calculateStatsTimer.Enabled = false;

                // then jump to the next lesson if it exists
                JumpToNextLesson();

                // reset previously stored temp variables
                prevUserInputLength = 0;
            }
            else
            {
                // if the current lesson has not finished yet, let the user go on...
                keyProgress.Value = tmpValue;
                prevUserInputLength = curLength;
                keyProgress.Refresh();
            }
        }

        private void increaseFontSize_Click(object sender, EventArgs e)
        {
            if (userLessonOutput.Font.Size < userLessonOutput.MaxFontSize)
            {
                userLessonOutput.Font = new Font(userLessonOutput.Font.FontFamily, userLessonOutput.Font.Size + 2);
                userLessonOutput.Refresh();
            }
        }

        private void decreaseFontSize_Click(object sender, EventArgs e)
        {
            if (userLessonOutput.Font.Size > userLessonOutput.MinFontSize)
            {
                userLessonOutput.Font = new Font(userLessonOutput.Font.FontFamily, userLessonOutput.Font.Size - 2);
                userLessonOutput.Refresh();
            }
        }

        private void JumpToNextLessonNumber_Click(object sender, EventArgs e)
        {
            JumpToNextLesson();
        }

        private void JumpToPrevLessonNumber_Click(object sender, EventArgs e)
        {
            JumpToPrevLesson();
        }

        private void StartStopLessonAux()
        {
            // the current lesson can be started ?
            if (canBeStarted)
            {
                // has it started already ?
                if (!courseStarted)
                {
                    // then start it
                    StartLesson();
                }
                else
                {
                    // else stop it
                    StopLesson();
                }
            }
        }

        private void JumpToNextLesson()
        {
            if (this.currentCourse != null)
            {
                if (this.currentCourse.NextCourse != null)
                {
                    ChangeCurrentCourse(this.currentCourse.NextCourse);

                    // lesson progress values shows the lesson numbers (IDs) of the current category (beginner, intermediate etc.)
                    userLessonOutput.Text = LoadLessonText(false);

                    if (userLessonOutput.Text != "")
                    {
                        keyProgress.Value = 0;

                        userLetterInput.TotalTextLength = 0;

                        // Reset preporties
                        userLetterInput.Text = "";

                        // reset keyboard statistics for the previous lesson
                        keyboardLayout.ResetKeyboardStats();

                        // Stop previous thread
                        this.keyboardLayout.StopThreads();

                        // reset keyprogressbar properties
                        CalculateKeyProgressValue();

                        // reset can be started value so that user can start the current lesson
                        canBeStarted = true;

                        if (!this.autoStartLesson.Checked)
                            userLetterInput.Enabled = courseStarted = false;
                        else
                            StartLesson();
                    }
                    else
                    {
                        if (courseStarted)
                            StopLesson();

                        // STRING LITERAL //
                        MessageBox.Show("Next lesson could not be found");
                    }

                    okButton.Text = "Start";
                }
                else
                {
                    // STRING LITERAL //
                    MessageBox.Show("Current course does not have any next lesson", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // STRING LITERAL //
                MessageBox.Show("Cannot load current lesson", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void JumpToPrevLesson()
        {
            if (this.currentCourse != null)
            {
                if (this.currentCourse.PrevCourse != null)
                {
                    ChangeCurrentCourse(this.currentCourse.PrevCourse);

                    userLessonOutput.Text = LoadLessonText(false);

                    if (userLessonOutput.Text != "")
                    {
                        // reset key progress
                        keyProgress.Value = 0;

                        // Reset preporties
                        userLetterInput.Text = "";

                        // reset keyboard statistics for the previous lesson
                        keyboardLayout.ResetKeyboardStats();

                        // Stop previous thread
                        this.keyboardLayout.StopThreads();

                        // reset keyprogressbar properties
                        CalculateKeyProgressValue();

                        // reset can be started value so that user can start the current lesson
                        canBeStarted = true;

                        if (!this.autoStartLesson.Checked)
                            userLetterInput.Enabled = courseStarted = false;
                        else
                            StartLesson();
                    }
                    else
                    {
                        if(courseStarted)
                            StopLesson();

                        // STRING LITERAL //
                        MessageBox.Show("Previous lesson could not be found");
                    }

                    okButton.Text = "Start";
                }
                else
                {
                    // STRING LITERAL //
                    MessageBox.Show("Current course does not have any previous lesson", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // STRING LITERAL //
                MessageBox.Show("Cannot load current lesson", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string LoadLessonText(bool reloadTextOnly)
        {
            string res = "";

            if (this.currentCourse != null)
            {
                res = this.currentCourse.Text;

                // set lesson progress
                lessonProgress.Value = this.currentCourse.No + 1;

                // Clear whitespaces
                if (res != "")
                    res = Regex.Replace(res, @"[\s]{2,}", " ");

                if (!reloadTextOnly)
                {
                    this.Text = this.currentCourse.Name;

                    if (this.currentCourse.NextCourse != null)
                        JumpToNextLessonNumber.Enabled = true;
                    else
                        JumpToNextLessonNumber.Enabled = false;

                    if (this.currentCourse.PrevCourse != null)
                        JumpToPrevLessonNumber.Enabled = true;
                    else
                        JumpToPrevLessonNumber.Enabled = false;

                    if (!courseStarted)
                        userLetterInput.Enabled = false;
                }
            }

            return res;
        }

        private void StartLesson()
        {
            if (!courseStarted)
            {
                // start statistics timer for the current course
                this.calculateStatsTimer.Enabled = true;

                this.userLetterInput.Text = "";

                this.userLetterInput.Enabled = true;

                this.JumpToNextLessonNumber.Enabled = false;

                this.JumpToPrevLessonNumber.Enabled = false;

                this.okButton.Text = "Stop";

                // Start the lesson
                this.userLessonOutput.LetterIndex = 0;

                // Reload lesson text
                this.userLessonOutput.Text = LoadLessonText(true);

                // set lesson start time
                this.lessonStartTime = DateTime.Now;

                this.courseStarted = true;

                this.userLetterInput.Focus();
            }
        }

        private void StopLesson()
        {
            if (courseStarted)
            {
                // start statistics timer for the current course
                this.calculateStatsTimer.Enabled = true;

                this.userLetterInput.Text = "";

                this.userLetterInput.Enabled = false;

                this.JumpToNextLessonNumber.Enabled = true;

                this.JumpToPrevLessonNumber.Enabled = true;

                this.okButton.Text = "Start";

                // reset previously stored temp variables
                this.prevUserInputLength = 0;

                this.keyProgress.Value = 0;

                this.userLetterInput.Enabled = true;

                this.userLetterInput.TotalTextLength = 0;

                this.keyboardLayout.StopThreads();

                // stop the current lesson
                this.courseStarted = false;
            }

        }

        private void allowBackspaces_CheckedChanged(object sender, EventArgs e)
        {
            this.userLetterInput.AllowBackSpace = allowBackspaces.Checked;
        }

        private void userLetterInput_OnCorrectKeyPressed(object sender, EventArgs e)
        {
            if (this.currentStats != null)
                this.currentStats.AddOrRemoveKeyStats(this.userLessonOutput.CurrentLetter, true);
        }

        private void userLetterInput_OnWrongKeyPressed(object sender, EventArgs e)
        {
            if (this.currentStats != null)
                this.currentStats.AddOrRemoveKeyStats(this.userLessonOutput.CurrentLetter, false);
        }

        private void calculateStatsTimer_Tick(object sender, EventArgs e)
        {
            // set current statistics for the current user
            if (this.currentStats != null)
            {
                if (Utilities.CurentUser != null)
                {
                    int currentIndex;

                    // show them first
                    this.currentAccuracyLabel.Text = this.currentStats.Accuracy.ToString() + " %";

                    this.currentKeyPerMinuteLabel.Text = this.currentStats.KeyPerMinute.ToString() + " key/min.";

                    this.currentTimeTakenLabel.Text = Utilities.PadZero(this.currentStats.TimeTaken.Hours) + ":"
                                                      + Utilities.PadZero(this.currentStats.TimeTaken.Minutes) + ":"
                                                      + Utilities.PadZero(this.currentStats.TimeTaken.Seconds);

                    // calculate new stats
                    this.currentStats.TimeTaken = DateTime.Now.Subtract(this.lessonStartTime);

                    if (this.currentStats.TimeTaken.Seconds > 0)
                    {
                        if (this.keyProgress.Value > 0)
                        {
                            int totalSeconds = this.currentStats.TimeTaken.Hours * 60 * 60 + this.currentStats.TimeTaken.Minutes*60+this.currentStats.TimeTaken.Seconds;

                            int keyPerMinute = ((this.keyProgress.Value * 60) / (totalSeconds));

                            this.currentStats.KeyPerMinute = keyPerMinute;
                        }
                    }

                    currentIndex = Utilities.CurentUser.Statistics.Contains(this.currentStats);

                    // if exists in the current collection then update it
                    if (currentIndex != -1)
                        Utilities.CurentUser.Statistics[currentIndex] = this.currentStats;
                    else
                    {
                        // else add it
                        Utilities.CurentUser.Statistics.Add(this.currentStats);
                    }
                }
            }
        }

        private void userLessonOutput_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}