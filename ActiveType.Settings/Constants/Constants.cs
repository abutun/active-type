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
using System.Collections;

namespace ActiveType.Settings
{
    public class Constants
    {
        // Default settings directory
        public const string settingsDirectory = "settings";

        // Default layouts directory
        public const string layoutsDirectory = "layouts";

        // Default users directory
        public const string usersDirectory = "users";

        // Security key(password) needed to encrypt/decrypt data
        public const string securityKey = "aBtreyPrtmNgdSeffaxz";

        // Default language setting for user 
        public static SettingPropery propLanguage = new SettingPropery("Language", "1"); //English

        // Default keyboard layout language setting for user 
        public static SettingPropery propKeyboardLayout = new SettingPropery("KeyboardLayout", new Keyboard("Türkçe","Türkçe-Q","TR", "Q"));

        // Default settings for application
        public static SettingPropery propPlaySounds = new SettingPropery("PlaySounds", true);

        // Default settings for application
        public static SettingPropery propCourseContentLength = new SettingPropery("CourseContentLength", "50");

        public static int currentLanguage = 1; //English

        public static long programLogFileLength = 1024 * 5; //5 MB
    }
}
