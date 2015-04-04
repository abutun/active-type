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

namespace ActiveType.Settings
{
    public enum UserType
    {
        Administrator = 0,
        User = 1
    }

    public enum PersonType
    {
        Teacher = 0,
        Student = 1
    }

    public enum KeyboardScheme
    {
        BLUE = 1,
        RED = 2,
        GRAY = 3,
        CUSTOM = 4
    }

    public enum CourseStatus
    {
        NONE = 0,
        LOADED = 1,
        UPDATED = 2,
        SAVED = 3,
        DELETED = 4
    }

    public enum SessionStatus
    {
        NONE = 0,
        LOADED = 1,
        UNLOADED = 2,
        UPDATED = 3,
        SAVED = 4,
        DELETED = 5
    }

    public enum Languages
    {
        ENGLISH = 0,
        TURKISH
    }
 }
