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
using System.IO;

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
        static public void Init(string file)
        {
            fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
            sw = new StreamWriter(fs);
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
