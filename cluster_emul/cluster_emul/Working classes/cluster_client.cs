using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cluster_emul
{
    /// <summary>
    /// Класс клиента
    /// </summary>
    class cluster_client
    {
        public int num;             //номер клиента
        public int num_region;      //номер региона
        public int num_request;     //номер текущего запроса
        private cluster_query cq;   //запросы
        public bool request_sended; //флаг посылки запроса
        public int query_col;       //количество обработанных запросов клиента
        private int query_weight;   //вес текущего запроса
        private float send_time;    //Время отправки запроса
        public float recive_time;   //Время задержки
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="Num">номер клиента</param>
        /// <param name="Num_reg">номер региона</param>
        public cluster_client(int Num, int Num_reg)
        {
            num = Num;
            num_region = Num_reg;
            cq = new cluster_query();
            request_sended = false;
            query_col = 0; query_weight = 0;
        }

        /// <summary>
        /// Функция определения нового запроса
        /// </summary>
        /// <param name="time">Текущее модельное время</param>
        public void NewRequest(float time)
        {
            if (!request_sended)
            {
                num_request = cq.GenQueryNum();
                query_weight = cq.GetQueryWeightByNum(num_request);
                request_sended = true;
                send_time = time;
            }
        }

        /// <summary>
        /// Функция получения ответа от сервера
        /// </summary>
        /// <param name="time">Текущее модельное время</param>
        /// <returns>время ожидания ответа</returns>
        public void ReciveAns(float time)
        {
            if (time < send_time) time += 500;
            recive_time = time - send_time;
            request_sended = false;
            query_col++;
        }

        /// <summary>
        /// <para>Возвращает параметры клиента</para>
        /// <para>номер запроса, номер клиента, номер региона</para>
        /// </summary>
        /// <returns>массив int (номер запроса, номер клиента, номер региона)</returns>
        public int[] GetParametrs()
        {
            int[] arr = new int[3];
            arr[0] = num_request;
            arr[1] = num;
            arr[2] = num_region;
            return arr;
        }
        /// <summary>
        ///Возвращает вес текущего запроса
        /// </summary>
        /// <returns>вес текущего запроса</returns>
        public int GetWieghtQuery()
        {
            return query_weight;
        }
    }
}
