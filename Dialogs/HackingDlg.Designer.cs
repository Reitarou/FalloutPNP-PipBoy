namespace FalloutPNP_PipBoy.Dialogs
{
    partial class HackingDlg
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HackingDlg));
            this.tmTyper = new System.Windows.Forms.Timer(this.components);
            this.pbTerminal = new System.Windows.Forms.PictureBox();
            this.pbPowerButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbTerminal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPowerButton)).BeginInit();
            this.SuspendLayout();
            // 
            // tmTyper
            // 
            this.tmTyper.Enabled = true;
            this.tmTyper.Interval = 1;
            this.tmTyper.Tick += new System.EventHandler(this.tmTyper_Tick);
            // 
            // pbTerminal
            // 
            this.pbTerminal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbTerminal.Image = ((System.Drawing.Image)(resources.GetObject("pbTerminal.Image")));
            this.pbTerminal.Location = new System.Drawing.Point(0, 0);
            this.pbTerminal.Name = "pbTerminal";
            this.pbTerminal.Size = new System.Drawing.Size(800, 672);
            this.pbTerminal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTerminal.TabIndex = 0;
            this.pbTerminal.TabStop = false;
            this.pbTerminal.Tag = "";
            this.pbTerminal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HackingDlg_MouseMove);
            this.pbTerminal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HackingDlg_MouseDown);
            this.pbTerminal.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HackingDlg_MouseUp);
            // 
            // pbPowerButton
            // 
            this.pbPowerButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPowerButton.Image = ((System.Drawing.Image)(resources.GetObject("pbPowerButton.Image")));
            this.pbPowerButton.Location = new System.Drawing.Point(567, 586);
            this.pbPowerButton.Name = "pbPowerButton";
            this.pbPowerButton.Size = new System.Drawing.Size(47, 45);
            this.pbPowerButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPowerButton.TabIndex = 1;
            this.pbPowerButton.TabStop = false;
            this.pbPowerButton.Tag = "";
            this.pbPowerButton.Click += new System.EventHandler(this.pbPowerButton_Click);
            // 
            // HackingDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 672);
            this.Controls.Add(this.pbPowerButton);
            this.Controls.Add(this.pbTerminal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HackingDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.HackingDlg_Load);
            this.Shown += new System.EventHandler(this.HackingDlg_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbTerminal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPowerButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmTyper;
        private System.Windows.Forms.PictureBox pbTerminal;
        private System.Windows.Forms.PictureBox pbPowerButton;

    }
}