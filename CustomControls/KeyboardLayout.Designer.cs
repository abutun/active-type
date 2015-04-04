namespace ActiveType.CustomControls
{
    partial class KeyboardLayout
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
            this.layoutBox = new System.Windows.Forms.GroupBox();
            this.pressedKeyCodeInfo = new System.Windows.Forms.Label();
            this.expectedKeyCodeInfo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fingerLayout = new ActiveType.CustomControls.FingerLayout();
            this.layoutBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutBox
            // 
            this.layoutBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.layoutBox.Controls.Add(this.pressedKeyCodeInfo);
            this.layoutBox.Controls.Add(this.expectedKeyCodeInfo);
            this.layoutBox.Location = new System.Drawing.Point(3, 0);
            this.layoutBox.Name = "layoutBox";
            this.layoutBox.Size = new System.Drawing.Size(792, 272);
            this.layoutBox.TabIndex = 0;
            this.layoutBox.TabStop = false;
            // 
            // pressedKeyCodeInfo
            // 
            this.pressedKeyCodeInfo.AutoSize = true;
            this.pressedKeyCodeInfo.Location = new System.Drawing.Point(6, 38);
            this.pressedKeyCodeInfo.Name = "pressedKeyCodeInfo";
            this.pressedKeyCodeInfo.Size = new System.Drawing.Size(0, 13);
            this.pressedKeyCodeInfo.TabIndex = 1;
            // 
            // expectedKeyCodeInfo
            // 
            this.expectedKeyCodeInfo.AutoSize = true;
            this.expectedKeyCodeInfo.Location = new System.Drawing.Point(6, 16);
            this.expectedKeyCodeInfo.Name = "expectedKeyCodeInfo";
            this.expectedKeyCodeInfo.Size = new System.Drawing.Size(0, 13);
            this.expectedKeyCodeInfo.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox2.Controls.Add(this.fingerLayout);
            this.groupBox2.Location = new System.Drawing.Point(4, 278);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(792, 224);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // fingerLayout
            // 
            this.fingerLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.fingerLayout.CurrentHighlightingFingers = null;
            this.fingerLayout.Location = new System.Drawing.Point(82, 19);
            this.fingerLayout.Name = "fingerLayout";
            this.fingerLayout.Size = new System.Drawing.Size(615, 199);
            this.fingerLayout.TabIndex = 2;
            // 
            // KeyboardLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.layoutBox);
            this.Name = "KeyboardLayout";
            this.Size = new System.Drawing.Size(800, 508);
            this.Load += new System.EventHandler(this.KeyboardLayout_Load);
            this.layoutBox.ResumeLayout(false);
            this.layoutBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox layoutBox;
        private FingerLayout fingerLayout;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label expectedKeyCodeInfo;
        private System.Windows.Forms.Label pressedKeyCodeInfo;
    }
}
