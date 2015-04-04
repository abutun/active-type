namespace ActiveType
{
    partial class CourseEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CourseEditor));
            this.editorPanel = new PureComponents.NicePanel.NicePanel();
            this.mainGroupBox = new System.Windows.Forms.GroupBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.addCategory = new System.Windows.Forms.Button();
            this.categoryName = new System.Windows.Forms.TextBox();
            this.courseLevelCombo = new System.Windows.Forms.ComboBox();
            this.newButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.courseName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.courseTreeView = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.courseContent = new System.Windows.Forms.TextBox();
            this.editorPanel.SuspendLayout();
            this.mainGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // editorPanel
            // 
            this.editorPanel.BackColor = System.Drawing.Color.Transparent;
            this.editorPanel.CloseButton = true;
            this.editorPanel.CollapseButton = false;
            containerImage1.Alignment = System.Drawing.ContentAlignment.BottomRight;
            containerImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None;
            containerImage1.Image = null;
            containerImage1.Size = PureComponents.NicePanel.ContainerImageSize.Small;
            containerImage1.Transparency = 50;
            this.editorPanel.ContainerImage = containerImage1;
            this.editorPanel.ContextMenuButton = false;
            this.editorPanel.Controls.Add(this.mainGroupBox);
            headerImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None;
            headerImage1.Image = null;
            this.editorPanel.FooterImage = headerImage1;
            this.editorPanel.FooterText = "";
            this.editorPanel.ForeColor = System.Drawing.Color.Black;
            headerImage2.ClipArt = PureComponents.NicePanel.ImageClipArt.ControlPanel;
            headerImage2.Image = null;
            this.editorPanel.HeaderImage = headerImage2;
            this.editorPanel.HeaderText = "ActiveType - Course Editor";
            this.editorPanel.IsExpanded = true;
            this.editorPanel.Location = new System.Drawing.Point(0, 0);
            this.editorPanel.MinimizeButton = true;
            this.editorPanel.Name = "editorPanel";
            this.editorPanel.OriginalFooterVisible = true;
            this.editorPanel.OriginalHeight = 0;
            this.editorPanel.Resizable = false;
            this.editorPanel.Size = new System.Drawing.Size(800, 524);
            containerStyle1.BackColor = System.Drawing.Color.LightCyan;
            containerStyle1.BaseColor = System.Drawing.Color.Transparent;
            containerStyle1.BorderColor = System.Drawing.Color.RoyalBlue;
            containerStyle1.BorderStyle = PureComponents.NicePanel.BorderStyle.Solid;
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
            this.editorPanel.Style = panelStyle1;
            this.editorPanel.TabIndex = 0;
            // 
            // mainGroupBox
            // 
            this.mainGroupBox.Controls.Add(this.statusLabel);
            this.mainGroupBox.Controls.Add(this.addCategory);
            this.mainGroupBox.Controls.Add(this.categoryName);
            this.mainGroupBox.Controls.Add(this.courseLevelCombo);
            this.mainGroupBox.Controls.Add(this.newButton);
            this.mainGroupBox.Controls.Add(this.downButton);
            this.mainGroupBox.Controls.Add(this.upButton);
            this.mainGroupBox.Controls.Add(this.refreshButton);
            this.mainGroupBox.Controls.Add(this.deleteButton);
            this.mainGroupBox.Controls.Add(this.saveButton);
            this.mainGroupBox.Controls.Add(this.label4);
            this.mainGroupBox.Controls.Add(this.label3);
            this.mainGroupBox.Controls.Add(this.courseName);
            this.mainGroupBox.Controls.Add(this.label2);
            this.mainGroupBox.Controls.Add(this.courseTreeView);
            this.mainGroupBox.Controls.Add(this.label1);
            this.mainGroupBox.Controls.Add(this.cancelButton);
            this.mainGroupBox.Controls.Add(this.courseContent);
            this.mainGroupBox.Location = new System.Drawing.Point(10, 38);
            this.mainGroupBox.Name = "mainGroupBox";
            this.mainGroupBox.Size = new System.Drawing.Size(779, 456);
            this.mainGroupBox.TabIndex = 6;
            this.mainGroupBox.TabStop = false;
            this.mainGroupBox.Text = "Course Editor";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(6, 28);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 13);
            this.statusLabel.TabIndex = 25;
            // 
            // addCategory
            // 
            this.addCategory.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.addCategory.Location = new System.Drawing.Point(152, 427);
            this.addCategory.Name = "addCategory";
            this.addCategory.Size = new System.Drawing.Size(75, 23);
            this.addCategory.TabIndex = 24;
            this.addCategory.Text = "Add";
            this.addCategory.UseVisualStyleBackColor = true;
            this.addCategory.Click += new System.EventHandler(this.addCategory_Click);
            // 
            // categoryName
            // 
            this.categoryName.Location = new System.Drawing.Point(6, 429);
            this.categoryName.Name = "categoryName";
            this.categoryName.Size = new System.Drawing.Size(140, 20);
            this.categoryName.TabIndex = 23;
            this.categoryName.TextChanged += new System.EventHandler(this.categoryName_TextChanged);
            // 
            // courseLevelCombo
            // 
            this.courseLevelCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.courseLevelCombo.FormattingEnabled = true;
            this.courseLevelCombo.Location = new System.Drawing.Point(673, 24);
            this.courseLevelCombo.Name = "courseLevelCombo";
            this.courseLevelCombo.Size = new System.Drawing.Size(100, 21);
            this.courseLevelCombo.TabIndex = 22;
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(364, 427);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 23);
            this.newButton.TabIndex = 21;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // downButton
            // 
            this.downButton.Location = new System.Drawing.Point(233, 223);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(44, 23);
            this.downButton.TabIndex = 20;
            this.downButton.Text = "Down";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // upButton
            // 
            this.upButton.Location = new System.Drawing.Point(233, 194);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(44, 23);
            this.upButton.TabIndex = 19;
            this.upButton.Text = "Up";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(283, 427);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 17;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(617, 424);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 16;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(536, 424);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 15;
            this.saveButton.Text = "Add";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(587, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Course Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(587, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Course Level";
            // 
            // courseName
            // 
            this.courseName.Location = new System.Drawing.Point(673, 51);
            this.courseName.Name = "courseName";
            this.courseName.Size = new System.Drawing.Size(100, 20);
            this.courseName.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Course Tree";
            // 
            // courseTreeView
            // 
            this.courseTreeView.Location = new System.Drawing.Point(6, 77);
            this.courseTreeView.Name = "courseTreeView";
            this.courseTreeView.Size = new System.Drawing.Size(221, 341);
            this.courseTreeView.TabIndex = 9;
            this.courseTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.courseTreeView_NodeMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Course Content";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(698, 424);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Close";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // courseContent
            // 
            this.courseContent.Location = new System.Drawing.Point(283, 77);
            this.courseContent.Multiline = true;
            this.courseContent.Name = "courseContent";
            this.courseContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.courseContent.Size = new System.Drawing.Size(490, 341);
            this.courseContent.TabIndex = 7;
            // 
            // CourseEditor
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(800, 524);
            this.Controls.Add(this.editorPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CourseEditor";
            this.Text = "Course Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CourseEditor_FormClosed);
            this.Load += new System.EventHandler(this.CourseEditor_Load);
            this.editorPanel.ResumeLayout(false);
            this.mainGroupBox.ResumeLayout(false);
            this.mainGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PureComponents.NicePanel.NicePanel editorPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox mainGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox courseContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView courseTreeView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox courseName;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.ComboBox courseLevelCombo;
        private System.Windows.Forms.Button addCategory;
        private System.Windows.Forms.TextBox categoryName;
        private System.Windows.Forms.Label statusLabel;
    }
}