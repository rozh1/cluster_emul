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
        Queue local_queue;              //Очередь запросов РБН
        int local_queue_length;         //длина очереди
        public int Region_num;          //номер региона
        ArrayList Clients;              //Клиенты
        ArrayList Clusters;             //Серверы
        float time = 200;               //Модельное мремя
        int TOTAL_QUERY_COUNT = 0;      //Общее количество обработанных регионом запросов 
        int CURENT_TOTAL_W = 0;         //Общий суммарный вес очредеи РБН
        public int db_capacity;         //Объём базы данных региона
        float normalizing_factor;       //нормирующий коэффициент при расчёте весов
        public ArrayList AnotherQueries;//Обработанные запросы от клиентов из других регионов
        int last_client_num = 0;        //Номер последнего обратившегося клиента

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="Region_number">Номер региона</param>
        /// <param name="Local_Queue_length">Длина очереди балансировщика</param>
        /// <param name="Clients">Количество клиентов в регионе</param>
        /// <param name="Clusters">Количество серверов в регионе</param>
        /// <param name="db_capacity">Объём базы данных региона</param>
        public RBN(int Region_number, int Local_Queue_length, int Clients, int Clusters, int db_capacity)
        {
            local_queue_length = Local_Queue_length;
            local_queue = new Queue(Local_Queue_length);
            Region_num = Region_number;
            this.Clients = new ArrayList(Clients);
            this.Clusters = new ArrayList(Clusters);
            this.db_capacity = db_capacity;
            AnotherQueries = new ArrayList();
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
                        int[] arr = (int[])local_queue.Peek();
                        //если запрос из своего региона
                        if (arr[2] == Region_num)
                        {
                            cluster_client cl_w = (cluster_client)Clients[arr[1]];
                            if (CURENT_TOTAL_W > 0) CURENT_TOTAL_W -= cl_w.GetWieghtQuery();
                        }
                        cl.QueueAdd((int[])local_queue.Dequeue());
                        cl.SetQueryTime();
                    }
                }
            }
        }

        int kol_iterations = 1;         //Количество итераций вызова функции QueueRecive()
        /// <summary>
        /// Получение новых запросов от клиентов и запись в очередь РБН
        /// </summary>
        void QueueRecive()
        {
            for (int i = last_client_num; i < Clients.Count; i++, last_client_num++)
            {
                cluster_client cl = (cluster_client)Clients[i];
                if (!cl.request_sended && local_queue.Count<local_queue_length)
                {
                    cl.NewRequest(time);
                    CURENT_TOTAL_W += cl.GetWieghtQuery();
                    local_queue.Enqueue(cl.GetParametrs());
                }
                if (QueueIsFull()) break;
            }
            if (last_client_num == Clients.Count)
            {
                last_client_num = 0;
                if (kol_iterations++ <= 2) QueueRecive();
                else
                {
                    kol_iterations = 1;
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
                    //если запрос из своего региона
                    if (arr[2] == Region_num)
                    {
                        TOTAL_QUERY_COUNT++;
                        cluster_client client = (cluster_client)Clients[arr[1]];
                        client.ReciveAns(time);
                        //Номер региона;номер запроса в регионе;номер запроса;номер клиента;номер региона клиента; время задержки; время
                        string output = String.Format("{0};{1};{2};{3};{4};{5:F2};{6:F2};{7}",
                            Region_num, TOTAL_QUERY_COUNT, arr[0], arr[1], arr[2], client.recive_time, time, local_queue.Count);
                        OutputHandler.WriteLine(output);
                    }
                    else
                    {
                        AnotherQueries.Add(arr);
                    }
                    if (cl.GetQueueCount() > 0) cl.SetQueryTime();
                    flag = true;
                }
            }
            return flag;
        }

        /// <summary>
        /// Обработчик запросов
        /// </summary>
        /// <param name="time">Текущее модельное время</param>
        public void Work(float time)
        {
            this.time = time;
            int i = Region_num - 1;
            if (i * 100 + 300 > time && i * 100 < time) WorkHandler();
            else SleepHandler();
        }

        /// <summary>
        /// Режим работы региона
        /// </summary>
        private void WorkHandler()
        {
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
        /// Режим сна региона (дорабатывает запросы из очереди, но новые из своего региона не принимает)
        /// </summary>
        private void SleepHandler()
        {
            if (CheckClusters())
            {
                QueueAllocation(2);
            }
            for (int i = 0; i < Clusters.Count; i++)
            {
                ((cluster)Clusters[i]).query_time -= 0.01F;
            }
        }
        /// <summary>
        /// Функция устанавливает нормирущий коэффициент
        /// </summary>
        /// <param name="koeff">нормирующий коэффициент</param>
        public void Set_normalizing_factor(float koeff)
        {
            normalizing_factor = koeff;
        }
        /// <summary>
        /// Функция вычисления веса региона
        /// </summary>
        /// <returns>вес региона</returns>
        public float Weight_Compute()
        {
            //Wr = { [ P ]/[Li ni]}∙normalizing_factor;
            return  (float)(CURENT_TOTAL_W/(2*Clients.Count)) * normalizing_factor;
        }

        /// <summary>
        /// Признак активности региона
        /// </summary>
        /// <returns>true - если регион не активен</returns>
        public bool IsSleep()
        {
            int i = Region_num-1;
            if ((i * 100 + 300 > time && i * 100 < time) || local_queue.Count!=0) return false;
            else return true;
        }

        /// <summary>
        /// Отправляет первый элемент очереди РБН
        /// </summary>
        /// <returns>массив с информацией о запросе и клиенте</returns>
        public int[] GetQueryFromQueue()
        {
            return (int[])local_queue.Dequeue();
        }
        /// <summary>
        /// Отправляет последний элемент очереди РБН
        /// </summary>
        /// <returns>>массив с информацией о запросе и клиенте</returns>
        public int[] GetLastQueryFromQueue()
        {
            object first = local_queue.Peek();
            object current = null;
            while (true)
            {
                current = local_queue.Dequeue();
                if (local_queue.Count == 0) break;
                if (local_queue.Peek() == first) break;
                local_queue.Enqueue(current);
            }
            return (int[])current;
        }
        /// <summary>
        /// Добавляет новый запрос в очередь РБН
        /// </summary>
        /// <param name="arr">Информация о запросе и клиенте</param>
        public void SetNewQuery(int[] arr)
        {
            local_queue.Enqueue(arr);
        }

        /// <summary>
        /// проверяет заполненность очереди РБН
        /// </summary>
        /// <returns>true - если заполнена</returns>
        public bool QueueIsFull()
        {
            if (local_queue.Count < local_queue_length) return false;
            else return true;
        }

        /// <summary>
        /// проверяет пустоту очереди РБН
        /// </summary>
        /// <returns>true - если пустая</returns>
        public bool QueueIsEmpty()
        {
            if (local_queue.Count == 0) return true;
            else return false;
        }

        /// <summary>
        /// Проверяет возможность получения запроса из очереди РБН
        /// </summary>
        /// <returns>true - если можно</returns>
        public bool CanGetQuery()
        {
            if (!QueueIsEmpty())
            {
                int[] arr = (int[])local_queue.Peek();
                if (arr[2] == Region_num)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Получает ответ от сервера из другого региона
        /// </summary>
        /// <param name="arr">Информация о запросе и клиенте</param>
        /// <param name="anotherRegion">номер другого региона</param>
        public void ReciveAns(int[] arr, int anotherRegion)
        {
            TOTAL_QUERY_COUNT++;
            cluster_client client = (cluster_client)Clients[arr[1]];
            client.ReciveAns(time);
            //Номер региона;номер запроса в регионе;номер запроса;номер клиента;номер региона клиента; время задержки; время
            string output = String.Format("{0};{1};{2};{3};{4};{5:F2};{6:F2};{7}",
                anotherRegion, TOTAL_QUERY_COUNT, arr[0], arr[1], arr[2], client.recive_time, time, local_queue.Count);
            OutputHandler.WriteLine(output);
        }
    }
}
