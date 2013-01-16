using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
