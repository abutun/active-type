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

namespace ActiveType.Settings
{
    [Serializable]
    public class Keyboard
    {
        private KeyboardScheme keyboardScheme_ = KeyboardScheme.BLUE;
        private string languageCode_;
        private string languageName_;
        private string languageDesc_;
        private string keyboardType_ = "";

        public Keyboard(string langcode)
        {
            this.languageCode_ = langcode;
            this.languageName_ = langcode;
            this.languageDesc_ = langcode;
        }
        public Keyboard(string langname,string langcode)
        {
            this.languageCode_ = langcode;
            this.languageName_ = langname;
            this.languageDesc_ = langname;
        }
        public Keyboard(string langname, string langdesc, string langcode, string kayboardtype)
        {
            this.languageCode_ = langcode.ToUpper();
            this.languageName_ = langname;
            this.languageDesc_ = langdesc;
            this.keyboardType_ = kayboardtype.ToUpper();
        }

        public KeyboardScheme Scheme
        {
            get
            {
                return this.keyboardScheme_;
            }
            set
            {
                this.keyboardScheme_ = value;
            }
        }
        public string Name
        {
            get
            {
                if (this.keyboardType_=="")
                    return this.languageName_ + "-" + this.keyboardType_;
                else
                    return this.languageName_;
            }
            set
            {
                this.languageName_ = value;
            }
        }
        public string Code
        {
            get
            {
                return this.languageCode_.ToUpper();
            }
            set
            {
                this.languageCode_ = value.ToUpper();
            }
        }
        public string Description
        {
            get
            {
                return this.languageDesc_;
            }
            set
            {
                this.languageDesc_ = value;
            }
        }
        public string KeyboardType
        {
            get
            {
                return this.keyboardType_.ToUpper();
            }
            set
            {
                this.keyboardType_ = value.ToUpper();
            }
        }
    }
}
