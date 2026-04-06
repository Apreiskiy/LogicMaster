using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Master.StaticData
{
    public static class MinimizeData
    {
        public static string? Implicants {  get; set; }
        public static int Limit { get; set; }
        public static int[]? AllM { get; set; }
        public static int[]? All { get; set; }
        public static int[]? Impls { get; set; }
        public static int[]? ImplsM { get; set; }
        public static int[]? First { get; set; }
        public static bool[]? FirstM { get; set; }
        public static int[]? Second { get; set; }
        public static int[]? Red { get; set; }
        public static int AllCount { get; set; }
        public static int ImplsCount { get; set; }
        public static int FirstCount { get; set; }
        public static int SecondCount { get; set; }

        /// <summary>
        /// Данные для Таблицы коэффициентов
        /// </summary>
        public static int[]? Coefs {  get; set; }
        public static int[][]? Flags { get; set; }

        public static string? MinPokritie { get; set; }

        public static int Kol(int m)
        {
            int k = 0;
            for (int i = 0; i < TruthTableData.CountX; i++)
            {
                if (Convert.ToBoolean(m & (1 << i)))
                {
                    k++;
                }
            }
            return k;
        }

        public static int Number(int a, int b)
        {
            int c = 0;
            int k = 0;
            for (int i = 0; i < TruthTableData.CountX; i++)
            {
                if ((a & (1 << i)) != 0)
                {
                    if ((b & (1 << i)) != 0)
                    {
                        c |= (1 << k);
                    }
                    k++;
                }
            }
            return c;
        }

    }
}
