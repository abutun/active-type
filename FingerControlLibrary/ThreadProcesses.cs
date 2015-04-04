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
using System.Threading;
using System.Drawing;

namespace ActiveType.FingerControlLibrary
{
    public class HighlightProcess
    {
        private Finger m_finger;

        public HighlightProcess(Finger m_finger)
        {
            this.m_finger = m_finger;
        }

        // Function runs in worker thread and emulates long process.
        public void Run()
        {
            while (m_finger.WaitForToBePressed)
            {
                Thread.Sleep(150);

                if (m_finger.HighlightState == 1)
                {
                    if (m_finger.HighlightMode == HighlightMode.COLOR)
                        m_finger.BackColor = m_finger.WrongKeyPressedColor;
                    else
                        m_finger.BackgroundImage = m_finger.WrongKeyPressedImage;

                    m_finger.HighlightState = 0; // do this highlighting only once
                }
                else if (m_finger.HighlightState == 2)
                {
                    if (m_finger.HighlightMode == HighlightMode.COLOR)
                        m_finger.BackColor = m_finger.CorrectKeyPressedColor;
                    else
                        m_finger.BackgroundImage = m_finger.CorrectKeyPressedImage;

                    m_finger.HighlightState = 0; // do this highlighting only once
                }
                else
                {
                    if (m_finger.HighlightMode == HighlightMode.COLOR)
                        m_finger.BackColor = m_finger.HighlightColor;
                    else
                        m_finger.BackgroundImage = m_finger.HighlightImage;
                }

                Thread.Sleep(150);

                if (m_finger.HighlightMode == HighlightMode.COLOR)
                    m_finger.BackColor = m_finger.BaseBackGroundColor;
                else
                    m_finger.BackgroundImage = m_finger.BaseBackGroundImage;
            }

            // Make synchronous call to main form
            // to inform it that thread finished
            m_finger.StopHighlightThread();
        }
    }

}
