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
            this.NoBalanceRadioButton = new System.Windows.Forms.RadioButton();
            this.DeCentralizedBalanceRadioButton = new System.Windows.Forms.RadioButton();
            this.CenralizedBalanceRadioButton = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.RegionsUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.FilePathTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ModelDaysNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.StatusWindowsCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ServersUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBcapNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RegionsUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelDaysNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // StartSimButton
            // 
            this.StartSimButton.Location = new System.Drawing.Point(12, 299);
            this.StartSimButton.Name = "StartSimButton";
            this.StartSimButton.Size = new System.Drawing.Size(260, 23);
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
            20,
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
            3,
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
            this.groupBox1.Controls.Add(this.NoBalanceRadioButton);
            this.groupBox1.Controls.Add(this.DeCentralizedBalanceRadioButton);
            this.groupBox1.Controls.Add(this.CenralizedBalanceRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(15, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 89);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип МРБН";
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
            // DeCentralizedBalanceRadioButton
            // 
            this.DeCentralizedBalanceRadioButton.AutoSize = true;
            this.DeCentralizedBalanceRadioButton.Location = new System.Drawing.Point(6, 66);
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
            this.FilePathTextBox.Location = new System.Drawing.Point(15, 273);
            this.FilePathTextBox.Name = "FilePathTextBox";
            this.FilePathTextBox.Size = new System.Drawing.Size(257, 20);
            this.FilePathTextBox.TabIndex = 6;
            this.FilePathTextBox.Text = "file.csv";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 257);
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
            this.StatusWindowsCheckBox.Location = new System.Drawing.Point(15, 237);
            this.StatusWindowsCheckBox.Name = "StatusWindowsCheckBox";
            this.StatusWindowsCheckBox.Size = new System.Drawing.Size(152, 17);
            this.StatusWindowsCheckBox.TabIndex = 7;
            this.StatusWindowsCheckBox.Text = "Визуализировать работу";
            this.StatusWindowsCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 329);
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
            this.Controls.Add(this.StartSimButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.Text = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ServersUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBcapNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RegionsUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelDaysNumericUpDown)).EndInit();
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
    }
}