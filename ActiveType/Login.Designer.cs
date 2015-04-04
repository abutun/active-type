namespace ActiveType
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PureComponents.NicePanel.ContainerImage containerImage1 = new PureComponents.NicePanel.ContainerImage();
            PureComponents.NicePanel.HeaderImage headerImage1 = new PureComponents.NicePanel.HeaderImage();
            PureComponents.NicePanel.HeaderImage headerImage2 = new PureComponents.NicePanel.HeaderImage();
            PureComponents.NicePanel.PanelStyle panelStyle1 = new PureComponents.NicePanel.PanelStyle();
            PureComponents.NicePanel.ContainerStyle containerStyle1 = new PureComponents.NicePanel.ContainerStyle();
            PureComponents.NicePanel.PanelHeaderStyle panelHeaderStyle1 = new PureComponents.NicePanel.PanelHeaderStyle();
            PureComponents.NicePanel.PanelHeaderStyle panelHeaderStyle2 = new PureComponents.NicePanel.PanelHeaderStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.loginButton = new System.Windows.Forms.Button();
            this.Username = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.addNewUser = new System.Windows.Forms.LinkLabel();
            this.nicePanel1 = new PureComponents.NicePanel.NicePanel();
            this.exitLink = new System.Windows.Forms.LinkLabel();
            this.nicePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(150, 103);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(125, 45);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(100, 20);
            this.Username.TabIndex = 1;
            this.Username.Tag = "|||Your username";
            this.Username.TextChanged += new System.EventHandler(this.Username_TextChanged);
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(125, 71);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(100, 20);
            this.Password.TabIndex = 2;
            this.Password.Tag = "|||Your password";
            this.Password.TextChanged += new System.EventHandler(this.Username_TextChanged);
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Location = new System.Drawing.Point(50, 48);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(55, 13);
            this.UserNameLabel.TabIndex = 3;
            this.UserNameLabel.Text = "Username";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(50, 74);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Tag = "|||";
            this.PasswordLabel.Text = "Password";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(122, 140);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(0, 13);
            this.ErrorLabel.TabIndex = 5;
            // 
            // addNewUser
            // 
            this.addNewUser.AutoSize = true;
            this.addNewUser.Location = new System.Drawing.Point(44, 209);
            this.addNewUser.Name = "addNewUser";
            this.addNewUser.Size = new System.Drawing.Size(76, 13);
            this.addNewUser.TabIndex = 4;
            this.addNewUser.TabStop = true;
            this.addNewUser.Tag = "|||Click here to add a new user";
            this.addNewUser.Text = "Add New User";
            this.addNewUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.addNewUser_LinkClicked);
            // 
            // nicePanel1
            // 
            this.nicePanel1.BackColor = System.Drawing.Color.Transparent;
            this.nicePanel1.CloseButton = true;
            this.nicePanel1.CollapseButton = false;
            containerImage1.Alignment = System.Drawing.ContentAlignment.BottomRight;
            containerImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.Login;
            containerImage1.Image = null;
            containerImage1.Size = PureComponents.NicePanel.ContainerImageSize.Small;
            containerImage1.Transparency = 50;
            this.nicePanel1.ContainerImage = containerImage1;
            this.nicePanel1.ContextMenuButton = false;
            this.nicePanel1.Controls.Add(this.exitLink);
            this.nicePanel1.Controls.Add(this.UserNameLabel);
            this.nicePanel1.Controls.Add(this.ErrorLabel);
            this.nicePanel1.Controls.Add(this.Password);
            this.nicePanel1.Controls.Add(this.addNewUser);
            this.nicePanel1.Controls.Add(this.PasswordLabel);
            this.nicePanel1.Controls.Add(this.loginButton);
            this.nicePanel1.Controls.Add(this.Username);
            headerImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None;
            headerImage1.Image = null;
            this.nicePanel1.FooterImage = headerImage1;
            this.nicePanel1.FooterText = "Login";
            this.nicePanel1.ForeColor = System.Drawing.Color.Black;
            headerImage2.ClipArt = PureComponents.NicePanel.ImageClipArt.Login;
            headerImage2.Image = null;
            this.nicePanel1.HeaderImage = headerImage2;
            this.nicePanel1.HeaderText = "ActiveType - Login";
            this.nicePanel1.IsExpanded = true;
            this.nicePanel1.Location = new System.Drawing.Point(0, 0);
            this.nicePanel1.MouseMoveTarget = PureComponents.NicePanel.MouseMoveTarget.Form;
            this.nicePanel1.Name = "nicePanel1";
            this.nicePanel1.OriginalFooterVisible = true;
            this.nicePanel1.OriginalHeight = 0;
            this.nicePanel1.Resizable = false;
            this.nicePanel1.Size = new System.Drawing.Size(292, 250);
            containerStyle1.BackColor = System.Drawing.Color.LightCyan;
            containerStyle1.BaseColor = System.Drawing.Color.Transparent;
            containerStyle1.BorderColor = System.Drawing.Color.RoyalBlue;
            containerStyle1.BorderStyle = PureComponents.NicePanel.BorderStyle.Double;
            containerStyle1.CaptionAlign = PureComponents.NicePanel.CaptionAlign.Left;
            containerStyle1.FadeColor = System.Drawing.Color.LightSteelBlue;
            containerStyle1.FillStyle = PureComponents.NicePanel.FillStyle.DiagonalForward;
            containerStyle1.FlashItemBackColor = System.Drawing.Color.Red;
            containerStyle1.FocusItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            containerStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            containerStyle1.ForeColor = System.Drawing.Color.Black;
            containerStyle1.Shape = PureComponents.NicePanel.Shape.Squared;
            panelStyle1.ContainerStyle = containerStyle1;
            panelHeaderStyle1.BackColor = System.Drawing.Color.RoyalBlue;
            panelHeaderStyle1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            panelHeaderStyle1.FadeColor = System.Drawing.Color.SkyBlue;
            panelHeaderStyle1.FillStyle = PureComponents.NicePanel.FillStyle.HorizontalFading;
            panelHeaderStyle1.FlashBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(122)))), ((int)(((byte)(1)))));
            panelHeaderStyle1.FlashFadeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(159)))));
            panelHeaderStyle1.FlashForeColor = System.Drawing.Color.White;
            panelHeaderStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            panelHeaderStyle1.ForeColor = System.Drawing.Color.PowderBlue;
            panelHeaderStyle1.Size = PureComponents.NicePanel.PanelHeaderSize.Small;
            panelStyle1.FooterStyle = panelHeaderStyle1;
            panelHeaderStyle2.BackColor = System.Drawing.Color.DeepSkyBlue;
            panelHeaderStyle2.ButtonColor = System.Drawing.Color.PowderBlue;
            panelHeaderStyle2.FadeColor = System.Drawing.Color.MediumBlue;
            panelHeaderStyle2.FillStyle = PureComponents.NicePanel.FillStyle.VerticalFading;
            panelHeaderStyle2.FlashBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(122)))), ((int)(((byte)(1)))));
            panelHeaderStyle2.FlashFadeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(159)))));
            panelHeaderStyle2.FlashForeColor = System.Drawing.Color.White;
            panelHeaderStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            panelHeaderStyle2.ForeColor = System.Drawing.Color.PaleTurquoise;
            panelHeaderStyle2.Size = PureComponents.NicePanel.PanelHeaderSize.Medium;
            panelStyle1.HeaderStyle = panelHeaderStyle2;
            this.nicePanel1.Style = panelStyle1;
            this.nicePanel1.TabIndex = 6;
            // 
            // exitLink
            // 
            this.exitLink.AutoSize = true;
            this.exitLink.Location = new System.Drawing.Point(12, 209);
            this.exitLink.Name = "exitLink";
            this.exitLink.Size = new System.Drawing.Size(24, 13);
            this.exitLink.TabIndex = 6;
            this.exitLink.TabStop = true;
            this.exitLink.Tag = "|||Click to exit";
            this.exitLink.Text = "Exit";
            this.exitLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.exitLink_LinkClicked);
            // 
            // Login
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exitLink;
            this.ClientSize = new System.Drawing.Size(292, 250);
            this.Controls.Add(this.nicePanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.nicePanel1.ResumeLayout(false);
            this.nicePanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.LinkLabel addNewUser;
        private PureComponents.NicePanel.NicePanel nicePanel1;
        private System.Windows.Forms.LinkLabel exitLink;
    }
}