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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cluster_emul.Utils;

namespace cluster_emul
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.Run(new MainWindow());
            OutputHandler.Init("file.txt");
            RegionsHandler rh = new RegionsHandler(3, 1000);
            rh.Work();
            OutputHandler.Close();
            Console.WriteLine("Все готово!");
            Console.ReadKey();
        }
    }
}
