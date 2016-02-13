namespace SF3TranslationPatch
{
    partial class Patcher
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
            this.btnRescan = new System.Windows.Forms.Button();
            this.btnPatch = new System.Windows.Forms.Button();
            this.lblScenario = new System.Windows.Forms.Label();
            this.pBarLoading = new System.Windows.Forms.ProgressBar();
            this.chkView = new System.Windows.Forms.CheckBox();
            this.lblProgressBar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRescan
            // 
            this.btnRescan.Location = new System.Drawing.Point(12, 65);
            this.btnRescan.Name = "btnRescan";
            this.btnRescan.Size = new System.Drawing.Size(119, 23);
            this.btnRescan.TabIndex = 2;
            this.btnRescan.Text = "Rescan Drives";
            this.btnRescan.UseVisualStyleBackColor = true;
            this.btnRescan.Click += new System.EventHandler(this.btnRescan_Click);
            // 
            // btnPatch
            // 
            this.btnPatch.Location = new System.Drawing.Point(153, 65);
            this.btnPatch.Name = "btnPatch";
            this.btnPatch.Size = new System.Drawing.Size(119, 23);
            this.btnPatch.TabIndex = 3;
            this.btnPatch.Text = "Patch";
            this.btnPatch.UseVisualStyleBackColor = true;
            this.btnPatch.Click += new System.EventHandler(this.btnPatch_Click);
            // 
            // lblScenario
            // 
            this.lblScenario.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblScenario.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScenario.Location = new System.Drawing.Point(0, 0);
            this.lblScenario.Name = "lblScenario";
            this.lblScenario.Size = new System.Drawing.Size(284, 33);
            this.lblScenario.TabIndex = 4;
            this.lblScenario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pBarLoading
            // 
            this.pBarLoading.Location = new System.Drawing.Point(12, 124);
            this.pBarLoading.Name = "pBarLoading";
            this.pBarLoading.Size = new System.Drawing.Size(260, 23);
            this.pBarLoading.TabIndex = 5;
            // 
            // chkView
            // 
            this.chkView.AutoSize = true;
            this.chkView.Location = new System.Drawing.Point(12, 42);
            this.chkView.Name = "chkView";
            this.chkView.Size = new System.Drawing.Size(166, 17);
            this.chkView.TabIndex = 6;
            this.chkView.Text = "Add paul_met\'s view increase";
            this.chkView.UseVisualStyleBackColor = true;
            this.chkView.CheckedChanged += new System.EventHandler(this.chkView_CheckedChanged);
            // 
            // lblProgressBar
            // 
            this.lblProgressBar.BackColor = System.Drawing.Color.Transparent;
            this.lblProgressBar.Location = new System.Drawing.Point(12, 97);
            this.lblProgressBar.Name = "lblProgressBar";
            this.lblProgressBar.Size = new System.Drawing.Size(260, 23);
            this.lblProgressBar.TabIndex = 7;
            // 
            // Patcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 155);
            this.Controls.Add(this.lblProgressBar);
            this.Controls.Add(this.chkView);
            this.Controls.Add(this.pBarLoading);
            this.Controls.Add(this.lblScenario);
            this.Controls.Add(this.btnPatch);
            this.Controls.Add(this.btnRescan);
            this.Name = "Patcher";
            this.Text = "SF3 Translation Patch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRescan;
        private System.Windows.Forms.Button btnPatch;
        private System.Windows.Forms.Label lblScenario;
        private System.Windows.Forms.ProgressBar pBarLoading;
        private System.Windows.Forms.CheckBox chkView;
        private System.Windows.Forms.Label lblProgressBar;
    }
}

