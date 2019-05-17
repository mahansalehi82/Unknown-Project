using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

public class Maze
{
    public static List<List<List<int>>> l = new List<List<List<int>>>();
    public static List<int> MovesCount = new List<int>();
    public static int count = 0, MC = 0;

    public static int[,] Way, WayBackUp;
    static int[] PossibleWaysW = new int[8] { 1, 1, 0, -1, 1, 0, -1, -1 };
    static int[] PossibleWaysH = new int[8] { 1, 0, 1, 1, -1, -1, 0, -1 };
    static void GetWay(out int n, out int k)
    {
        n = int.Parse(Console.ReadLine());
        k = int.Parse(Console.ReadLine());
        Way = new int[n, k];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < k; j++)
            {
                Console.WriteLine("[" + i + "," + j + "] = ?");
                Way[i, j] = int.Parse(Console.ReadLine());

            }
        }
    }
    static List<List<int>> Make2DList(int[,] Input, int w, int h)
    {
        MovesCount.Add(0);
        List<List<int>> ret = new List<List<int>>();
        for (int i = 0; i < w; i++)
        {
            List<int> LoopList = new List<int>();
            for (int j = 0; j < h; j++)
            {
                if (Input[i, j] == 2)
                    MovesCount[count]++;
                LoopList.Add(Input[i, j]);
            }
            ret.Add(LoopList);
        }
        count++;
        return ret;
    }
    public static int[,] MakeArrayFromPanels(Panel[,] Panels, int W, int H)
    {
        int[,] Way = new int[W, H];
        for (int i = 0; i < W; i++)
        {
            for (int j = 0; j < H; j++)
            {
                if (Panels[i, j].BackColor == Color.Blue)
                    Way[i, j] = 1;
                else if (Panels[i, j].BackColor == Color.Green)
                    Panels[i, j].BackColor = Color.White;
            }
        }
        return Way;
    }
    public static int[,] Copy2DArray(int[,] N1, int w, int h)
    {
        int[,] N2 = new int[w, h];
        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                N2[i, j] = N1[i, j];
            }
        }
        return N2;
    }
    static void Print(int w, int h)
    {
        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                Console.Write(Way[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    public static bool Stop = false;
    public static bool FindWays(int w, int h, int InW, int InH, Panel[,] P)
    {
        if (InW == w - 1 && InH == h - 1)
        {
            P[InW, InH].BackColor = Color.Green;
            Way[InW, InH] = 2;
            Application.DoEvents();
            Thread.Sleep(200);
            return true;
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                int H = 0, W = 0;
                if (IsPossible(i, InW, InH, w, h))
                {
                    bool GetOut = false;

                    W = PossibleWaysW[i];
                    H = PossibleWaysH[i];
                    P[InW, InH].BackColor = Color.Green;
                    Way[InW + W, InH + H] = 2;
                    Application.DoEvents();
                    Thread.Sleep(200);
                    MC++;
                    GetOut = FindWays(w, h, InW + W, InH + H, P);

                    if (GetOut)
                        return true;
                    else
                    {
                        MC--;
                        P[InW, InH].BackColor = Color.White;
                        Thread.Sleep(200);
                        Application.DoEvents();
                        Way[InW + W, InH + H] = 1;
                    }
                }

            }
        }
        return false;

    }
    public static void FindWays2(int w, int h, int InW, int InH)
    {
        if (InW == w - 1 && InH == h - 1)
            l.Add(Make2DList(Way, w, h));
        else
            for (int i = 0; i < 8; i++)
                if (IsPossible(i, InW, InH, w, h))
                {
                    int H, W;
                    W = PossibleWaysW[i];
                    H = PossibleWaysH[i];
                    Way[InW + W, InH + H] = 2;
                    FindWays2(w, h, InW + W, InH + H);
                    Way[InW + W, InH + H] = 0;
                }
    }
    public static int Best;
    public static int[,] Best3;
    
    public static void Copy(int[,] Way,ref int[,] Dest,int n1,int n2)
    {
        Dest = new int[n1, n2];
        for (int i = 0; i < n1; i++)
            for (int j = 0; j < n2; j++)
                Dest[i, j] = Way[i, j];
    }
    public static void FindWays3(int w, int h, int InW, int InH, int n)
    {
        if (n < Best)
            if (InW == w - 1 && InH == h - 1)
            {
                if (n <= Best)
                {
                    Copy(Way, ref Best3, w, h);
                    Best = n;
                }
            }
            else
                for (int i = 0; i < 8; i++)
                    if (IsPossible(i, InW, InH, w, h))
                    {
                        int H, W;
                        W = PossibleWaysW[i];
                        H = PossibleWaysH[i];
                        Way[InW + W, InH + H] = 2;
                        FindWays3(w, h, InW + W, InH + H, n + 1);
                        Way[InW + W, InH + H] = 0;
                    }
    }
    public static int BestWay()
    {
        int best = 0;
        for (int i = 1; i < count; i++)
        {
            if (MovesCount[best] > MovesCount[i])
                best = i;
        }
        return best;
    }
    static bool IsPossible(int Move, int InW, int InH, int w, int h)
    {
        int H = PossibleWaysH[Move], W = PossibleWaysW[Move];
        return (H + InH < h && W + InW < w && W + InW >= 0 && H + InH >= 0 && Way[InW + W, InH + H] == 0) ? true : false;
    }
    static void Print(List<List<int>> l, int w, int h)
    {
        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                Console.Write(l[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}
