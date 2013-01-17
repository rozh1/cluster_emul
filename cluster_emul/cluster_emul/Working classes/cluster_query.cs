using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace cluster_emul
{
    /// <summary>
    /// Класс генерации запроса к серверу
    /// </summary>
    class cluster_query
    {
        private float[] queries;    //массив запросов
        private Random rand;        //великий русский рандом

        /// <summary>
        ///  Конструктор класса
        /// </summary>
        public cluster_query()
        {
            rand = new Random();
            queries = new float[14];
            queries[0] = 0.09F;
            queries[1] = 0.10F;
            queries[2] = 0.11F;
            queries[3] = 0.21F;
            queries[4] = 0.22F;
            queries[5] = 0.23F;
            queries[6] = 0.35F;
            queries[7] = 0.39F;
            queries[8] = 0.40F;
            queries[9] = 0.41F;
            queries[10] = 0.42F;
            queries[11] = 0.44F;
            queries[12] = 0.48F;
            queries[13] = 1.00F;
        }

        /// <summary>
        /// Функция выдачи номера запроса
        /// </summary>
        /// <returns>номер запроса</returns>
        public int GenQueryNum()
        {
            return (int)(13*rand.NextDouble());
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

    }
}
