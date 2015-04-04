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
    public class User
    {
        private string username_;
        private string password_;
        private string firstName_;
        private string lastName_;

        private DateTime createDate_;
        private DateTime lastLogin_;
        private DateTime lastLogout_;

        private UserType userType_;
        private PersonType personType_;

        private UserRights userRights_ = new UserRights();

        private StatisticsCollection innerStats_ = new StatisticsCollection();

        public User()
        {
            this.createDate_ = DateTime.Now;
        }

        public User(String firstname, string lastname, string username, string password) : this(firstname, lastname, username, password, UserType.User, PersonType.Student) { }

        public User(String firstname, string lastname, string username, string password, UserType userType) : this(firstname, lastname, username, password, userType, PersonType.Student) { }

        public User(String firstname, string lastname, string username, string password, UserType userType, PersonType personType)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Username = username;
            this.Password = password;

            this.UserType = userType;
            this.PersonType = personType;

            this.createDate_ = DateTime.Now;
        }

        public string Username
        {
            get
            {
                // decrypt username
                return Security.UnMaskInformation(this.username_);
            }
            set
            {
                // encrypt username
                this.username_ = Security.MaskInformation(value);
            }
        }

        public string Password
        {
            get
            {
                // decrypt password
                return Security.UnMaskInformation(this.password_);
            }
            set
            {
                // encrypt password
                this.password_ = Security.MaskInformation(value);
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return this.createDate_;
            }
        }

        public DateTime LastLogin
        {
            get
            {
                return this.lastLogin_;
            }
        }

        public DateTime LastLogout
        {
            get
            {
                return this.lastLogout_;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName_;
            }
            set
            {
                this.firstName_ = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName_;
            }
            set
            {
                this.lastName_ = value;
            }
        }

        public UserType UserType
        {
            get
            {
                return this.userType_;
            }
            set
            {
                this.userType_ = value;
            }
        }

        public PersonType PersonType
        {
            get
            {
                return this.personType_;
            }
            set
            {
                this.personType_ = value;
            }
        }

        public UserRights Rights
        {
            get
            {
                return this.userRights_;
            }
        }

        public StatisticsCollection Statistics
        {
            get
            {
                return this.innerStats_;
            }
        }

        public void Login()
        {
            this.lastLogin_ = DateTime.Now;
        }

        public void Logout()
        {
            this.lastLogout_ = DateTime.Now;
        }
    }

    [Serializable]
    public class UserRights
    {
        private bool canEditLessons_ = false;

        public UserRights()
        {
        }

        public bool CanEditLessons
        {
            get
            {
                return this.canEditLessons_;
            }
            set
            {
                canEditLessons_ = value;
            }
        }
    }
}
