using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace cluster_emul
{
    /// <summary>
    /// Класс региональнального балансировщика
    /// </summary>
    class RBN
    {
        Queue local_queue;      //Очередь запросов РБН
        int local_queue_length; //длина очереди
        int Region_num;         //номер региона
        ArrayList Clients;      //Клиенты
        ArrayList Clusters;     //Серверы
        float time = 0;         //Модельное мремя

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="Region_number">Номер региона</param>
        /// <param name="Local_Queue_length">Длина очереди балансировщика</param>
        /// <param name="Clients">Количество клиентов в регионе</param>
        /// <param name="Clusters">Количество серверов в регионе</param>
        public RBN(int Region_number, int Local_Queue_length, int Clients, int Clusters)
        {
            local_queue_length = Local_Queue_length;
            local_queue = new Queue(Local_Queue_length);
            Region_num = Region_number;
            this.Clients = new ArrayList(Clients);
            this.Clusters = new ArrayList(Clusters);
            InitClientCluster();
        }

        /// <summary>
        /// Инициализая серверов и клиентов
        /// </summary>
        private void InitClientCluster()
        {
            for (int i = 0; i < Clients.Capacity; i++)
            {
                cluster_client cl = new cluster_client(i, Region_num);
                Clients.Add(cl);
                
            }
            for (int i = 0; i < local_queue_length; i++)
            {
                cluster_client cl = (cluster_client)Clients[i];
                cl.NewRequest();
                local_queue.Enqueue(cl.GetParametrs());     //Инициализация очереди РБН
            }
            for (int i = 0; i < Clusters.Capacity; i++)
            {
                cluster cl = new cluster();
                Clients.Add(cl);
                cl.QueueAdd((int[])local_queue.Dequeue());
            }
        }

        void WorkHandler()
        {
            for(int i=0; i < )
        }
    }
}
