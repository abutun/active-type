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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ActiveType.CustomControls
{
    // IndexChanged Delegate
    public delegate void LetterIndexChangedEventHandler(object sender, EventArgs e);

    public class LessonOutputBox : RichTextBox
    {
        // IndexChanged Event
        public event LetterIndexChangedEventHandler LetterChanged = null;

        private LetterInputBox userLetterInputBox_ = null;
        private KeyboardLayout keyboardLayout_ = null;

        private int maxFontSize_ = 20;
        private int minFontSize_ = 8;

        private Color borderColor_ = Color.Black;
        private int borderWidth_ = 1;

        private string previousLetter_;
        private string currentLetter_;
        private string nextLetter_;

        private int letterIndex_ = 0;

        private Color selectionBackBolor_;
        private Font selectionFont_;
        private Font defaultSelectionFont_ = new Font("Verdana", 14, FontStyle.Regular);
        private Color selectionColor_;

        #region Constructor Logic

        public LessonOutputBox()
        {
            // set default properties
            base.BorderStyle = BorderStyle.None;
            base.BackColor = Color.White;
            base.ForeColor = Color.Black;
            base.Font = new Font("Verdana", 20, FontStyle.Regular);

            BaseSelectionColor = Color.Red;
            BaseSelectionBackColor = Color.Yellow;
            BaseSelectionFont = defaultSelectionFont_;
        }

        #endregion

        #region Public Properties

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

        public LetterInputBox UserLetterInputBox
        {
            get
            {
                return userLetterInputBox_;
            }
            set
            {
                userLetterInputBox_ = value;
            }
        }

        public int MaxFontSize
        {
            get
            {
                return this.maxFontSize_;
            }
        }

        public int MinFontSize
        {
            get
            {
                return this.minFontSize_;
            }
        }

        [Browsable(false)]
        public string PreviousLetter
        {
            get
            {
                return previousLetter_;
            }
            set
            {
                previousLetter_ = value;
            }
        }

        [Browsable(false)]
        public string CurrentLetter
        {
            get
            {
                return currentLetter_;
            }
            set
            {
                currentLetter_ = value;

                if (this.KeyboardLayout != null)
                    this.KeyboardLayout.ExpectedKeyCodes = this.KeyboardLayout.GetKeyCodeQueue(currentLetter_);
            }
        }

        [Browsable(false)]
        public string NextLetter
        {
            get
            {
                return nextLetter_;
            }
            set
            {
                nextLetter_ = value;
            }
        }

        [Browsable(false)]
        public int LetterIndex
        {
            get
            {
                return letterIndex_;
            }
            set
            {
                if (value >= 0 && value < Text.Length)
                {
                    letterIndex_ = value;

                    EventArgs e = new EventArgs();

                    // if letter index changed, update the properties, stats etc.
                    OnLetterIndexChanged(e);

                    // fire the event
                    if (LetterChanged != null)
                    {
                        LetterChanged(this, e);
                    }
                }
            }
        }

        [DefaultValue(typeof(Color), "Red")]
        public Color BaseSelectionColor
        {
            get
            {
                return selectionColor_;
            }
            set
            {
                selectionColor_ = value;
            }
        }

        [DefaultValue(typeof(Color), "Yellow")]
        public Color BaseSelectionBackColor
        {
            get
            {
                return selectionBackBolor_;
            }
            set
            {
                selectionBackBolor_ = value;
            }
        }

        public Font BaseSelectionFont
        {
            get
            {
                return selectionFont_;
            }
            set
            {
                selectionFont_ = value;
            }
        }

        #endregion

        #region Public Methods

        private bool ShouldSerializeBaseSelectionFont()
        {
            return (!BaseSelectionFont.Equals(defaultSelectionFont_));
        }

        #endregion

        #region Protected Methods

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == (int)Msgs.WM_PAINT)
            {
                PaintBorder(this.CreateGraphics());
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            //base.OnKeyPress(e);

            e.Handled = true;
        }

        protected virtual void OnLetterIndexChanged(EventArgs e)
        {
            // set current and previous letters of the object
            ChangeLetters();

            // check if the current index reached to the end of the seen part of the 
            // inner richtextbox object
            CheckTextPortion();

            // highlight the current letter (so that user understands better which key to press)
            HighlightCurrentLetter();

            // also higlight the finger on the keyboardlayout
            // which current letter must be pressed with
            KeyboardLayout.HighlightExpectedLetter(CurrentLetter);

            //if (this.letterIndex_>=this.Text.Length-1)
            //    this.letterIndex_ = 0;
        }

        #endregion

        #region Private Methods

        private void CheckTextPortion()
        {
            Graphics g = this.CreateGraphics();

            SizeF size = g.MeasureString(this.Text.Substring(0, LetterIndex), this.Font);

            // current text length causes and overflow so cut it!
            if (size.Width > this.Width - 40)
            {
                this.Text = this.Text.Substring(LetterIndex);

                LetterIndex = 0;
            }
        }

        private void ChangeLetters()
        {
            if (LetterIndex >= 0 && LetterIndex < Text.Length)
            {
                if (LetterIndex > 0)
                    PreviousLetter = Text[LetterIndex - 1].ToString();
                else
                    PreviousLetter = "";

                CurrentLetter = Text[LetterIndex].ToString();

                if (LetterIndex > 0 && LetterIndex + 1 < Text.Length)
                    NextLetter = Text[LetterIndex + 1].ToString();
                else
                    NextLetter = "";
            }
        }

        private void HighlightCurrentLetter()
        {
            // highlight curent selection
            Select(LetterIndex, 1);

            // this is a bug actually, if the lesson is started for the first time
            // the background color of the textbox is set to the baseselectioncolor
            // instead of the textbox backcolor ???
            if(LetterIndex==0)
                SelectionBackColor = this.BackColor;
            else
                SelectionBackColor = BaseSelectionBackColor;
            SelectionFont = this.Font;
            SelectionColor = BaseSelectionColor;

            // reload previous selection
            if (LetterIndex > 0)
            {
                Select(LetterIndex - 1, 1);
                SelectionBackColor = this.BackColor;
                SelectionFont = this.Font;
                SelectionColor = this.ForeColor;
            }
        }

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
