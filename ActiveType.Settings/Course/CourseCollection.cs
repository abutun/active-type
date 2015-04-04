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

namespace ActiveType.Settings
{
    [Serializable]
    public class CourseCollection : ICollection
    {
        ArrayList innerList = new ArrayList();

        public Course this[int index]
        {
            get
            {
                return (Course)this.innerList[index];
            }
            set
            {
                this.innerList[index] = value;
            }
        }

        #region ICollection Members

        public void Add(Course item)
        {
            this.innerList.Add(item);
        }

        public void Clear()
        {
            this.innerList.Clear();
        }

        public bool Contains(Course item)
        {
            bool res = false;

            foreach(Course itm in this.innerList)
            {
                if (item.Path.ToUpper() == item.Path.ToUpper())
                {
                    res = true;
                    break;
                }
            }

            return res;
        }

        public int Count
        {
            get 
            {
                return this.innerList.Count;
            }
        }

        public bool IsReadOnly
        {
            get 
            {
                return this.innerList.IsReadOnly;
            }
        }

        public bool Remove(Course item)
        {
            int index = -1;

            for (int i = 0; i < this.innerList.Count; i++)
            {
                if (this[i].Path.ToUpper() == item.Path.ToUpper())
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                this.RemoveAt(index);

                return true;
            }
            else
                return false;
        }

        public void RemoveAt(int index)
        {
            this.innerList.RemoveAt(index);
        }

        public void CopyTo(Array array, int index)
        {
            this.innerList.CopyTo(array, index);
        }

        public bool IsSynchronized
        {
            get 
            {
                return this.innerList.IsSynchronized;
            }
        }

        public object SyncRoot
        {
            get 
            {
                return this.innerList.SyncRoot;
            }
        }

        #endregion

        public void Sort()
        {
            CourseComparer com = new CourseComparer();

            this.innerList.Sort((IComparer)com);
        }

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.innerList.GetEnumerator();
        }

        #endregion
    }

    public class CourseComparer: IComparer
    {
        #region IComparer Members

        public int Compare(object x, object y)
        {
            return ((Course)x).No - ((Course)y).No;
        }

        #endregion
    }
}
