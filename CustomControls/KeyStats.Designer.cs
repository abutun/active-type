namespace ActiveType.CustomControls
{
    partial class KeyStats
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
            this.keyProgressPanel = new System.Windows.Forms.Panel();
            this.keyNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // keyProgressPanel
            // 
            this.keyProgressPanel.BackColor = System.Drawing.SystemColors.Desktop;
            this.keyProgressPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyProgressPanel.Location = new System.Drawing.Point(3, 3);
            this.keyProgressPanel.Name = "keyProgressPanel";
            this.keyProgressPanel.Size = new System.Drawing.Size(16, 220);
            this.keyProgressPanel.TabIndex = 0;
            // 
            // keyNameLabel
            // 
            this.keyNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.keyNameLabel.Location = new System.Drawing.Point(3, 226);
            this.keyNameLabel.Name = "keyNameLabel";
            this.keyNameLabel.Size = new System.Drawing.Size(16, 22);
            this.keyNameLabel.TabIndex = 1;
            this.keyNameLabel.Text = "A";
            this.keyNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KeyStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.keyNameLabel);
            this.Controls.Add(this.keyProgressPanel);
            this.Name = "KeyStats";
            this.Size = new System.Drawing.Size(22, 248);
            this.Load += new System.EventHandler(this.KeyStats_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel keyProgressPanel;
        private System.Windows.Forms.Label keyNameLabel;
    }
}
