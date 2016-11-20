using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = NextInt();
            int m = NextInt();
            string ten = "";
            string ho = "";
            string tenlot = "";
            string fullname = "";
            List<sinhvien> dssinhvien = new List<sinhvien>();
            Dictionary<string, int> dicsv = new Dictionary<string, int>();
            StringBuilder xuat = new StringBuilder();
            List<int> kq = new List<int>();


            //Sap xep danh sach nhap
            for (int i = 0; i < n; i++)
            {
                fullname = Console.ReadLine();
                string[] tachra = fullname.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                int count = tachra.Count();
                //fullname = nhap.Split(' ');
                #region
                if (count == 1)
                {
                    ho = "";
                    ten = tachra[0];
                    tenlot = "";
                    sinhvien a = new sinhvien(ho, ten, tenlot, fullname);
                    dssinhvien.Add(a);
                }

                if (count == 2)
                {
                    ho = tachra[0];
                    ten = tachra[1];
                    tenlot = "";
                    sinhvien a = new sinhvien(ho, ten, tenlot, fullname);
                    dssinhvien.Add(a);
                }

                if (count == 3)
                {
                    ho = tachra[0];
                    tenlot = tachra[1];
                    ten = tachra[2];
                    sinhvien a = new sinhvien(ho, ten, tenlot, fullname);
                    dssinhvien.Add(a);
                }

                if (count > 3)
                {
                    ho = tachra[0];
                    ten = tachra[count - 1];
                    tenlot = "";
                    for (int dem = 1; dem < tachra.Count() - 1; dem++)
                    {
                        tenlot = tenlot + tachra[dem] + " ";
                    }
                    sinhvien a = new sinhvien(ho, ten, tenlot, fullname);
                    dssinhvien.Add(a);
                }
                #endregion

            }
            dssinhvien.Sort();

            //gan fullname vao dic
            for (int j = 0; j < dssinhvien.Count; j++)
            {
                int id = j + 1;
                dicsv.Add(dssinhvien[j].fullname, id);
            }

            //tim kiem trong dic da tao
            for (int i = 0; i < m; i++)
            {
                string tim = Console.ReadLine();
                if (dicsv.ContainsKey(tim))
                {
                    xuat.Append(dicsv[tim] + "\n");
                }
                else
                    xuat.AppendLine("-1");

                //xuat.AppendLine(id + "");
            }
            Console.Write(xuat);
            Console.ReadLine();

        }

        class sinhvien : IComparable<sinhvien>
        {
            public string ho = " ";
            public string ten = " ";
            public string tenlot = " ";
            public string fullname = " ";
            public sinhvien(string ho, string ten, string tenlot, string fullname)
            {
                this.ho = ho;
                this.ten = ten;
                this.tenlot = tenlot;
                this.fullname = fullname;
            }
            public int CompareTo(sinhvien other)
            {
                if (this.ten.CompareTo(other.ten) == 0)
                {
                    if (this.ho.CompareTo(other.ho) == 0)
                    {
                        return this.tenlot.CompareTo(other.tenlot);
                    }
                    else
                    {
                        return this.ho.CompareTo(other.ho);
                    }
                }
                return this.ten.CompareTo(other.ten);
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
