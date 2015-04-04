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
using System.Diagnostics;
using System.Text;
using System.Drawing;

using ActiveType.Settings;

namespace ActiveType.CustomControls
{
    public class Key : System.Windows.Forms.Button
    {
        private KeyState keyState_ = KeyState.NORMAL;

        private KeyboardScheme layoutScheme_ = KeyboardScheme.BLUE;

        private string symbolPositionOne_ = "";
        private string symbolPositionTwo_ = "";
        private string symbolPositionThree_ = "";
        private string symbolPositionFour_ = "";
        private string keyCode_ = "";

        private Color keyDownColor_ = Color.DeepSkyBlue;
        private Color keyUpColor_ = Color.SteelBlue;
        private Color keyHighlightColor_ = Color.LightSkyBlue;

        private int borderSize_ = 1;
        private int defaultWidth_ = 45;
        private int defaultHeight_ = 45;

        private bool isHighligted_ = false;
        private bool bypassLayoutScheme_ = false;

        private float fontSize_ = 13;

        #region Constructor Logic
        
        public Key()
        {
            SetDefaults();
        }

        public Key(string keycode)
        {
            this.keyCode_ = keycode;

            SetDefaults();
        }
        public Key(string keycode, string symbolOne, string symbolTwo, string symbolThree, string symbolFour)
        {
            this.keyCode_ = keycode;

            this.symbolPositionOne_ = symbolOne;
            this.symbolPositionTwo_ = symbolTwo;
            this.symbolPositionThree_ = symbolThree;
            this.symbolPositionFour_ = symbolFour;

            SetDefaults();
        }

        #endregion

        #region Private Properties
        #endregion

        #region Protected Properties

        #endregion

        #region Public Properties

        public string KeyCode
        {
            get
            {
                return this.keyCode_;
            }
            set
            {
                this.keyCode_ = value;
            }
        }

        [
        RefreshProperties(RefreshProperties.Repaint)
        ]
        public KeyboardScheme LayoutScheme
        {
            get
            {
                return this.layoutScheme_;
            }
            set
            {
                this.layoutScheme_ = value;

                this.bypassLayoutScheme_ = true;

                if (value == KeyboardScheme.BLUE)
                {
                    this.BackColor = this.KeyUpColor = Color.SteelBlue;
                    this.KeyDownColor = Color.DeepSkyBlue;
                    this.KeyHighlightColor = Color.LightSkyBlue;
                    this.ForeColor = Color.White;
                    this.Invalidate();
                }
                else if (value == KeyboardScheme.GRAY)
                {
                    this.BackColor = this.KeyUpColor = Color.Gray;
                    this.KeyDownColor = Color.DarkGray;
                    this.KeyHighlightColor = Color.Gainsboro;
                    this.ForeColor = Color.Black;
                    this.Invalidate();
                }
                else if (value == KeyboardScheme.RED)
                {
                    this.BackColor = this.KeyUpColor = Color.Red;
                    this.KeyDownColor = Color.Tomato;
                    this.KeyHighlightColor = Color.LightSalmon;
                    this.ForeColor = Color.White;
                    this.Invalidate();
                }

                this.bypassLayoutScheme_ = false;
            }
        }

        [
        RefreshProperties(RefreshProperties.Repaint)
        ]
        public int BorderSize
        {
            get
            {
                return this.borderSize_;
            }
            set
            {
                this.borderSize_ = value;
                this.Invalidate();
            }
        }

        [
        RefreshProperties(RefreshProperties.Repaint)
        ]
        public Color KeyHighlightColor
        {
            get
            {
                return this.keyHighlightColor_;
            }
            set
            {
                if (this.LayoutScheme == KeyboardScheme.CUSTOM || this.bypassLayoutScheme_)
                {
                    this.keyHighlightColor_ = value;
                    this.Invalidate();
                }
            }
        }

        [
        RefreshProperties(RefreshProperties.Repaint)
        ]
        public Color KeyDownColor
        {
            get
            {
                return this.keyDownColor_;
            }
            set
            {
                if (this.LayoutScheme == KeyboardScheme.CUSTOM || this.bypassLayoutScheme_)
                {
                    this.keyDownColor_ = value;
                    this.Invalidate();
                }
            }
        }

        [
        RefreshProperties(RefreshProperties.Repaint)
        ]
        public Color KeyUpColor
        {
            get
            {
                return this.keyUpColor_;
            }
            set
            {
                if (this.LayoutScheme == KeyboardScheme.CUSTOM || this.bypassLayoutScheme_)
                {
                    this.keyUpColor_ = value;
                    this.Invalidate();
                }
            }
        }

        [
        Browsable(false)
        ]
        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
        }

        [
        Browsable(false)
        ]
        public override System.Windows.Forms.ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
        }

        [
        RefreshProperties(RefreshProperties.Repaint)
        ]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                if (this.LayoutScheme == KeyboardScheme.CUSTOM || this.bypassLayoutScheme_)
                {
                    base.BackColor = value;
                    this.Invalidate();
                }
            }
        }

        [
        RefreshProperties(RefreshProperties.Repaint)
        ]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                this.Invalidate();
            }
        }

        [
        RefreshProperties(RefreshProperties.Repaint)
        ]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                if (this.LayoutScheme == KeyboardScheme.CUSTOM || this.bypassLayoutScheme_)
                {
                    base.ForeColor = value;
                    this.Invalidate();
                }
            }
        }

        [
        Browsable(false)
        ]
        public override string Text
        {
            get
            {
                return base.Text;
            }
        }

        [
        Browsable(false)
        ]
        public override ContentAlignment TextAlign
        {
            get
            {
                return base.TextAlign;
            }
        }

        [
        RefreshProperties(RefreshProperties.Repaint)
        ]
        public float FontSize
        {
            get
            {
                return this.fontSize_;
            }
            set
            {
                this.fontSize_ = value;
                this.Invalidate();
            }
        }

        [
        RefreshProperties(RefreshProperties.Repaint)
        ]
        public string SymbolPositionOne
        {
            get
            {
                return this.symbolPositionOne_;
            }
            set
            {
                this.symbolPositionOne_ = value;
                this.Invalidate();
            }
        }

        [
        RefreshProperties(RefreshProperties.Repaint)
        ]
        public string SymbolPositionTwo
        {
            get
            {
                return this.symbolPositionTwo_;
            }
            set
            {
                this.symbolPositionTwo_ = value;
                this.Invalidate();
            }
        }

        [
        RefreshProperties(RefreshProperties.Repaint)
        ]
        public string SymbolPositionThree
        {
            get
            {
                return this.symbolPositionThree_;
            }
            set
            {
                this.symbolPositionThree_ = value;
                this.Invalidate();
            }
        }

        [
        RefreshProperties(RefreshProperties.Repaint)
        ]
        public string SymbolPositionFour
        {
            get
            {
                return this.symbolPositionFour_;
            }
            set
            {
                this.symbolPositionFour_ = value;
                this.Invalidate();
            }
        }

        #endregion

        #region Private Methods

        private void SetDefaults()
        {
            this.Width = base.Width = this.defaultWidth_;
            this.Height = base.Height = this.defaultHeight_;

            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        }

        private void DrawUpKeys(Graphics g)
        {
            int tmp = (int)this.keyState_;

            ClearKeys(g);

            DrawBorders(g);

            if (isHighligted_)
                g.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(this.BorderSize + tmp, this.BorderSize + tmp, this.Width - 2 * this.BorderSize - 2 + tmp, this.Height - 2 * this.BorderSize - 2 + tmp));
            else
                g.FillRectangle(new SolidBrush(this.KeyUpColor), new Rectangle(this.BorderSize + tmp, this.BorderSize + tmp, this.Width - 2 * this.BorderSize - 2 + tmp, this.Height - 2 * this.BorderSize - 2 + tmp));

            if (this.SymbolPositionOne != "")
            {
                g.DrawString(this.SymbolPositionOne, new Font(this.Font.FontFamily, this.FontSize, FontStyle.Bold), new SolidBrush(this.ForeColor), 2 + tmp, tmp + this.Height - (this.FontSize + 12));
            }

            if (this.SymbolPositionTwo != "")
            {
                g.DrawString(this.SymbolPositionTwo, new Font(this.Font.FontFamily, this.FontSize, FontStyle.Bold), new SolidBrush(this.ForeColor), 2 + tmp, tmp + 2);
            }

            if (this.SymbolPositionThree != "")
            {
                g.DrawString(this.SymbolPositionThree, new Font(this.Font.FontFamily, this.FontSize, FontStyle.Bold), new SolidBrush(this.ForeColor), tmp + this.Width - (this.FontSize + 8), tmp + 2);
            }

            if (this.SymbolPositionFour != "")
            {
                g.DrawString(this.SymbolPositionFour, new Font(this.Font.FontFamily, this.FontSize, FontStyle.Bold), new SolidBrush(this.ForeColor), tmp + this.Width - (this.FontSize + 8), tmp + this.Height - (this.FontSize + 12));
            }
        }

        private void ClearKeys(Graphics g)
        {
            g.Clear(this.BackColor);

            DrawBorders(g);
        }

        private void DrawBorders(Graphics g)
        {
            for (int i = 0; i < this.BorderSize; i++)
            {
                int tmp = (int)this.keyState_;
                g.DrawRectangle(new Pen(Brushes.Black), new Rectangle(tmp, tmp, tmp + this.Width - 2 * i - 2, tmp + this.Height - 2 * i - 2));
            }
        }

        private void DrawDownKeys(Graphics g)
        {
            int tmp = (int)this.keyState_;

            ClearKeys(g);

            DrawBorders(g);

            g.FillRectangle(new SolidBrush(this.KeyDownColor), new Rectangle(this.BorderSize + tmp, this.BorderSize + tmp, tmp + this.Width - 2 * this.BorderSize - 2, tmp + this.Height - 2 * this.BorderSize - 2));

            if (this.SymbolPositionOne != "")
            {
                g.DrawString(this.SymbolPositionOne, new Font(this.Font.FontFamily, this.FontSize, FontStyle.Bold), new SolidBrush(this.ForeColor), 2 + tmp, tmp + this.Height - (this.FontSize + 12));
            }

            if (this.SymbolPositionTwo != "")
            {
                g.DrawString(this.SymbolPositionTwo, new Font(this.Font.FontFamily, this.FontSize, FontStyle.Bold), new SolidBrush(this.ForeColor), 2 + tmp, tmp + 2);
            }

            if (this.SymbolPositionThree != "")
            {
                g.DrawString(this.SymbolPositionThree, new Font(this.Font.FontFamily, this.FontSize, FontStyle.Bold), new SolidBrush(this.ForeColor), tmp + this.Width - (this.FontSize + 8), tmp + 2);
            }

            if (this.SymbolPositionFour != "")
            {
                g.DrawString(this.SymbolPositionFour, new Font(this.Font.FontFamily, this.FontSize, FontStyle.Bold), new SolidBrush(this.ForeColor), tmp + this.Width - (this.FontSize + 8), tmp + this.Height - (this.FontSize + 12));
            }
        }

        #endregion

        #region Protected Methods

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent)
        {
            if (this.keyState_ == KeyState.NORMAL)
                DrawUpKeys(pevent.Graphics);
            else if (this.keyState_ == KeyState.PRESSED)
                DrawDownKeys(pevent.Graphics);
            else
                DrawUpKeys(pevent.Graphics);

            this.Text = "";
        }

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            //base.OnKeyPress(e);

            this.keyState_ = KeyState.PRESSED;

            this.bypassLayoutScheme_ = true;
            this.BackColor = this.KeyDownColor;
            this.bypassLayoutScheme_ = false;
        }

        protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs kevent)
        {
            //base.OnKeyUp(kevent);

            this.keyState_ = KeyState.NORMAL;

            this.bypassLayoutScheme_ = true;
            this.BackColor = this.KeyUpColor;
            this.bypassLayoutScheme_ = false;
        }

        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs kevent)
        {
            //base.OnKeyDown(kevent);

            this.keyState_ = KeyState.PRESSED;

            this.bypassLayoutScheme_ = true;
            this.BackColor = this.KeyDownColor;
            this.bypassLayoutScheme_ = false;
        }

        protected override void OnClick(EventArgs e)
        {
            //base.OnClick(e);

            this.keyState_ = KeyState.PRESSED;

            DrawDownKeys(this.CreateGraphics());
        }

        protected override void OnMouseClick(System.Windows.Forms.MouseEventArgs e)
        {
            this.keyState_ = KeyState.PRESSED;

            this.bypassLayoutScheme_ = true;
            this.BackColor = this.KeyDownColor;
            this.bypassLayoutScheme_ = false;
        }

        protected override void OnMouseDoubleClick(System.Windows.Forms.MouseEventArgs e)
        {
            this.keyState_ = KeyState.PRESSED;

            this.bypassLayoutScheme_ = true;
            this.BackColor = this.KeyDownColor;
            this.bypassLayoutScheme_ = false;
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs mevent)
        {
            //base.OnMouseDown(mevent);

            this.keyState_ = KeyState.PRESSED;

            this.bypassLayoutScheme_ = true;
            this.BackColor = this.KeyDownColor;
            this.bypassLayoutScheme_ = false;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            //base.OnMouseEnter(e);
        }

        protected override void OnMouseHover(EventArgs e)
        {
            //base.OnMouseHover(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.keyState_ = KeyState.NORMAL;

            this.bypassLayoutScheme_ = true;
            this.BackColor = this.KeyUpColor;
            this.bypassLayoutScheme_ = false;
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs mevent)
        {
            //base.OnMouseUp(mevent);

            this.keyState_ = KeyState.NORMAL;

            this.bypassLayoutScheme_ = true;
            this.BackColor = this.KeyUpColor;
            this.bypassLayoutScheme_ = false;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if (this.keyState_ == KeyState.NORMAL)
                DrawUpKeys(this.CreateGraphics());
            else if (this.keyState_ == KeyState.PRESSED)
                DrawDownKeys(this.CreateGraphics());
            else
                DrawUpKeys(this.CreateGraphics());
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if (this.keyState_ == KeyState.NORMAL)
                DrawUpKeys(this.CreateGraphics());
            else if (this.keyState_ == KeyState.PRESSED)
                DrawDownKeys(this.CreateGraphics());
            else
                DrawUpKeys(this.CreateGraphics());
        }

        #endregion

        #region Public Methods

        public void StartHighlightKey()
        {
            this.bypassLayoutScheme_ = true;

            this.BackColor = this.KeyHighlightColor;

            this.isHighligted_ = true;

            this.bypassLayoutScheme_ = false;
        }

        public void StopHighlightKey()
        {
            this.bypassLayoutScheme_ = true;

            this.BackColor = this.KeyUpColor;

            this.isHighligted_ = false;

            this.bypassLayoutScheme_ = false;
        }

        #endregion
    }
}
