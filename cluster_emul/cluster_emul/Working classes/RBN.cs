using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using cluster_emul.Utils;

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
            QueueRecive();                                              //Инициализация очереди РБН
            for (int i = 0; i < Clusters.Capacity; i++)
            {
                cluster cl = new cluster();
                Clusters.Add(cl);
            }
            QueueAllocation(2);                                         //Инициализация очереди серверов
            QueueRecive();                                              //Заполенение очереди РБН
        }

        /// <summary>
        /// Размещает запросы в очереди по серверам
        /// </summary>
        void QueueAllocation()
        {
            QueueAllocation(1);
        }

        /// <summary>
        /// Размещает запросы в очереди по серверам
        /// </summary>
        /// <param name="k">Количество мест в очереди сервера</param>
        void QueueAllocation(int k)
        {
            for (int j = 0; j < k; j++)
            {
                for (int i = 0; i < Clusters.Count; i++)
                {
                    cluster cl = (cluster)Clusters[i];
                    if ((cl.GetQueueCount() < 2) && local_queue.Count > 0)
                    {
                        cl.QueueAdd((int[])local_queue.Dequeue());
                        cl.SetQueryTime();
                    }
                    if (cl.GetQueueCount() == 1) cl.SetQueryTime();
                }
            }
        }

        /// <summary>
        /// Получение новых запросов от клиентов и запись в очередь РБН
        /// </summary>
        void QueueRecive()
        {
            for (int i = 0; i < Clients.Count; i++)
            {
                cluster_client cl = (cluster_client)Clients[i];
                if (!cl.request_sended && local_queue.Count<local_queue_length)
                {
                    cl.NewRequest();
                    local_queue.Enqueue(cl.GetParametrs());
                }
            }
        }

        /// <summary>
        /// проверяет кластеры на наличие выполненых запросов
        /// </summary>
        /// <returns>true - если есть сервера с выполенными запросами</returns>
        bool CheckClusters()
        {
            bool flag = false;
            for (int i = 0; i < Clusters.Count; i++)
            {
                cluster cl = (cluster)Clusters[i];
                if (cl.query_time < 0.01 && cl.GetQueueCount()>0)
                {
                    int[] arr = cl.GetQueryInfo(true);
                    cluster_client client = (cluster_client)Clients[arr[1]];
                    client.ReciveAns();
                    flag = true;
                    //Console.WriteLine("{0};{1};{2};{3}", arr[0], arr[1],arr[2],time);
                    OutputHandler.WriteLine(arr[0] + ";" + arr[1] + ";" + arr[2] + ";" + time);
                }
            }
            return flag;
        }

        /// <summary>
        /// Обработчик запросов
        /// </summary>
        /// <param name="time">Текущее время</param>
        public void WorkHandler(float time)
        {
            this.time = time;
            if (local_queue.Count == 0)
            {
                QueueRecive();
                QueueAllocation(2);
            }
            if (CheckClusters())
            {
                QueueRecive();
                QueueAllocation();
            }
            for (int i = 0; i < Clusters.Count; i++)
            {
                ((cluster)Clusters[i]).query_time -= 0.01F;
            }
        }

        /// <summary>
        /// Режим сна региона (дорабатывает запросы из очереди, но новые не принимает)
        /// </summary>
        /// <param name="time">Текущее время</param>
        public void SleepHandler(float time)
        {
            this.time = time;
            if (CheckClusters())
            {
                QueueAllocation();
            }
            for (int i = 0; i < Clusters.Count; i++)
            {
                ((cluster)Clusters[i]).query_time -= 0.01F;
            }
        }
    }
}
