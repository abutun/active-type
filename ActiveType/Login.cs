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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ActiveType.Settings;

namespace ActiveType
{
    public partial class Login : Form
    {
        Settings.Messages innerMessages = new Messages();

        public Login()
        {
            InitializeComponent();

            // Load Users
            Utilities.SafeCheckDirectory(AppDomain.CurrentDomain.BaseDirectory + Constants.usersDirectory);
            Utilities.SafeCheckDirectory(AppDomain.CurrentDomain.BaseDirectory + Constants.settingsDirectory);

            Utilities.LoadUsers();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = this.Username.Text;
            string password = this.Password.Text;

            if (Utilities.Users.Contains(username, password))
            {
                // Load Sounds
                Settings.Utilities.LoadSounds();

                this.Hide();

                MainWindow mWindows = new MainWindow(username);
                mWindows.ShowDialog();

                this.Close();
            }
            else
                this.ErrorLabel.Text = this.innerMessages.GetLanguageString(7);
        }

        private void addNewUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddUser addUser = new AddUser();

            addUser.ShowDialog();
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {
            ClearErrorLabel();
        }

        private void ClearErrorLabel()
        {
            this.ErrorLabel.Text = "";
        }

        private void exitLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.Username.Focus();
        }
    }
}