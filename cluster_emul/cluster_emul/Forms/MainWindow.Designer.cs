namespace cluster_emul
{
    partial class MainWindow
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
            this.StartSimButton = new System.Windows.Forms.Button();
            this.ServersUpDown = new System.Windows.Forms.NumericUpDown();
            this.ClientsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DBcapNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CentralizedType2RadioButton = new System.Windows.Forms.RadioButton();
            this.NoBalanceRadioButton = new System.Windows.Forms.RadioButton();
            this.DeCentralizedT2RadioButton = new System.Windows.Forms.RadioButton();
            this.DeCentralizedBalanceRadioButton = new System.Windows.Forms.RadioButton();
            this.CenralizedBalanceRadioButton = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.RegionsUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.FilePathTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ModelDaysNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.StatusWindowsCheckBox = new System.Windows.Forms.CheckBox();
            this.DaysProgressBar = new System.Windows.Forms.ProgressBar();
            this.TimeProgressBar = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ModelDaysLabel = new System.Windows.Forms.Label();
            this.ModelTimeLabel = new System.Windows.Forms.Label();
            this.StopSimButton = new System.Windows.Forms.Button();
            this.RandomQueryCheckBox = new System.Windows.Forms.CheckBox();
            this.RefreshSpeedTrackBar = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.ResrefhSpeedLable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ServersUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBcapNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RegionsUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelDaysNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshSpeedTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // StartSimButton
            // 
            this.StartSimButton.Location = new System.Drawing.Point(12, 444);
            this.StartSimButton.Name = "StartSimButton";
            this.StartSimButton.Size = new System.Drawing.Size(128, 23);
            this.StartSimButton.TabIndex = 0;
            this.StartSimButton.Text = "Начать симуляцию";
            this.StartSimButton.UseVisualStyleBackColor = true;
            this.StartSimButton.Click += new System.EventHandler(this.StartSimButton_Click);
            // 
            // ServersUpDown
            // 
            this.ServersUpDown.Location = new System.Drawing.Point(212, 38);
            this.ServersUpDown.Name = "ServersUpDown";
            this.ServersUpDown.Size = new System.Drawing.Size(60, 20);
            this.ServersUpDown.TabIndex = 1;
            this.ServersUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // ClientsNumericUpDown
            // 
            this.ClientsNumericUpDown.Location = new System.Drawing.Point(212, 64);
            this.ClientsNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ClientsNumericUpDown.Name = "ClientsNumericUpDown";
            this.ClientsNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.ClientsNumericUpDown.TabIndex = 1;
            this.ClientsNumericUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Количество серверов в 1-м регионе";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Количество клиентов в 1-м регионе";
            // 
            // DBcapNumericUpDown
            // 
            this.DBcapNumericUpDown.Location = new System.Drawing.Point(212, 90);
            this.DBcapNumericUpDown.Name = "DBcapNumericUpDown";
            this.DBcapNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.DBcapNumericUpDown.TabIndex = 1;
            this.DBcapNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Объем БД в 1-м регионе";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CentralizedType2RadioButton);
            this.groupBox1.Controls.Add(this.NoBalanceRadioButton);
            this.groupBox1.Controls.Add(this.DeCentralizedT2RadioButton);
            this.groupBox1.Controls.Add(this.DeCentralizedBalanceRadioButton);
            this.groupBox1.Controls.Add(this.CenralizedBalanceRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(15, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 138);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип МРБН";
            // 
            // CentralizedType2RadioButton
            // 
            this.CentralizedType2RadioButton.AutoSize = true;
            this.CentralizedType2RadioButton.Location = new System.Drawing.Point(6, 66);
            this.CentralizedType2RadioButton.Name = "CentralizedType2RadioButton";
            this.CentralizedType2RadioButton.Size = new System.Drawing.Size(177, 17);
            this.CentralizedType2RadioButton.TabIndex = 2;
            this.CentralizedType2RadioButton.Text = "Централизованный вариант 2";
            this.CentralizedType2RadioButton.UseVisualStyleBackColor = true;
            // 
            // NoBalanceRadioButton
            // 
            this.NoBalanceRadioButton.AutoSize = true;
            this.NoBalanceRadioButton.Checked = true;
            this.NoBalanceRadioButton.Location = new System.Drawing.Point(6, 20);
            this.NoBalanceRadioButton.Name = "NoBalanceRadioButton";
            this.NoBalanceRadioButton.Size = new System.Drawing.Size(119, 17);
            this.NoBalanceRadioButton.TabIndex = 1;
            this.NoBalanceRadioButton.TabStop = true;
            this.NoBalanceRadioButton.Text = "Нет балансировки";
            this.NoBalanceRadioButton.UseVisualStyleBackColor = true;
            // 
            // DeCentralizedT2RadioButton
            // 
            this.DeCentralizedT2RadioButton.AutoSize = true;
            this.DeCentralizedT2RadioButton.Location = new System.Drawing.Point(6, 112);
            this.DeCentralizedT2RadioButton.Name = "DeCentralizedT2RadioButton";
            this.DeCentralizedT2RadioButton.Size = new System.Drawing.Size(190, 17);
            this.DeCentralizedT2RadioButton.TabIndex = 0;
            this.DeCentralizedT2RadioButton.Text = "Децентрализованный вариант 2";
            this.DeCentralizedT2RadioButton.UseVisualStyleBackColor = true;
            // 
            // DeCentralizedBalanceRadioButton
            // 
            this.DeCentralizedBalanceRadioButton.AutoSize = true;
            this.DeCentralizedBalanceRadioButton.Location = new System.Drawing.Point(6, 89);
            this.DeCentralizedBalanceRadioButton.Name = "DeCentralizedBalanceRadioButton";
            this.DeCentralizedBalanceRadioButton.Size = new System.Drawing.Size(137, 17);
            this.DeCentralizedBalanceRadioButton.TabIndex = 0;
            this.DeCentralizedBalanceRadioButton.Text = "Децентрализованный";
            this.DeCentralizedBalanceRadioButton.UseVisualStyleBackColor = true;
            // 
            // CenralizedBalanceRadioButton
            // 
            this.CenralizedBalanceRadioButton.AutoSize = true;
            this.CenralizedBalanceRadioButton.Location = new System.Drawing.Point(6, 43);
            this.CenralizedBalanceRadioButton.Name = "CenralizedBalanceRadioButton";
            this.CenralizedBalanceRadioButton.Size = new System.Drawing.Size(124, 17);
            this.CenralizedBalanceRadioButton.TabIndex = 0;
            this.CenralizedBalanceRadioButton.Text = "Централизованный";
            this.CenralizedBalanceRadioButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Количество регионов";
            // 
            // RegionsUpDown5
            // 
            this.RegionsUpDown5.Location = new System.Drawing.Point(212, 12);
            this.RegionsUpDown5.Name = "RegionsUpDown5";
            this.RegionsUpDown5.Size = new System.Drawing.Size(60, 20);
            this.RegionsUpDown5.TabIndex = 4;
            this.RegionsUpDown5.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // FilePathTextBox
            // 
            this.FilePathTextBox.Location = new System.Drawing.Point(15, 418);
            this.FilePathTextBox.Name = "FilePathTextBox";
            this.FilePathTextBox.Size = new System.Drawing.Size(257, 20);
            this.FilePathTextBox.TabIndex = 6;
            this.FilePathTextBox.Text = "file.csv";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Файл лога работы:";
            // 
            // ModelDaysNumericUpDown
            // 
            this.ModelDaysNumericUpDown.Location = new System.Drawing.Point(212, 116);
            this.ModelDaysNumericUpDown.Name = "ModelDaysNumericUpDown";
            this.ModelDaysNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.ModelDaysNumericUpDown.TabIndex = 1;
            this.ModelDaysNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Количество модельных суток (0 - inf)";
            // 
            // StatusWindowsCheckBox
            // 
            this.StatusWindowsCheckBox.AutoSize = true;
            this.StatusWindowsCheckBox.Location = new System.Drawing.Point(15, 286);
            this.StatusWindowsCheckBox.Name = "StatusWindowsCheckBox";
            this.StatusWindowsCheckBox.Size = new System.Drawing.Size(152, 17);
            this.StatusWindowsCheckBox.TabIndex = 7;
            this.StatusWindowsCheckBox.Text = "Визуализировать работу";
            this.StatusWindowsCheckBox.UseVisualStyleBackColor = true;
            // 
            // DaysProgressBar
            // 
            this.DaysProgressBar.Location = new System.Drawing.Point(12, 492);
            this.DaysProgressBar.Name = "DaysProgressBar";
            this.DaysProgressBar.Size = new System.Drawing.Size(260, 23);
            this.DaysProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.DaysProgressBar.TabIndex = 8;
            // 
            // TimeProgressBar
            // 
            this.TimeProgressBar.Location = new System.Drawing.Point(12, 541);
            this.TimeProgressBar.Maximum = 1440;
            this.TimeProgressBar.Name = "TimeProgressBar";
            this.TimeProgressBar.Size = new System.Drawing.Size(260, 23);
            this.TimeProgressBar.Step = 100;
            this.TimeProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.TimeProgressBar.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 474);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(217, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Количество прошедших модельных суток";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 523);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Текущее модельное время";
            // 
            // ModelDaysLabel
            // 
            this.ModelDaysLabel.AutoSize = true;
            this.ModelDaysLabel.Location = new System.Drawing.Point(236, 474);
            this.ModelDaysLabel.Name = "ModelDaysLabel";
            this.ModelDaysLabel.Size = new System.Drawing.Size(13, 13);
            this.ModelDaysLabel.TabIndex = 11;
            this.ModelDaysLabel.Text = "0";
            // 
            // ModelTimeLabel
            // 
            this.ModelTimeLabel.AutoSize = true;
            this.ModelTimeLabel.Location = new System.Drawing.Point(236, 523);
            this.ModelTimeLabel.Name = "ModelTimeLabel";
            this.ModelTimeLabel.Size = new System.Drawing.Size(13, 13);
            this.ModelTimeLabel.TabIndex = 11;
            this.ModelTimeLabel.Text = "0";
            // 
            // StopSimButton
            // 
            this.StopSimButton.Enabled = false;
            this.StopSimButton.Location = new System.Drawing.Point(146, 444);
            this.StopSimButton.Name = "StopSimButton";
            this.StopSimButton.Size = new System.Drawing.Size(126, 23);
            this.StopSimButton.TabIndex = 0;
            this.StopSimButton.Text = "Стоп";
            this.StopSimButton.UseVisualStyleBackColor = true;
            this.StopSimButton.Click += new System.EventHandler(this.StopSimButton_Click);
            // 
            // RandomQueryCheckBox
            // 
            this.RandomQueryCheckBox.AutoSize = true;
            this.RandomQueryCheckBox.Location = new System.Drawing.Point(15, 307);
            this.RandomQueryCheckBox.Name = "RandomQueryCheckBox";
            this.RandomQueryCheckBox.Size = new System.Drawing.Size(173, 17);
            this.RandomQueryCheckBox.TabIndex = 7;
            this.RandomQueryCheckBox.Text = "Случайные номера запросов";
            this.RandomQueryCheckBox.UseVisualStyleBackColor = true;
            // 
            // RefreshSpeedTrackBar
            // 
            this.RefreshSpeedTrackBar.Location = new System.Drawing.Point(12, 354);
            this.RefreshSpeedTrackBar.Name = "RefreshSpeedTrackBar";
            this.RefreshSpeedTrackBar.Size = new System.Drawing.Size(260, 45);
            this.RefreshSpeedTrackBar.TabIndex = 12;
            this.RefreshSpeedTrackBar.Scroll += new System.EventHandler(this.RefreshSpeedTrackBar_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 331);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(195, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Скорость обновления визуализации:";
            // 
            // ResrefhSpeedLable
            // 
            this.ResrefhSpeedLable.AutoSize = true;
            this.ResrefhSpeedLable.Location = new System.Drawing.Point(236, 331);
            this.ResrefhSpeedLable.Name = "ResrefhSpeedLable";
            this.ResrefhSpeedLable.Size = new System.Drawing.Size(13, 13);
            this.ResrefhSpeedLable.TabIndex = 14;
            this.ResrefhSpeedLable.Text = "0";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 578);
            this.Controls.Add(this.ResrefhSpeedLable);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.RefreshSpeedTrackBar);
            this.Controls.Add(this.ModelTimeLabel);
            this.Controls.Add(this.ModelDaysLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TimeProgressBar);
            this.Controls.Add(this.DaysProgressBar);
            this.Controls.Add(this.RandomQueryCheckBox);
            this.Controls.Add(this.StatusWindowsCheckBox);
            this.Controls.Add(this.FilePathTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RegionsUpDown5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ModelDaysNumericUpDown);
            this.Controls.Add(this.DBcapNumericUpDown);
            this.Controls.Add(this.ClientsNumericUpDown);
            this.Controls.Add(this.ServersUpDown);
            this.Controls.Add(this.StopSimButton);
            this.Controls.Add(this.StartSimButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Эмулятор балансировщика";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ServersUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBcapNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RegionsUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelDaysNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshSpeedTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartSimButton;
        private System.Windows.Forms.NumericUpDown ServersUpDown;
        private System.Windows.Forms.NumericUpDown ClientsNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown DBcapNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton DeCentralizedBalanceRadioButton;
        private System.Windows.Forms.RadioButton CenralizedBalanceRadioButton;
        private System.Windows.Forms.RadioButton NoBalanceRadioButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown RegionsUpDown5;
        private System.Windows.Forms.TextBox FilePathTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ModelDaysNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox StatusWindowsCheckBox;
        private System.Windows.Forms.ProgressBar DaysProgressBar;
        private System.Windows.Forms.ProgressBar TimeProgressBar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label ModelDaysLabel;
        private System.Windows.Forms.Label ModelTimeLabel;
        private System.Windows.Forms.Button StopSimButton;
        private System.Windows.Forms.CheckBox RandomQueryCheckBox;
        private System.Windows.Forms.TrackBar RefreshSpeedTrackBar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label ResrefhSpeedLable;
        private System.Windows.Forms.RadioButton DeCentralizedT2RadioButton;
        private System.Windows.Forms.RadioButton CentralizedType2RadioButton;
    }
}