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

namespace cluster_emul
{
    public partial class MainWindow : Form
    {
        Thread t;                               //Поток обработчика регионов
        RegionsHandler rh;                      //обработчик регионов
        delegate void EnStartSimButtonDel();    //Делегат активации кнопки симуляции
        int ModelDays = 0;                      //Количество дней смуляции
        bool thread_life = true;                //Признак жизнитпотока

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartSimButton_Click(object sender, EventArgs e)
        {
            if (OutputHandler.Init(FilePathTextBox.Text))
            {
                t = new Thread(new ThreadStart(MainThread));
                int BalanceType = 0;
                if (NoBalanceRadioButton.Checked) BalanceType = 0;
                if (DeCentralizedBalanceRadioButton.Checked) BalanceType = 1;
                if (CenralizedBalanceRadioButton.Checked) BalanceType = 2;
                StartSimButton.Enabled = false;
                rh = new RegionsHandler((int)RegionsUpDown5.Value, (int)ClientsNumericUpDown.Value,
                    (int)ServersUpDown.Value, (int)DBcapNumericUpDown.Value, BalanceType);
                ModelDays = (int)ModelDaysNumericUpDown.Value;
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
             //   Thread.Sleep(10); //Скрость симуляции
            }
            OutputHandler.Close();
            Console.WriteLine("Все готово!");
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
                this.StartSimButton.Enabled = true;
            }
        }

        /// <summary>
        /// Включение кнопки
        /// </summary>
        private void EnStartSimButton()
        {
            StartSimButton.Enabled = true;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread_life = false;
        }
    }
}
