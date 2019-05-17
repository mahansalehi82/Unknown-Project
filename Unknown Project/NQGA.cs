using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unknown_Project
{
    class Creature : IComparable<Creature>
    {
        public int[] Loc;
        public static int Length = 8;
        public Creature(int[] Loc)
        {
            this.Loc = Loc;
        }

        public int CompareTo(Creature C)
        {
            if (Loc[Length] > C.Loc[Length])
                return 1;
            if (Loc[Length] == C.Loc[Length])
                return 0;
            return -1;
        }
    }
    class NQGA
    {
        class Program
        {
            static Creature[] Pops;
            static int Length = 8, Pop = 1000, CrossOverC = Pop / 3, Gen = 0;
            static Random Rnd = new Random();
            static void FirstGeneration()
            {
                Pops = new Creature[Pop + CrossOverC];
                for (int i = 0; i < Pop; i++)
                {
                    int[] Loc = new int[Length + 1];
                    for (int j = 0; j < Length; j++)
                        Loc[j] = Rnd.Next(0, Length);
                    Loc[Length] = Fitness(Loc);
                    Creature C = new Creature(Loc);
                    Pops[i] = C;
                }
            }
            static int Fitness(int[] L)
            {
                int Ret = 0;
                for (int i = 0; i < Length - 1; i++)
                    for (int j = i + 1; j < Length; j++)
                        if (L[i] == L[j] || (L[i] - L[j] == j - i) || L[j] - L[i] == j - i)
                            Ret++;
                return Ret;
            }
            static void CrossOver(int K)
            {
                int H = Rnd.Next(1, Length - 1), H1 = Rnd.Next(0, Pop), H2 = Rnd.Next(0, Pop);
                int[] Loc = new int[Length + 1];
                for (int i = 0; i <= H; i++)
                    Loc[i] = Pops[H1].Loc[i];
                for (int i = H + 1; i < Length; i++)
                    Loc[i] = Pops[H2].Loc[i];
                Mutate(Loc);
                Loc[Length] = Fitness(Loc);
                Creature C = new Creature(Loc);
                Pops[K] = C;
            }
            static void DoCrossOvers()
            {
                for (int i = 0; i < CrossOverC; i++)
                    CrossOver(Pop + i);
                Array.Sort(Pops);
            }
            static void Mutate(int[] Loc)
            {
                int R = Rnd.Next(0, 100);
                if (R <= 1)
                    Loc[Rnd.Next(0, Length)] = Rnd.Next(0, Length);

            }
            static void Print(Creature C)
            {
                for (int i = 0; i <= Length; i++)
                    Console.Write(C.Loc[i] + " ");

                Console.WriteLine();
            }
            static void Print(int N)
            {
                for (int i = 0; i < N; i++)
                    Print(Pops[i]);
            }
            static int[] Solve(int N)
            {
                Length = N;
                FirstGeneration();
                while (true)
                {
                    Gen++;
                    DoCrossOvers();
                    if (Pops[0].Loc[Length] == 0)
                    {
                        Print(Pops[0]);
                        return Pops[0].Loc;
                    }
                    //else
                    //    Print(5);
                    //Console.WriteLine("Generation : " + Gen);
                }
            }
        }
    }
}
