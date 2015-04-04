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

namespace ActiveType.FingerControlLibrary
{
    public enum FingerType
    {
        LeftSmall = 0,
        LeftRing = 1,
        LeftMiddle = 2,
        LeftIndex = 3,
        LeftThumb = 4,
        RightSmall = 5,
        RightRing = 6,
        RightMiddle = 7,
        RightIndex = 8,
        RightThumb = 9,
        None = 10
    }

    public enum HighlightMode
    {
        COLOR = 0,
        IMAGE = 1
    }
}
