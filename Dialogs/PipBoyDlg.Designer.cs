namespace FalloutPNP_PipBoy.Dialogs
{
    partial class PipBoyDlg
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
            this.btnTerminalEasy = new System.Windows.Forms.Button();
            this.btnTerminalNormal = new System.Windows.Forms.Button();
            this.btnTerminalHard = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnItemsList = new System.Windows.Forms.Button();
            this.btnCreateCharacter = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTerminalEasy
            // 
            this.btnTerminalEasy.Location = new System.Drawing.Point(6, 19);
            this.btnTerminalEasy.Name = "btnTerminalEasy";
            this.btnTerminalEasy.Size = new System.Drawing.Size(100, 23);
            this.btnTerminalEasy.TabIndex = 0;
            this.btnTerminalEasy.Text = "Level 1";
            this.btnTerminalEasy.UseVisualStyleBackColor = true;
            this.btnTerminalEasy.Click += new System.EventHandler(this.btnTerminalEasy_Click);
            // 
            // btnTerminalNormal
            // 
            this.btnTerminalNormal.Location = new System.Drawing.Point(6, 48);
            this.btnTerminalNormal.Name = "btnTerminalNormal";
            this.btnTerminalNormal.Size = new System.Drawing.Size(100, 23);
            this.btnTerminalNormal.TabIndex = 1;
            this.btnTerminalNormal.Text = "Level 2";
            this.btnTerminalNormal.UseVisualStyleBackColor = true;
            this.btnTerminalNormal.Click += new System.EventHandler(this.btnTerminalNormal_Click);
            // 
            // btnTerminalHard
            // 
            this.btnTerminalHard.Location = new System.Drawing.Point(6, 77);
            this.btnTerminalHard.Name = "btnTerminalHard";
            this.btnTerminalHard.Size = new System.Drawing.Size(100, 23);
            this.btnTerminalHard.TabIndex = 2;
            this.btnTerminalHard.Text = "Level 3";
            this.btnTerminalHard.UseVisualStyleBackColor = true;
            this.btnTerminalHard.Click += new System.EventHandler(this.btnTerminalHard_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTerminalEasy);
            this.groupBox1.Controls.Add(this.btnTerminalHard);
            this.groupBox1.Controls.Add(this.btnTerminalNormal);
            this.groupBox1.Location = new System.Drawing.Point(362, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 110);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Взлом терминала";
            // 
            // btnItemsList
            // 
            this.btnItemsList.Location = new System.Drawing.Point(341, 139);
            this.btnItemsList.Name = "btnItemsList";
            this.btnItemsList.Size = new System.Drawing.Size(127, 23);
            this.btnItemsList.TabIndex = 4;
            this.btnItemsList.Text = "Список предметов";
            this.btnItemsList.UseVisualStyleBackColor = true;
            this.btnItemsList.Click += new System.EventHandler(this.btnItemsList_Click);
            // 
            // btnCreateCharacter
            // 
            this.btnCreateCharacter.Location = new System.Drawing.Point(12, 12);
            this.btnCreateCharacter.Name = "btnCreateCharacter";
            this.btnCreateCharacter.Size = new System.Drawing.Size(127, 23);
            this.btnCreateCharacter.TabIndex = 5;
            this.btnCreateCharacter.Text = "Создание персонажа";
            this.btnCreateCharacter.UseVisualStyleBackColor = true;
            this.btnCreateCharacter.Click += new System.EventHandler(this.btnCreateCharacter_Click);
            // 
            // PipBoyDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 260);
            this.Controls.Add(this.btnCreateCharacter);
            this.Controls.Add(this.btnItemsList);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PipBoyDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pip-Boy";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTerminalEasy;
        private System.Windows.Forms.Button btnTerminalNormal;
        private System.Windows.Forms.Button btnTerminalHard;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnItemsList;
        private System.Windows.Forms.Button btnCreateCharacter;
    }
}

