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

﻿using cluster_emul.Utils;
using System;
using System.Collections;
using System.Threading;
using System.Windows.Forms;

namespace cluster_emul
{
    /// <summary>
    /// Делегат пересылки модельного времени
    /// </summary>
    /// <param name="time">время</param>
    delegate void TimeStatus(int time);

    /// <summary>
    /// Класс главного окна приложения
    /// </summary>
    public partial class MainWindow : Form
    {
        Thread t;                               //Поток обработчика регионов
        RegionsHandler rh;                      //обработчик регионов
        delegate void EnStartSimButtonDel();    //Делегат активации кнопки симуляции
        int ModelDays = 0;                      //Количество дней смуляции
        bool thread_life = true;                //Признак жизнитпотока
        ArrayList StatusWindows;                //Коллекция статусных окон

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.Icon = AppResources.icon;
            StatusWindows = new ArrayList();
        }

        /// <summary>
        /// Запуск симуляции по кнопке
        /// </summary>
        private void StartSimButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < StatusWindows.Count; i++)
                ((StatusWindow)StatusWindows[i]).Dispose();
            StatusWindows.Clear();
            if (OutputHandler.Init(FilePathTextBox.Text))
            {
                t = new Thread(new ThreadStart(MainThread));
                int BalanceType = 0;
                if (NoBalanceRadioButton.Checked) BalanceType = 0;
                if (DeCentralizedBalanceRadioButton.Checked) BalanceType = 1;
                if (CenralizedBalanceRadioButton.Checked) BalanceType = 2;
                if (DeCentralizedT2RadioButton.Checked) BalanceType = 3;
                if (CentralizedType2RadioButton.Checked) BalanceType = 4;
                ModelDays = (int)ModelDaysNumericUpDown.Value;
                DaysProgressBar.Maximum = ModelDays;
                DaysProgressBar.Value = 0;
                TimeProgressBar.Maximum = 1440;
                ModelDaysLabel.Text = "0";
                StopSimButton.Enabled = true;
                StartSimButton.Enabled = false;
                rh = new RegionsHandler((int)RegionsUpDown5.Value,
                    (int)ClientsNumericUpDown.Value, (int)ServersUpDown.Value,
                    (int)DBcapNumericUpDown.Value, BalanceType);
                rh.SetThrottle(RefreshSpeedTrackBar.Value);
                if (ZeroTimeСheckBox.Checked) rh.SetTimeToZero();
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
                            rbn.Region_num * (int)ClientsNumericUpDown.Value,
                            rbn.Region_num * (int)DBcapNumericUpDown.Value);
                        StatusWindows.Add(sw);
                        rh.RIA += new RegionIsActive(sw.RegionStatusHandler);
                        rh.QS += new QueueStatus(sw.QueueStatusHandler);
                        rh.QCS += new QueryCountStatus(sw.QueryCountStatusHandler);
                        rh.QWS += new QueueWeightStatus(sw.QueueWeightStatusHandler);
                        rh.GR += new GeneralRegionStatus(sw.GeneralRegionStatusHandler);
                        if ((col + 1) * sw.Width + sw.Width >
                            Screen.PrimaryScreen.WorkingArea.Width)
                        {
                            col = 0;
                            row++;
                        }
                        sw.SetLocation((++col) * sw.Width, row * sw.Height);
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
            if (day <= DaysProgressBar.Maximum) DaysProgressBar.Value = day;
            ModelDaysLabel.Text = day.ToString();
        }

        /// <summary>
        /// Прерывание процесса симуляции
        /// </summary>
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

        /// <summary>
        /// Обновление показания скорости симуляции
        /// </summary>
        private void RefreshSpeedTrackBar_Scroll(object sender, EventArgs e)
        {
            ResrefhSpeedLable.Text = ((TrackBar)sender).Value.ToString();
        }
    }
}
