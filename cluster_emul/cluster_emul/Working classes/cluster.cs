using System;
using System.Collections.Generic;
using System.Collections;

namespace cluster_emul
{
    /// <summary>
    /// Класс кластера
    /// </summary>
    class cluster
    {
        private Queue queue;        //Внутрення очередь
        private cluster_query cq;   //запросы
        public float query_time;    //время необходимое для выполения текущего запроса

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public cluster()
        {
            cq = new cluster_query();
            queue = new Queue(2);
        }

        /// <summary>
        /// Функция добавления запроса в очередь
        /// </summary>
        /// <param name="arr"><para>массив параметоров запроса в очереди</para>
        /// <para>номер запроса, номер клиента, номер региона</para></param>
        public void QueueAdd(int[] arr)
        {
            queue.Enqueue(arr);
        }

        /// <summary>
        /// Функция удаления запроса из очереди
        /// </summary>
        public void QueueRemove()
        {
            queue.Dequeue();
        }

        /// <summary>
        /// Функция установки времени, нобходимого для выполения текущего запроса
        /// </summary>
        public void SetQueryTime()
        {
            int[] arr = (int[])queue.Peek();
            query_time=cq.GetQueryByNum(arr[0]);
        }

        /// <summary>
        /// Возвращает информацию о текущем запросе 
        /// </summary>
        /// <param name="delete">Фглаг удаления запроса из локальной очереди</param>
        /// <returns>Массив с информацие о запросе</returns>
        public int[] GetQueryInfo(bool delete)
        {
            if (delete) return (int[])queue.Dequeue();
            else return (int[])queue.Peek();
        }

        /// <summary>
        /// Возвращает информацию о текущем запросе 
        /// </summary>
        /// <returns>Массив с информацие о запросе</returns>
        public int[] GetQueryInfo()
        {
            return (int[])queue.Peek();
        }

        /// <summary>
        /// Возвращает количество запросов в очереди
        /// </summary>
        /// <returns>количество запросов в очереди</returns>
        public int GetQueueCount()
        {
            return queue.Count;
        }
    }
}
