using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = NextInt();
            List<int> ds = new List<int>();
            for (int i = 0; i < n; i++)
            {
                ds.Add(NextInt());
            }

            Di_Re(ds, n);
            foreach (var item in ds)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        public static void Merge(List<int> ds, List<int> left, List<int> right, int left_elements, int right_elements)
        {
            int i = 0; //list start
            int l = 0; //list left
            int r = 0; //list right
                       // int temp = 0;

            while (l < left_elements && r < right_elements)
            {
                if (left[l] <= right[r])
                {
                    //  temp = ds[i];
                    ds[i] = left[l];
                    //  left[l] = temp;
                    l++;
                }
                else
                {
                    ds[i] = right[r];
                    r++;
                }
                i++;

            }
            while (l < left_elements)
            {
                ds[i] = left[l];
                l++;
                i++;
            }
            while (r < right_elements)
            {
                ds[i] = right[r];
                i++;
                r++;
            }
        }

        public static void Di_Re(List<int> ds, int n) // Divide & Recursive
        {
            if (n < 2)
                return;
            else
            {
                List<int> left = new List<int>();
                List<int> right = new List<int>();
                int mid = n / 2;
                for (int i = 0; i < mid; i++)
                {
                    left.Add(ds[i]);
                }

                for (int j = mid; j < n; j++)
                {
                    right.Add(ds[j]);
                }
                Di_Re(left, mid);
                Di_Re(right, n - mid);
                Merge(ds, left, right, mid, n - mid);
                left.Clear();
                right.Clear();
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
