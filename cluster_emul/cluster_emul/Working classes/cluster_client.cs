using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cluster_emul
{
    /* Класс клиента
     */
    class cluster_client
    {
        public int num;             //номер клиента
        public int num_region;      //номер региона
        public int num_request;     //номер текущего запроса
        private cluster_query cq;   //запросы
        public bool request_sended; //флаг посылки запроса

        /* Конструктор класса
         * Входные параметры:
         *  int Num - номер клиента
         *  int Num_reg - номер региона
         */
        public cluster_client(int Num, int Num_reg)
        {
            num = Num;
            num_region = Num_reg;
            cq = new cluster_query();
            request_sended = false;
        }

        /* Функция определения нового запроса
         */
        public void NewRequest()
        {
            if (!request_sended)
            {
                num_request = cq.GenQueryNum();
                request_sended = true;
            }
        }

        /* Функция получения ответа от сервера
         */
        public void ReciveAns()
        {
            request_sended = false;
        }
    }
}
