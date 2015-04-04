namespace ActiveType
{
    partial class AppSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppSettings));
            this.settingsPanel = new PureComponents.NicePanel.NicePanel();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.currentLanguageCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.keybaordLayoutCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.settingsPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsPanel
            // 
            this.settingsPanel.BackColor = System.Drawing.Color.Transparent;
            this.settingsPanel.CloseButton = true;
            this.settingsPanel.CollapseButton = false;
            containerImage1.Alignment = System.Drawing.ContentAlignment.BottomRight;
            containerImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None;
            containerImage1.Image = null;
            containerImage1.Size = PureComponents.NicePanel.ContainerImageSize.Small;
            containerImage1.Transparency = 50;
            this.settingsPanel.ContainerImage = containerImage1;
            this.settingsPanel.ContextMenuButton = false;
            this.settingsPanel.Controls.Add(this.groupBox1);
            this.settingsPanel.Controls.Add(this.groupBox2);
            this.settingsPanel.Controls.Add(this.okButton);
            this.settingsPanel.Controls.Add(this.cancelButton);
            this.settingsPanel.Controls.Add(this.applyButton);
            headerImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None;
            headerImage1.Image = null;
            this.settingsPanel.FooterImage = headerImage1;
            this.settingsPanel.FooterText = "Settings";
            this.settingsPanel.ForeColor = System.Drawing.Color.Black;
            headerImage2.ClipArt = PureComponents.NicePanel.ImageClipArt.ControlPanel;
            headerImage2.Image = null;
            this.settingsPanel.HeaderImage = headerImage2;
            this.settingsPanel.HeaderText = "ActiveType - Settings";
            this.settingsPanel.IsExpanded = true;
            this.settingsPanel.Location = new System.Drawing.Point(0, 0);
            this.settingsPanel.MinimizeButton = true;
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.OriginalFooterVisible = true;
            this.settingsPanel.OriginalHeight = 0;
            this.settingsPanel.Resizable = false;
            this.settingsPanel.Size = new System.Drawing.Size(269, 273);
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
            this.settingsPanel.Style = panelStyle1;
            this.settingsPanel.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(174, 216);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(93, 216);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(12, 216);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // currentLanguageCombo
            // 
            this.currentLanguageCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.currentLanguageCombo.FormattingEnabled = true;
            this.currentLanguageCombo.Items.AddRange(new object[] {
            "English",
            "Türkçe"});
            this.currentLanguageCombo.Location = new System.Drawing.Point(69, 28);
            this.currentLanguageCombo.Name = "currentLanguageCombo";
            this.currentLanguageCombo.Size = new System.Drawing.Size(162, 21);
            this.currentLanguageCombo.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Language";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.currentLanguageCombo);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 66);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "";
            this.groupBox2.Text = "Language";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.keybaordLayoutCombo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 66);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Keyboard";
            // 
            // keybaordLayoutCombo
            // 
            this.keybaordLayoutCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keybaordLayoutCombo.FormattingEnabled = true;
            this.keybaordLayoutCombo.Items.AddRange(new object[] {
            "English",
            "Türkçe - Q",
            "Türkçe - F"});
            this.keybaordLayoutCombo.Location = new System.Drawing.Point(67, 28);
            this.keybaordLayoutCombo.Name = "keybaordLayoutCombo";
            this.keybaordLayoutCombo.Size = new System.Drawing.Size(164, 21);
            this.keybaordLayoutCombo.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Layout";
            // 
            // AppSettings
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(269, 273);
            this.Controls.Add(this.settingsPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AppSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.AppSettings_Load);
            this.settingsPanel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PureComponents.NicePanel.NicePanel settingsPanel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox keybaordLayoutCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox currentLanguageCombo;
        private System.Windows.Forms.Label label1;
    }
}