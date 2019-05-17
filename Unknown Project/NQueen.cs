using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unknown_Project
{
    class NQueen
    {
        public static int Count = 0;
        public static List<List<int>> QueensPlace = new List<List<int>>();
        static bool Hit2(int[] Places)
        {
            for (int i = 0; i < Places.Length - 1; i++)
                for (int j = i + 1; j < Places.Length; j++)
                    if (Places[i] == Places[j] || j - i == Places[j] - Places[i] || Places[i] - Places[j] == j - i)
                        return false;

            return true;
        }
        static List<int> Ty(int[] n)
        {
            List<int> ret = new List<int>();
            for (int i = 0; i < n.Length; i++)
                ret.Add(n[i]);
            return ret;
        }
        public static void A2(int n, int[] l, int k)
        {
            Application.DoEvents();
            if (k == n && Hit2(l))
            {
                Count++;
                List<int> m = Ty(l);
                Application.DoEvents();
                QueensPlace.Add(m);
            }
            else
                for (int i = k; i < n; i++)
                {
                    Swap(ref l[i], ref l[k]);
                    A2(n, l, k + 1);
                    Application.DoEvents();
                    Swap(ref l[i], ref l[k]);
                }
        }
        static void Swap(ref int n1, ref int n2)
        {
            int h = n1;
            n1 = n2;
            n2 = h;
        }
    }
}
