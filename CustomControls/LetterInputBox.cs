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
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ActiveType.CustomControls
{
    public delegate void CorrectKeyPressedEventHandler(object sender, EventArgs e);
    public delegate void WrongKeyPressedEventHandler(object sender, EventArgs e);

    public class LetterInputBox : RichTextBox
    {
        private LessonOutputBox lessonOutputBox_ = null;
        private KeyboardLayout keyboardLayout_ = null;

        private bool allowBackSpace_ = false;
        private Color borderColor_ = Color.Black;
        private int borderWidth_ = 1;

        private int totalTextLength_ = 0;

        private string expectedLetter_ = "";
        private string pressedLetter_ = "";

        public event CorrectKeyPressedEventHandler OnCorrectKeyPressed;
        public event CorrectKeyPressedEventHandler OnWrongKeyPressed;

        #region Constructor Logic

        public LetterInputBox()
        {
            // set default properties
            base.BorderStyle = BorderStyle.None;
            base.BackColor = Color.White;
            base.ForeColor = Color.Black;

            Font = new Font("Verdana", 20, FontStyle.Regular);
        }

        #endregion

        #region Public Properties

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        new public BorderStyle BorderStyle
        {
            get
            {
                return base.BorderStyle;
            }
            set
            {
                base.BorderStyle = BorderStyle;
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        public Color BorderColor
        {
            get
            {
                return borderColor_;
            }
            set
            {
                if (borderColor_ != value)
                {
                    borderColor_ = value;

                    Invalidate();
                }
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [DefaultValue(1)]
        public int BorderWidth
        {
            get
            {
                return borderWidth_;
            }
            set
            {
                if (borderWidth_ != value && value != 0)
                {
                    borderWidth_ = value;

                    Invalidate();
                }
            }
        }

        public bool AllowBackSpace
        {
            get
            {
                return allowBackSpace_;
            }
            set
            {
                allowBackSpace_ = value;
            }
        }

        public LessonOutputBox LessonOutputBox
        {
            get
            {
                return lessonOutputBox_;
            }
            set
            {
                lessonOutputBox_ = value;
            }
        }

        public KeyboardLayout KeyboardLayout
        {
            get
            {
                return keyboardLayout_;
            }
            set
            {
                keyboardLayout_ = value;
            }
        }

        public string ExpectedLetter
        {
            get
            {
                return expectedLetter_;
            }
        }

        public string PressedLetter
        {
            get
            {
                return pressedLetter_;
            }
         }

        public int TotalTextLength
        {
            get
            {
                return totalTextLength_;
            }
            set
            {
                totalTextLength_ = value;
            }
        }

        #endregion

        #region Public Methods
        #endregion

        #region Protected Methods

        public virtual void CorrectKeyPressed(object sender, EventArgs e)
        {
            if (this.OnCorrectKeyPressed != null)
                this.OnCorrectKeyPressed(sender, e);
        }

        public virtual void WrongKeyPressed(object sender, EventArgs e)
        {
            if (this.OnWrongKeyPressed != null)
                this.OnWrongKeyPressed(sender, e);
        }

        protected void SetLetterPairs(string expectedLetter, string pressedLetter)
        {
            this.pressedLetter_ = pressedLetter;
            this.expectedLetter_ = expectedLetter;

            if (expectedLetter == pressedLetter) // pressed key is correct
            {
                KeyboardLayout.ChangeHighlightStatus(2);

                // Play sound
                //Settings.Utilities.PlayCorrectSound();

                // Change the smile
                KeyboardLayout.ChangeSmileImage(1);

                // Set statistics
                KeyboardLayout.CorrectKeyPresses++;

                this.CorrectKeyPressed(this, new EventArgs());
            }
            else // pressed key is wrong
            {
                KeyboardLayout.ChangeHighlightStatus(1);

                // Play sound
                //Settings.Utilities.PlayWrongSound();

                // Change the smile
                KeyboardLayout.ChangeSmileImage(2);

                // Set statistics
                KeyboardLayout.WrongKeyPresses++;

                this.WrongKeyPressed(this, new EventArgs());
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            //IMPORTANT : This method is thought to be managed by threads
            // since the program was responding slowly. When I checked the playsound method
            // in settings, it was clear that Settings.Utilities.PlayWrongSound() and Settings.Utilities.PlayCorrectSound()
            // methods was responsible for that slow response. So it is not neccesary to modify thi
            // method
            KeyPressMainThreadMethod(e);
        }

        private void KeyPressMainThreadMethod(KeyPressEventArgs e)
        {
            // Call base method
            //base.OnKeyPress(e);

            // If not backspace
            if (e.KeyChar != (char)8)
            {
                this.pressedLetter_ = e.KeyChar.ToString();

                // Check if the current expected letter is the same with the pressed letter ?
                // take the neccesary actions after that
                SetLetterPairs(PressedLetter, this.LessonOutputBox.CurrentLetter);

                // Go to next letter
                this.LessonOutputBox.LetterIndex++;
                this.totalTextLength_++;
            }
            else
            {
                // Check if backspace allowed
                if (!this.AllowBackSpace)
                {
                    // Restore the text and re-position the cursor
                    e.Handled = true;
                }
                else
                {
                    // as user pressed the backspace button
                    // decrease the current LetterIndex and TotalTextLength
                    if (this.LessonOutputBox.LetterIndex > 0)
                        this.LessonOutputBox.LetterIndex--;
                    if (this.totalTextLength_ > 0)
                        this.totalTextLength_--;
                }
            }

            // is there any overflow ?
            CheckTextPortion();
        }

        private void CheckTextPortion()
        {
            Graphics g = this.CreateGraphics();
            SizeF size = g.MeasureString(this.Text.Substring(0, this.Text.Length), this.Font);

            // current text length causes and overflow so cut it!
            if (size.Width > this.Width - 15)
                this.Text = this.Text.Substring(this.Text.Length);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == (int)Msgs.WM_PAINT)
            {
                PaintBorder(this.CreateGraphics());
            }
        }

        #endregion

        #region Private Methods

        private void PaintBorder(Graphics g)
        {
            if (this.Enabled)
            {
                for (int i = 0; i < BorderWidth; i++)
                {
                    int newWidth = this.Width;
                    int newHeight = this.Height;

                    int locX = 0;
                    int locY = 0;

                    if (i > 0)
                    {
                        newWidth -= i * 2;
                        newHeight -= i * 2;
                        locX = (this.Width - newWidth) / 2;
                        locY = (this.Height - newHeight) / 2;
                    }
                    else
                    {
                        newWidth -= 1;
                        newHeight -= 1;
                    }

                    if (locX >= 0 && locY >= 0 && newHeight > 0 && newWidth > 0)
                    {
                        g.DrawRectangle(new Pen(new SolidBrush(BorderColor)), new Rectangle(locX,
                                                                                    locY,
                                                                                    newWidth,
                                                                                    newHeight));
                    }
                }
                g.Flush();
            }
        }

        #endregion

    }
}
