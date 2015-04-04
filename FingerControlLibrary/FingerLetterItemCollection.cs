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

namespace ActiveType.FingerControlLibrary
{
    public class FingerLetterItemCollection : CollectionBase
    {
        public FingerLetterItemCollection()
        {
        }

        public FingerLetterItem Add(FingerLetterItem lt)
        {
            base.InnerList.Add(lt);

            return lt;
        }

        public void Remove(FingerLetterItem lt)
        {
            base.InnerList.Remove(lt);
        }

        public bool Contains(FingerLetterItem currentItem)
        {
            bool res = false;

            foreach (FingerLetterItem itm in this.InnerList)
            {
                if (itm.Letter == currentItem.Letter)
                {
                    res = true;
                    break;
                }
            }

            return res;
        }

        public FingerLetterItem this[int index]
        {
            get
            {
                return (FingerLetterItem)base.InnerList[index];
            }
            set
            {
                this.InnerList[index] = value;
            }
        }

        public void AddRange(FingerLetterItem[] lt)
        {
            base.InnerList.AddRange(lt);
        }

        public FingerLetterItem[] GetValues()
        {
            FingerLetterItem[] lt = new FingerLetterItem[this.InnerList.Count];

            this.InnerList.CopyTo(0, lt, 0, this.InnerList.Count);

            return lt;
        }

        protected override void OnInsert(int index, object value)
        {
            base.OnInsert(index, value);
        }

    }
}
