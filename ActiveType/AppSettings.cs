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
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ActiveType.Settings;

namespace ActiveType
{
    public partial class AppSettings : Form
    {
        public AppSettings()
        {
            InitializeComponent();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            ApplySettings();

            applyButton.Enabled = false;
        }

        private void ApplySettings()
        {
            // LANGUAGE
            if (Utilities.Settings.Contains(Constants.propLanguage))
                Utilities.Settings[Constants.propLanguage] = currentLanguageCombo.SelectedIndex;
            else
                Utilities.Settings.Add(Constants.propLanguage);

            // KEYBOARD LAYOUT
            if (Utilities.Settings.Contains(Constants.propKeyboardLayout))
            {
                switch (this.keybaordLayoutCombo.SelectedIndex)
                {
                    case 0:
                        Utilities.Settings[Constants.propKeyboardLayout] = new Keyboard("English", "English US International", "EN", "");
                        break;

                    case 1:
                        Utilities.Settings[Constants.propKeyboardLayout] = new Keyboard("Türkçe","Türkçe-Q","TR", "Q");
                        break;

                    default:
                        Utilities.Settings[Constants.propKeyboardLayout] = new Keyboard("Türkçe", "Türkçe-F", "TR", "F");
                        break;
                }
            }
            else
                Utilities.Settings.Add(Constants.propKeyboardLayout);

            // save settings
            Utilities.SaveSettings(Utilities.CurentUser);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult res = DialogResult.Cancel;

            bool needRestart = false;

            if (Constants.currentLanguage != currentLanguageCombo.SelectedIndex)
                needRestart = true;

            ApplySettings();

            this.DialogResult = DialogResult.OK;

            if (needRestart)
            {
                if (Constants.currentLanguage == 1)
                {
                    // STRING LITERAL
                    res = MessageBox.Show("Deðiþikliklerin yansýtýlmasý için ActiveType yeniden baþlatýlmalý.\nActiveType þimdi yeniden baþlatýlsýn mý?", "ActiveType", MessageBoxButtons.OKCancel);
                }
                else
                {
                    // STRING LITERAL
                    res = MessageBox.Show("ActiveType must be restarted in order to changes take effect.\nWould you like to restart ActiveType now?", "ActiveType", MessageBoxButtons.OKCancel);
                }
            }

            if (res == DialogResult.OK)
                Application.Restart();
            else
                this.Close();
        }

        private void AppSettings_Load(object sender, EventArgs e)
        {
            this.currentLanguageCombo.SelectedIndex = Constants.currentLanguage;

            Keyboard keyboardLayout = (Keyboard)Utilities.Settings[Constants.propKeyboardLayout];

            switch (keyboardLayout.Code)
            {
                case "TR":
                    {
                        if (keyboardLayout.KeyboardType == "Q")
                            this.keybaordLayoutCombo.SelectedIndex = 1;
                        else
                            this.keybaordLayoutCombo.SelectedIndex = 2;
                    }
                    break;

                case "EN":
                    this.keybaordLayoutCombo.SelectedIndex = 0;
                    break;

                default :
                    this.keybaordLayoutCombo.SelectedIndex = 1;
                    break;
            }

        }
    }
}