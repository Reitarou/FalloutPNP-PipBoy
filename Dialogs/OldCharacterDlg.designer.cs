namespace FalloutPNP_PipBoy.Dialogs
{
    partial class OldCharacterDlg
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.nudStr = new System.Windows.Forms.NumericUpDown();
            this.nudPer = new System.Windows.Forms.NumericUpDown();
            this.nudEnd = new System.Windows.Forms.NumericUpDown();
            this.nudCha = new System.Windows.Forms.NumericUpDown();
            this.nudInt = new System.Windows.Forms.NumericUpDown();
            this.nudAgi = new System.Windows.Forms.NumericUpDown();
            this.nudLck = new System.Windows.Forms.NumericUpDown();
            this.lbStr = new System.Windows.Forms.Label();
            this.lbPer = new System.Windows.Forms.Label();
            this.lbEnd = new System.Windows.Forms.Label();
            this.lbCha = new System.Windows.Forms.Label();
            this.lbInt = new System.Windows.Forms.Label();
            this.lbAgi = new System.Windows.Forms.Label();
            this.lbLck = new System.Windows.Forms.Label();
            this.cmbRace = new System.Windows.Forms.ComboBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.lbRace = new System.Windows.Forms.Label();
            this.gbSpecial = new System.Windows.Forms.GroupBox();
            this.lbLckMax = new System.Windows.Forms.Label();
            this.lbLckMin = new System.Windows.Forms.Label();
            this.lbAgiMax = new System.Windows.Forms.Label();
            this.lbAgiMin = new System.Windows.Forms.Label();
            this.lbIntMax = new System.Windows.Forms.Label();
            this.lbIntMin = new System.Windows.Forms.Label();
            this.lbChaMax = new System.Windows.Forms.Label();
            this.lbChaMin = new System.Windows.Forms.Label();
            this.lbEndMax = new System.Windows.Forms.Label();
            this.lbEndMin = new System.Windows.Forms.Label();
            this.lbPerMax = new System.Windows.Forms.Label();
            this.lbPerMin = new System.Windows.Forms.Label();
            this.lbStrMax = new System.Windows.Forms.Label();
            this.lbStrMin = new System.Windows.Forms.Label();
            this.gbParameters = new System.Windows.Forms.GroupBox();
            this.gbSkills = new System.Windows.Forms.GroupBox();
            this.tcEffects = new System.Windows.Forms.TabControl();
            this.tcpTraits = new System.Windows.Forms.TabPage();
            this.rtbTraitSecond = new System.Windows.Forms.RichTextBox();
            this.rtbTraitFirst = new System.Windows.Forms.RichTextBox();
            this.cmbTraitSecond = new System.Windows.Forms.ComboBox();
            this.cmbTraitFirst = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.nudStr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAgi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLck)).BeginInit();
            this.gbSpecial.SuspendLayout();
            this.tcEffects.SuspendLayout();
            this.tcpTraits.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudStr
            // 
            this.nudStr.Location = new System.Drawing.Point(117, 19);
            this.nudStr.Name = "nudStr";
            this.nudStr.ReadOnly = true;
            this.nudStr.Size = new System.Drawing.Size(34, 20);
            this.nudStr.TabIndex = 1;
            this.nudStr.Tag = "0";
            this.nudStr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudStr.ValueChanged += new System.EventHandler(this.nudSpecial_ValueChanged);
            // 
            // nudPer
            // 
            this.nudPer.Location = new System.Drawing.Point(117, 45);
            this.nudPer.Name = "nudPer";
            this.nudPer.ReadOnly = true;
            this.nudPer.Size = new System.Drawing.Size(34, 20);
            this.nudPer.TabIndex = 2;
            this.nudPer.Tag = "1";
            this.nudPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudPer.ValueChanged += new System.EventHandler(this.nudSpecial_ValueChanged);
            // 
            // nudEnd
            // 
            this.nudEnd.Location = new System.Drawing.Point(117, 71);
            this.nudEnd.Name = "nudEnd";
            this.nudEnd.ReadOnly = true;
            this.nudEnd.Size = new System.Drawing.Size(34, 20);
            this.nudEnd.TabIndex = 3;
            this.nudEnd.Tag = "2";
            this.nudEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudEnd.ValueChanged += new System.EventHandler(this.nudSpecial_ValueChanged);
            // 
            // nudCha
            // 
            this.nudCha.Location = new System.Drawing.Point(117, 97);
            this.nudCha.Name = "nudCha";
            this.nudCha.ReadOnly = true;
            this.nudCha.Size = new System.Drawing.Size(34, 20);
            this.nudCha.TabIndex = 4;
            this.nudCha.Tag = "3";
            this.nudCha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCha.ValueChanged += new System.EventHandler(this.nudSpecial_ValueChanged);
            // 
            // nudInt
            // 
            this.nudInt.Location = new System.Drawing.Point(117, 123);
            this.nudInt.Name = "nudInt";
            this.nudInt.ReadOnly = true;
            this.nudInt.Size = new System.Drawing.Size(34, 20);
            this.nudInt.TabIndex = 5;
            this.nudInt.Tag = "4";
            this.nudInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudInt.ValueChanged += new System.EventHandler(this.nudSpecial_ValueChanged);
            // 
            // nudAgi
            // 
            this.nudAgi.Location = new System.Drawing.Point(117, 149);
            this.nudAgi.Name = "nudAgi";
            this.nudAgi.ReadOnly = true;
            this.nudAgi.Size = new System.Drawing.Size(34, 20);
            this.nudAgi.TabIndex = 6;
            this.nudAgi.Tag = "5";
            this.nudAgi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudAgi.ValueChanged += new System.EventHandler(this.nudSpecial_ValueChanged);
            // 
            // nudLck
            // 
            this.nudLck.Location = new System.Drawing.Point(117, 175);
            this.nudLck.Name = "nudLck";
            this.nudLck.ReadOnly = true;
            this.nudLck.Size = new System.Drawing.Size(34, 20);
            this.nudLck.TabIndex = 7;
            this.nudLck.Tag = "6";
            this.nudLck.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudLck.ValueChanged += new System.EventHandler(this.nudSpecial_ValueChanged);
            // 
            // lbStr
            // 
            this.lbStr.AutoSize = true;
            this.lbStr.Location = new System.Drawing.Point(6, 21);
            this.lbStr.Name = "lbStr";
            this.lbStr.Size = new System.Drawing.Size(32, 13);
            this.lbStr.TabIndex = 8;
            this.lbStr.Text = "Сила";
            // 
            // lbPer
            // 
            this.lbPer.AutoSize = true;
            this.lbPer.Location = new System.Drawing.Point(6, 47);
            this.lbPer.Name = "lbPer";
            this.lbPer.Size = new System.Drawing.Size(67, 13);
            this.lbPer.TabIndex = 9;
            this.lbPer.Text = "Восприятие";
            // 
            // lbEnd
            // 
            this.lbEnd.AutoSize = true;
            this.lbEnd.Location = new System.Drawing.Point(6, 73);
            this.lbEnd.Name = "lbEnd";
            this.lbEnd.Size = new System.Drawing.Size(81, 13);
            this.lbEnd.TabIndex = 10;
            this.lbEnd.Text = "Выносливость";
            // 
            // lbCha
            // 
            this.lbCha.AutoSize = true;
            this.lbCha.Location = new System.Drawing.Point(6, 99);
            this.lbCha.Name = "lbCha";
            this.lbCha.Size = new System.Drawing.Size(52, 13);
            this.lbCha.TabIndex = 11;
            this.lbCha.Text = "Харизма";
            // 
            // lbInt
            // 
            this.lbInt.AutoSize = true;
            this.lbInt.Location = new System.Drawing.Point(6, 125);
            this.lbInt.Name = "lbInt";
            this.lbInt.Size = new System.Drawing.Size(61, 13);
            this.lbInt.TabIndex = 12;
            this.lbInt.Text = "Интеллект";
            // 
            // lbAgi
            // 
            this.lbAgi.AutoSize = true;
            this.lbAgi.Location = new System.Drawing.Point(6, 151);
            this.lbAgi.Name = "lbAgi";
            this.lbAgi.Size = new System.Drawing.Size(56, 13);
            this.lbAgi.TabIndex = 13;
            this.lbAgi.Text = "Ловкость";
            // 
            // lbLck
            // 
            this.lbLck.AutoSize = true;
            this.lbLck.Location = new System.Drawing.Point(6, 177);
            this.lbLck.Name = "lbLck";
            this.lbLck.Size = new System.Drawing.Size(38, 13);
            this.lbLck.TabIndex = 14;
            this.lbLck.Text = "Удача";
            // 
            // cmbRace
            // 
            this.cmbRace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRace.FormattingEnabled = true;
            this.cmbRace.Items.AddRange(new object[] {
            "Человек",
            "Гуль",
            "Супер Мутант Альфа",
            "Супер Мутант Бета",
            "Полумутант",
            "Коготь Смерти",
            "Собака",
            "Робот Гуманоид"});
            this.cmbRace.Location = new System.Drawing.Point(256, 12);
            this.cmbRace.Name = "cmbRace";
            this.cmbRace.Size = new System.Drawing.Size(158, 21);
            this.cmbRace.TabIndex = 15;
            this.cmbRace.SelectedIndexChanged += new System.EventHandler(this.cmbRaces_SelectedIndexChanged);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(47, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(165, 20);
            this.tbName.TabIndex = 40;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(12, 15);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(29, 13);
            this.lbName.TabIndex = 41;
            this.lbName.Text = "Имя";
            // 
            // lbRace
            // 
            this.lbRace.AutoSize = true;
            this.lbRace.Location = new System.Drawing.Point(218, 15);
            this.lbRace.Name = "lbRace";
            this.lbRace.Size = new System.Drawing.Size(32, 13);
            this.lbRace.TabIndex = 42;
            this.lbRace.Text = "Раса";
            // 
            // gbSpecial
            // 
            this.gbSpecial.Controls.Add(this.lbLckMax);
            this.gbSpecial.Controls.Add(this.lbLckMin);
            this.gbSpecial.Controls.Add(this.lbAgiMax);
            this.gbSpecial.Controls.Add(this.lbAgiMin);
            this.gbSpecial.Controls.Add(this.lbIntMax);
            this.gbSpecial.Controls.Add(this.lbIntMin);
            this.gbSpecial.Controls.Add(this.lbChaMax);
            this.gbSpecial.Controls.Add(this.lbChaMin);
            this.gbSpecial.Controls.Add(this.lbEndMax);
            this.gbSpecial.Controls.Add(this.lbEndMin);
            this.gbSpecial.Controls.Add(this.lbPerMax);
            this.gbSpecial.Controls.Add(this.lbPerMin);
            this.gbSpecial.Controls.Add(this.lbStrMax);
            this.gbSpecial.Controls.Add(this.lbStrMin);
            this.gbSpecial.Controls.Add(this.lbStr);
            this.gbSpecial.Controls.Add(this.nudStr);
            this.gbSpecial.Controls.Add(this.nudPer);
            this.gbSpecial.Controls.Add(this.nudEnd);
            this.gbSpecial.Controls.Add(this.nudCha);
            this.gbSpecial.Controls.Add(this.nudInt);
            this.gbSpecial.Controls.Add(this.nudAgi);
            this.gbSpecial.Controls.Add(this.nudLck);
            this.gbSpecial.Controls.Add(this.lbPer);
            this.gbSpecial.Controls.Add(this.lbEnd);
            this.gbSpecial.Controls.Add(this.lbCha);
            this.gbSpecial.Controls.Add(this.lbInt);
            this.gbSpecial.Controls.Add(this.lbAgi);
            this.gbSpecial.Controls.Add(this.lbLck);
            this.gbSpecial.Location = new System.Drawing.Point(15, 48);
            this.gbSpecial.Name = "gbSpecial";
            this.gbSpecial.Size = new System.Drawing.Size(183, 206);
            this.gbSpecial.TabIndex = 43;
            this.gbSpecial.TabStop = false;
            this.gbSpecial.Text = " S.P.E.C.I.A.L. ";
            // 
            // lbLckMax
            // 
            this.lbLckMax.Location = new System.Drawing.Point(157, 177);
            this.lbLckMax.Name = "lbLckMax";
            this.lbLckMax.Size = new System.Drawing.Size(19, 13);
            this.lbLckMax.TabIndex = 28;
            this.lbLckMax.Text = "00";
            this.lbLckMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLckMin
            // 
            this.lbLckMin.Location = new System.Drawing.Point(92, 177);
            this.lbLckMin.Name = "lbLckMin";
            this.lbLckMin.Size = new System.Drawing.Size(19, 13);
            this.lbLckMin.TabIndex = 27;
            this.lbLckMin.Text = "00";
            this.lbLckMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbAgiMax
            // 
            this.lbAgiMax.Location = new System.Drawing.Point(157, 151);
            this.lbAgiMax.Name = "lbAgiMax";
            this.lbAgiMax.Size = new System.Drawing.Size(19, 13);
            this.lbAgiMax.TabIndex = 26;
            this.lbAgiMax.Text = "00";
            this.lbAgiMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbAgiMin
            // 
            this.lbAgiMin.Location = new System.Drawing.Point(92, 151);
            this.lbAgiMin.Name = "lbAgiMin";
            this.lbAgiMin.Size = new System.Drawing.Size(19, 13);
            this.lbAgiMin.TabIndex = 25;
            this.lbAgiMin.Text = "00";
            this.lbAgiMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbIntMax
            // 
            this.lbIntMax.Location = new System.Drawing.Point(157, 125);
            this.lbIntMax.Name = "lbIntMax";
            this.lbIntMax.Size = new System.Drawing.Size(19, 13);
            this.lbIntMax.TabIndex = 24;
            this.lbIntMax.Text = "00";
            this.lbIntMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbIntMin
            // 
            this.lbIntMin.Location = new System.Drawing.Point(92, 125);
            this.lbIntMin.Name = "lbIntMin";
            this.lbIntMin.Size = new System.Drawing.Size(19, 13);
            this.lbIntMin.TabIndex = 23;
            this.lbIntMin.Text = "00";
            this.lbIntMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbChaMax
            // 
            this.lbChaMax.Location = new System.Drawing.Point(157, 99);
            this.lbChaMax.Name = "lbChaMax";
            this.lbChaMax.Size = new System.Drawing.Size(19, 13);
            this.lbChaMax.TabIndex = 22;
            this.lbChaMax.Text = "00";
            this.lbChaMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbChaMin
            // 
            this.lbChaMin.Location = new System.Drawing.Point(92, 99);
            this.lbChaMin.Name = "lbChaMin";
            this.lbChaMin.Size = new System.Drawing.Size(19, 13);
            this.lbChaMin.TabIndex = 21;
            this.lbChaMin.Text = "00";
            this.lbChaMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbEndMax
            // 
            this.lbEndMax.Location = new System.Drawing.Point(157, 73);
            this.lbEndMax.Name = "lbEndMax";
            this.lbEndMax.Size = new System.Drawing.Size(19, 13);
            this.lbEndMax.TabIndex = 20;
            this.lbEndMax.Text = "00";
            this.lbEndMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbEndMin
            // 
            this.lbEndMin.Location = new System.Drawing.Point(92, 73);
            this.lbEndMin.Name = "lbEndMin";
            this.lbEndMin.Size = new System.Drawing.Size(19, 13);
            this.lbEndMin.TabIndex = 19;
            this.lbEndMin.Text = "00";
            this.lbEndMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPerMax
            // 
            this.lbPerMax.Location = new System.Drawing.Point(157, 47);
            this.lbPerMax.Name = "lbPerMax";
            this.lbPerMax.Size = new System.Drawing.Size(19, 13);
            this.lbPerMax.TabIndex = 18;
            this.lbPerMax.Text = "00";
            this.lbPerMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPerMin
            // 
            this.lbPerMin.Location = new System.Drawing.Point(92, 47);
            this.lbPerMin.Name = "lbPerMin";
            this.lbPerMin.Size = new System.Drawing.Size(19, 13);
            this.lbPerMin.TabIndex = 17;
            this.lbPerMin.Text = "00";
            this.lbPerMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbStrMax
            // 
            this.lbStrMax.Location = new System.Drawing.Point(157, 21);
            this.lbStrMax.Name = "lbStrMax";
            this.lbStrMax.Size = new System.Drawing.Size(19, 13);
            this.lbStrMax.TabIndex = 16;
            this.lbStrMax.Text = "00";
            this.lbStrMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbStrMin
            // 
            this.lbStrMin.Location = new System.Drawing.Point(92, 21);
            this.lbStrMin.Name = "lbStrMin";
            this.lbStrMin.Size = new System.Drawing.Size(19, 13);
            this.lbStrMin.TabIndex = 15;
            this.lbStrMin.Text = "00";
            this.lbStrMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbParameters
            // 
            this.gbParameters.Location = new System.Drawing.Point(12, 260);
            this.gbParameters.Name = "gbParameters";
            this.gbParameters.Size = new System.Drawing.Size(183, 301);
            this.gbParameters.TabIndex = 44;
            this.gbParameters.TabStop = false;
            this.gbParameters.Text = " Характеристики ";
            // 
            // gbSkills
            // 
            this.gbSkills.Location = new System.Drawing.Point(204, 48);
            this.gbSkills.Name = "gbSkills";
            this.gbSkills.Size = new System.Drawing.Size(234, 467);
            this.gbSkills.TabIndex = 45;
            this.gbSkills.TabStop = false;
            this.gbSkills.Text = " Умения ";
            // 
            // tcEffects
            // 
            this.tcEffects.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tcEffects.Controls.Add(this.tcpTraits);
            this.tcEffects.Controls.Add(this.tabPage2);
            this.tcEffects.Location = new System.Drawing.Point(464, 48);
            this.tcEffects.Multiline = true;
            this.tcEffects.Name = "tcEffects";
            this.tcEffects.SelectedIndex = 0;
            this.tcEffects.Size = new System.Drawing.Size(350, 467);
            this.tcEffects.TabIndex = 47;
            // 
            // tcpTraits
            // 
            this.tcpTraits.BackColor = System.Drawing.Color.Transparent;
            this.tcpTraits.Controls.Add(this.rtbTraitSecond);
            this.tcpTraits.Controls.Add(this.rtbTraitFirst);
            this.tcpTraits.Controls.Add(this.cmbTraitSecond);
            this.tcpTraits.Controls.Add(this.cmbTraitFirst);
            this.tcpTraits.Location = new System.Drawing.Point(23, 4);
            this.tcpTraits.Name = "tcpTraits";
            this.tcpTraits.Padding = new System.Windows.Forms.Padding(3);
            this.tcpTraits.Size = new System.Drawing.Size(323, 459);
            this.tcpTraits.TabIndex = 0;
            this.tcpTraits.Text = "Уникумы";
            // 
            // rtbTraitSecond
            // 
            this.rtbTraitSecond.Location = new System.Drawing.Point(6, 258);
            this.rtbTraitSecond.Name = "rtbTraitSecond";
            this.rtbTraitSecond.ReadOnly = true;
            this.rtbTraitSecond.Size = new System.Drawing.Size(311, 192);
            this.rtbTraitSecond.TabIndex = 3;
            this.rtbTraitSecond.Text = "";
            // 
            // rtbTraitFirst
            // 
            this.rtbTraitFirst.Location = new System.Drawing.Point(6, 33);
            this.rtbTraitFirst.Name = "rtbTraitFirst";
            this.rtbTraitFirst.ReadOnly = true;
            this.rtbTraitFirst.Size = new System.Drawing.Size(311, 192);
            this.rtbTraitFirst.TabIndex = 2;
            this.rtbTraitFirst.Text = "";
            // 
            // cmbTraitSecond
            // 
            this.cmbTraitSecond.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTraitSecond.FormattingEnabled = true;
            this.cmbTraitSecond.Location = new System.Drawing.Point(6, 231);
            this.cmbTraitSecond.Name = "cmbTraitSecond";
            this.cmbTraitSecond.Size = new System.Drawing.Size(311, 21);
            this.cmbTraitSecond.TabIndex = 1;
            this.cmbTraitSecond.SelectedIndexChanged += new System.EventHandler(this.cmbTrait_SelectedIndexChanged);
            // 
            // cmbTraitFirst
            // 
            this.cmbTraitFirst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTraitFirst.FormattingEnabled = true;
            this.cmbTraitFirst.Location = new System.Drawing.Point(6, 6);
            this.cmbTraitFirst.Name = "cmbTraitFirst";
            this.cmbTraitFirst.Size = new System.Drawing.Size(311, 21);
            this.cmbTraitFirst.TabIndex = 0;
            this.cmbTraitFirst.SelectedIndexChanged += new System.EventHandler(this.cmbTrait_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Location = new System.Drawing.Point(23, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(323, 459);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // CharacterDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(903, 625);
            this.Controls.Add(this.tcEffects);
            this.Controls.Add(this.gbSkills);
            this.Controls.Add(this.gbParameters);
            this.Controls.Add(this.gbSpecial);
            this.Controls.Add(this.lbRace);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.cmbRace);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "CharacterDlg";
            this.Text = "Страница персонажа";
            this.Load += new System.EventHandler(this.CharacterDlg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudStr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAgi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLck)).EndInit();
            this.gbSpecial.ResumeLayout(false);
            this.gbSpecial.PerformLayout();
            this.tcEffects.ResumeLayout(false);
            this.tcpTraits.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudStr;
        private System.Windows.Forms.NumericUpDown nudPer;

        private System.Windows.Forms.NumericUpDown nudEnd;
        private System.Windows.Forms.NumericUpDown nudCha;
        private System.Windows.Forms.NumericUpDown nudInt;
        private System.Windows.Forms.NumericUpDown nudAgi;
        private System.Windows.Forms.NumericUpDown nudLck;
        private System.Windows.Forms.Label lbStr;
        private System.Windows.Forms.Label lbPer;
        private System.Windows.Forms.Label lbEnd;
        private System.Windows.Forms.Label lbCha;
        private System.Windows.Forms.Label lbInt;
        private System.Windows.Forms.Label lbAgi;
        private System.Windows.Forms.Label lbLck;
        private System.Windows.Forms.ComboBox cmbRace;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbRace;
        private System.Windows.Forms.GroupBox gbSpecial;
        private System.Windows.Forms.Label lbPerMax;
        private System.Windows.Forms.Label lbPerMin;
        private System.Windows.Forms.Label lbStrMax;
        private System.Windows.Forms.Label lbStrMin;

        private System.Windows.Forms.Label lbEndMax;
        private System.Windows.Forms.Label lbEndMin;
        private System.Windows.Forms.Label lbChaMax;
        private System.Windows.Forms.Label lbChaMin;
        private System.Windows.Forms.Label lbLckMax;
        private System.Windows.Forms.Label lbLckMin;
        private System.Windows.Forms.Label lbAgiMax;
        private System.Windows.Forms.Label lbAgiMin;
        private System.Windows.Forms.Label lbIntMax;
        private System.Windows.Forms.Label lbIntMin;

        private System.Windows.Forms.GroupBox gbParameters;
        private System.Windows.Forms.GroupBox gbSkills;
        private System.Windows.Forms.TabControl tcEffects;
        private System.Windows.Forms.TabPage tcpTraits;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cmbTraitSecond;
        private System.Windows.Forms.ComboBox cmbTraitFirst;
        private System.Windows.Forms.RichTextBox rtbTraitSecond;
        private System.Windows.Forms.RichTextBox rtbTraitFirst;
    }
}

