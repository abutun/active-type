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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (this.firstName.Text != "" && this.lastName.Text != "" && this.username.Text != "")
            {
                if (this.password1.Text != "" && this.password2.Text != "")
                {
                    if (this.password1.Text == this.password2.Text)
                    {
                        User newUser = new User(this.firstName.Text, this.lastName.Text, this.username.Text, this.password1.Text);

                        newUser.Rights.CanEditLessons = this.canEditLessons.Checked;

                        // Add it to the users collection
                        if (!Utilities.Users.Contains(this.username.Text))
                        {
                            Utilities.Users.Add(newUser);

                            Utilities.SaveCurrentUsers();

                            Utilities.LoadUsers();

                            this.DialogResult = DialogResult.OK;

                            ActiveType.Settings.Log.AddtoLogFile("New user added sucessfully - " + this.username.Text);
                        }
                        else
                        {
                            // STRING LITERAL //
                            this.statusLabel.Text = "This user alreadys exists!";
                            ActiveType.Settings.Log.AddtoLogFile("This user alreadys exists! - " + this.username.Text);
                        }
                    }
                    else
                    {
                        // STRING LITERAL //
                        this.statusLabel.Text = "Your passwords do not match!";
                    }
                }
                else
                {
                    // STRING LITERAL //
                    this.statusLabel.Text = "Please enter your password!";
                }
            }
            else
            {
                // STRING LITERAL //
                this.statusLabel.Text = "Please enter all the information above!";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            this.statusLabel.Text = "";
        }
    }
}