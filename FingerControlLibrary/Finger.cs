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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Drawing.Design;
using System.Threading;

namespace ActiveType.FingerControlLibrary
{
    public delegate void OnFingerPressEventHandler(Object sender, EventArgs e);

    public partial class Finger : Panel
    {
        private System.ComponentModel.Container components;

        private HighlightMode highlightMode_ = HighlightMode.COLOR;

        private FingerLetterItemCollection responsibleLetters_;
        private FingerType fingerType_ = FingerType.None;

        private bool waitForToBePressed_ = false;

        private Color baseBackGroundColor_ = Color.Transparent;
        private Color highlightColor_ = Color.LimeGreen;
        private Color correctKeyPressedColor_ = Color.DodgerBlue;
        private Color wrongKeyPressedColor_ = Color.Red;

        private Bitmap baseBackGroundImage_ = null;
        private Bitmap highlightImage_ = null;
        private Bitmap correctKeyPressedImage_ = null;
        private Bitmap wrongKeyPressedImage_ = null;

        private int highlightState_ = 0; // 0 = Highlight, 1 = Wrong Key Pressed, 2 = Corrrect Key Pressed

        private OnFingerPressEventHandler OnFingerPressed = null;

        private Thread m_HighlightWorker;

        #region Constructor Logic & Windows Form Designer Support

        public Finger()
        {
            InitializeComponent();

            HighlightColor = Color.LimeGreen;
            CorrectKeyPressedColor = Color.DodgerBlue;
            WrongKeyPressedColor = Color.Red;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.responsibleLetters_ = new FingerLetterItemCollection();

            this.ForeColor = System.Drawing.Color.Black;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Size = new System.Drawing.Size(15, 60);
            this.Text = "Finger";
        }

        #endregion

        #region Public Properties

        [
        Category("FingerType"),
        RefreshProperties(RefreshProperties.Repaint),
        DefaultValue(FingerType.None)
        ]
        public FingerType FingerType
        {
            get
            {
                return fingerType_;
            }
            set
            {
                if (this.fingerType_ != value)
                {
                    this.fingerType_ = value;
                    
                    SetFingerLetters();

                    SetSize();

                    Invalidate();
                }
            }
        }

        [
        Category("Color"),
        RefreshProperties(RefreshProperties.Repaint)
        ]
        public Color HighlightColor
        {
            get
            {
                return highlightColor_;
            }
            set
            {
                if (this.highlightColor_ != value)
                {
                    this.highlightColor_ = value;

                    Invalidate();
                }
            }
        }

        [
        Category("Color")
        ]
        public Color CorrectKeyPressedColor
        {
            get
            {
                return correctKeyPressedColor_;
            }
            set
            {
                if (this.correctKeyPressedColor_ != value)
                {
                    this.correctKeyPressedColor_ = value;

                    Invalidate();
                }
            }
        }

        [Browsable(false)]
        public Color BaseBackGroundColor
        {
            get
            {
                return baseBackGroundColor_;
            }
        }

        [
        Category("Color")
        ]
        public Color WrongKeyPressedColor
        {
            get
            {
                return wrongKeyPressedColor_;
            }
            set
            {
                if (this.wrongKeyPressedColor_ != value)
                {
                    this.wrongKeyPressedColor_ = value;

                    Invalidate();
                }
            }
        }

        [Browsable(false)]
        public Bitmap HighlightImage
        {
            get
            {
                return highlightImage_;
            }
        }

        [Browsable(false)]
        public Bitmap BaseBackGroundImage
        {
            get
            {
                return baseBackGroundImage_;
            }
        }

        [Browsable(false)]
        public Bitmap CorrectKeyPressedImage
        {
            get
            {
                return correctKeyPressedImage_;
            }
        }

        [Browsable(false)]
        public Bitmap WrongKeyPressedImage
        {
            get
            {
                return wrongKeyPressedImage_;
            }
        }

        [
        Category("Style")
        ]
        public HighlightMode HighlightMode
        {
            get
            {
                return highlightMode_;
            }
            set
            {
                this.highlightMode_ = value;
                SetBackgroundImages();
            }
        }

        [Browsable(false)]
        public int HighlightState
        {
            get
            {
                return highlightState_;
            }
            set
            {
                highlightState_ = value;
            }
        }

        [Browsable(false)]
        public System.Threading.ThreadState HighlightThreadState
        {
            get
            {
                if (m_HighlightWorker != null)
                    return m_HighlightWorker.ThreadState;
                else
                    return System.Threading.ThreadState.Unstarted;
            }
        }

        [Browsable(false)]
        public bool WaitForToBePressed
        {
            get
            {
                return waitForToBePressed_;
            }
            set
            {
                if (this.waitForToBePressed_ != value)
                {
                    this.waitForToBePressed_ = value;

                    // Be sure that current thread is stopped
                    StopHighlightThread();

                    // If value is true then start a new thread
                    if (value)
                    {
                        // create worker thread instance
                        m_HighlightWorker = new Thread(new ThreadStart(this.HighligthWorkerThreadMethod));

                        m_HighlightWorker.Name = "Finger Worker Thread";

                        m_HighlightWorker.IsBackground = true;

                        m_HighlightWorker.Priority = ThreadPriority.Normal;

                        m_HighlightWorker.Start();
                    }

                }
            }
        }

        [Category("Collections")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(FingerItemCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public FingerLetterItemCollection ResponsibleLetters
        {
            get
            {
                return responsibleLetters_;
            }
        }
    
        #endregion

        #region Public Methods

        public void KillThread()
        {
            if (m_HighlightWorker != null)
                m_HighlightWorker.Abort();
        }

        // Stop worker thread if it is running.
        // Called when user presses Stop button or form is closed.
        public void StopHighlightThread()
        {
            if (m_HighlightWorker != null && m_HighlightWorker.IsAlive)  // thread is active
            {
                try
                {
                    m_HighlightWorker.Abort();
                }
                catch
                {
                    // NOP
                }
            }

            // Current thread could change the back color
            if (this.HighlightMode == HighlightMode.COLOR)
                BackColor = BaseBackGroundColor;
            else
                BackgroundImage = BaseBackGroundImage;

            Refresh();
        }

        #endregion

        #region Protected Methods

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.Enabled)
            {
                SetSize();

                SetFingerLetters();

                e.Graphics.FillRectangle(new SolidBrush(base.BackColor), this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);
                e.Graphics.Flush();
            }
        }

        protected virtual void OnKeyPressed(EventArgs e)
        {
            if (this.OnFingerPressed != null)
            {
                this.OnFingerPressed.Invoke(this, e);
            }
        }

        #endregion

        #region Private Methods

        private void SetBackgroundImages()
        {
            switch (this.FingerType)
            {
                case FingerType.LeftSmall:
                    this.highlightImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.leftsmallg;
                    this.baseBackGroundImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.leftsmall;
                    this.correctKeyPressedImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.leftsmallb;
                    this.wrongKeyPressedImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.leftsmallr;
                    break;
                case FingerType.LeftRing:
                    this.highlightImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.leftringg;
                    this.baseBackGroundImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.leftring;
                    this.correctKeyPressedImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.leftringb;
                    this.wrongKeyPressedImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.leftringr;
                    break;
                case FingerType.LeftMiddle:
                    this.highlightImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.leftmiddleg;
                    this.baseBackGroundImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.leftmiddle;
                    this.correctKeyPressedImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.leftmiddleb;
                    this.wrongKeyPressedImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.leftmiddler;
                    break;
                case FingerType.LeftIndex:
                    this.highlightImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.leftindexg;
                    this.baseBackGroundImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.leftindex;
                    this.correctKeyPressedImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.leftindexb;
                    this.wrongKeyPressedImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.leftindexr;
                    break;
                case FingerType.LeftThumb:
                    this.highlightImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.leftthumbg;
                    this.baseBackGroundImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.leftthumb;
                    this.correctKeyPressedImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.leftthumbb;
                    this.wrongKeyPressedImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.leftthumbr;
                    break;
                case FingerType.RightSmall:
                    this.highlightImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.rightsmallg;
                    this.baseBackGroundImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.rightsmall;
                    this.correctKeyPressedImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.rightsmallb;
                    this.wrongKeyPressedImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.rightsmallr;
                    break;
                case FingerType.RightRing:
                    this.highlightImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.rightringg;
                    this.baseBackGroundImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.rightring;
                    this.correctKeyPressedImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.rightringb;
                    this.wrongKeyPressedImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.rightringr;
                    break;
                case FingerType.RightMiddle:
                    this.highlightImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.rightmiddleg;
                    this.baseBackGroundImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.rightmiddle;
                    this.correctKeyPressedImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.rightmiddleb;
                    this.wrongKeyPressedImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.rightmiddler;
                    break;
                case FingerType.RightIndex:
                    this.highlightImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.rightindexg;
                    this.baseBackGroundImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.rightindex;
                    this.correctKeyPressedImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.rightindexb;
                    this.wrongKeyPressedImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.rightindexr;
                    break;
                case FingerType.RightThumb:
                    this.highlightImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.rightthumbg;
                    this.baseBackGroundImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.rightthumb;
                    this.correctKeyPressedImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.rightthumbb;
                    this.wrongKeyPressedImage_ = global::ActiveType.FingerControlLibrary.Properties.Resources.rightthumbr;
                    break;
            }
        }

        private void SetFingerLetters()
        {
            FingerLetterItemCollection tmpCol = new FingerLetterItemCollection();

            switch (this.FingerType)
            {
                case FingerType.LeftSmall:
                    tmpCol.Add(new FingerLetterItem("q"));
                    tmpCol.Add(new FingerLetterItem("a"));
                    tmpCol.Add(new FingerLetterItem("z"));
                    tmpCol.Add(new FingerLetterItem("<"));
                    tmpCol.Add(new FingerLetterItem(">"));
                    tmpCol.Add(new FingerLetterItem("|"));
                    break;
                case FingerType.LeftRing:
                    tmpCol.Add(new FingerLetterItem("w"));
                    tmpCol.Add(new FingerLetterItem("s"));
                    tmpCol.Add(new FingerLetterItem("x"));
                    break;
                case FingerType.LeftMiddle:
                    tmpCol.Add(new FingerLetterItem("e"));
                    tmpCol.Add(new FingerLetterItem("d"));
                    tmpCol.Add(new FingerLetterItem("c"));
                    break;
                case FingerType.LeftIndex:
                    tmpCol.Add(new FingerLetterItem("r"));
                    tmpCol.Add(new FingerLetterItem("f"));
                    tmpCol.Add(new FingerLetterItem("v"));
                    tmpCol.Add(new FingerLetterItem("t"));
                    tmpCol.Add(new FingerLetterItem("g"));
                    tmpCol.Add(new FingerLetterItem("b"));
                    break;
                case FingerType.LeftThumb:
                    tmpCol.Add(new FingerLetterItem(" "));
                    break;
                case FingerType.RightSmall:
                    tmpCol.Add(new FingerLetterItem(";"));
                    tmpCol.Add(new FingerLetterItem(":"));
                    tmpCol.Add(new FingerLetterItem("'"));
                    tmpCol.Add(new FingerLetterItem("\""));
                    tmpCol.Add(new FingerLetterItem("þ"));
                    tmpCol.Add(new FingerLetterItem("ð"));
                    tmpCol.Add(new FingerLetterItem("ü"));
                    break;
                case FingerType.RightRing:
                    tmpCol.Add(new FingerLetterItem("o"));
                    tmpCol.Add(new FingerLetterItem("l"));
                    tmpCol.Add(new FingerLetterItem("ç"));
                    break;
                case FingerType.RightMiddle:
                    tmpCol.Add(new FingerLetterItem("ý"));
                    tmpCol.Add(new FingerLetterItem("k"));
                    tmpCol.Add(new FingerLetterItem("ö"));
                    break;
                case FingerType.RightIndex:
                    tmpCol.Add(new FingerLetterItem("u"));
                    tmpCol.Add(new FingerLetterItem("j"));
                    tmpCol.Add(new FingerLetterItem("m"));
                    tmpCol.Add(new FingerLetterItem("y"));
                    tmpCol.Add(new FingerLetterItem("h"));
                    tmpCol.Add(new FingerLetterItem("n"));
                    break;
                case FingerType.RightThumb:
                    tmpCol.Add(new FingerLetterItem(" "));
                    break;
            }

            this.responsibleLetters_ = tmpCol;
        }

        private void SetSize()
        {
            int width = 15;
            int height = 60;

            switch (this.FingerType)
            {
                case FingerType.LeftSmall:
                    width = 31;
                    height = 56;
                    break;
                case FingerType.LeftRing:
                    width = 27;
                    height = 71;
                    break;
                case FingerType.LeftMiddle:
                    width = 27;
                    height = 67;
                    break;
                case FingerType.LeftIndex:
                    width = 30;
                    height = 74;
                    break;
                case FingerType.LeftThumb:
                    width = 41;
                    height = 53;
                    break;
                case FingerType.RightSmall:
                    width = 31;
                    height = 56;
                    break;
                case FingerType.RightRing:
                    width = 25;
                    height = 72;
                    break;
                case FingerType.RightMiddle:
                    width = 28;
                    height = 73;
                    break;
                case FingerType.RightIndex:
                    width = 30;
                    height = 69;
                    break;
                case FingerType.RightThumb:
                    width = 41;
                    height = 53;
                    break;
            }

            this.Size = new Size(width, height);
        }

        private void HighligthWorkerThreadMethod()
        {
            HighlightProcess longProcess;

            longProcess = new HighlightProcess(this);

            longProcess.Run();
        }

        #endregion

    }
}
