namespace cluster_emul
{
    partial class StatusWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.RbnStatus = new System.Windows.Forms.Label();
            this.ClusterCount = new System.Windows.Forms.Label();
            this.ClientsCount = new System.Windows.Forms.Label();
            this.QueryCount = new System.Windows.Forms.Label();
            this.QueueProgressBar = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Статус региона";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Количество кластеров";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Количество клиентов";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.29578F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.70423F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.RbnStatus, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ClusterCount, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ClientsCount, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.QueryCount, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 100);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Количество обработанных запросов";
            // 
            // RbnStatus
            // 
            this.RbnStatus.AutoSize = true;
            this.RbnStatus.Location = new System.Drawing.Point(214, 0);
            this.RbnStatus.Name = "RbnStatus";
            this.RbnStatus.Size = new System.Drawing.Size(49, 13);
            this.RbnStatus.TabIndex = 5;
            this.RbnStatus.Text = "Активен";
            // 
            // ClusterCount
            // 
            this.ClusterCount.AutoSize = true;
            this.ClusterCount.Location = new System.Drawing.Point(214, 20);
            this.ClusterCount.Name = "ClusterCount";
            this.ClusterCount.Size = new System.Drawing.Size(13, 13);
            this.ClusterCount.TabIndex = 5;
            this.ClusterCount.Text = "0";
            // 
            // ClientsCount
            // 
            this.ClientsCount.AutoSize = true;
            this.ClientsCount.Location = new System.Drawing.Point(214, 40);
            this.ClientsCount.Name = "ClientsCount";
            this.ClientsCount.Size = new System.Drawing.Size(13, 13);
            this.ClientsCount.TabIndex = 6;
            this.ClientsCount.Text = "0";
            // 
            // QueryCount
            // 
            this.QueryCount.AutoSize = true;
            this.QueryCount.Location = new System.Drawing.Point(214, 60);
            this.QueryCount.Name = "QueryCount";
            this.QueryCount.Size = new System.Drawing.Size(13, 13);
            this.QueryCount.TabIndex = 6;
            this.QueryCount.Text = "0";
            // 
            // QueueProgressBar
            // 
            this.QueueProgressBar.Location = new System.Drawing.Point(12, 226);
            this.QueueProgressBar.Name = "QueueProgressBar";
            this.QueueProgressBar.Size = new System.Drawing.Size(260, 23);
            this.QueueProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.QueueProgressBar.TabIndex = 3;
            this.QueueProgressBar.Value = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Очередь балансировщика региона:";
            // 
            // StatusWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.QueueProgressBar);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StatusWindow";
            this.Text = "StatusWindow";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label RbnStatus;
        private System.Windows.Forms.Label ClusterCount;
        private System.Windows.Forms.Label ClientsCount;
        private System.Windows.Forms.Label QueryCount;
        private System.Windows.Forms.ProgressBar QueueProgressBar;
        private System.Windows.Forms.Label label5;
    }
}