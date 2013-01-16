using System;
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
