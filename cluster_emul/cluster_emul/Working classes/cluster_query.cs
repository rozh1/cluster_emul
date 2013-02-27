using System;
using System.Collections.Generic;
using System.Text;
using cluster_emul.Utils;

namespace cluster_emul
{
    /// <summary>
    /// Класс генерации запроса к серверу
    /// </summary>
    class cluster_query
    {
        private float[] queries;    //массив запросов
        private float[] queries_weight;    //массив запросов

        /// <summary>
        ///  Конструктор класса
        /// </summary>
        public cluster_query()
        {
            queries_weight = new float[14];
            queries_weight[0] = 0.09F;
            queries_weight[1] = 0.10F;
            queries_weight[2] = 0.11F;
            queries_weight[3] = 0.21F;
            queries_weight[4] = 0.22F;
            queries_weight[5] = 0.23F;
            queries_weight[6] = 0.35F;
            queries_weight[7] = 0.39F;
            queries_weight[8] = 0.40F;
            queries_weight[9] = 0.41F;
            queries_weight[10] = 0.42F;
            queries_weight[11] = 0.44F;
            queries_weight[12] = 0.48F;
            queries_weight[13] = 1.00F;
            queries = new float[14];
            queries[0] = 0.17F;
            queries[1] = 0.18F;
            queries[2] = 0.2F;
            queries[3] = 0.37F;
            queries[4] = 0.38F;
            queries[5] = 0.4F;
            queries[6] = 0.62F;
            queries[7] = 0.68F;
            queries[8] = 0.7F;
            queries[9] = 0.72F;
            queries[10] = 0.73F;
            queries[11] = 0.77F;
            queries[12] = 0.83F;
            queries[12] = 1.75F;
        }

        /// <summary>
        /// Функция выдачи номера запроса
        /// </summary>
        /// <returns>номер запроса</returns>
        public int GenQueryNum()
        {
            return NextNum.Gen(13);
        }

        /// <summary>
        /// Функция выдачи номера запроса
        /// </summary>
        /// <param name="num">номер запроса</param>
        /// <returns>время выполенения запроса</returns>
        public float GetQueryByNum(int num)
        {
            return queries[num];
        }
        /// <summary>
        /// Функция выдачи веса запроса
        /// </summary>
        /// <param name="num">номер запроса</param>
        /// <returns>вес запроса</returns>
        public float GetQueryWeightByNum(int num)
        {
            //здесь можно добавить функцию расчёта веса для каждого ЗАПРОСА
            //пока взяли простой случай, когда вес == порядковому номеру
            return queries_weight[num];
        }

    }
}
