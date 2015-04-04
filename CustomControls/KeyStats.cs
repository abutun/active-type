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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ActiveType.CustomControls
{
    public partial class KeyStats : UserControl
    {
        private int correctPressCount_;
        private int wrongPressCount_;
        private string keycode_;

        public KeyStats(string keycode, int correctPressCount, int wrongPressCount)
        {
            InitializeComponent();

            this.keycode_ = keycode;
            this.correctPressCount_ = correctPressCount;
            this.wrongPressCount_ = wrongPressCount;
        }

        private void KeyStats_Load(object sender, EventArgs e)
        {
            double nHeight = 2;

            int totalPressCount = correctPressCount_ + wrongPressCount_;
            
            this.keyNameLabel.Text = keycode_;

            if (totalPressCount>0)
                nHeight = (correctPressCount_ * 1.0) / (totalPressCount) * 220;

            if (nHeight == 0)
                nHeight = 2;

            this.keyProgressPanel.Size = new Size(this.keyProgressPanel.Width, (int)nHeight);
            this.keyProgressPanel.Location = new Point(this.keyProgressPanel.Location.X, 220 - (int)nHeight);
        }
    }
}
