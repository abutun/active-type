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
    public class StatisticsCollection : ICollection
    {
        ArrayList innerList = new ArrayList();

        public Statistics this[int index]
        {
            get
            {
                return (Statistics)this.innerList[index];
            }
            set
            {
                this.innerList[index] = value;
            }
        }

        public Statistics this[Statistics item]
        {
            get
            {
                int index = -1;

                for (int i = 0; i < this.innerList.Count; i++)
                {
                    if ((this[i].User.Username == item.User.Username) && (this[i].Course.Path.ToUpper() == item.Course.Path.ToUpper()))
                    {
                        index = i;
                        break;
                    }
                }

                if (index != -1)
                    return this[index];
                else
                    return null;
            }
        }

        #region ICollection Members

        public KeyValues GetOverAllKeyStat(string keycode)
        {
            int c = 0;
            int w = 0;

            // Operator overloading can be used here
            foreach (Statistics stat in this)
            {
                c = c + stat.GetKeyStat(keycode).CorrectPressCount;
                w = w + stat.GetKeyStat(keycode).WrongPressCount;
            }

            return new KeyValues(c, w);
        }

        public void Add(Statistics item)
        {
            this.innerList.Add(item);
        }

        public void Clear()
        {
            this.innerList.Clear();
        }

        public int Contains(Statistics item)
        {
            int res = -1;

            int i = 0;
            foreach (Statistics itm in this.innerList)
            {
                if ((itm.User.Username == item.User.Username) && (itm.Course.Path.ToUpper()==item.Course.Path.ToUpper()))
                {
                    res = i;
                    break;
                }
                i++;
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

        public bool Remove(Statistics item)
        {
            int index = -1;

            for (int i = 0; i < this.innerList.Count; i++)
            {
                if ((this[i].User.Username == item.User.Username) && (this[i].Course.Path.ToUpper() == item.Course.Path.ToUpper()))
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

        public void AddRange(StatisticsCollection col)
        {
            this.innerList.Clear();

            foreach (Statistics stat in col)
                this.Add(stat);
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

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.innerList.GetEnumerator();
        }

        #endregion
    }
}
