using System;
using System.Collections;

namespace cluster_emul
{
    /// <summary>
    /// Управляющий класс работы балансировки
    /// </summary>
    class RegionsHandler
    {
        int RegionsCount;                   //Количество регионов
        int ClientsCount;                   //Количество клиентов в 1-м регионе
        int DB_capacity;                    //Объем БД в 1-м объеме
        int ServersCount;                   //Количество серверов в 1-м регионе
        public ArrayList Regions;           //Региональные балансировщики
        float time = 720;                   //Модельное мремя
        int BalanceType = 0;                //Тип балансировки
        int ModelDays = 0;                  //Количество модельных суток
        public event RegionIsActive RIA;    //Событие активности региона
        public event QueueStatus QS;        //Событие передачи статуса очереди
        public event QueryCountStatus QCS;  //Событие передачи количества выполенных 
                                            //запросов
        public event TimeStatus TS;         //Событие передачи текущего модельного 
                                            //времени
        public event TimeStatus DaysTS;     //Событие передачи текущих суток
        public event QueueWeightStatus QWS; //Событие передачи текущего веса очереди
        public event GeneralRegionStatus GR;//Событие передачи номера главного региона
        int Throttle = 10;                  //Пропуск итераций перед уведомлением
        int ThrottleCount = 0;              //Количество прощенных итераций
        int WeightComputeMode = 0;          //Вариант формулы для вычисления веса 
                                            //очереди
        int GeneralRNBnum = 0;              //Номер главного региона
        int delta_count;                    //Количество периодов времени
        bool startFromZero = false;         //Признак начала с времени = 0;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="RegionsCount">Количество регионов</param>
        /// <param name="ClientsCount">Количество клиентов в 1-м регионе</param>
        /// <param name="ServersCount">Количество серверов в 1-м регионе</param>
        /// <param name="DB_capacity">Объем БД в 1-м объеме</param>
        /// <param name="BalanceType">Тип балансировки</param>
        public RegionsHandler(int RegionsCount, int ClientsCount, int ServersCount,
            int DB_capacity, int BalanceType)
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
            delta_count = 2 + RegionsCount;
            float delta = 1440.0F / delta_count;
            time = RegionsCount * delta;
            for (int i = 0; i < RegionsCount; i++)
            {
                int k = i + 1;
                float start_time = i * delta;
                RBN rbn = new RBN(k, k * ClientsCount, k * ClientsCount,
                    k * ServersCount, k * DB_capacity, start_time, start_time + time);
                rbn.Set_normalizing_factor((float)(RegionsCount * ClientsCount) / 
                    rbn.db_capacity);
                Regions.Add(rbn);
            }
            time = 720;
        }

        /// <summary>
        /// Устанавливает значение модельного времени в 0
        /// </summary>
        public void SetTimeToZero()
        {
            time = 0;
            startFromZero = true;
            for (int i = 0; i < RegionsCount; i++)
            {
                RBN rbn = (RBN)Regions[i];
                rbn.ClearQueue();
            }
        }

        /// <summary>
        /// Функция - обработчик
        /// </summary>
        /// <returns>количество модельных суток</returns>
        public int Work()
        {
            time += 0.01F;
            ThrottleCount++;
            switch (BalanceType)
            {
                case 0:
                    WeightComputeMode = 0;
                    NotBalancedHandler();
                    break;
                case 1:
                    WeightComputeMode = 1;
                    DeCentralizedHandler();
                    break;
                case 2:
                    WeightComputeMode = 0;
                    CentralizedHandler();
                    break;
                case 3:
                    WeightComputeMode = 0;
                    DeCentralizedHandlerType2();
                    break;
                case 4:
                    WeightComputeMode = 1;
                    CentralizedHandlerType2();
                    break;

            }
            if (startFromZero)
            {
                if (time >= 1439.99F)
                {
                    if (DaysTS != null) DaysTS(++ModelDays);
                }
            }
            else
            {
                if (time >= 719.99F && time <= 720.0F)
                {
                    if (DaysTS != null) DaysTS(++ModelDays);
                }
            }
            if (time >= 1439.99F)
            {
                time = 0;
            }
            if (time * 100 % 100 > 99 && time * 100 % 100 < 100 && TS != null)
                TS((int)time);
            if (Throttle == ThrottleCount) ThrottleCount = 0;
            return ModelDays;
        }

        /// <summary>
        /// Функция реализует работу без балансировщика
        /// </summary>
        void NotBalancedHandler()
        {
            for (int i = 0; i < RegionsCount; i++)
            {
                RBN rbn = (RBN)Regions[i];
                rbn.Work(time);
                if (ThrottleCount == Throttle)
                {
                    if (RIA != null) RIA(rbn.Region_num, !rbn.IsSleep());
                    if (QS != null) QS(rbn.Region_num, rbn.GetQueueCount());
                    if (QCS != null) QCS(rbn.Region_num, rbn.TOTAL_QUERY_COUNT);
                    if (QWS != null) QWS(rbn.Region_num, rbn.Weight_Compute());
                    if (GR != null) GR(GeneralRNBnum);
                }
            }
        }

        /// <summary>
        /// Функция реализует работу децентрализованной балансировки
        /// </summary>
        void DeCentralizedHandler()
        {
            NotBalancedHandler();
            for (int i = 0; i < RegionsCount; i++)
            {
                RBN rbn = (RBN)Regions[i];
                if (rbn.IsSleep())
                {
                    RBN another_rbn = MaxWeightRegion(i);
                    if (another_rbn != null)
                    {
                        if (rbn.QueueIsEmpty() && another_rbn.CanGetQuery())
                        {
                            rbn.SetNewQuery(another_rbn.GetQueryFromQueue());
                        }
                    }
                }
                SendAns(rbn);
            }
        }

        /// <summary>
        /// Выбирает регион с максимальным весом очереди
        /// </summary>
        /// <param name="j">номер главного региона</param>
        /// <returns>регион с максимальным весом</returns>
        RBN MaxWeightRegion(int j)
        {
            ArrayList NotSleepRegions = new ArrayList(RegionsCount);
            for (int i = 0; i < RegionsCount; i++)
            {
                RBN rbn = (RBN)Regions[i];
                if (!rbn.IsSleep()) NotSleepRegions.Add(rbn);
            }
            if (NotSleepRegions.Count > 0)
            {
                RBN maxWeight = (RBN)NotSleepRegions[0];
                for (int i = 1; i < NotSleepRegions.Count; i++)
                {
                    RBN rbn = (RBN)NotSleepRegions[i];
                    if (maxWeight.Weight_Compute(WeightComputeMode) < 
                        rbn.Weight_Compute(WeightComputeMode))
                        maxWeight = rbn;
                }
                return maxWeight;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Функция реализует работу централизованной балансировки
        /// </summary>
        void CentralizedHandler()
        {
            NotBalancedHandler();
            int[] dev = deviation_average_weight(compute_mean_weigth());
            for (int i = 0; i < RegionsCount; i++)
            {
                RBN rbn_i = (RBN)Regions[i];
                for (int j = 0; (j < RegionsCount); j++)
                {
                    if (i != j)
                    {
                        RBN rbn_j = (RBN)Regions[j];
                        if (dev[i] > dev[j] && !rbn_j.QueueIsFull() && 
                            !rbn_i.QueueIsEmpty())
                        {
                            rbn_j.SetNewQuery(rbn_i.GetLastQueryFromQueue());
                        }
                        if (dev[i] < dev[j] && !rbn_i.QueueIsFull() && 
                            !rbn_j.QueueIsEmpty())
                        {
                            rbn_i.SetNewQuery(rbn_j.GetLastQueryFromQueue());
                        }
                    }
                }
                SendAns(rbn_i);
            }
        }

        /// <summary>
        /// Функция вычисляет среднее значение весов регионов
        /// </summary>
        /// <returns>среднее значение весов регионов </returns>
        float compute_mean_weigth()
        {
            float s = 0;
            for (int i = 0; i < RegionsCount; i++)
            {
                RBN rbn = (RBN)Regions[i];
                s += rbn.Weight_Compute(WeightComputeMode);
            }
            return s / RegionsCount;
        }

        /// <summary>
        /// Функция вычисляет отклонение веса региона от среднего веса
        /// </summary>
        /// <param name="mean">среднее значение весов регионов</param>
        /// <returns>массив целых чисел для каждого региона: 
        /// 0 - "-" девиация 1 - "+" девиация</returns>
        int[] deviation_average_weight(float mean)
        {
            int[] deviation = new int[RegionsCount];
            for (int i = 0; i < RegionsCount; i++)
            {
                RBN rbn = (RBN)Regions[i];
                if (rbn.Weight_Compute(WeightComputeMode) > mean)
                {
                    deviation[i] = 1;
                }
                else
                {
                    deviation[i] = 0;
                }
            }
            return deviation;
        }

        /// <summary>
        /// При наличии выполненных запросов для другого региона,
        /// они будут отосланы в свои регионы
        /// </summary>
        /// <param name="rbn">рабочий регион</param>
        void SendAns(RBN rbn)
        {
            if (rbn.AnotherQueries.Count > 0)
            {
                for (int k = 0; k < rbn.AnotherQueries.Count; k++)
                {
                    int[] arr = (int[])rbn.AnotherQueries[k];
                    ((RBN)Regions[arr[2] - 1]).ReciveAns(arr, rbn.Region_num);
                }
                rbn.AnotherQueries.Clear();
            }
        }

        /// <summary>
        /// Устанавливает значение пропуска итераций для обновления окон статуса
        /// </summary>
        /// <param name="val">множитель количества пропусков</param>
        public void SetThrottle(int val)
        {
            if (val == 0) Throttle = 1;
            else Throttle = 10 * val;
        }

        /// <summary>
        /// Функция реализует работу децентрализованной балансировки 
        /// c элементами централизованной
        /// </summary>
        void DeCentralizedHandlerType2()
        {
            NotBalancedHandler();
            if (GeneralRegions())
            {
                int[] dev = deviation_average_weight(compute_mean_weigth());
                for (int i = 0; i < RegionsCount; i++)
                {
                    RBN rbn_i = (RBN)Regions[i];
                    for (int j = 0; (j < RegionsCount); j++)
                    {
                        if (i != j)
                        {
                            RBN rbn_j = (RBN)Regions[j];
                            if (dev[i] > dev[j] && !rbn_j.QueueIsFull() && 
                                !rbn_i.QueueIsEmpty())
                            {
                                rbn_j.SetNewQuery(rbn_i.GetLastQueryFromQueue());
                            }
                            if (dev[i] < dev[j] && !rbn_i.QueueIsFull() && 
                                !rbn_j.QueueIsEmpty())
                            {
                                rbn_i.SetNewQuery(rbn_j.GetLastQueryFromQueue());
                            }

                        }
                    }
                    SendAns(rbn_i);
                }
            }
            for (int i = 0; i < RegionsCount; i++)
            {
                RBN rbn = (RBN)Regions[i];
                if (rbn.IsSleep() && !GeneralRegions()) rbn.general = true;
                SendAns(rbn);
            }
        }

        /// <summary>
        /// Возращает true если есть главный регион
        /// </summary>
        /// <returns>true если есть главный регион</returns>
        bool GeneralRegions()
        {
            for (int i = 0; i < RegionsCount; i++)
            {
                RBN rbn = (RBN)Regions[i];
                if (rbn.general)
                {
                    GeneralRNBnum = rbn.Region_num;
                    return true;
                }
            }
            GeneralRNBnum = 0;
            return false;
        }

        /// <summary>
        /// Функция реализует работу второго варианта централизованной балансировки
        /// </summary>
        void CentralizedHandlerType2()
        {
            NotBalancedHandler();
            for (int i = 0; i < RegionsCount; i++)
            {
                RBN rbn = (RBN)Regions[i];
                if (rbn.IsSleep())
                {
                    RBN another_rbn = MaxWeightRegion(i);
                    if (another_rbn != null)
                    {
                        if (!rbn.QueueIsFull() && another_rbn.CanGetQuery())
                        {
                            rbn.SetNewQuery(another_rbn.GetQueryFromQueue());
                        }
                    }
                }
                SendAns(rbn);
            }
        }
    }
}
