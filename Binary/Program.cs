using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = NextInt();
            int m = NextInt();
            List<int> dsach = new List<int>();
            List<int> search = new List<int>();
            StringBuilder xuat = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                dsach.Add(NextInt());
            }
            for (int j = 0; j < m; j++)
            {
                search.Add(NextInt());
            }

            dsach.Sort();


            foreach (var item in search)
            {
                bool th = false;
                int l = 0;
                int r = n - 1;
                int k = 0;
                while (l <= r)
                {
                    k = (l + r) / 2;
                    if (item == dsach[k])
                    {
                        xuat.Append(checkback(k, item, dsach) + " ");
                        th = true;
                        break;
                    }
                    else
                    {
                        if (item < dsach[k])
                            r = k - 1;
                        else
                            l = k + 1;
                    }

                }

                if (th == false)
                    xuat.Append("-1 ");
            }
            Console.WriteLine(xuat);
            Console.ReadLine();
        }

        public static int checkback(int point, int value, List<int> dsach)
        {
            if (point == 0)
                return 0;
            if (dsach[point - 1] == value)
            {
                return checkback(point - 1, value, dsach);
            }
            else
                return point;
        }
        #region Input wrapper
        static int s_index = 0;
        static string[] s_tokens;
        private static string Next()
        {
            while (s_tokens == null || s_index == s_tokens.Length)
            {
                s_tokens = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                s_index = 0;
            }
            return s_tokens[s_index++];
        }
        private static int NextInt()
        {
            return Int32.Parse(Next());
        }
        private static long NextLong()
        {
            return Int64.Parse(Next());
        }
        #endregion
    }
}
