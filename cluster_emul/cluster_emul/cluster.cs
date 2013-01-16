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
using System.Collections;

namespace cluster_emul
{
    /* Класс кластера
     */ 
    class cluster
    {
        private Queue queue;        //Внутрення очередь
        private cluster_query cq;   //запросы
        public float query_time;    //время необходимое для выполения текущего запроса

        /* Конструктор класса
         */
        public cluster()
        {
            queue = new Queue(2);
        }

        /* Функция добавления запроса в очередь
         * Входные параметры:
         *  int[] arr - массив параметоров запроса в очереди
         *              номер запроса, номер клиента, номер региона
         */
        public void QueueAdd(int[] arr)
        {
            queue.Enqueue(arr);
        }

        /* Функция удаления запроса из очереди
         */
        public void QueueRemove()
        {
            queue.Dequeue();
        }

        /* Функция установки времени, нобходимого для выполения текущего запроса
         */
        public void SetQueryTime()
        {
            int[] arr = (int[])queue.Peek();
            query_time=cq.GetQueryByNum(arr[0]);
        }

    }
}
