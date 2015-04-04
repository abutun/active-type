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
    public class Statistics
    {
        private User innerUser_ = null;
        private Course innerCourse_ = null;

        private Hashtable innerKeyStats_ = new Hashtable();

        private int accuracy_;
        private TimeSpan timeTaken_;
        private int keyPerMinute_;

        private int innerCorrectKeyPressedCount = 0;
        private int innerWrongKeyPressedCount = 0;

        public Statistics(User user, Course course)
        {
            this.innerUser_ = user;
            this.innerCourse_ = course;

            this.accuracy_ = 0;
            this.timeTaken_ = new TimeSpan(0);
            this.keyPerMinute_ = 0;
        }

        public int Accuracy
        {
            get
            {
                if (innerCorrectKeyPressedCount == 0 && innerWrongKeyPressedCount == 0)
                    return 0;
                else
                    return (innerCorrectKeyPressedCount * 100) / (innerCorrectKeyPressedCount + innerWrongKeyPressedCount);
            }
        }

        public TimeSpan TimeTaken
        {
            get
            {
                return this.timeTaken_;
            }
            set
            {
                this.timeTaken_ = value;
            }
        }

        public int KeyPerMinute
        {
            get
            {
                return this.keyPerMinute_;
            }
            set
            {
                this.keyPerMinute_ = value;
            }
        }

        public User User
        {
            get
            {
                return this.innerUser_;
            }
        }

        public Course Course
        {
            get
            {
                return this.innerCourse_;
            }
        }

        public Hashtable KeyStats
        {
            get
            {
                return this.innerKeyStats_;
            }
        }

        public KeyValues GetKeyStat(string keycode)
        {
            if (this.innerKeyStats_.Contains(keycode))
                return (KeyValues)this.innerKeyStats_[keycode];
            else
                return new KeyValues(0, 0);
        }

        public void AddOrRemoveKeyStats(string keycode, bool flag)
        {
            if (this.innerKeyStats_.Contains(keycode))
            {
                if (flag)
                {
                    ((KeyValues)this.innerKeyStats_[keycode]).CorrectPressCount += 1;
                    this.innerCorrectKeyPressedCount++;
                }
                else
                {
                    ((KeyValues)this.innerKeyStats_[keycode]).WrongPressCount += 1;
                    this.innerWrongKeyPressedCount++;
                }
            }
            else
            {
                if (flag)
                {
                    this.innerKeyStats_.Add(keycode, new KeyValues(1, 0));
                    this.innerCorrectKeyPressedCount++;
                }
                else
                {
                    this.innerKeyStats_.Add(keycode, new KeyValues(0, 1));
                    this.innerWrongKeyPressedCount++;
                }
            }
        }
    }

    [Serializable]
    public class KeyValues
    {
        private int correctPressCount_;
        private int wrongPressCount_;

        public KeyValues()
        {
            this.wrongPressCount_ = 0;
            this.correctPressCount_ = 0;
        }

        public KeyValues(int correct, int wrong)
        {
            this.wrongPressCount_ = wrong;
            this.correctPressCount_ = correct;
        }

        public int CorrectPressCount
        {
            get
            {
                return this.correctPressCount_;
            }
            set
            {
                this.correctPressCount_ = value;
            }
        }

        public int WrongPressCount
        {
            get
            {
                return this.wrongPressCount_;
            }
            set
            {
                this.wrongPressCount_ = value;
            }
        }
    }
}
