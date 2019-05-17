using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unknown_Project
{
    class KnightMove
    {
        public static int Count=1;
        public static int[,] Way=new int[8,8],WayBackUp,Scores;
        static int[] PossibleWaysW = new int[8] { 2, 2, 1, -1, -2, -2, -1, 1 };
        static int[] PossibleWaysH = new int[8] { 1, -1, -2, -2, -1, 1, 2, 2 };
        static Random x=new Random();
        static bool IsPossible(int Move, int InW, int InH)
        {
            int H = PossibleWaysH[Move], W = PossibleWaysW[Move];
            return (H + InH < 8 && W + InW < 8 && W + InW >= 0 && H + InH >= 0 && Way[InW + W, InH + H] == 0) ? true : false;
        }
        static void Print()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                    Console.Write((Way[i, j] < 10 ? "0" : "") + Way[i, j] + " ");

                Console.WriteLine();
            }
        }
        static void Print(int[ , ] Sc)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                    Console.Write(Sc[i, j] + " ");

                Console.WriteLine();
            }
        }
        static bool IsPossibleToMove(int InW, int InH)
        {
            for (int i = 0; i < 8; i++)
                if (IsPossible(i, InW, InH))
                    return true;

            return false;
        }
        public static int[ , ] Copy2DArray(int[ , ] N1)
        {
            int[,] N2 = new int[8, 8];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    N2[i, j] = N1[i, j];

            return N2;
        }
        static bool Move(int InW, int InH)
        {

            if (!IsPossibleToMove(InW, InH))
            {
                Print();
                return true;
            }
            else
            {
                for (int i = 0; i < 8; i++)
                    if (IsPossible(i, InW, InH))
                    {
                        bool GetOut = false;
                        int H, W;
                        W = PossibleWaysW[i];
                        H = PossibleWaysH[i];
                        Way[InW + W, InH + H] = ++Count;
                        GetOut = Move(InW + W, InH + H);
                        if (GetOut)
                            return true;
                    }

            }
            return false;

        }
        public static void BestMoves(int InW, int InH,Panel[,] Panels)
        {
            if (InW == 1 && InH == 5)
            {

            }
            if (!IsPossibleToMove(InW, InH))
            {
                Print();
            }
            else
            {
                int BestMove=-1,B1=0,B2=0;
                for (int i = 0; i < 8; i++)
                    if (BestMove == -1 && IsPossible(i, InW, InH))
                    {
                        BestMove = i;
                        B1 = PossibleWaysW[BestMove];
                        B2 = PossibleWaysH[BestMove];
                    }
                    else if (IsPossible(i, InW, InH) && (Scores[InW + B1, InH + B2] == 0 || (Scores[InW + B1, InH + B2] > Scores[InW + PossibleWaysW[i], InH + PossibleWaysH[i]])))
                    {
                        BestMove = i;
                        B1 = PossibleWaysW[BestMove];
                        B2 = PossibleWaysH[BestMove];
                    }
                Way[InW + B1, InH + B2] = ++Count;
                UpdateScore(InW + B1, InH + B2);

                Panels[InW + B1, InH + B2].BackColor = Color.FromArgb(x.Next(25,256), x.Next(25,256), x.Next(25,256));
                Panels[InW + B1, InH + B2].BackgroundImage = Properties.Resources.Picture11;
                Application.DoEvents();
                System.Threading.Thread.Sleep(250);
                BestMoves(InW + B1, InH + B2, Panels);

            }
        }
        public static void Scoring()
        {
            Scores = new int[8, 8];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    Scores[i, j] = MovesCount(i, j);

        }
        static int MovesCount(int InW, int InH)
        {
            int ret=0;
            for (int i = 0; i < 8; i++)
                if (IsPossible(i, InW, InH))
                    ret++;

            return ret;
        }
        public static void UpdateScore(int InW, int InH)
        {
            for (int i = 0; i < 8; i++)
                if (IsPossible(i, InW, InH))
                    Scores[PossibleWaysW[i] + InW, PossibleWaysH[i] + InH]--;
        }
    }
}
