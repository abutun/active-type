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
    public class FingerCollection : CollectionBase
    {
        public FingerCollection()
        {
        }

        public Finger Add(Finger f)
        {
            base.InnerList.Add(f);

            return f;
        }

        public void Remove(Finger f)
        {
            base.InnerList.Remove(f);
        }

        public bool Contains(Finger f)
        {
            bool res = false;

            foreach (Finger itm in this.InnerList)
            {
                if (itm.FingerType == f.FingerType)
                {
                    res = true;
                    break;
                }
            }

            return res;
        }

        public Finger this[int index]
        {
            get
            {
                return (Finger)base.InnerList[index];
            }
            set
            {
                this.InnerList[index] = value;
            }
        }

        public void AddRange(Finger[] farr)
        {
            base.InnerList.AddRange(farr);
        }

        public Finger[] GetValues()
        {
            Finger[] farr = new Finger[this.InnerList.Count];

            this.InnerList.CopyTo(0, farr, 0, this.InnerList.Count);

            return farr;
        }

        protected override void OnInsert(int index, object value)
        {
            base.OnInsert(index, value);
        }

    }
}
