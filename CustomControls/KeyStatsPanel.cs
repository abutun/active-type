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

using ActiveType.Settings;

namespace ActiveType.CustomControls
{
    public partial class KeyStatsPanel : UserControl
    {
        private StatisticsCollection statsCollection = new StatisticsCollection();

        private Course currentCourse = null;

        private bool loadOverAllStats = true;

        private Panel activePanel = null;

        public KeyStatsPanel(Course curr)
        {
            InitializeComponent();

            this.currentCourse = curr;
        }

        public void GetKeyStats()
        {
            int x = 0;
            int y = 0;

            KeyStats keyStat;
            KeyValues keyValues;

            if (!loadOverAllStats)
            {
                int courseStatIndex = -1;

                for (int i = 0; i < Utilities.CurentUser.Statistics.Count; i++)
                {
                    if (this.currentCourse != null)
                    {
                        if (Utilities.CurentUser.Statistics[i].Course.Path.ToUpper() == this.currentCourse.Path.ToUpper())
                            courseStatIndex = i;
                    }
                }

                if (courseStatIndex != -1)
                {
                    this.statsCollection.Clear();

                    this.statsCollection.Add(Utilities.CurentUser.Statistics[courseStatIndex]);
                }
            }

            Keyboard keyboardLayout = (Keyboard)Utilities.Settings[Constants.propKeyboardLayout];

            switch (keyboardLayout.Code)
            {
                case "TR":
                    {
                        if (keyboardLayout.KeyboardType == "Q")
                        {
                            // Q Keyboard

                            #region LowerCase Characters

                            // keycode for "q"
                            keyValues = this.statsCollection.GetOverAllKeyStat("q");
                            keyStat = new KeyStats("q", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "w"
                            keyValues = this.statsCollection.GetOverAllKeyStat("w");
                            keyStat = new KeyStats("w", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "e"
                            keyValues = this.statsCollection.GetOverAllKeyStat("e");
                            keyStat = new KeyStats("e", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "r"
                            keyValues = this.statsCollection.GetOverAllKeyStat("r");
                            keyStat = new KeyStats("r", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "t"
                            keyValues = this.statsCollection.GetOverAllKeyStat("t");
                            keyStat = new KeyStats("t", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22; ;

                            // keycode for "y"
                            keyValues = this.statsCollection.GetOverAllKeyStat("y");
                            keyStat = new KeyStats("y", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "u"
                            keyValues = this.statsCollection.GetOverAllKeyStat("u");
                            keyStat = new KeyStats("u", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "ý"
                            keyValues = this.statsCollection.GetOverAllKeyStat("ý");
                            keyStat = new KeyStats("ý", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "o"
                            keyValues = this.statsCollection.GetOverAllKeyStat("o");
                            keyStat = new KeyStats("o", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "p"
                            keyValues = this.statsCollection.GetOverAllKeyStat("p");
                            keyStat = new KeyStats("p", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "ð"
                            keyValues = this.statsCollection.GetOverAllKeyStat("ð");
                            keyStat = new KeyStats("ð", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "ü"
                            keyValues = this.statsCollection.GetOverAllKeyStat("ü");
                            keyStat = new KeyStats("ü", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "a"
                            keyValues = this.statsCollection.GetOverAllKeyStat("a");
                            keyStat = new KeyStats("a", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "s"
                            keyValues = this.statsCollection.GetOverAllKeyStat("s");
                            keyStat = new KeyStats("s", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "d"
                            keyValues = this.statsCollection.GetOverAllKeyStat("d");
                            keyStat = new KeyStats("d", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "f"
                            keyValues = this.statsCollection.GetOverAllKeyStat("f");
                            keyStat = new KeyStats("f", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "g"
                            keyValues = this.statsCollection.GetOverAllKeyStat("g");
                            keyStat = new KeyStats("g", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "h"
                            keyValues = this.statsCollection.GetOverAllKeyStat("h");
                            keyStat = new KeyStats("h", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "j"
                            keyValues = this.statsCollection.GetOverAllKeyStat("j");
                            keyStat = new KeyStats("j", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "k"
                            keyValues = this.statsCollection.GetOverAllKeyStat("k");
                            keyStat = new KeyStats("k", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "l"
                            keyValues = this.statsCollection.GetOverAllKeyStat("l");
                            keyStat = new KeyStats("l", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "þ"
                            keyValues = this.statsCollection.GetOverAllKeyStat("þ");
                            keyStat = new KeyStats("þ", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "i"
                            keyValues = this.statsCollection.GetOverAllKeyStat("i");
                            keyStat = new KeyStats("i", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "z"
                            keyValues = this.statsCollection.GetOverAllKeyStat("z");
                            keyStat = new KeyStats("z", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "x"
                            keyValues = this.statsCollection.GetOverAllKeyStat("x");
                            keyStat = new KeyStats("x", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "c"
                            keyValues = this.statsCollection.GetOverAllKeyStat("c");
                            keyStat = new KeyStats("c", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "v"
                            keyValues = this.statsCollection.GetOverAllKeyStat("v");
                            keyStat = new KeyStats("v", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "b"
                            keyValues = this.statsCollection.GetOverAllKeyStat("b");
                            keyStat = new KeyStats("b", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "n"
                            keyValues = this.statsCollection.GetOverAllKeyStat("n");
                            keyStat = new KeyStats("n", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "m"
                            keyValues = this.statsCollection.GetOverAllKeyStat("m");
                            keyStat = new KeyStats("m", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "ö"
                            keyValues = this.statsCollection.GetOverAllKeyStat("ö");
                            keyStat = new KeyStats("ö", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "ç"
                            keyValues = this.statsCollection.GetOverAllKeyStat("ç");
                            keyStat = new KeyStats("ç", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.lowerCasePanel.Controls.Add(keyStat);
                            x += 22;

                            #endregion

                            #region UpperCase Characters
                            x = 0;
                            // keycode for "Q"
                            keyValues = this.statsCollection.GetOverAllKeyStat("Q");
                            keyStat = new KeyStats("Q", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "W"
                            keyValues = this.statsCollection.GetOverAllKeyStat("W");
                            keyStat = new KeyStats("W", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "E"
                            keyValues = this.statsCollection.GetOverAllKeyStat("E");
                            keyStat = new KeyStats("E", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "R"
                            keyValues = this.statsCollection.GetOverAllKeyStat("R");
                            keyStat = new KeyStats("R", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "T"
                            keyValues = this.statsCollection.GetOverAllKeyStat("T");
                            keyStat = new KeyStats("T", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "A"
                            keyValues = this.statsCollection.GetOverAllKeyStat("A");
                            keyStat = new KeyStats("A", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "S"
                            keyValues = this.statsCollection.GetOverAllKeyStat("S");
                            keyStat = new KeyStats("S", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "D"
                            keyValues = this.statsCollection.GetOverAllKeyStat("D");
                            keyStat = new KeyStats("D", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "F"
                            keyValues = this.statsCollection.GetOverAllKeyStat("F");
                            keyStat = new KeyStats("F", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "G"
                            keyValues = this.statsCollection.GetOverAllKeyStat("G");
                            keyStat = new KeyStats("G", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "Z"
                            keyValues = this.statsCollection.GetOverAllKeyStat("Z");
                            keyStat = new KeyStats("Z", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "X"
                            keyValues = this.statsCollection.GetOverAllKeyStat("X");
                            keyStat = new KeyStats("X", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "C"
                            keyValues = this.statsCollection.GetOverAllKeyStat("C");
                            keyStat = new KeyStats("C", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for V"
                            keyValues = this.statsCollection.GetOverAllKeyStat("V");
                            keyStat = new KeyStats("V", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "B"
                            keyValues = this.statsCollection.GetOverAllKeyStat("B");
                            keyStat = new KeyStats("B", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "Y"
                            keyValues = this.statsCollection.GetOverAllKeyStat("Y");
                            keyStat = new KeyStats("Y", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "U"
                            keyValues = this.statsCollection.GetOverAllKeyStat("U");
                            keyStat = new KeyStats("U", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "I"
                            keyValues = this.statsCollection.GetOverAllKeyStat("I");
                            keyStat = new KeyStats("I", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "O"
                            keyValues = this.statsCollection.GetOverAllKeyStat("O");
                            keyStat = new KeyStats("O", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "P"
                            keyValues = this.statsCollection.GetOverAllKeyStat("P");
                            keyStat = new KeyStats("P", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "Ð"
                            keyValues = this.statsCollection.GetOverAllKeyStat("Ð");
                            keyStat = new KeyStats("Ð", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "Ü"
                            keyValues = this.statsCollection.GetOverAllKeyStat("Ü");
                            keyStat = new KeyStats("Ü", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "H"
                            keyValues = this.statsCollection.GetOverAllKeyStat("H");
                            keyStat = new KeyStats("H", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "J"
                            keyValues = this.statsCollection.GetOverAllKeyStat("J");
                            keyStat = new KeyStats("J", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "K"
                            keyValues = this.statsCollection.GetOverAllKeyStat("K");
                            keyStat = new KeyStats("K", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "L"
                            keyValues = this.statsCollection.GetOverAllKeyStat("L");
                            keyStat = new KeyStats("L", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "Þ"
                            keyValues = this.statsCollection.GetOverAllKeyStat("Þ");
                            keyStat = new KeyStats("Þ", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "Ý"
                            keyValues = this.statsCollection.GetOverAllKeyStat("Ý");
                            keyStat = new KeyStats("Ý", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "N"
                            keyValues = this.statsCollection.GetOverAllKeyStat("N");
                            keyStat = new KeyStats("N", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "M"
                            keyValues = this.statsCollection.GetOverAllKeyStat("M");
                            keyStat = new KeyStats("M", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "Ö"
                            keyValues = this.statsCollection.GetOverAllKeyStat("Ö");
                            keyStat = new KeyStats("Ö", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "Ç"
                            keyValues = this.statsCollection.GetOverAllKeyStat("Ç");
                            keyStat = new KeyStats("Ç", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.upperCasePanel.Controls.Add(keyStat);
                            x += 22;

                            #endregion

                            #region Controls Keys
                            x = 0;

                            // keycode for "@"
                            keyValues = this.statsCollection.GetOverAllKeyStat("@");
                            keyStat = new KeyStats("@", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "~"
                            keyValues = this.statsCollection.GetOverAllKeyStat("~");
                            keyStat = new KeyStats("~", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "<"
                            keyValues = this.statsCollection.GetOverAllKeyStat("<");
                            keyStat = new KeyStats("<", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for ">"
                            keyValues = this.statsCollection.GetOverAllKeyStat(">");
                            keyStat = new KeyStats(">", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "|"
                            keyValues = this.statsCollection.GetOverAllKeyStat("|");
                            keyStat = new KeyStats("|", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "."
                            keyValues = this.statsCollection.GetOverAllKeyStat(".");
                            keyStat = new KeyStats(".", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for ":"
                            keyValues = this.statsCollection.GetOverAllKeyStat(":");
                            keyStat = new KeyStats(":", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for ","
                            keyValues = this.statsCollection.GetOverAllKeyStat(",");
                            keyStat = new KeyStats(",", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for ";"
                            keyValues = this.statsCollection.GetOverAllKeyStat(";");
                            keyStat = new KeyStats(";", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "`"
                            keyValues = this.statsCollection.GetOverAllKeyStat("`");
                            keyStat = new KeyStats("`", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            #endregion

                            #region Symbols and Numbers

                            // keycode for """
                            keyValues = this.statsCollection.GetOverAllKeyStat("\"");
                            keyStat = new KeyStats("\"", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "é"
                            keyValues = this.statsCollection.GetOverAllKeyStat("é");
                            keyStat = new KeyStats("é", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "1"
                            keyValues = this.statsCollection.GetOverAllKeyStat("1");
                            keyStat = new KeyStats("1", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "!"
                            keyValues = this.statsCollection.GetOverAllKeyStat("!");
                            keyStat = new KeyStats("!", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "2"
                            keyValues = this.statsCollection.GetOverAllKeyStat("2");
                            keyStat = new KeyStats("2", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "'"
                            keyValues = this.statsCollection.GetOverAllKeyStat("'");
                            keyStat = new KeyStats("'", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "3"
                            keyValues = this.statsCollection.GetOverAllKeyStat("3");
                            keyStat = new KeyStats("3", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "^"
                            keyValues = this.statsCollection.GetOverAllKeyStat("^");
                            keyStat = new KeyStats("^", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "#"
                            keyValues = this.statsCollection.GetOverAllKeyStat("#");
                            keyStat = new KeyStats("#", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "4"
                            keyValues = this.statsCollection.GetOverAllKeyStat("4");
                            keyStat = new KeyStats("4", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "+"
                            keyValues = this.statsCollection.GetOverAllKeyStat("+");
                            keyStat = new KeyStats("+", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "$"
                            keyValues = this.statsCollection.GetOverAllKeyStat("$");
                            keyStat = new KeyStats("$", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "5"
                            keyValues = this.statsCollection.GetOverAllKeyStat("5");
                            keyStat = new KeyStats("5", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "%"
                            keyValues = this.statsCollection.GetOverAllKeyStat("%");
                            keyStat = new KeyStats("%", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "6"
                            keyValues = this.statsCollection.GetOverAllKeyStat("6");
                            keyStat = new KeyStats("6", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "&"
                            keyValues = this.statsCollection.GetOverAllKeyStat("&");
                            keyStat = new KeyStats("&", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "7"
                            keyValues = this.statsCollection.GetOverAllKeyStat("Ç");
                            keyStat = new KeyStats("Ç", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "/"
                            keyValues = this.statsCollection.GetOverAllKeyStat("/");
                            keyStat = new KeyStats("/", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "{"
                            keyValues = this.statsCollection.GetOverAllKeyStat("{");
                            keyStat = new KeyStats("{", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "8"
                            keyValues = this.statsCollection.GetOverAllKeyStat("8");
                            keyStat = new KeyStats("8", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "("
                            keyValues = this.statsCollection.GetOverAllKeyStat("(");
                            keyStat = new KeyStats("(", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "["
                            keyValues = this.statsCollection.GetOverAllKeyStat("[");
                            keyStat = new KeyStats("[", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "9"
                            keyValues = this.statsCollection.GetOverAllKeyStat("9");
                            keyStat = new KeyStats("9", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for ")"
                            keyValues = this.statsCollection.GetOverAllKeyStat("Ç");
                            keyStat = new KeyStats("Ç", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "]"
                            keyValues = this.statsCollection.GetOverAllKeyStat(")");
                            keyStat = new KeyStats(")", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "0"
                            keyValues = this.statsCollection.GetOverAllKeyStat("0");
                            keyStat = new KeyStats("0", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "="
                            keyValues = this.statsCollection.GetOverAllKeyStat("=");
                            keyStat = new KeyStats("=", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "}"
                            keyValues = this.statsCollection.GetOverAllKeyStat("}");
                            keyStat = new KeyStats("}", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "*"
                            keyValues = this.statsCollection.GetOverAllKeyStat("*");
                            keyStat = new KeyStats("*", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "?"
                            keyValues = this.statsCollection.GetOverAllKeyStat("?");
                            keyStat = new KeyStats("?", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "\"
                            keyValues = this.statsCollection.GetOverAllKeyStat(@"\");
                            keyStat = new KeyStats(@"\", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "-"
                            keyValues = this.statsCollection.GetOverAllKeyStat("-");
                            keyStat = new KeyStats("-", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            // keycode for "_"
                            keyValues = this.statsCollection.GetOverAllKeyStat("_");
                            keyStat = new KeyStats("_", keyValues.CorrectPressCount, keyValues.WrongPressCount);
                            keyStat.Location = new Point(x, y);
                            this.symbolsPanel.Controls.Add(keyStat);
                            x += 22;

                            #endregion
                        }
                        else
                        {
                            // F Keyboard
                        }
                    }
                    break;
            }
        }

        private void KeyStatsPanel_Load(object sender, EventArgs e)
        {
            if (Utilities.CurentUser != null)
            {
                if (Utilities.CurentUser.Statistics != null)
                {
                    this.statsCollection.AddRange(Utilities.CurentUser.Statistics);

                    this.activePanel = this.lowerCasePanel;

                    GetKeyStats();
                }
            }
        }

        private void lowerCasePanelButton_Click(object sender, EventArgs e)
        {
            this.lowerCasePanel.Visible = true;
            this.upperCasePanel.Visible = false;
            this.symbolsPanel.Visible = false;

            this.activePanel = this.lowerCasePanel;

            this.activePanel.Location = new Point(0, 0);

            this.hScrollBar1.Value = 0;

            this.hScrollBar1.Maximum = 322;
        }

        private void upperCasePanelButton_Click(object sender, EventArgs e)
        {
            this.lowerCasePanel.Visible = false;
            this.upperCasePanel.Visible = true;
            this.symbolsPanel.Visible = false;

            this.activePanel = this.upperCasePanel;

            this.activePanel.Location = new Point(0, 0);

            this.hScrollBar1.Value = 0;

            this.hScrollBar1.Maximum = 322;
        }

        private void symbolsPanelButton_Click(object sender, EventArgs e)
        {
            this.lowerCasePanel.Visible = false;
            this.upperCasePanel.Visible = false;
            this.symbolsPanel.Visible = true;

            this.activePanel = this.symbolsPanel;

            this.activePanel.Location = new Point(0, 0);

            this.hScrollBar1.Value = 0;

            this.hScrollBar1.Maximum = 560;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (this.activePanel != null)
            {
                int tmpVal = e.NewValue - e.OldValue;

                this.activePanel.Location = new Point(this.activePanel.Location.X - tmpVal, this.activePanel.Location.Y);
            }
        }
    }
}
