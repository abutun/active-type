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

using ActiveType.FingerControlLibrary;

namespace ActiveType.CustomControls
{
    public partial class FingerLayout : UserControl
    {
        private FingerCollection currentHighlightingFingers_ = null;

        public FingerLayout()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        public FingerCollection CurrentHighlightingFingers
        {
            get
            {
                return currentHighlightingFingers_;
            }
            set
            {
                currentHighlightingFingers_ = value;
            }
        }

        public void ChangeSmileImage(int status)
        {
            switch (status)
            {
                case 1:
                    this.smilePicture.BackgroundImage = ActiveType.CustomControls.Properties.Resources.s1;
                    break;
                case 2:
                    this.smilePicture.BackgroundImage = ActiveType.CustomControls.Properties.Resources.s3;
                    break;
                default:
                    this.smilePicture.BackgroundImage = ActiveType.CustomControls.Properties.Resources.s2;
                    break;
            }

            this.smilePicture.Refresh();
        }

        public void KillThreads()
        {
            leftIndex.KillThread();
            leftMiddle.KillThread();
            leftRing.KillThread();
            leftSmall.KillThread();
            leftThumb.KillThread();
            rightIndex.KillThread();
            rightMiddle.KillThread();
            rightRing.KillThread();
            rightSmall.KillThread();
            rightThumb.KillThread();
        }

        public void StopThreads()
        {
            if (CurrentHighlightingFingers != null)
            {
                foreach (Finger f in CurrentHighlightingFingers)
                    f.WaitForToBePressed = false;
            }
        }

        public void HighlightExpectedLetter(string expectedLetter)
        {
            // Stop previous threads first
            StopThreads();

            if (CurrentHighlightingFingers != null)
                CurrentHighlightingFingers.Clear();

            CurrentHighlightingFingers = GetResponsibleFingers(expectedLetter);

            if (CurrentHighlightingFingers != null)
            {
                foreach (Finger f in CurrentHighlightingFingers)
                    f.WaitForToBePressed = true;
            }
        }

        public void ChangeHighlightStatus(int status)
        {
            if (CurrentHighlightingFingers != null)
            {
                foreach (Finger f in CurrentHighlightingFingers)
                     f.HighlightState = status;
            }
        }

        public FingerCollection GetResponsibleFingers(string letter)
        {
            FingerCollection fingerCol = new FingerCollection();
            FingerLetterItem itm = new FingerLetterItem(letter);

            // Can be sorted from most used finger to less used

            if (this.leftIndex.ResponsibleLetters.Contains(itm))
                fingerCol.Add(this.leftIndex);
            if (this.leftMiddle.ResponsibleLetters.Contains(itm))
                fingerCol.Add(this.leftMiddle);
            if (this.leftRing.ResponsibleLetters.Contains(itm))
                fingerCol.Add(this.leftRing);
            if (this.leftSmall.ResponsibleLetters.Contains(itm))
                fingerCol.Add(this.leftSmall);
            if (this.leftThumb.ResponsibleLetters.Contains(itm))
                fingerCol.Add(this.leftThumb);
            if (this.rightIndex.ResponsibleLetters.Contains(itm))
                fingerCol.Add(this.rightIndex);
            if (this.rightMiddle.ResponsibleLetters.Contains(itm))
                fingerCol.Add(this.rightMiddle);
            if (this.rightRing.ResponsibleLetters.Contains(itm))
                fingerCol.Add(this.rightRing);
            if (this.rightSmall.ResponsibleLetters.Contains(itm))
                fingerCol.Add(this.rightSmall);
            if (this.rightThumb.ResponsibleLetters.Contains(itm))
                fingerCol.Add(this.rightThumb);

            if (fingerCol.Count > 0)
                return fingerCol;
            else
                return null;
        }
    }
}
