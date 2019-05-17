using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unknown_Project
{
    class Graph
    {
        public static int[] Best;
        public static string[] Ways;
        public static int[,] L, BestWays;
        public static bool[] P;
        public static long Count = 0;

        public static int[,] Floyd(int n, int[,] W,ListBox LB,out string[,] Ways,out int Val)
        {
            Ways = new string[n, n];
            int[,] D = new int[n, n];
            Array.Copy(W, D, n * n);
            for (int i = 0; i < n; i++)
                for (int j1 = 0; j1 < n; j1++)
                    if (j1 != i)
                    {
                        for (int j2 = 0; j2 < n; j2++)
                        {
                            int New = D[j1, i] + D[i, j2];
                            if (D[j1, j2] > New)
                            {
                                Ways[j1, j2] = ">" + i + Ways[j1, i] + Ways[i, j2];
                                D[j1, j2] = New;
                            }
                        }
                    }
            
            PutFE(Ways, n);
            Ins(D, Ways, n, LB);
            Val = D[0, n-1];
            return D;
        }
        static void PutFE(string[,] O,int n)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    O[i, j] = i + O[i, j] + ">" + j;
        }
        static void Ins(int[,] W,string[,] Way,int n,ListBox Lb)
        {
            Lb.Items.Clear();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    Lb.Items.Add(Way[i, j] + "\t" + W[i, j]);
        }
        static void FBW(int[,] L, int n, int Current, int Cost, string Way, int Index)
        {
            if (Index <= n)
            {
                if (Index != 1 && (Best[Current] > Cost || Best[Current] == -1))
                {
                    Ways[Current] = Way;
                    Best[Current] = Cost;
                }
                for (int i = 0; i < n; i++, Count++)
                    if (L[Current, i] != -1 /*&& !P[i]*/)
                    {
                        P[i] = true;
                        FBW(L, n, i, Cost + L[Current, i], Way + " > " + i, Index + 1);
                        P[i] = false;
                    }
            }
        }
        static void PutToAll(int[] L, int Data)
        {
            for (int i = 0; i < L.Length; i++)
                L[i] = Data;
        }
        static void Fill2D(int[,] L, int n, int Data)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    L[i, j] = Data;
        }
        public static void InsertWays(string S,int n,ref int[,] W)
        {

            string[] In = S.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            W = new int[n, n];
            Fill2D(W, n, 1000);
            for (int i = 0; i < n; i++)
                W[i, i] = 0;
            for (int i = 0; i < In.Length; i++)
            {
                int[] Ln = Array.ConvertAll((In[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)), int.Parse);
                W[Ln[0], Ln[1]] = Ln[2];
            }
        }
        public static void Start(int n,ListBox LB)
        {
            LB.Items.Clear();
            BestWays = new int[n,n];
            //Fill2D(BestWays)
            for (int i = 0; i < n; i++, Count++)
            {
                P = new bool[n];
                Best = new int[n];
                Ways = new string[n];
                PutToAll(Best, -1);

                P[i] = true;
                FBW(L, n, i, 0, " " + i, 1);
                P[i] = false;
                for (int j = 0; j < Ways.Length; j++)
                {
                    if (i == j)
                        LB.Items.Add(" " + i + " > " + i + " = " + L[i, j]);
                    else
                    {
                        BestWays[i, j] = Best[j];
                        LB.Items.Add(Ways[j] + " = " + Best[j]);
                    }
                }
            }
        }
    }
}
