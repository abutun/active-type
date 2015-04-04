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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;

using ActiveType.Settings;

namespace ActiveType.CustomControls
{
    public partial class KeyboardLayout : UserControl
    {
        // Inner error flag
        private bool innerError = false;

        // Default keycodes for the characters
        private Dictionary<string, Queue> CharacterCodes = new Dictionary<string, Queue>();

        // Keys
        KeyboardKeysCollection keyboardKeys = new KeyboardKeysCollection();

        // Language messages
        Settings.Messages innerMessages = new Messages();

        private bool keyCodesLoaded_ = false;
        private bool keyCodesCaptured_ = false;
        //private bool waitForKeyUp_ = false;

        private UserActivityHook innerHook;

        private int correctKeyPresses_ = 1;
        private int wrongKeyPresses_ = 0;

        private Queue previousKeyCodes_ = null;
        private Queue expectedKeyCodes_ = null;

        private Queue tmpPressedKeyCodes_ = new Queue();
        private Queue pressedKeyCodes_ = null;

        #region Constructor Logic

        public KeyboardLayout()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Preporties

        public bool KeyCodesLoaded
        {
            get
            {
                return keyCodesLoaded_;
            }
        }

        public Queue PreviousKeyCodes
        {
            get
            {
                return this.previousKeyCodes_;
            }
            set
            {
                previousKeyCodes_ = value;
            }
        }

        public Queue ExpectedKeyCodes
        {
            get
            {
                return this.expectedKeyCodes_;
            }
            set
            {
                //store previous key codes
                PreviousKeyCodes = expectedKeyCodes_;

                //set current codes
                expectedKeyCodes_ = value;

                //highlight them
                HighlightExpectedKeys();

                //display them
                //DisplayExpectedKeyCodeInfo();
            }
        }

        public int CorrectKeyPresses
        {
            get
            {
                return correctKeyPresses_;
            }
            set
            {
                correctKeyPresses_ = value;
            }
        }

        public int WrongKeyPresses
        {
            get
            {
                return wrongKeyPresses_;
            }
            set
            {
                wrongKeyPresses_ = value;
            }
        }

        public int Accuracy
        {
            get
            {
                int total = CorrectKeyPresses + WrongKeyPresses;
                int percent = (CorrectKeyPresses * 100) / total;

                return percent;
            }
        }

        #endregion

        #region Private Preporties

        private Queue PressedKeyCodes
        {
            get
            {
                return this.pressedKeyCodes_;
            }
            set
            {
                this.pressedKeyCodes_ = value;
                this.keyCodesCaptured_ = false;
            }
        }

        #endregion

        #region Public Methods

        public void ResetKeyboardStats()
        {
            CorrectKeyPresses = 1; // if it is 0 it will lead to devide by zero exception
            WrongKeyPresses = 0;
        }

        public void KillThreads()
        {
            this.fingerLayout.KillThreads();
        }

        public void StopThreads()
        {
            this.fingerLayout.StopThreads();
        }

        public void HighlightExpectedLetter(string expectedLetter)
        {
            this.fingerLayout.HighlightExpectedLetter(expectedLetter);
        }

        public void ChangeHighlightStatus(int status)
        {
            this.fingerLayout.ChangeHighlightStatus(status);
        }

        public void ChangeSmileImage(int status)
        {
            this.fingerLayout.ChangeSmileImage(status);
        }

        public void LoadKeyboardLayout()
        {
            if (!innerError)
            {
                // no need to install mouse hook
                innerHook = new UserActivityHook(false, true);

                //innerHook.OnMouseActivity += new MouseEventHandler(MouseMoved);
                innerHook.KeyDown += new KeyEventHandler(MyKeyDown);
                innerHook.KeyPress += new KeyPressEventHandler(MyKeyPress);
                innerHook.KeyUp += new KeyEventHandler(MyKeyUp);

                try
                {
                    if (Utilities.Settings != null)
                    {
                        if (Utilities.Settings.Contains(Constants.propKeyboardLayout))
                            DrawKeyboardFromFile();
                    }
                }
                catch
                {
                    ExceptionUtilities.ShowException(new Exception(this.innerMessages.GetLanguageString(2)), MessageBoxButtons.OK);
                    this.innerError = true;
                }
            }
        }

        #endregion

        #region Public Methods

        public void LoadKeyboardLayoutKeyCodes()
        {
            Keyboard keyboardLayout = (Keyboard)Utilities.Settings[Constants.propKeyboardLayout];

            switch(keyboardLayout.Code)
            {
                case "TR" :
                     {
                         if (keyboardLayout.KeyboardType == "Q")
                         {
                             // Q Keyboard

                             #region LowerCase Characters

                             // keycode for "q"
                             Queue q = new Queue();
                             q.Enqueue("Q");

                             CharacterCodes.Add("q", q);

                             // keycode for "w"
                             q = new Queue();
                             q.Enqueue("W");

                             CharacterCodes.Add("w", q);

                             // keycode for "e"
                             q = new Queue();
                             q.Enqueue("E");

                             CharacterCodes.Add("e", q);

                             // keycode for "r"
                             q = new Queue();
                             q.Enqueue("R");

                             CharacterCodes.Add("r", q);

                             // keycode for "t"
                             q = new Queue();
                             q.Enqueue("T");

                             CharacterCodes.Add("t", q);

                             // keycode for "y"
                             q = new Queue();
                             q.Enqueue("Y");

                             CharacterCodes.Add("y", q);

                             // keycode for "u"
                             q = new Queue();
                             q.Enqueue("U");

                             CharacterCodes.Add("u", q);

                             // keycode for "ý"
                             q = new Queue();
                             q.Enqueue("I");

                             CharacterCodes.Add("ý", q);

                             // keycode for "o"
                             q = new Queue();
                             q.Enqueue("O");

                             CharacterCodes.Add("o", q);

                             // keycode for "p"
                             q = new Queue();
                             q.Enqueue("P");

                             CharacterCodes.Add("p", q);

                             // keycode for "ð"
                             q = new Queue();
                             q.Enqueue("OemOpenBrackets");

                             CharacterCodes.Add("ð", q);

                             // keycode for "ü"
                             q = new Queue();
                             q.Enqueue("Oem6");

                             CharacterCodes.Add("ü", q);

                             // keycode for "a"
                             q = new Queue();
                             q.Enqueue("A");

                             CharacterCodes.Add("a", q);

                             // keycode for "s"
                             q = new Queue();
                             q.Enqueue("S");

                             CharacterCodes.Add("s", q);

                             // keycode for "d"
                             q = new Queue();
                             q.Enqueue("D");

                             CharacterCodes.Add("d", q);

                             // keycode for "f"
                             q = new Queue();
                             q.Enqueue("F");

                             CharacterCodes.Add("f", q);

                             // keycode for "g"
                             q = new Queue();
                             q.Enqueue("G");

                             CharacterCodes.Add("g", q);

                             // keycode for "h"
                             q = new Queue();
                             q.Enqueue("H");

                             CharacterCodes.Add("h", q);

                             // keycode for "j"
                             q = new Queue();
                             q.Enqueue("J");

                             CharacterCodes.Add("j", q);

                             // keycode for "k"
                             q = new Queue();
                             q.Enqueue("K");

                             CharacterCodes.Add("k", q);

                             // keycode for "l"
                             q = new Queue();
                             q.Enqueue("L");

                             CharacterCodes.Add("l", q);

                             // keycode for "þ"
                             q = new Queue();
                             q.Enqueue("Oem1");

                             CharacterCodes.Add("þ", q);

                             // keycode for "i"
                             q = new Queue();
                             q.Enqueue("Oem7");

                             CharacterCodes.Add("i", q);

                             // keycode for "z"
                             q = new Queue();
                             q.Enqueue("Z");

                             CharacterCodes.Add("z", q);

                             // keycode for "x"
                             q = new Queue();
                             q.Enqueue("X");

                             CharacterCodes.Add("x", q);

                             // keycode for "c"
                             q = new Queue();
                             q.Enqueue("C");

                             CharacterCodes.Add("c", q);

                             // keycode for "v"
                             q = new Queue();
                             q.Enqueue("V");

                             CharacterCodes.Add("v", q);

                             // keycode for "b"
                             q = new Queue();
                             q.Enqueue("B");

                             CharacterCodes.Add("b", q);

                             // keycode for "n"
                             q = new Queue();
                             q.Enqueue("N");

                             CharacterCodes.Add("n", q);

                             // keycode for "m"
                             q = new Queue();
                             q.Enqueue("M");

                             CharacterCodes.Add("m", q);

                             // keycode for "ö"
                             q = new Queue();
                             q.Enqueue("OemQuestion");

                             CharacterCodes.Add("ö", q);

                             // keycode for "ç"
                             q = new Queue();
                             q.Enqueue("Oem5");

                             CharacterCodes.Add("ç", q);

                             #endregion

                             #region UpperCase Characters

                             // keycode for "Q"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("Q");

                             CharacterCodes.Add("Q", q);

                             // keycode for "W"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("W");

                             CharacterCodes.Add("W", q);

                             // keycode for "E"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("E");

                             CharacterCodes.Add("E", q);

                             // keycode for "R"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("R");

                             CharacterCodes.Add("R", q);

                             // keycode for "T"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("T");

                             CharacterCodes.Add("T", q);

                             // keycode for "A"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("A");

                             CharacterCodes.Add("A", q);

                             // keycode for "S"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("S");

                             CharacterCodes.Add("S", q);

                             // keycode for "D"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("D");

                             CharacterCodes.Add("D", q);

                             // keycode for "F"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("F");

                             CharacterCodes.Add("F", q);

                             // keycode for "G"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("G");

                             CharacterCodes.Add("G", q);

                             // keycode for "Z"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("Z");

                             CharacterCodes.Add("Z", q);

                             // keycode for "X"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("X");

                             CharacterCodes.Add("X", q);

                             // keycode for "C"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("C");

                             CharacterCodes.Add("C", q);

                             // keycode for V"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("V");

                             CharacterCodes.Add("V", q);

                             // keycode for "B"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("B");

                             CharacterCodes.Add("B", q);

                             // keycode for "Y"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("Y");

                             CharacterCodes.Add("Y", q);

                             // keycode for "U"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("U");

                             CharacterCodes.Add("U", q);

                             // keycode for "I"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("I");

                             CharacterCodes.Add("I", q);

                             // keycode for "O"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("O");

                             CharacterCodes.Add("O", q);

                             // keycode for "P"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("P");

                             CharacterCodes.Add("P", q);

                             // keycode for "Ð"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("OemOpenBrackets");

                             CharacterCodes.Add("Ð", q);

                             // keycode for "Ü"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("Oem6");

                             CharacterCodes.Add("Ü", q);

                             // keycode for "H"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("H");

                             CharacterCodes.Add("H", q);

                             // keycode for "J"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("J");

                             CharacterCodes.Add("J", q);

                             // keycode for "K"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("K");

                             CharacterCodes.Add("K", q);

                             // keycode for "L"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("L");

                             CharacterCodes.Add("L", q);

                             // keycode for "Þ"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("Oem1");

                             CharacterCodes.Add("Þ", q);

                             // keycode for "Ý"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("Oem7");

                             CharacterCodes.Add("Ý", q);

                             // keycode for "N"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("N");

                             CharacterCodes.Add("N", q);

                             // keycode for "M"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("M");

                             CharacterCodes.Add("M", q);

                             // keycode for "Ö"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("OemQuestion");

                             CharacterCodes.Add("Ö", q);

                             // keycode for "Ç"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("Oem5");

                             CharacterCodes.Add("Ç", q);

                             #endregion

                             #region Controls Keys

                             // keycode for "Tab"
                             q = new Queue();
                             q.Enqueue("Tab");

                             CharacterCodes.Add("Tab", q);

                             // keycode for "@"
                             q = new Queue();
                             q.Enqueue("RMenu");
                             q.Enqueue("Q");

                             CharacterCodes.Add("@", q);

                             // keycode for "~"
                             q = new Queue();
                             q.Enqueue("RMenu");
                             q.Enqueue("Oem6");

                             CharacterCodes.Add("~", q);

                             // keycode for "Capital"
                             q = new Queue();
                             q.Enqueue("Capital");

                             CharacterCodes.Add("Capital", q);

                             // keycode for "<"
                             q = new Queue();
                             q.Enqueue("OemBackslash");

                             CharacterCodes.Add("<", q);

                             // keycode for ">"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("OemBackslash");

                             CharacterCodes.Add(">", q);

                             // keycode for "|"
                             q = new Queue();
                             q.Enqueue("RMenu");
                             q.Enqueue("OemBackslash");

                             CharacterCodes.Add("|", q);

                             // keycode for "."
                             q = new Queue();
                             q.Enqueue("OemPeriod");

                             CharacterCodes.Add(".", q);

                             // keycode for ":"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("OemPeriod");

                             CharacterCodes.Add(":", q);

                             // keycode for ","
                             q = new Queue();
                             q.Enqueue("Oemcomma");

                             CharacterCodes.Add(",", q);

                             // keycode for ";"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("Oemcomma");

                             CharacterCodes.Add(";", q);

                             // keycode for "`"
                             q = new Queue();
                             q.Enqueue("RMenu");
                             q.Enqueue("Oemcomma");

                             CharacterCodes.Add("`", q);

                             // keycode for "Back"
                             q = new Queue();
                             q.Enqueue("Back");

                             CharacterCodes.Add("Back", q);

                             // keycode for "LControlKey"
                             q = new Queue();
                             q.Enqueue("LControlKey");

                             CharacterCodes.Add("LControlKey", q);

                             // keycode for "LWin"
                             q = new Queue();
                             q.Enqueue("LWin");

                             CharacterCodes.Add("LWin", q);

                             // keycode for "LMenu"
                             q = new Queue();
                             q.Enqueue("LMenu");

                             CharacterCodes.Add("LMenu", q);

                             // keycode for "Space"
                             q = new Queue();
                             q.Enqueue("Space");

                             CharacterCodes.Add(" ", q);

                             // keycode for "RMenu"
                             q = new Queue();
                             q.Enqueue("RMenu");

                             CharacterCodes.Add("RMenu", q);

                             // keycode for "RWin"
                             q = new Queue();
                             q.Enqueue("RWin");

                             CharacterCodes.Add("RWin", q);

                             // keycode for "Apps"
                             q = new Queue();
                             q.Enqueue("Apps");

                             CharacterCodes.Add("Apps", q);

                             // keycode for "RControlKey"
                             q = new Queue();
                             q.Enqueue("RControlKey");

                             CharacterCodes.Add("RControlKey", q);

                             // keycode for "Return"
                             q = new Queue();
                             q.Enqueue("Return");

                             CharacterCodes.Add("Return", q);

                             #endregion

                             #region Symbols and Numbers

                             // keycode for """
                             q = new Queue();
                             q.Enqueue("Oemtilde");

                             CharacterCodes.Add("\"", q);

                             // keycode for "é"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("Oemtilde");

                             CharacterCodes.Add("é", q);

                             // keycode for "1"
                             q = new Queue();
                             q.Enqueue("D1");

                             CharacterCodes.Add("1", q);

                             // keycode for "!"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("D1");

                             CharacterCodes.Add("!", q);

                             // keycode for "2"
                             q = new Queue();
                             q.Enqueue("D2");

                             CharacterCodes.Add("2", q);

                             // keycode for "'"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("D2");

                             CharacterCodes.Add("'", q);

                             // keycode for "3"
                             q = new Queue();
                             q.Enqueue("D3");

                             CharacterCodes.Add("3", q);

                             // keycode for "^"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("D3");

                             CharacterCodes.Add("^", q);

                             // keycode for "#"
                             q = new Queue();
                             q.Enqueue("RMenu");
                             q.Enqueue("D3");

                             CharacterCodes.Add("#", q);

                             // keycode for "4"
                             q = new Queue();
                             q.Enqueue("D4");

                             CharacterCodes.Add("4", q);

                             // keycode for "+"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("D4");

                             CharacterCodes.Add("+", q);

                             // keycode for "$"
                             q = new Queue();
                             q.Enqueue("RMenu");
                             q.Enqueue("D4");

                             CharacterCodes.Add("$", q);

                             // keycode for "5"
                             q = new Queue();
                             q.Enqueue("D5");

                             CharacterCodes.Add("5", q);

                             // keycode for "%"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("D5");

                             CharacterCodes.Add("%", q);

                             // keycode for "6"
                             q = new Queue();
                             q.Enqueue("D6");

                             CharacterCodes.Add("6", q);

                             // keycode for "&"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("D6");

                             CharacterCodes.Add("&", q);

                             // keycode for "7"
                             q = new Queue();
                             q.Enqueue("D7");

                             CharacterCodes.Add("7", q);

                             // keycode for "/"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("D7");

                             CharacterCodes.Add("/", q);

                             // keycode for "{"
                             q = new Queue();
                             q.Enqueue("RMenu");
                             q.Enqueue("D7");

                             CharacterCodes.Add("{", q);

                             // keycode for "8"
                             q = new Queue();
                             q.Enqueue("D8");

                             CharacterCodes.Add("8", q);

                             // keycode for "("
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("D8");

                             CharacterCodes.Add("(", q);

                             // keycode for "["
                             q = new Queue();
                             q.Enqueue("RMenu");
                             q.Enqueue("D8");

                             CharacterCodes.Add("[", q);

                             // keycode for "9"
                             q = new Queue();
                             q.Enqueue("D9");

                             CharacterCodes.Add("9", q);

                             // keycode for ")"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("D9");

                             CharacterCodes.Add(")", q);

                             // keycode for "]"
                             q = new Queue();
                             q.Enqueue("RMenu");
                             q.Enqueue("D9");

                             CharacterCodes.Add("]", q);

                             // keycode for "0"
                             q = new Queue();
                             q.Enqueue("D0");

                             CharacterCodes.Add("0", q);

                             // keycode for "="
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("D0");

                             CharacterCodes.Add("=", q);

                             // keycode for "}"
                             q = new Queue();
                             q.Enqueue("RMenu");
                             q.Enqueue("D0");

                             CharacterCodes.Add("}", q);

                             // keycode for "*"
                             q = new Queue();
                             q.Enqueue("Oem8");

                             CharacterCodes.Add("*", q);

                             // keycode for "?"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("Oem8");

                             CharacterCodes.Add("?", q);

                             // keycode for "\"
                             q = new Queue();
                             q.Enqueue("RMenu");
                             q.Enqueue("Oem8");

                             CharacterCodes.Add("\\", q);

                             // keycode for "-"
                             q = new Queue();
                             q.Enqueue("OemMinus");

                             CharacterCodes.Add("-", q);

                             // keycode for "_"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("OemMinus");

                             CharacterCodes.Add("_", q);

                             #endregion
                         }
                         else
                         {
                             // F Keyboard

                             #region LowerCase Characters

                             // keycode for "f"
                             Queue q = new Queue();
                             q.Enqueue("F");

                             CharacterCodes.Add("f", q);

                             // keycode for "g"
                             q = new Queue();
                             q.Enqueue("G");

                             CharacterCodes.Add("g", q);

                             // keycode for "ð"
                             q = new Queue();
                             q.Enqueue("Ð");

                             CharacterCodes.Add("ð", q);

                             // keycode for "ý"
                             q = new Queue();
                             q.Enqueue("I");

                             CharacterCodes.Add("ý", q);

                             // keycode for "o"
                             q = new Queue();
                             q.Enqueue("O");

                             CharacterCodes.Add("o", q);

                             // keycode for "d"
                             q = new Queue();
                             q.Enqueue("D");

                             CharacterCodes.Add("d", q);

                             // keycode for "r"
                             q = new Queue();
                             q.Enqueue("R");

                             CharacterCodes.Add("r", q);

                             // keycode for "n"
                             q = new Queue();
                             q.Enqueue("N");

                             CharacterCodes.Add("n", q);

                             // keycode for "h"
                             q = new Queue();
                             q.Enqueue("H");

                             CharacterCodes.Add("h", q);

                             // keycode for "p"
                             q = new Queue();
                             q.Enqueue("P");

                             CharacterCodes.Add("p", q);

                             // keycode for "q"
                             q = new Queue();
                             q.Enqueue("OemOpenBrackets");

                             CharacterCodes.Add("q", q);

                             // keycode for "w"
                             q = new Queue();
                             q.Enqueue("Oem6");

                             CharacterCodes.Add("w", q);

                             // keycode for "u"
                             q = new Queue();
                             q.Enqueue("U");

                             CharacterCodes.Add("u", q);

                             // keycode for "i"
                             q = new Queue();
                             q.Enqueue("Ý");

                             CharacterCodes.Add("i", q);

                             // keycode for "e"
                             q = new Queue();
                             q.Enqueue("E");

                             CharacterCodes.Add("e", q);

                             // keycode for "a"
                             q = new Queue();
                             q.Enqueue("A");

                             CharacterCodes.Add("a", q);

                             // keycode for "ü"
                             q = new Queue();
                             q.Enqueue("Ü");

                             CharacterCodes.Add("ü", q);

                             // keycode for "t"
                             q = new Queue();
                             q.Enqueue("T");

                             CharacterCodes.Add("t", q);

                             // keycode for "k"
                             q = new Queue();
                             q.Enqueue("K");

                             CharacterCodes.Add("k", q);

                             // keycode for "m"
                             q = new Queue();
                             q.Enqueue("M");

                             CharacterCodes.Add("m", q);

                             // keycode for "l"
                             q = new Queue();
                             q.Enqueue("L");

                             CharacterCodes.Add("l", q);

                             // keycode for "y"
                             q = new Queue();
                             q.Enqueue("Oem1");

                             CharacterCodes.Add("y", q);

                             // keycode for "þ"
                             q = new Queue();
                             q.Enqueue("Oem7");

                             CharacterCodes.Add("þ", q);

                             // keycode for "j"
                             q = new Queue();
                             q.Enqueue("J");

                             CharacterCodes.Add("j", q);

                             // keycode for "ö"
                             q = new Queue();
                             q.Enqueue("Ö");

                             CharacterCodes.Add("ö", q);

                             // keycode for "v"
                             q = new Queue();
                             q.Enqueue("V");

                             CharacterCodes.Add("v", q);

                             // keycode for "c"
                             q = new Queue();
                             q.Enqueue("C");

                             CharacterCodes.Add("c", q);

                             // keycode for "ç"
                             q = new Queue();
                             q.Enqueue("Ç");

                             CharacterCodes.Add("ç", q);

                             // keycode for "z"
                             q = new Queue();
                             q.Enqueue("Z");

                             CharacterCodes.Add("z", q);

                             // keycode for "s"
                             q = new Queue();
                             q.Enqueue("S");

                             CharacterCodes.Add("s", q);

                             // keycode for "b"
                             q = new Queue();
                             q.Enqueue("OemQuestion");

                             CharacterCodes.Add("b", q);

                             #endregion

                             #region UpperCase Characters

                             // keycode for "F"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("F");

                             CharacterCodes.Add("F", q);

                             // keycode for "G"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("G");

                             CharacterCodes.Add("G", q);

                             // keycode for "Ð"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("Ð");

                             CharacterCodes.Add("Ð", q);

                             // keycode for "I"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("I");

                             CharacterCodes.Add("I", q);

                             // keycode for "O"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("O");

                             CharacterCodes.Add("O", q);

                             // keycode for "U"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("U");

                             CharacterCodes.Add("U", q);

                             // keycode for "Ý"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("Ý");

                             CharacterCodes.Add("Ý", q);

                             // keycode for "E"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("E");

                             CharacterCodes.Add("E", q);

                             // keycode for "A"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("A");

                             CharacterCodes.Add("A", q);

                             // keycode for "Ü"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("Ü");

                             CharacterCodes.Add("Ü", q);

                             // keycode for "J"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("J");

                             CharacterCodes.Add("J", q);

                             // keycode for "Ö"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("Ö");

                             CharacterCodes.Add("Ö", q);

                             // keycode for "V"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("V");

                             CharacterCodes.Add("V", q);

                             // keycode for C"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("C");

                             CharacterCodes.Add("C", q);

                             // keycode for "Ç"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("Ç");

                             CharacterCodes.Add("Ç", q);

                             // keycode for "D"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("D");

                             CharacterCodes.Add("D", q);

                             // keycode for "R"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("R");

                             CharacterCodes.Add("R", q);

                             // keycode for "N"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("N");

                             CharacterCodes.Add("N", q);

                             // keycode for "H"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("H");

                             CharacterCodes.Add("H", q);

                             // keycode for "P"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("P");

                             CharacterCodes.Add("P", q);

                             // keycode for "Q"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("OemOpenBrackets");

                             CharacterCodes.Add("Q", q);

                             // keycode for "W"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("Oem6");

                             CharacterCodes.Add("W", q);

                             // keycode for "X"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("X");

                             CharacterCodes.Add("X", q);

                             // keycode for "T"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("T");

                             CharacterCodes.Add("T", q);

                             // keycode for "K"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("K");

                             CharacterCodes.Add("K", q);

                             // keycode for "M"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("M");

                             CharacterCodes.Add("M", q);

                             // keycode for "L"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("L");

                             CharacterCodes.Add("L", q);

                             // keycode for "Y"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("Oem1");

                             CharacterCodes.Add("Y", q);

                             // keycode for "Þ"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("Oem7");

                             CharacterCodes.Add("Þ", q);

                             // keycode for "Z"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("Z");

                             CharacterCodes.Add("Z", q);

                             // keycode for "S"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("S");

                             CharacterCodes.Add("S", q);

                             // keycode for "B"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("OemQuestion");

                             CharacterCodes.Add("B", q);

                             #endregion

                             #region Controls Keys

                             // keycode for "Tab"
                             q = new Queue();
                             q.Enqueue("Tab");

                             CharacterCodes.Add("Tab", q);

                             // keycode for "@"
                             q = new Queue();
                             q.Enqueue("RMenu");
                             q.Enqueue("F");

                             CharacterCodes.Add("@", q);

                             // keycode for "~"
                             q = new Queue();
                             q.Enqueue("RMenu");
                             q.Enqueue("Oem6");

                             CharacterCodes.Add("~", q);

                             // keycode for "Capital"
                             q = new Queue();
                             q.Enqueue("Capital");

                             CharacterCodes.Add("Capital", q);

                             // keycode for "<"
                             q = new Queue();
                             q.Enqueue("OemBackslash");

                             CharacterCodes.Add("<", q);

                             // keycode for ">"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("OemBackslash");

                             CharacterCodes.Add(">", q);

                             // keycode for "|"
                             q = new Queue();
                             q.Enqueue("RMenu");
                             q.Enqueue("OemBackslash");

                             CharacterCodes.Add("|", q);

                             // keycode for "."
                             q = new Queue();
                             q.Enqueue("OemPeriod");

                             CharacterCodes.Add(".", q);

                             // keycode for ":"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("OemPeriod");

                             CharacterCodes.Add(":", q);

                             // keycode for ","
                             q = new Queue();
                             q.Enqueue("Oemcomma");

                             CharacterCodes.Add(",", q);

                             // keycode for ";"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("Oemcomma");

                             CharacterCodes.Add(";", q);

                             // keycode for "`"
                             q = new Queue();
                             q.Enqueue("RMenu");
                             q.Enqueue("Oemcomma");

                             CharacterCodes.Add("`", q);

                             // keycode for "Back"
                             q = new Queue();
                             q.Enqueue("Back");

                             CharacterCodes.Add("Back", q);

                             // keycode for "LControlKey"
                             q = new Queue();
                             q.Enqueue("LControlKey");

                             CharacterCodes.Add("LControlKey", q);

                             // keycode for "LWin"
                             q = new Queue();
                             q.Enqueue("LWin");

                             CharacterCodes.Add("LWin", q);

                             // keycode for "LMenu"
                             q = new Queue();
                             q.Enqueue("LMenu");

                             CharacterCodes.Add("LMenu", q);

                             // keycode for "Space"
                             q = new Queue();
                             q.Enqueue("Space");

                             CharacterCodes.Add(" ", q);

                             // keycode for "RMenu"
                             q = new Queue();
                             q.Enqueue("RMenu");

                             CharacterCodes.Add("RMenu", q);

                             // keycode for "RWin"
                             q = new Queue();
                             q.Enqueue("RWin");

                             CharacterCodes.Add("RWin", q);

                             // keycode for "Apps"
                             q = new Queue();
                             q.Enqueue("Apps");

                             CharacterCodes.Add("Apps", q);

                             // keycode for "RControlKey"
                             q = new Queue();
                             q.Enqueue("RControlKey");

                             CharacterCodes.Add("RControlKey", q);

                             // keycode for "Return"
                             q = new Queue();
                             q.Enqueue("Return");

                             CharacterCodes.Add("Return", q);

                             #endregion

                             #region Symbols and Numbers

                             // keycode for """
                             q = new Queue();
                             q.Enqueue("Oemtilde");

                             CharacterCodes.Add("\"", q);

                             // keycode for "é"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("Oemtilde");

                             CharacterCodes.Add("é", q);

                             // keycode for "1"
                             q = new Queue();
                             q.Enqueue("D1");

                             CharacterCodes.Add("1", q);

                             // keycode for "!"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("D1");

                             CharacterCodes.Add("!", q);

                             // keycode for "2"
                             q = new Queue();
                             q.Enqueue("D2");

                             CharacterCodes.Add("2", q);

                             // keycode for "'"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("D2");

                             CharacterCodes.Add("'", q);

                             // keycode for "3"
                             q = new Queue();
                             q.Enqueue("D3");

                             CharacterCodes.Add("3", q);

                             // keycode for "^"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("D3");

                             CharacterCodes.Add("^", q);

                             // keycode for "#"
                             q = new Queue();
                             q.Enqueue("RMenu");
                             q.Enqueue("D3");

                             CharacterCodes.Add("#", q);

                             // keycode for "4"
                             q = new Queue();
                             q.Enqueue("D4");

                             CharacterCodes.Add("4", q);

                             // keycode for "+"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("D4");

                             CharacterCodes.Add("+", q);

                             // keycode for "$"
                             q = new Queue();
                             q.Enqueue("RMenu");
                             q.Enqueue("D4");

                             CharacterCodes.Add("$", q);

                             // keycode for "5"
                             q = new Queue();
                             q.Enqueue("D5");

                             CharacterCodes.Add("5", q);

                             // keycode for "%"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("D5");

                             CharacterCodes.Add("%", q);

                             // keycode for "6"
                             q = new Queue();
                             q.Enqueue("D6");

                             CharacterCodes.Add("6", q);

                             // keycode for "&"
                             q = new Queue();
                             q.Enqueue("RShiftKey");
                             q.Enqueue("D6");

                             CharacterCodes.Add("&", q);

                             // keycode for "7"
                             q = new Queue();
                             q.Enqueue("D7");

                             CharacterCodes.Add("7", q);

                             // keycode for "/"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("D7");

                             CharacterCodes.Add("/", q);

                             // keycode for "{"
                             q = new Queue();
                             q.Enqueue("RMenu");
                             q.Enqueue("D7");

                             CharacterCodes.Add("{", q);

                             // keycode for "8"
                             q = new Queue();
                             q.Enqueue("D8");

                             CharacterCodes.Add("8", q);

                             // keycode for "("
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("D8");

                             CharacterCodes.Add("(", q);

                             // keycode for "["
                             q = new Queue();
                             q.Enqueue("RMenu");
                             q.Enqueue("D8");

                             CharacterCodes.Add("[", q);

                             // keycode for "9"
                             q = new Queue();
                             q.Enqueue("D9");

                             CharacterCodes.Add("9", q);

                             // keycode for ")"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("D9");

                             CharacterCodes.Add(")", q);

                             // keycode for "]"
                             q = new Queue();
                             q.Enqueue("RMenu");
                             q.Enqueue("D9");

                             CharacterCodes.Add("]", q);

                             // keycode for "0"
                             q = new Queue();
                             q.Enqueue("D0");

                             CharacterCodes.Add("0", q);

                             // keycode for "="
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("D0");

                             CharacterCodes.Add("=", q);

                             // keycode for "}"
                             q = new Queue();
                             q.Enqueue("RMenu");
                             q.Enqueue("D0");

                             CharacterCodes.Add("}", q);

                             // keycode for "*"
                             q = new Queue();
                             q.Enqueue("Oem8");

                             CharacterCodes.Add("*", q);

                             // keycode for "?"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("Oem8");

                             CharacterCodes.Add("?", q);

                             // keycode for "\"
                             q = new Queue();
                             q.Enqueue("RMenu");
                             q.Enqueue("Oem8");

                             CharacterCodes.Add("\\", q);

                             // keycode for "-"
                             q = new Queue();
                             q.Enqueue("OemMinus");

                             CharacterCodes.Add("-", q);

                             // keycode for "_"
                             q = new Queue();
                             q.Enqueue("LShiftKey");
                             q.Enqueue("OemMinus");

                             CharacterCodes.Add("_", q);

                             #endregion
                         }
                     }
                     break;
            }
        }

        public void LoadKeyCodes()
        {
            if (!innerError)
            {
                if (!keyCodesLoaded_)
                {
                    if (Utilities.Settings.Contains(Constants.propKeyboardLayout))
                    {
                        LoadKeyboardLayoutKeyCodes();

                        keyCodesLoaded_ = true;
                    }
                    else
                    {
                        ExceptionUtilities.ShowException(new Exception(this.innerMessages.GetLanguageString(3)), MessageBoxButtons.OK);
                        this.innerError = true;
                    }
                }
            }
        }

        public void UnloadKeyCodes()
        {
            if (keyCodesLoaded_)
                CharacterCodes.Clear();
        }

        public Queue GetKeyCodeQueue(string key)
        {
            if (CharacterCodes.ContainsKey(key))
                return CharacterCodes[key];
            else
                return null;
        }

        #endregion

        #region Private Methods

        private void MyKeyDown(object sender, KeyEventArgs e)
        {
            CaptureKey(e);
        }

        private void MyKeyPress(object sender, KeyPressEventArgs e)
        {
            EndCaptureKey();
        }

        private void MyKeyUp(object sender, KeyEventArgs e)
        {/*
            if (waitForKeyUp_)
            {
                CaptureKey(e);
                EndCaptureKey();

                waitForKeyUp_ = false;
            }
          */
        }

        private void CaptureKey(KeyEventArgs e)
        {
            if (!keyCodesCaptured_)
            {
                string keyCode = e.KeyCode.ToString();

                if (!this.tmpPressedKeyCodes_.Contains(keyCode))
                    this.tmpPressedKeyCodes_.Enqueue(keyCode);
            }

            /*
            if (e.Alt)
                waitForKeyUp_ = true;
            */
        }

        private void EndCaptureKey()
        {
            keyCodesCaptured_ = true;

            this.PressedKeyCodes = (Queue)this.tmpPressedKeyCodes_.Clone();

            this.tmpPressedKeyCodes_.Clear();
        }

        private void HighlightExpectedKeys()
        {
            // first stop highlighting previous keys
            if (PreviousKeyCodes != null)
            {
                IEnumerator en = PreviousKeyCodes.GetEnumerator();

                while (en.MoveNext())
                {
                    string keyCode = en.Current.ToString();

                    if (keyboardKeys.ContainsKey(keyCode))
                    {
                        Key tmpKey = keyboardKeys[keyCode];

                        tmpKey.StopHighlightKey();
                    }
                }
            }

            if (ExpectedKeyCodes != null)
            {
                IEnumerator en = ExpectedKeyCodes.GetEnumerator();

                while (en.MoveNext())
                {
                    string keyCode = en.Current.ToString();

                    if (keyboardKeys.ContainsKey(keyCode))
                    {
                        Key tmpKey = keyboardKeys[keyCode];

                        tmpKey.StartHighlightKey();
                    }
                }
            }
        }

        private void DisplayExpectedKeyCodeInfo()
        {
            if (ExpectedKeyCodes != null)
            {
                this.expectedKeyCodeInfo.Text = "";

                IEnumerator en = ExpectedKeyCodes.GetEnumerator();

                while (en.MoveNext())
                {
                    this.expectedKeyCodeInfo.Text += en.Current.ToString() + "/";
                }
            }

            if (PressedKeyCodes != null)
            {
                this.pressedKeyCodeInfo.Text = "";

                IEnumerator en = PressedKeyCodes.GetEnumerator();

                while (en.MoveNext())
                {
                    this.pressedKeyCodeInfo.Text += en.Current.ToString() + "/";
                }
            }
        }

        private void KeyboardLayout_Load(object sender, EventArgs e)
        {
            if (!innerError)
                LoadKeyboardLayout();
        }

        private void DrawKeyboardFromFile()
        {
            Keyboard keyboardLayout = (Keyboard)Utilities.Settings[Constants.propKeyboardLayout];

            if (!innerError)
            {
                if (keyboardLayout != null)
                {
                    string xmlpath = AppDomain.CurrentDomain.BaseDirectory + Settings.Constants.layoutsDirectory;

                    this.layoutBox.Text = keyboardLayout.Name;

                    //load the current layout from the xml file
                    XmlDocument xmldoc = new XmlDocument();

                    if (keyboardLayout.KeyboardType != "")
                        xmldoc.Load(xmlpath + @"\" + keyboardLayout.Code + @"\" + keyboardLayout.Code + "_" + keyboardLayout.KeyboardType + ".xml");
                    else
                        xmldoc.Load(xmlpath + @"\" + keyboardLayout.Code + @"\" + keyboardLayout.Code + ".xml");

                    AddToKeyboardKeysAndDrawButtons(xmldoc);
                }
                else
                {
                    ExceptionUtilities.ShowException(new Exception(this.innerMessages.GetLanguageString(4)), MessageBoxButtons.OK);
                    this.innerError = true;
                }
            }
        }

        private void AddToKeyboardKeysAndDrawButtons(XmlDocument xmldoc)
        {
            if (Utilities.Settings.Contains("KeyboardLayout"))
            {
                Keyboard currentKeyboardSettings = (Keyboard)Utilities.Settings["KeyboardLayout"];

                if (currentKeyboardSettings != null)
                {
                    // select keyboard key for the specified properties (language, type, scheme etc.)
                    string xpath = "";
                    xpath = "/keyboards/keyboard[@code='" + currentKeyboardSettings.Code + "' and @type='" + currentKeyboardSettings.KeyboardType + "']";
                    xpath += "/scheme[@name='" + currentKeyboardSettings.Scheme.ToString() + "']/rows/row";

                    XmlNodeList rows = xmldoc.SelectNodes(xpath);

                    if (rows.Count > 0)
                    {
                        // get rows and create a key object for each key node
                        foreach (XmlNode row in rows)
                        {
                            XmlNodeList keys = row.SelectNodes("key");

                            foreach (XmlNode key in keys)
                            {
                                string keyCode = key.Attributes["code"].Value;

                                // add key to the current layout key dictionary and draw it
                                if (keyCode != "")
                                {
                                    // create new key instance
                                    Key tmpKey = new Key(keyCode);

                                    //set attributes
                                    tmpKey.Name = "Key_" + keyCode;
                                    tmpKey.Size = new System.Drawing.Size(GetIntegerValueFromXmlNode(key, "width"), GetIntegerValueFromXmlNode(key, "height"));
                                    tmpKey.Location = new System.Drawing.Point(GetIntegerValueFromXmlNode(key, "positionx"), GetIntegerValueFromXmlNode(key, "positiony"));

                                    tmpKey.SymbolPositionOne = GetStringValueFromXmlNode(key, "characters/position[@id=1]");
                                    tmpKey.SymbolPositionTwo = GetStringValueFromXmlNode(key, "characters/position[@id=2]");
                                    tmpKey.SymbolPositionThree = GetStringValueFromXmlNode(key, "characters/position[@id=3]");
                                    tmpKey.SymbolPositionFour = GetStringValueFromXmlNode(key, "characters/position[@id=4]");

                                    tmpKey.LayoutScheme = currentKeyboardSettings.Scheme;

                                    // draw it
                                    this.layoutBox.Controls.Add(tmpKey);

                                    // add to dictionary
                                    this.keyboardKeys.Add(keyCode, tmpKey);
                                }
                            }
                        }
                    }
                    else
                    {
                        // STRING LITERAL
                        ExceptionUtilities.ShowException(new Exception(this.innerMessages.GetLanguageString(5)), MessageBoxButtons.OK);
                        this.innerError = true;
                    }
                }
            }
            else
            {
                // STRING LITERAL
                ExceptionUtilities.ShowException(new Exception(this.innerMessages.GetLanguageString(6)), MessageBoxButtons.OK);
                this.innerError = true;
            }
        }

        private string GetStringValueFromXmlNode(XmlNode node, string childNodeName)
        {
            string res = "";

            if (node != null)
            {
                XmlNode tmpNode = node.SelectSingleNode(childNodeName);

                if (tmpNode != null)
                {
                    if (tmpNode.InnerText != "")
                        res = tmpNode.InnerText;
                }
            }

            return res;
        }

        private int GetIntegerValueFromXmlNode(XmlNode node, string childNodeName)
        {
            int res = 0;

            if (node != null)
            {
                XmlNode tmpNode = node.SelectSingleNode(childNodeName);

                if (tmpNode != null)
                {
                    if (tmpNode.InnerText != "")
                        res = int.Parse(tmpNode.InnerText);
                }
            }

            return res;
        }

        #endregion
    }

    public class KeyboardKeysCollection : Dictionary<string, Key>
    {
        public KeyboardKeysCollection()
        {
            
        }
    }
}
