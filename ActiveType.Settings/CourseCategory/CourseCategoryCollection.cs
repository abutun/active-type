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
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ActiveType.Settings
{
    [Serializable]
    public class CourseCategoryCollection : ICollection
    {
        ArrayList innerList = new ArrayList();

        public CourseCategory this[int index]
        {
            get
            {
                return (CourseCategory)this.innerList[index];
            }
            set
            {
                this.innerList[index] = value;
            }
        }

        #region ICollection Members

        public void Add(CourseCategory item)
        {
            this.innerList.Add(item);
        }

        public void Clear()
        {
            this.innerList.Clear();
        }

        public bool Contains(CourseCategory item)
        {
            bool res = false;

            foreach (CourseCategory itm in this.innerList)
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

        public bool Remove(CourseCategory item)
        {
            int index = -1;

            for (int i = 0; i < this.innerList.Count; i++)
            {
                if (item.Path.ToUpper() == item.Path.ToUpper())
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

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.innerList.GetEnumerator();
        }

        #endregion

        public bool LoadCourseCategories(string path)
        {
            CourseCategoryCollection tmpCourseCollection = new CourseCategoryCollection();

            if (Utilities.CurentUser != null)
            {
                if (!File.Exists(path))
                    SaveCourseCategories(path);

                try
                {
                    BinaryFormatter bf = new BinaryFormatter();

                    FileStream CourseCollectionFile = new FileStream(path, FileMode.Open, FileAccess.Read);

                    tmpCourseCollection = (CourseCategoryCollection)bf.Deserialize(CourseCollectionFile);

                    this.Clear();

                    foreach (CourseCategory itm in tmpCourseCollection)
                        this.Add(itm);

                    CourseCollectionFile.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    // STRING LITERAL //
                    MessageBox.Show("Cannot load course categories", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
            }
            else
                return false;
        }

        public bool SaveCourseCategories(string path)
        {
            if (path != "")
            {
                if (Utilities.CurentUser != null)
                {
                    try
                    {
                        FileStream CourseCategoryFile = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);

                        BinaryFormatter bf = new BinaryFormatter();

                        bf.Serialize(CourseCategoryFile, this);

                        CourseCategoryFile.Close();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        // STRING LITERAL //
                        MessageBox.Show("Cannot save course categories", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}
