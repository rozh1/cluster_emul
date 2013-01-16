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

namespace cluster_emul
{
    /* Класс генерации запроса к серверу.
    */
    class cluster_query
    {
        private float[] queries;    //массив запросов
        private Random rand;        //великий русский рандом

        /* конструктор класса 
         */
        public cluster_query()
        {
            rand = new Random();
            queries = new float[14];
            queries[0] = 0.09F;
            queries[1] = 0.10F;
            queries[2] = 0.11F;
            queries[3] = 0.21F;
            queries[4] = 0.22F;
            queries[5] = 0.23F;
            queries[6] = 0.35F;
            queries[7] = 0.39F;
            queries[8] = 0.40F;
            queries[9] = 0.41F;
            queries[10] = 0.42F;
            queries[11] = 0.44F;
            queries[12] = 0.48F;
            queries[13] = 1.00F;
        }

        /* Функция выдачи номера запроса
         * Входные параметры: 
         *  нет
         * Выходные параметры:
         *  int - номер запроса
         */
        public int GenQueryNum()
        {
            return rand.Next(0, 13);
        }

        /* Функция выдачи номера запроса
         * Входные параметры: 
         *  int num - номер запроса
         * Выходные параметры:
         *  float - время выполенения запроса
         */
        public float GetQueryByNum(int num)
        {
            return queries[num];
        }

    }
}
