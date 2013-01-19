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

namespace cluster_emul
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartSimButton_Click(object sender, EventArgs e)
        {
            int BalanceType=0;
            if (NoBalanceRadioButton.Checked) BalanceType = 0;
            if (DeCentralizedBalanceRadioButton.Checked) BalanceType = 1;
            if (CenralizedBalanceRadioButton.Checked) BalanceType = 2;
            StartSimButton.Enabled = false;
            OutputHandler.Init(FilePathTextBox.Text);
            RegionsHandler rh = new RegionsHandler((int)RegionsUpDown5.Value, (int)ClientsNumericUpDown.Value,
                (int)ServersUpDown.Value, (int)DBcapNumericUpDown.Value, BalanceType);
            rh.Work();
            OutputHandler.Close();
            Console.WriteLine("Все готово!");
            StartSimButton.Enabled = true;
        }
    }
}
