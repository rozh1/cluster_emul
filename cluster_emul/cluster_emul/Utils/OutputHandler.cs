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
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace cluster_emul.Utils
{
    /// <summary>
    /// Статичный класс вывода в файл
    /// </summary>
    public static class OutputHandler
    {
        static FileStream fs;   //Файловый паток
        static StreamWriter sw; //писатель

        /// <summary>
        /// Инициализация статического класса
        /// </summary>
        /// <param name="file">Путь к файлу вывода</param>
        static public bool Init(string file)
        {
            try
            {
                fs = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.Read);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Что-то с файлом не так", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            sw = new StreamWriter(fs);
            //WriteLine("Номер региона;номер запроса в регионе;номер запроса;номер клиента;номер региона клиента;время задержки;время;длина очереди");
            return true;
        }

        /// <summary>
        /// Выводит строку в файл
        /// </summary>
        /// <param name="line">Текст для вывода в файл</param>
        static public void WriteLine(string line)
        {
            sw.WriteLine(line);
        }

        /// <summary>
        /// Закрывает все потоки записи
        /// </summary>
        static public void Close()
        {
            sw.Close();
        }
    }
}
