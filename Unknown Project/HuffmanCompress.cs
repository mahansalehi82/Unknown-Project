using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unknown_Project
{
    class HuffmanCompress
    {
        public static int[] CountLetters(string s, out int First, out int Last, out int LetterCount)
        {
            int[] Ret = new int[256];
            First = 256;
            Last = 0;
            LetterCount = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int c = s[i];
                if (c > Last)
                    Last = c;
                if (c < First)
                    First = c;
                Ret[c]++;
                if (Ret[c] == 1)
                    LetterCount++;
            }
            return Ret;
        }
        public static int[] CountLetters(byte[] s, out int First, out int Last, out int LetterCount)
        {
            int[] Ret = new int[256];
            First = 256;
            Last = 0;
            LetterCount = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int c = s[i];
                if (c > Last)
                    Last = c;
                if (c < First)
                    First = c;
                Ret[c]++;
                if (Ret[c] == 1)
                    LetterCount++;
            }
            return Ret;
        }
        static void Least(int[] Counts, int First, int Last, out int N1c, out int N2c)
        {
            int Count = 0, N1, N2;
            N1c = 0;
            N2c = 0;
            N1 = 0;
            N2 = 0;
            for (int i = First; i <= Last; i++)
            {
                if (Counts[i] != 0)
                {
                    if (Count == 0)
                    {
                        N1 = Counts[i];
                        N1c = i;
                        Count++;
                    }
                    else if (Count == 1)
                    {

                        N2 = Counts[i];
                        N2c = i;
                        if (N2 < N1)
                        {
                            int h = N1;
                            N1 = N2;
                            N2 = h;
                            h = N1c;
                            N1c = N2c;
                            N2c = h;
                        }
                        Count++;
                    }
                    else
                    {
                        if (Counts[i] < N1)
                        {
                            N2 = N1;
                            N1 = Counts[i];
                            N2c = N1c;
                            N1c = i;
                        }
                        else if (Counts[i] < N2)
                        {
                            N2 = Counts[i];
                            N2c = i;
                        }
                    }
                }
            }
            if (Count < 2)
                N2c = -1;
        }
        public static Node Compress(int[] Counts, int First, int Last)
        {

            bool b = false;
            List<Node> Roots = new List<Node>();
            Roots.Add(new Node(0, NodeMode.Number));
            int[] Indexes = new int[256];
            while (!b)
            {
                int N1, N2, Sum;

                Least(Counts, First, Last, out N1, out N2);
                if (N2 == -1)
                    break;
                Sum = Counts[N1] + Counts[N2];
                Node n = new Node(Sum, NodeMode.Number);
                if (Indexes[N1] != 0)
                    n.LChild = Roots[Indexes[N1]];
                else
                    n.LChild = new Node(N1, NodeMode.Char);
                if (Indexes[N2] != 0)
                    n.RChild = Roots[Indexes[N2]];
                else
                    n.RChild = new Node(N2, NodeMode.Char);
                Counts[N2] = 0;
                Counts[N1] = Sum;
                Indexes[N1] = Roots.Count;
                Indexes[N2] = 0;

                Roots.Add(n);

            }
            return Roots[Roots.Count - 1];
        }
        public static void AddNeededBits(ref string s, int Bits)
        {
            for (int i = s.Length; i < Bits; i++)
                s = "0" + s;
        }
        public static byte ToByte(string s)
        {
            int x = 0;
            byte F = 1;
            for (int i = 7; i >= 0; i--)
            {
                x += byte.Parse(s[i].ToString()) * F;
                F *= 2;
            }
            return (byte)x;
        }
        public static string FormatTheOutput(int LetterCounts, string[] Codes, byte[] s, ProgressBar Pbar)
        {

            string ret = "", H = "";
            H = Convert.ToString(LetterCounts, 2);
            AddNeededBits(ref H, 9);
            ret += H;
            for (int i = 0; i < Codes.Length; i++)
            {
                if (Codes[i] != null)
                {
                    H = Convert.ToString(Codes[i].Length, 2);
                    AddNeededBits(ref H, 5);
                    ret += H;
                    ret += Codes[i];
                    H = Convert.ToString(i, 2);
                    AddNeededBits(ref H, 8);
                    ret += H;
                    int n = ret.Length;
                }
            }
            Pbar.Maximum = s.Length;
            Pbar.Value = 0;
            for (int i = 0; i < s.Length; i++)
            {
                ret += Codes[s[i]];
                Pbar.Value++;
            }
            Pbar.Value = 0;
            MessageBox.Show("Compression Finished", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return ret;
        }
        public static void Print(string[] Sts)
        {
            for (int i = 0; i < 256; i++)
                if (Sts[i] != null)
                    Console.Write(Sts[i] + " " + "\"" + (char)i + "\"" + "   ");
        }
        public static string GetString(int i, int j, string s)
        {
            string Ret = "";

            int f = s.Length;
            for (int h = 0; h < j; h++, i++)
                Ret += s[i];
            return Ret;
        }
        static int FindCode(string Code, List<string> Ls)
        {
            for (int i = 0; i < Ls.Count; i++)
                if (Code == Ls[i])
                    return i;
            return -1;
        }
        public static List<byte> Decompress(string s)
        {
            List<byte> Ret = new List<byte>();
            int y = s.Length;
            int ZeroCount = Convert.ToInt32(GetString(0, 8, s), 2), LetterCount = Convert.ToInt32(GetString(8, 9, s), 2), j = 17;
            if (ZeroCount != 0)
                s = s.Remove(s.Length - ZeroCount);
            List<byte> LC = new List<byte>();
            List<string> LS = new List<string>();
            for (int i = 0; i < LetterCount; i++)
            {
                int Length = Convert.ToInt32(GetString(j, 5, s), 2);
                j += 5;
                string c = GetString(j, Length, s);
                LS.Add(c);
                j += Length;
                c = GetString(j, 8, s);
                byte ch = (byte)Convert.ToInt32(c, 2);
                j += 8;
                LC.Add(ch);
            }
            int n = s.Length;
            string H = "";
            for (int i = j; i < s.Length; i++)
            {
                H += s[i];
                int Index = FindCode(H, LS);
                if (Index != -1)
                {
                    Ret.Add((byte)LC[Index]);
                    H = "";
                }
            }
            return Ret;
        }
    }
}
