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
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace ActiveType.Settings
{
    [Serializable]
    public class UserCollection : ICollection, ICloneable
    {
        private ArrayList userList;

        public UserCollection()
        {
            this.userList = new ArrayList();
        }

        public UserCollection(ICollection Collection)
        {
            this.userList = new ArrayList();

            foreach (User u in Collection)
                this.Add(u);
        }

        public void Add(User nUser)
        {
            this.userList.Add(nUser);
        }

        public void Remove(User nUser)
        {
            userList.Remove(nUser);
        }

        public void RemoveAt(int index)
        {
            userList.RemoveAt(index);
        }

        public User Find(string username)
        {
            bool found = false;
            int i = 0;

            while (i < this.Count && found == false)
            {
                if (this[i].Username.ToLower() == username.ToLower())
                    found = true;
                i++;
            }

            if (found)
                return this[i - 1];
            else
                return null;
        }

        public User this[int index]
        {
            get
            {
                return (User)this.userList[index];
            }
            set
            {
                this.userList[index] = value;
            }
        }

        public bool Contains(User nUser)
        {
            if (userList != null)
                return this.userList.Contains(nUser);
            else
                return false;
        }

        public bool Contains(string username)
        {
            bool result = false;

            if (userList != null)
            {
                foreach (User u in this.userList)
                {
                    if (u.Username.ToLower() == username.ToLower())
                        result = true;
                }
            }

            return result;
        }

        public bool Contains(string username, string password)
        {
            bool result = false;

            foreach (User u in this.userList)
            {
                if (u.Username.ToLower() == username.ToLower() && u.Password.ToLower() == password.ToLower())
                    result = true;
            }

            return result;
        }

        #region ICollection Members

        public void CopyTo(Array array, int index)
        {
            this.userList.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return this.userList.Count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return this.userList.IsSynchronized;
            }
        }

        public object SyncRoot
        {
            get 
            {
                return this;
            }
        }

        #endregion

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return this.userList.GetEnumerator();
        }

        #endregion

        #region ICloneable Members

        public object Clone()
        {
            return userList.Clone();
        }

        #endregion
    }
}
