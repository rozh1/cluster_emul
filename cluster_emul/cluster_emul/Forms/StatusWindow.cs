#region Copyright
/*
 * Copyright 2013 Roman Klassen, Lenar Khisamiev
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not
 * use this file except in compliance with the License. You may obtain a copy
 * of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations
 * under the License.
 *
 */
#endregion

﻿using System.Drawing;
using System.Windows.Forms;

namespace cluster_emul
{
    /// <summary>
    /// Делегат пересылки статуса региона
    /// </summary>
    /// <param name="RegionNum">№ региона</param>
    /// <param name="active">активность</param>
    delegate void RegionIsActive(int RegionNum, bool active);

    /// <summary>
    /// Делегат пересылки информации о заполнении очереди РБН
    /// </summary>
    /// <param name="RegionNum">Номер региона</param>
    /// <param name="QueueCount">Количество запросов в регионе</param>
    delegate void QueueStatus(int RegionNum, int QueueCount);

    /// <summary>
    /// Делегат пересылки количества выполненных запросов
    /// </summary>
    /// <param name="RegionNum">Номер региона</param>
    /// <param name="QueryCount">Количество выполненных запросов в регионе</param>
    delegate void QueryCountStatus(int RegionNum, int QueryCount);

    /// <summary>
    /// Делегат пересылки веса очереди
    /// </summary>
    /// <param name="RegionNum">Номер региона</param>
    /// <param name="QueueWeight">Вес очереди</param>
    delegate void QueueWeightStatus(int RegionNum, float QueueWeight);

    /// <summary>
    /// Делегат пересылки номера главного региона
    /// </summary>
    /// <param name="RegionNum">Номер региона</param>
    delegate void GeneralRegionStatus(int RegionNum);

    /// <summary>
    /// Класс статусного окна
    /// </summary>
    public partial class StatusWindow : Form
    {
        int RegionNum;      //Номер региона

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public StatusWindow()
        {
            InitializeComponent();
            this.Icon = AppResources.icon;
            this.Visible = true;
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="NumRegion">Номер региона</param>
        /// <param name="Clusters">Количество кластеров</param>
        /// <param name="Clients">Количество Клиентов</param>
        /// <param name="QueueLength">Длина очереди</param>
        /// <param name="DbCapacity">Объем БД региона</param>
        public StatusWindow(int NumRegion, int Clusters, int Clients,
            int QueueLength, int DbCapacity)
        {
            InitializeComponent();
            this.Text = "Регион №" + NumRegion;
            ClusterCount.Text = Clusters + " ";
            ClientsCount.Text = Clients + " ";
            RegionDbCapacity.Text = DbCapacity.ToString();
            this.Icon = AppResources.icon;
            this.Visible = true;
            QueueProgressBar.Maximum = QueueLength;
            RegionNum = NumRegion;
        }

        /// <summary>
        /// Функция установки положения окна
        /// </summary>
        /// <param name="X">координата X</param>
        /// <param name="Y">координата Y</param>
        public void SetLocation(int X, int Y)
        {
            this.Location = new Point(X, Y);
            this.Size = new System.Drawing.Size(this.Width, this.Height);
        }

        /// <summary>
        /// Обработчик делегата активности региона
        /// </summary>
        /// <param name="regnum">Номер региона</param>
        /// <param name="active">активность</param>
        public void RegionStatusHandler(int regnum, bool active)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new RegionIsActive(SetRegionStatus), regnum, active);
            }
            else
            {
                SetRegionStatus(regnum, active);
            }
        }

        /// <summary>
        /// Устанавливает статус региона в окне
        /// </summary>
        /// <param name="regnum">номер региона</param>
        /// <param name="active">активность</param>
        void SetRegionStatus(int regnum, bool active)
        {
            if (regnum == RegionNum)
                if (active)
                {
                    RbnStatus.Text = "Активен";
                    RbnStatus.BackColor = Color.LightGreen;
                }
                else
                {
                    RbnStatus.Text = "Спит";
                    RbnStatus.BackColor = Color.Yellow;
                }
        }

        /// <summary>
        /// Обработчик делегата заполненности очереди
        /// </summary>
        /// <param name="regnum">номер региона</param>
        /// <param name="queuecount">количество запросов в очереди</param>
        public void QueueStatusHandler(int regnum, int queuecount)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new QueueStatus(SetQueueStatus), regnum, queuecount);
            }
            else
            {
                SetQueueStatus(regnum, queuecount);
            }
        }

        /// <summary>
        /// Устанавливает количество запросов в очереди в окне
        /// </summary>
        /// <param name="regnum">номер региона</param>
        /// <param name="queuecount">количество запросов в очереди</param>
        void SetQueueStatus(int regnum, int queuecount)
        {
            if (regnum == RegionNum)
            {
                QueueProgressBar.Value = queuecount;
                CurrentQueryCount.Text = queuecount.ToString();
            }
        }

        /// <summary>
        /// Обработчик делегата количества обработанных запросов
        /// </summary>
        /// <param name="regnum">Номер региона</param>
        /// <param name="querycount">Количество выполненных запросов в регионе</param>
        public void QueryCountStatusHandler(int regnum, int querycount)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new QueryCountStatus(SetQueryCountStatus),
                    regnum, querycount);
            }
            else
            {
                SetQueryCountStatus(regnum, querycount);
            }
        }

        /// <summary>
        /// Устанавливает количество обработанных запросов региона в окне
        /// </summary>
        /// <param name="regnum">Номер региона</param>
        /// <param name="querycount">Количество выполненных запросов в регионе</param>
        void SetQueryCountStatus(int regnum, int querycount)
        {
            if (regnum == RegionNum)
                QueryCount.Text = querycount.ToString();
        }

        /// <summary>
        /// Обработчик делегата пересылки веса очереди
        /// </summary>
        /// <param name="regnum">Номер региона</param>
        /// <param name="queueweight">Вес очереди</param>
        public void QueueWeightStatusHandler(int regnum, float queueweight)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new QueueWeightStatus(SetQueueWeightStatus),
                    regnum, queueweight);
            }
            else
            {
                SetQueueWeightStatus(regnum, queueweight);
            }
        }

        /// <summary>
        /// Устанавливает вес очереди региона в окне
        /// </summary>
        /// <param name="regnum">Номер региона</param>
        /// <param name="queueweight">Вес очереди</param>
        void SetQueueWeightStatus(int regnum, float queueweight)
        {
            if (regnum == RegionNum)
                RegionQueuWeight.Text = queueweight.ToString();
        }

        /// <summary>
        /// Обработчик делегата пересылки номера главного регина
        /// </summary>
        /// <param name="regnum">Номер региона</param>
        /// <param name="queueweight">Вес очереди</param>
        public void GeneralRegionStatusHandler(int regnum)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new GeneralRegionStatus(GeneralRegionStatus), regnum);
            }
            else
            {
                GeneralRegionStatus(regnum);
            }
        }

        /// <summary>
        /// Устанавливает вес очереди региона в окне
        /// </summary>
        /// <param name="regnum">Номер региона</param>
        /// <param name="queueweight">Вес очереди</param>
        void GeneralRegionStatus(int regnum)
        {
            if (regnum == RegionNum)
                this.BackColor = Color.LightGreen;
            else this.BackColor = Color.FromArgb(240, 240, 240);
        }
    }
}
