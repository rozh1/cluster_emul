using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace cluster_emul
{
    /// <summary>
    /// Управляющий класс работы балансировки
    /// </summary>
    class RegionsHandler
    {
        int RegionsCount;       //Количество регионов
        int ClientsCount;       //Количество клиентов в 1-м регионе
        int DB_capacity;        //Объем БД в 1-м объеме
        int ServersCount;       //Количество серверов в 1-м регионе
        ArrayList Regions;      //Региональные балансировщики
        float time = 0;         //Модельное мремя
        int BalanceType = 0;    //Тип балансировки

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="RegionsCount">Количество регионов</param>
        /// <param name="ClientsCount">Количество клиентов в 1-м регионе</param>
        /// <param name="ServersCount">Количество серверов в 1-м регионе</param>
        /// <param name="DB_capacity">Объем БД в 1-м объеме</param>
        /// <param name="BalanceType">Тип балансировки</param>
        public RegionsHandler(int RegionsCount, int ClientsCount, int ServersCount, int DB_capacity, int BalanceType)
        {
            this.RegionsCount = RegionsCount;
            this.ClientsCount = ClientsCount;
            this.ServersCount = ServersCount;
            this.DB_capacity = DB_capacity;
            this.BalanceType = BalanceType;
            Regions = new ArrayList(RegionsCount);
            InitRegions();
        }

        /// <summary>
        /// Инициализация регионов
        /// </summary>
        void InitRegions()
        {
            for (int i = 0; i < RegionsCount; i++)
            {
                int k = i + 1;
                RBN rbn = new RBN(k, k * ClientsCount, k * ClientsCount, k * ServersCount, k * DB_capacity);
                rbn.Set_normalizing_factor((float)(RegionsCount * ClientsCount /rbn.db_capacity));
                Regions.Add(rbn);
            }
        }

        /// <summary>
        /// Функция - обработчик
        /// </summary>
        public void Work()
        {
            time = 200;
            for (int k = 0; k < 2; k++)
            {
                Console.WriteLine("Сутки №" + (k + 1));
                while (time < (RegionsCount - 1) * 100 + 300)
                {
                    time += 0.01F;
                    switch (BalanceType)
                    {
                        case 0:
                            NotBalancedHandler();
                            break;
                        case 1:
                            DeCentralizedHandler();
                            break;
                    }
                }
                time = 0;
            }
        }

        /// <summary>
        /// Функция реализует работу без балансировщика
        /// </summary>
        public void NotBalancedHandler()
        {

            for (int i = 0; i < RegionsCount; i++)
            {
                RBN rbn = (RBN)Regions[i];
                if (i * 100 + 300 > time && i * 100 < time) rbn.WorkHandler(time);
                else rbn.SleepHandler(time);
            }
        }

        /// <summary>
        /// Функция реализует работу децентрализованной балансировки
        /// </summary>
        public void DeCentralizedHandler()
        {

            for (int i = 0; i < RegionsCount; i++)
            {
                RBN rbn = (RBN)Regions[i];
                if (i * 100 + 300 > time && i * 100 < time) rbn.WorkHandler(time);
                else rbn.SleepHandler(time);
                if (rbn.IsSleep())
                {
                    RBN another_rbn = MaxWeightRegion(i);
                    if (!rbn.QueueIsFull() && !another_rbn.QueueIsEmpty())
                    {
                        rbn.SetNewQuery(another_rbn.GetQueryFromQueue());
                    }
                }
                if (rbn.AnotherQueries.Count > 0)
                {
                    for (int k = 0; k < rbn.AnotherQueries.Count; k++)
                    {
                        int[] arr = (int[])rbn.AnotherQueries[k];
                        ((RBN)Regions[arr[2]-1]).ReciveAns(arr,rbn.Region_num);
                    }
                    rbn.AnotherQueries.Clear();
                }
            }
        }

        /// <summary>
        /// Выбирает регион с максимальным весом очереди
        /// </summary>
        /// <param name="j">номер главного региона</param>
        /// <returns>регион с максимальным весом</returns>
        RBN MaxWeightRegion(int j)
        {
            RBN maxWeight = (RBN)Regions[RegionsCount-1-j];
            for (int i = 0; i < RegionsCount; i++)
            {
                if (i != j)
                {
                    RBN rbn = (RBN)Regions[i];
                    if (maxWeight.Weight_Compute() < rbn.Weight_Compute())
                        maxWeight = rbn;
                }
            }
            return maxWeight;
        }
    }
}
