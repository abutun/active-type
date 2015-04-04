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
using System.Windows.Forms;

namespace ActiveType.Settings
{
    public class Messages
    {
        public Messages()
        {
            string currentLanguage = "";

            try
            {
                currentLanguage = (string)Utilities.Settings[Constants.propLanguage];

                /*
                if (currentLanguage != "")
                    this.innerLanguage = currentLanguage;
                else
                    ExceptionUtilities.ShowException(new Exception(this.GetLanguageString(1)), MessageBoxButtons.OK);
                 */
            }
            catch
            {
                // ExceptionUtilities.ShowException(new Exception(this.GetLanguageString(1)), MessageBoxButtons.OK);
            }
        }

        public string GetLanguageString(int stringNo)
        {
            string res = "#" + stringNo.ToString();

            switch (Constants.currentLanguage)
            {
                case 1:
                    {
                        switch (stringNo)
                        {
                            case 1 :
                                res = "Hata : 0x00000001 \nAçýklama : Dil yüklenemiyor!";
                                break;
                            case 2 :
                                res = "Hata : 0x00000002 \nAçýklama : Klavye þemasý yüklenemiyor!";
                                break;
                            case 3 :
                                res = "Hata : 0x00000003 \nAçýklama : Sisteme tanýtýlmýþ klavye þemasý bulunamadý!";
                                break;
                            case 4 :
                                res = "Hata : 0x00000004 \nAçýklama : Klavye þemasý yüklenemiyor!";
                                break;
                            case 5 :
                                res = "Hata : 0x00000005 \nAçýklama : Klavye þemasý herhangi bir tanýmlama içermiyor!";
                                break;
                            case 6 :
                                res = "Hata : 0x00000006 \nAçýklama : Sisteme tanýtýlmýþ klavye þemasý bulunamadý!";
                                break;
                            case 7:
                                res = "Geçersiz kullanýcý adý yada þifre";
                                break;
                            case 8:
                                res = "Hata : 0x00000008 \nAçýklama : Veri þifrelenirken hata oluþtu!";
                                break;
                        }
                    }
                    break;

                case 0:
                    {
                        switch (stringNo)
                        {
                            case 1 :
                                res = "Error : 0x00000001 \nDescription : Language cannot be loaded!";
                                break;
                            case 2 :
                                res = "Error : 0x00000002 \nDescription : Cannot load keyboard layout!";
                                break;
                            case 3 :
                                res = "Error : 0x00000003 \nDescription : Keyboard layout not present!";
                                break;
                            case 4 :
                                res = "Error : 0x00000004 \nDescription : Keyboard layout could not be loaded!";
                                break;
                            case 5 :
                                res = "Error : 0x00000005 \nDescription : Keyboard layout does not contain any key definition!";
                                break;
                            case 6 :
                                res = "Error : 0x00000006 \nDescription : Keyboard layout not present!";
                                break;
                            case 7 :
                                res = "Invalid username or password";
                                break;
                            case 8:
                                res = "Error : 0x00000008 \nDescription : Error occured while securing data!";
                                break;
                        }
                    }
                    break;
            }

            return res;
        }
    }
}
