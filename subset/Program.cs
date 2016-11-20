using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubSet
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = NextInt();
            List<string> nhap = new List<string>();
            List<string> chuoi = new List<string>();
            List<int> bit = new List<int>();
            StringBuilder kqht = new StringBuilder();
            StringBuilder kw = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                nhap.Add(Next());

                bit.Add(0);
                chuoi.Add("");
            }

            double kq = Math.Pow(2, n) - 1;
            int ketqua = int.Parse(kq.ToString());
            Console.WriteLine(ketqua);

            for (int j = ketqua; j > 0; j--)
            {
                kqht = new StringBuilder();
                for (int i = nhap.Count - 1; i >= 0; i--)
                {
                    if (bit[i] == 0)
                    {
                        bit[i] = 1;
                        chuoi[i] = nhap[i];
                        break;

                    }
                    else
                    {
                        bit[i] = 0;
                        chuoi[i] = "";
                    }
                }
                foreach (var item in chuoi)
                {
                    if (item != "")
                        kqht.Append(item + " ");
                }
                kw.Append(kqht + "\n");

            }
            Console.Write(kw);
            Console.ReadKey();
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
