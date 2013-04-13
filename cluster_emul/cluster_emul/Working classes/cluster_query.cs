using cluster_emul.Utils;

namespace cluster_emul
{
    /// <summary>
    /// Класс генерации запроса к серверу
    /// </summary>
    static class cluster_query
    {
        static private float[] queries = new float[14]          //массив запросов
            {0.17F, 0.18F, 0.2F, 0.37F, 0.38F, 0.4F, 0.62F, 
             0.68F, 0.7F, 0.72F, 0.73F, 0.77F, 0.83F, 1.75F};

        static private float[] queries_weight = new float[14]   //массив весов запросов
            {0.09F, 0.10F, 0.11F, 0.21F, 0.22F, 0.23F, 0.35F,
             0.39F, 0.40F, 0.41F, 0.42F, 0.44F, 0.48F, 1.00F};

        /// <summary>
        /// Функция выдачи номера запроса
        /// </summary>
        /// <returns>номер запроса</returns>
        static public int GenQueryNum()
        {
            return NextNum.Gen(13);
        }

        /// <summary>
        /// Функция выдачи номера запроса
        /// </summary>
        /// <param name="num">номер запроса</param>
        /// <returns>время выполенения запроса</returns>
        static public float GetQueryByNum(int num)
        {
            return queries[num];
        }

        /// <summary>
        /// Функция выдачи веса запроса
        /// </summary>
        /// <param name="num">номер запроса</param>
        /// <returns>вес запроса</returns>
        static public float GetQueryWeightByNum(int num)
        {
            return queries_weight[num];
        }

    }
}
