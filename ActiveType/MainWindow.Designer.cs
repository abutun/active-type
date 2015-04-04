namespace ActiveType
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.mainStatus = new System.Windows.Forms.StatusStrip();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSessionAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lessonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settngsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSessionDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveSessionDialog = new System.Windows.Forms.SaveFileDialog();
            this.newSessonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTipStripExit = new System.Windows.Forms.ToolStripMenuItem();
            this.courseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.courseEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyResponseTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bilgisayarkorsanicomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainStatus
            // 
            this.mainStatus.Location = new System.Drawing.Point(0, 606);
            this.mainStatus.Name = "mainStatus";
            this.mainStatus.Size = new System.Drawing.Size(792, 22);
            this.mainStatus.TabIndex = 0;
            this.mainStatus.Text = "statusStrip1";
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.lessonToolStripMenuItem,
            this.settngsToolStripMenuItem,
            this.statisticsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(792, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSessonToolStripMenuItem,
            this.openSesionToolStripMenuItem,
            this.saveSessionToolStripMenuItem,
            this.saveSessionAsToolStripMenuItem,
            this.closeSessionToolStripMenuItem,
            this.toolTipStripExit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(35, 20);
            this.menuItemFile.Text = "&File";
            // 
            // saveSessionAsToolStripMenuItem
            // 
            this.saveSessionAsToolStripMenuItem.Enabled = false;
            this.saveSessionAsToolStripMenuItem.Name = "saveSessionAsToolStripMenuItem";
            this.saveSessionAsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.saveSessionAsToolStripMenuItem.Text = "Save Session As..";
            this.saveSessionAsToolStripMenuItem.Click += new System.EventHandler(this.saveSessionAsToolStripMenuItem_Click);
            // 
            // closeSessionToolStripMenuItem
            // 
            this.closeSessionToolStripMenuItem.Enabled = false;
            this.closeSessionToolStripMenuItem.Name = "closeSessionToolStripMenuItem";
            this.closeSessionToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.closeSessionToolStripMenuItem.Text = "Close Session";
            this.closeSessionToolStripMenuItem.Click += new System.EventHandler(this.closeSessionToolStripMenuItem_Click);
            // 
            // lessonToolStripMenuItem
            // 
            this.lessonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.courseToolStripMenuItem,
            this.courseEditorToolStripMenuItem});
            this.lessonToolStripMenuItem.Name = "lessonToolStripMenuItem";
            this.lessonToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.lessonToolStripMenuItem.Text = "&Courses";
            // 
            // settngsToolStripMenuItem
            // 
            this.settngsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem});
            this.settngsToolStripMenuItem.Name = "settngsToolStripMenuItem";
            this.settngsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.settngsToolStripMenuItem.Text = "&Settings";
            // 
            // statisticsToolStripMenuItem
            // 
            this.statisticsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keyResponseTimeToolStripMenuItem});
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.statisticsToolStripMenuItem.Text = "S&tatistics";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1,
            this.bilgisayarkorsanicomToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // openSessionDialog
            // 
            this.openSessionDialog.Filter = "ActiveType Session Files (*.ses) | *.ses";
            // 
            // saveSessionDialog
            // 
            this.saveSessionDialog.Filter = "ActiveType Session Files (*.ses) | *.ses";
            // 
            // newSessonToolStripMenuItem
            // 
            this.newSessonToolStripMenuItem.Image = global::ActiveType.Properties.Resources.description;
            this.newSessonToolStripMenuItem.Name = "newSessonToolStripMenuItem";
            this.newSessonToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newSessonToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.newSessonToolStripMenuItem.Text = "New Session";
            this.newSessonToolStripMenuItem.Click += new System.EventHandler(this.newSessonToolStripMenuItem_Click);
            // 
            // openSesionToolStripMenuItem
            // 
            this.openSesionToolStripMenuItem.Image = global::ActiveType.Properties.Resources.explorer;
            this.openSesionToolStripMenuItem.Name = "openSesionToolStripMenuItem";
            this.openSesionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openSesionToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.openSesionToolStripMenuItem.Text = "Open Session";
            this.openSesionToolStripMenuItem.Click += new System.EventHandler(this.openSesionToolStripMenuItem_Click);
            // 
            // saveSessionToolStripMenuItem
            // 
            this.saveSessionToolStripMenuItem.Enabled = false;
            this.saveSessionToolStripMenuItem.Image = global::ActiveType.Properties.Resources.a_driver;
            this.saveSessionToolStripMenuItem.Name = "saveSessionToolStripMenuItem";
            this.saveSessionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveSessionToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.saveSessionToolStripMenuItem.Text = "Save Session";
            this.saveSessionToolStripMenuItem.Click += new System.EventHandler(this.saveSessionToolStripMenuItem_Click);
            // 
            // toolTipStripExit
            // 
            this.toolTipStripExit.Image = global::ActiveType.Properties.Resources.alert;
            this.toolTipStripExit.Name = "toolTipStripExit";
            this.toolTipStripExit.Size = new System.Drawing.Size(190, 22);
            this.toolTipStripExit.Text = "Exit";
            this.toolTipStripExit.Click += new System.EventHandler(this.toolTipStripExit_Click);
            // 
            // courseToolStripMenuItem
            // 
            this.courseToolStripMenuItem.Image = global::ActiveType.Properties.Resources.calendar;
            this.courseToolStripMenuItem.Name = "courseToolStripMenuItem";
            this.courseToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.courseToolStripMenuItem.Text = "Courses";
            // 
            // courseEditorToolStripMenuItem
            // 
            this.courseEditorToolStripMenuItem.Image = global::ActiveType.Properties.Resources.config_file_viewer;
            this.courseEditorToolStripMenuItem.Name = "courseEditorToolStripMenuItem";
            this.courseEditorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                        | System.Windows.Forms.Keys.E)));
            this.courseEditorToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.courseEditorToolStripMenuItem.Text = "Course Editor";
            this.courseEditorToolStripMenuItem.Click += new System.EventHandler(this.courseEditorToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Image = global::ActiveType.Properties.Resources.process_monitor;
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // keyResponseTimeToolStripMenuItem
            // 
            this.keyResponseTimeToolStripMenuItem.Image = global::ActiveType.Properties.Resources.graph;
            this.keyResponseTimeToolStripMenuItem.Name = "keyResponseTimeToolStripMenuItem";
            this.keyResponseTimeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.keyResponseTimeToolStripMenuItem.Text = "Overall Stats";
            this.keyResponseTimeToolStripMenuItem.Click += new System.EventHandler(this.keyResponseTimeToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Image = global::ActiveType.Properties.Resources.host_detail;
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(163, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // bilgisayarkorsanicomToolStripMenuItem
            // 
            this.bilgisayarkorsanicomToolStripMenuItem.Image = global::ActiveType.Properties.Resources.ie;
            this.bilgisayarkorsanicomToolStripMenuItem.Name = "bilgisayarkorsanicomToolStripMenuItem";
            this.bilgisayarkorsanicomToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.bilgisayarkorsanicomToolStripMenuItem.Text = "ahmetbutun.net";
            this.bilgisayarkorsanicomToolStripMenuItem.Click += new System.EventHandler(this.bilgisayarkorsanicomToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.AutoSize = false;
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton5.Text = "toolStripButton5";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.AutoSize = false;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 628);
            this.Controls.Add(this.mainStatus);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainWindow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip mainStatus;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolTipStripExit;
        private System.Windows.Forms.ToolStripMenuItem newSessonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lessonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settngsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem courseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyResponseTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripMenuItem saveSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bilgisayarkorsanicomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem courseEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSessionAsToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openSessionDialog;
        private System.Windows.Forms.SaveFileDialog saveSessionDialog;
        private System.Windows.Forms.ToolStripMenuItem closeSessionToolStripMenuItem;
    }
}

