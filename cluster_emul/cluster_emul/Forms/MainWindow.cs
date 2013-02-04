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
using cluster_emul.Utils;
using System.Threading;
using System.Collections;

namespace cluster_emul
{
    /// <summary>
    /// Делегат пересылки модельного времени
    /// </summary>
    /// <param name="time">время</param>
    delegate void TimeStatus(int time);

    public partial class MainWindow : Form
    {
        Thread t;                               //Поток обработчика регионов
        RegionsHandler rh;                      //обработчик регионов
        delegate void EnStartSimButtonDel();    //Делегат активации кнопки симуляции
        int ModelDays = 0;                      //Количество дней смуляции
        bool thread_life = true;                //Признак жизнитпотока
        ArrayList StatusWindows;                //Коллекция статусных окон

        public MainWindow()
        {
            InitializeComponent();
            this.Icon = AppResources.icon;
        }

        private void StartSimButton_Click(object sender, EventArgs e)
        {
            if (OutputHandler.Init(FilePathTextBox.Text))
            {
                t = new Thread(new ThreadStart(MainThread));
                StatusWindows = new ArrayList();
                int BalanceType = 0;
                if (NoBalanceRadioButton.Checked) BalanceType = 0;
                if (DeCentralizedBalanceRadioButton.Checked) BalanceType = 1;
                if (CenralizedBalanceRadioButton.Checked) BalanceType = 2;
                if (DeCentralizedT2RadioButton.Checked) BalanceType = 3;
                ModelDays = (int)ModelDaysNumericUpDown.Value;
                DaysProgressBar.Maximum = ModelDays;
                DaysProgressBar.Value = 0;
                TimeProgressBar.Maximum = ((int)RegionsUpDown5.Value - 1) * 100 + 300;
                ModelDaysLabel.Text = "0";
                StopSimButton.Enabled = true;
                StartSimButton.Enabled = false;
                rh = new RegionsHandler((int)RegionsUpDown5.Value, (int)ClientsNumericUpDown.Value,
                    (int)ServersUpDown.Value, (int)DBcapNumericUpDown.Value, BalanceType);
                rh.SetThrottle(RefreshSpeedTrackBar.Value);
                rh.TS += new TimeStatus(TimeStatusHandler);
                rh.DaysTS += new TimeStatus(ModelDaysStatusHandler);
                NextNum.Mode(RandomQueryCheckBox.Checked);
                if (StatusWindowsCheckBox.Checked)
                {
                    int col = 0;
                    int row = 0;
                    for (int i = 0; i < rh.Regions.Count; i++)
                    {
                        RBN rbn = (RBN)rh.Regions[i];
                        StatusWindow sw = new StatusWindow(rbn.Region_num,
                            rbn.Region_num * (int)ServersUpDown.Value,
                            rbn.Region_num * (int)ClientsNumericUpDown.Value,
                            rbn.Region_num * (int)ServersUpDown.Value * 2);
                        StatusWindows.Add(sw);
                        rh.RIA += new RegionIsActive(sw.RegionStatusHandler);
                        rh.QS += new QueueStatus(sw.QueueStatusHandler);
                        rh.QCS += new QueryCountStatus(sw.QueryCountStatusHandler);
                        if ((col+1) * 300 + 300 > Screen.PrimaryScreen.WorkingArea.Width)
                        {
                            col = 0;
                            row++;
                        }
                        sw.SetLocation((++col) * 300, row * 300);
                    }
                }
                thread_life = true;
                t.Start();
            }
        }
        
        /// <summary>
        /// Поток обработчика регионов
        /// </summary>
        private void MainThread()
        {
            while ((ModelDays > rh.Work() || ModelDays == 0) && thread_life)
            {
            //    Thread.Sleep(1); //Скрость симуляции
            }
            OutputHandler.Close();
            if (thread_life) EnStartSimButtonInvoke();
        }

        /// <summary>
        /// Потокобезопасный метод включения кнопки
        /// </summary>
        private void EnStartSimButtonInvoke()
        {
            if (this.StartSimButton.InvokeRequired)
            {
                EnStartSimButtonDel d = new EnStartSimButtonDel(EnStartSimButton);
                this.Invoke(d);
            }
            else
            {
                EnStartSimButton();
            }
        }

        /// <summary>
        /// Включение кнопки
        /// </summary>
        private void EnStartSimButton()
        {
            StartSimButton.Enabled = true;
            StopSimButton.Enabled = false;
            for (int i = 0; i < StatusWindows.Count; i++)
                ((StatusWindow)StatusWindows[i]).Dispose();
            StatusWindows.Clear();
        }

        /// <summary>
        /// Обрабатвает событие закрытия формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread_life = false;
            if (t != null) t.Abort();
        }

        /// <summary>
        /// Получает модельное время
        /// </summary>
        /// <param name="time">модельное время</param>
        public void TimeStatusHandler(int time)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new TimeStatus(SetTimeStatus), time);
            }
            else
            {
                SetTimeStatus(time);
            }
        }

        /// <summary>
        /// Устанавливает модельное время в окне
        /// </summary>
        /// <param name="time">модельное время</param>
        void SetTimeStatus(int time)
        {
            TimeProgressBar.Value = time;
            ModelTimeLabel.Text = time.ToString();
        }

        /// <summary>
        /// Получает модельные сутки
        /// </summary>
        /// <param name="day">модельные сутки</param>
        public void ModelDaysStatusHandler(int day)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new TimeStatus(SetModelDaysStatus), day);
            }
            else
            {
                SetModelDaysStatus(day);
            }
        }

        /// <summary>
        /// Устанавливает модельные сутки в окне
        /// </summary>
        /// <param name="day">модельные сутки</param>
        void SetModelDaysStatus(int day)
        {
            DaysProgressBar.Value = day;
            ModelDaysLabel.Text = day.ToString();
        }

        private void StopSimButton_Click(object sender, EventArgs e)
        {
            thread_life = false;
            t.Abort();
            OutputHandler.Close();
            DaysProgressBar.Value = 0;
            ModelDaysLabel.Text = "0";
            TimeProgressBar.Value = 0;
            ModelTimeLabel.Text = "0";
            EnStartSimButton();
        }

        private void RefreshSpeedTrackBar_Scroll(object sender, EventArgs e)
        {
            ResrefhSpeedLable.Text = ((TrackBar)sender).Value.ToString();
        }
    }
}
