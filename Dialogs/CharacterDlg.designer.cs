namespace FalloutPNP_PipBoy
{
    partial class CharacterDlg
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
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbSkills = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudStr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAgi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLck)).BeginInit();
            this.gbSpecial.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudStr
            // 
            this.nudStr.Location = new System.Drawing.Point(117, 19);
            this.nudStr.Name = "nudStr";
            this.nudStr.ReadOnly = true;
            this.nudStr.Size = new System.Drawing.Size(34, 20);
            this.nudStr.TabIndex = 1;
            this.nudStr.Tag = "Str";
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
            this.nudPer.Tag = "Per";
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
            this.nudEnd.Tag = "End";
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
            this.nudCha.Tag = "Cha";
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
            this.nudInt.Tag = "Int";
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
            this.nudAgi.Tag = "Agi";
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
            this.nudLck.Tag = "Lck";
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
            this.lbInt.Size = new System.Drawing.Size(55, 13);
            this.lbInt.TabIndex = 12;
            this.lbInt.Text = "Интелект";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "OД";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Макс груз";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "РУ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "СЯ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 123);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "СР";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 148);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "ПД";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 174);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "УЛ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 198);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "КШ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 220);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 13);
            this.label16.TabIndex = 24;
            this.label16.Text = "СЭ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 242);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 13);
            this.label17.TabIndex = 25;
            this.label17.Text = "СГ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 265);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(21, 13);
            this.label18.TabIndex = 26;
            this.label18.Text = "КБ";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Location = new System.Drawing.Point(12, 260);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 298);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(501, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 46;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CharacterDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 625);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gbSkills);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbSpecial);
            this.Controls.Add(this.lbRace);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.cmbRace);
            this.Name = "CharacterDlg";
            this.Text = "Form1";
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
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

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbSkills;
        private System.Windows.Forms.Button button1;
    }
}

