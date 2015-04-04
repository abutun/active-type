namespace ActiveType.CustomControls
{
    partial class KeyStatsPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lowerCasePanel = new System.Windows.Forms.Panel();
            this.lowerCasePanelButton = new System.Windows.Forms.Button();
            this.upperCasePanelButton = new System.Windows.Forms.Button();
            this.symbolsPanelButton = new System.Windows.Forms.Button();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.symbolsPanel = new System.Windows.Forms.Panel();
            this.upperCasePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lowerCasePanel
            // 
            this.lowerCasePanel.Location = new System.Drawing.Point(0, 0);
            this.lowerCasePanel.Name = "lowerCasePanel";
            this.lowerCasePanel.Size = new System.Drawing.Size(700, 250);
            this.lowerCasePanel.TabIndex = 0;
            // 
            // lowerCasePanelButton
            // 
            this.lowerCasePanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lowerCasePanelButton.Location = new System.Drawing.Point(27, 290);
            this.lowerCasePanelButton.Name = "lowerCasePanelButton";
            this.lowerCasePanelButton.Size = new System.Drawing.Size(75, 23);
            this.lowerCasePanelButton.TabIndex = 1;
            this.lowerCasePanelButton.Text = "LowerCase";
            this.lowerCasePanelButton.UseVisualStyleBackColor = true;
            this.lowerCasePanelButton.Click += new System.EventHandler(this.lowerCasePanelButton_Click);
            // 
            // upperCasePanelButton
            // 
            this.upperCasePanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upperCasePanelButton.Location = new System.Drawing.Point(108, 290);
            this.upperCasePanelButton.Name = "upperCasePanelButton";
            this.upperCasePanelButton.Size = new System.Drawing.Size(75, 23);
            this.upperCasePanelButton.TabIndex = 2;
            this.upperCasePanelButton.Text = "UpperCase";
            this.upperCasePanelButton.UseVisualStyleBackColor = true;
            this.upperCasePanelButton.Click += new System.EventHandler(this.upperCasePanelButton_Click);
            // 
            // symbolsPanelButton
            // 
            this.symbolsPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.symbolsPanelButton.Location = new System.Drawing.Point(189, 290);
            this.symbolsPanelButton.Name = "symbolsPanelButton";
            this.symbolsPanelButton.Size = new System.Drawing.Size(75, 23);
            this.symbolsPanelButton.TabIndex = 3;
            this.symbolsPanelButton.Text = "Symbols";
            this.symbolsPanelButton.UseVisualStyleBackColor = true;
            this.symbolsPanelButton.Click += new System.EventHandler(this.symbolsPanelButton_Click);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.LargeChange = 31;
            this.hScrollBar1.Location = new System.Drawing.Point(27, 256);
            this.hScrollBar1.Maximum = 322;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(418, 27);
            this.hScrollBar1.SmallChange = 10;
            this.hScrollBar1.TabIndex = 4;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.symbolsPanel);
            this.mainPanel.Controls.Add(this.upperCasePanel);
            this.mainPanel.Controls.Add(this.lowerCasePanel);
            this.mainPanel.Location = new System.Drawing.Point(27, 3);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(700, 250);
            this.mainPanel.TabIndex = 1;
            // 
            // symbolsPanel
            // 
            this.symbolsPanel.Location = new System.Drawing.Point(0, 0);
            this.symbolsPanel.Name = "symbolsPanel";
            this.symbolsPanel.Size = new System.Drawing.Size(976, 250);
            this.symbolsPanel.TabIndex = 2;
            // 
            // upperCasePanel
            // 
            this.upperCasePanel.Location = new System.Drawing.Point(0, 0);
            this.upperCasePanel.Name = "upperCasePanel";
            this.upperCasePanel.Size = new System.Drawing.Size(700, 250);
            this.upperCasePanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "100";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "0";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "50";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // KeyStatsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.symbolsPanelButton);
            this.Controls.Add(this.upperCasePanelButton);
            this.Controls.Add(this.lowerCasePanelButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "KeyStatsPanel";
            this.Size = new System.Drawing.Size(477, 323);
            this.Load += new System.EventHandler(this.KeyStatsPanel_Load);
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel lowerCasePanel;
        private System.Windows.Forms.Button lowerCasePanelButton;
        private System.Windows.Forms.Button upperCasePanelButton;
        private System.Windows.Forms.Button symbolsPanelButton;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel symbolsPanel;
        private System.Windows.Forms.Panel upperCasePanel;
    }
}
