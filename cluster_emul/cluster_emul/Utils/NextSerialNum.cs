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

namespace cluster_emul.Utils
{
    /// <summary>
    /// Класс генерации последовальности чисел
    /// </summary>
    static class NextSerialNum
    {
        static int num = 0; //число

        /// <summary>
        /// Выдает следующее число
        /// </summary>
        /// <param name="maxNum">Максимальное число</param>
        /// <returns>следующее число</returns>
        static public int Gen(int maxNum)
        {
            num++;
            if (num > maxNum) num = 0;
            return num;
        }
    }
}
