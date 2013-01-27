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

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public partial class StatusWindow : Form
    {
        int RegionNum;
        public StatusWindow()
        {
            InitializeComponent();
            this.Visible = true;
        }

        public StatusWindow(int NumRegion, int Clusters, int Clients, int QueueLength)
        {
            InitializeComponent();
            this.Text = "Регион №" + NumRegion;
            ClusterCount.Text = Clusters+" ";
            ClientsCount.Text = Clients + " ";
            this.Visible = true;
            QueueProgressBar.Maximum = QueueLength;
            RegionNum = NumRegion;
        }


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

        void SetRegionStatus(int regnum, bool active)
        {
            if (regnum==RegionNum)
            if (active) RbnStatus.Text = "Активен";
            else RbnStatus.Text = "Спит";
        }

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

        void SetQueueStatus(int regnum, int queuecount)
        {
            if (regnum == RegionNum)
                QueueProgressBar.Value = queuecount;
        }

        public void QueryCountStatusHandler(int regnum, int querycount)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new QueryCountStatus(SetQueryCountStatus), regnum, querycount);
            }
            else
            {
                SetQueryCountStatus(regnum, querycount);
            }
        }

        void SetQueryCountStatus(int regnum, int querycount)
        {
            if (regnum == RegionNum)
                QueryCount.Text = querycount.ToString();
        }
    }
}
