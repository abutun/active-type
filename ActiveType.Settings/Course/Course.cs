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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;

namespace ActiveType.Settings
{
    [Serializable]
    public class Course : IComparable<Course>
    {
        private CourseStatus innerStatus_ = CourseStatus.NONE;

        private string innerAlias_;
        private string innerText_;
        private string courseFilePath_;

        private CourseCategory innerCategory_;

        private int courseNo_;
        private int innerLevel_;

        private Course nextCourse_ = null;
        private Course prevCourse_ = null;

        public Course()
        {
        }

        public Course(string path) : this(path, 0, "", "", 0, null) { }

        public Course(string path, int no) : this(path, no, "", "", 0, null) { }

        public Course(string path, int no, string name) : this(path, no, name, "", 0, null) { }

        public Course(string path, int no, string name, string text) : this(path, no, name, text, 0, null) { }

        public Course(string path, int no, string name, string text, int level, CourseCategory category)
        {
            this.courseFilePath_ = path;
            this.innerAlias_ = name;
            this.innerText_ = text;

            this.innerLevel_ = level;
            this.courseNo_ = no;

            this.innerCategory_ = category;

            if(path!="")
                LoadCourse(this.Path);
        }

        public CourseCategory Category
        {
            get
            {
                return this.innerCategory_;
            }
            set
            {
                this.innerCategory_ = value;
            }
        }

        public string Path
        {
            get
            {
                return this.courseFilePath_;
            }
        }

        public int No
        {
            get
            {
                return this.courseNo_;
            }
            set
            {
                this.courseNo_ = value;
            }
        }

        public string Name
        {
            get
            {
                return this.innerAlias_;
            }
            set
            {
                this.innerAlias_ = value;
            }
        }

        public string Text
        {
            get
            {
                return this.innerText_;
            }
            set
            {
                this.innerText_ = value;
            }
        }

        public int Level
        {
            get
            {
                return this.innerLevel_;
            }
            set
            {
                this.innerLevel_ = value;
            }
        }

        public CourseStatus Status
        {
            get
            {
                return this.innerStatus_;
            }
        }

        public Course NextCourse
        {
            get
            {
                return this.nextCourse_;
            }
            set
            {
                this.nextCourse_ = value;
            }
        }

        public Course PrevCourse
        {
            get
            {
                return this.prevCourse_;
            }
            set
            {
                this.prevCourse_ = value;
            }
        }

        private bool LoadCourse(string path)
        {
            Course tmpCourse = new Course();

            if (Utilities.CurentUser != null)
            {
                if (File.Exists(path))
                {
                    try
                    {
                        BinaryFormatter bf = new BinaryFormatter();

                        FileStream CourseFile = new FileStream(path, FileMode.Open, FileAccess.Read);

                        tmpCourse = (Course)bf.Deserialize(CourseFile);

                        this.Name = tmpCourse.Name;
                        this.Text = tmpCourse.Text;
                        this.Level = tmpCourse.Level;
                        this.Category = tmpCourse.Category;
                        this.No = tmpCourse.No;
                        this.NextCourse = tmpCourse.NextCourse;
                        this.PrevCourse = tmpCourse.PrevCourse;

                        CourseFile.Close();

                        this.innerStatus_ = CourseStatus.LOADED;

                        return true;
                    }
                    catch (Exception ex)
                    {
                        // STRING LITERAL //
                        MessageBox.Show("Cannot load course", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                }
                else
                    return false;
            }
            else
                return false;
        }

        public bool SaveCourse()
        {
            if (this.Path != "")
            {
                if (Utilities.CurentUser != null)
                {
                    try
                    {
                        FileStream CourseFile = new FileStream(this.Path, FileMode.OpenOrCreate, FileAccess.Write);

                        BinaryFormatter bf = new BinaryFormatter();

                        bf.Serialize(CourseFile, this);

                        CourseFile.Close();

                        this.innerStatus_ = CourseStatus.SAVED;

                        return true;
                    }
                    catch (Exception ex)
                    {
                        // STRING LITERAL //
                        MessageBox.Show("Cannot save course", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                }
                else
                    return false;
            }
            else
                return false;
        }

        public bool RefreshCourse()
        {
            if (this.LoadCourse(this.Path))
                return true;
            else
                return false;
        }

        public bool DeleteCourse()
        {
            if (this.Path != "")
            {
                if (Utilities.CurentUser != null)
                {
                    try
                    {
                        File.Delete(this.Path);

                        this.innerStatus_ = CourseStatus.DELETED;

                        return true;
                    }
                    catch (Exception ex)
                    {
                        // STRING LITERAL //
                        MessageBox.Show("Cannot delete course", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                }
                else
                    return false;
            }
            else
                return false;
        }

        #region IComparable<Course> Members

        public int CompareTo(Course courseToCompare)
        {
            return this.No - courseToCompare.No;
        }

        #endregion
    }
}
