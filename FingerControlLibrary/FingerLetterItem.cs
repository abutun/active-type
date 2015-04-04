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

namespace ActiveType.FingerControlLibrary
{
    public class FingerLetterItem
    {
        private string letter_;
        private string value_;

        public FingerLetterItem() : this("")
        {
        }

        public FingerLetterItem(string letter) : this(letter, letter)
        {
        }

        public FingerLetterItem(string letter, string value)
        {
            this.letter_ = letter;
            this.value_ = value;
        }

        [Category("Finger")]
        [DefaultValue(typeof(string), "")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Letter
        {
            get { return this.letter_; }
            set { this.letter_ = value; }
        }

        [Category("Finger")]
        [DefaultValue(typeof(string), "")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Value
        {
            get { return this.value_; }
            set { this.value_ = value; }
        }
    }
}
