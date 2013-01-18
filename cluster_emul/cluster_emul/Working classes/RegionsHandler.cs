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
        ArrayList Regions;      //Региональные балансировщики
        float time = 0;         //Модельное мремя

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="RegionsCount">Количество регионов</param>
        /// <param name="ClientsCount">Количество клиентов в 1-м регионе</param>
        public RegionsHandler(int RegionsCount,int ClientsCount)
        {
            this.RegionsCount = RegionsCount;
            this.ClientsCount = ClientsCount;
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
                RBN rbn = new RBN(k, k * 10, k * ClientsCount, k * 3);
                Regions.Add(rbn);
            }
        }

        /// <summary>
        /// Функция - обработчик
        /// </summary>
        public void Work()
        {
            time = 200;
            for (int k = 0; k < 10; k++)
            {
                Console.WriteLine("Сутки №" + (k + 1));
                while (time < (ClientsCount-1) * 100 + 300)
                {
                    time += 0.01F;
                    for (int i = 0; i < RegionsCount; i++)
                    {
                        RBN rbn = (RBN)Regions[i];
                        if (i * 100 + 300 > time && i * 100 < time) rbn.WorkHandler(time);
                        else rbn.SleepHandler(time);
                    }
                }
                time = 0;
            }
        }
    }
}
