using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quick
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = NextInt();
            StringBuilder xuat = new StringBuilder();
            for (int i = 0; i < t; i++)
            {
                List<long> kw = new List<long>();
                long n = NextLong();
                long a = NextLong();
                long p = NextLong();
                int k = NextInt();
                long newa = a;
                for (long j = 0; j < n; j++)
                {
                    a = (a * newa) % p;
                    kw.Add(a);
                }

                QuickSort(kw, 0, kw.Count - 1, k);

                //for (int z = 0; z < kw.Count; z++)
                //{
                //    Console.WriteLine(kw[i]);
                //    Console.ReadLine();
                //}
                xuat.Append(kw[k - 1] + "\n");

            }
            Console.WriteLine(xuat);
            Console.ReadLine();
        }

        static public int Sort(List<long> ds, int left, int right, int k)
        {
            Random random = new Random();
            long pivot = ds[random.Next(left, right + 1)];
            while (true)
            {
                while (ds[left] < pivot)
                    left++;

                while (ds[right] > pivot)
                    right--;

                if (left < right)
                {
                    long temp = ds[right];
                    ds[right] = ds[left];
                    ds[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        static public void QuickSort(List<long> ds, int left, int right, int k)
        {
            if (left < right)
            {
                int pivot = Sort(ds, left, right, k);
                if (pivot == k)
                {
                    QuickSort(ds, left, pivot, k);
                }
                else
                {
                    if (pivot > k)
                        QuickSort(ds, left, pivot - 1, k);
                    if (pivot < k)
                        QuickSort(ds, pivot + 1, right, k);
                }
            }
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
