using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unknown_Project
{
    class Polynomial
    {
        public static void Sort(List<int> In)
        {
            for (int i = 1; i < In.Count - 1;)
            {
                bool StepApplier = false;
                for (int j = i + 2, h = i; j < In.Count; j += 2)
                {
                    int n1;
                    if (In[h] < In[j])
                    {
                        n1 = In[j - 1];
                        In[j - 1] = In[h - 1];
                        In[h - 1] = n1;
                        n1 = In[j];
                        In[j] = In[h];
                        In[h] = n1;
                        h = j;
                    }
                }
                if (!StepApplier)
                    i += 2;
            }
        }

        public static string ResultFormatter(List<int> W1, char Integer)
        {
            string ret = "";
            for (int i = 0; i < W1.Count; i += 2)
                /*ret += (W1[i] > 0 ? "+" + W1[i] : W1[i].ToString()) + (W1[i + 1] == 0 ? "" : (W1[i + 1] == 1 ? "x" : "x^" + W1[i + 1]))*/
                ret += /*(i == 0 ? "" :W1[i]<=-1?"": "+") + */(W1[i] > 0 ? "+" + (W1[i] == 1 ? (W1[i + 1] > 0 ? "" : W1[i] + "") : W1[i] + "") + (W1[i + 1] == 0 ? " " : (W1[i + 1] == 1 ? "x " : "x^" + W1[i + 1])) + " " : (W1[i] != 0 ? W1[i].ToString() + (W1[i + 1] == 0 ? " " : (W1[i + 1] == 1 ? "x " : "x^" + W1[i + 1])) + " " : ""));

            return ret.Length > 0 ? ret : "0";
        }

        public static string ResultFormatter2(List<int> W1, char Integer)
        {
            string ret="";
            for (int i = 0; i < W1.Count; i += 2)
            {
                ret += /*(i == 0 ? "" :W1[i]<=-1?"": "+") + */(W1[i] > 0 ? "+" + (W1[i] == 1 ? (W1[i + 1]>0?"":W1[i]+""):W1[i]+"") + (W1[i + 1] == 0 ? " " : (W1[i + 1] == 1 ? "x " : "x^" + W1[i + 1])) + " " : (W1[i] != 0 ? (W1[i].ToString()) + (W1[i + 1] == 0 ? " " : (W1[i + 1] == 1 ? "x " : "x^" + W1[i + 1])) + " " : ""));
            }
            return ret.Length > 0 ? ret : "0";
        }
        static void CopyArray(List<int> n1, out List<int> n2)
        {
            n2 = new List<int>();
            for(int i = 0; i < n1.Count; i++)
            {
                n2.Add(n1[i]);
            }
        }
        public static List<int> ToStandardForMultiply(List<int> ls)
        {
            
            List<int> ls2=new List<int>(), ret = new List<int>();
            CopyArray(ls, out ls2);
            while (ls2.Count >= 2)
            {
                int B = ls2[0], P = ls2[1];
                ls2.RemoveAt(0);
                ls2.RemoveAt(0);
                for (int j = 1; j < ls2.Count;)
                {
                    if (ls2[j] == P)
                    {
                        ls2.RemoveAt(j);
                        B += ls2[j - 1];
                        ls2.RemoveAt(j - 1);
                    }
                    else
                        j += 2;
                }
                ret.Add(B);
                ret.Add(P);
            }
            Sort(ret);
            return ret;
        }
        static string AddSpace(string s)
        {
            string ret="";
            for (int i = 0; i < s.Length; i++)
                if (s[i] == '-' || s[i] == '+')
                    ret += " " + s[i];
                else
                    ret += s[i];
            return ret;
        }
        public static void StandardToArray(string Standard, char Integer, out List<int> WithInt)
        {
            List<int> B1 = new List<int>();
            Standard = Standard.Replace(" ", "");
            Standard = AddSpace(Standard);
            string[] A=Standard.Split(" ".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
            Seperate(A, B1);
            WithInt = B1;
        }
        public static string S(ref int i, string Standard, char Integer)
        {
            string C="";
            C += i < Standard.Length ? (Standard[i] == '-' ? "-" : (Standard[i] == '+' ? "+" : "")) : "";
            i++;

            int l=0;
            for (; i < Standard.Length && Standard[i] != Integer && Standard[i] != '^' && Standard[i] != '-' && Standard[i] != '+'; i++)
            {
                C += Standard[i];
                l++;
            }
            if (l>=2 && i < Standard.Length) i--;
            return C;
        }
        public static void Seperate(string[] Standard, List<int> Bases)
        {
            for(int i = 0; i < Standard.Length; i++)
            {
                int HatIndex,Help=Standard[i].IndexOf("x"),P;
                HatIndex = Standard[i].IndexOf("^");

                if (HatIndex == -1)
                {
                    if (Help != -1)
                    {
                        P = 1;
                        HatIndex= Help;
                    }
                    else
                    {
                        P = 0;
                        HatIndex = Standard[i].Length;
                    }
                }
                else
                {
                    P = int.Parse(Standard[i].Substring(HatIndex + 1));
                }
                if (Help == 0)
                {
                    Bases.Add(1);
                    Bases.Add(P);
                }
                else if (Help == 1 && Standard[i][0] == '-')
                {
                    Bases.Add(-1);
                    Bases.Add(P);
                }
                else if (Help == 1 && Standard[i][0] == '+')
                {
                    Bases.Add(1);
                    Bases.Add(P);
                }
                else if(Help!=-1)
                {
                    Bases.Add(int.Parse(Standard[i].Substring(0, Help)));
                    Bases.Add(P);
                }
                else
                {
                    Bases.Add(int.Parse(Standard[i].Substring(0, HatIndex)));
                    Bases.Add(P);
                }
            }
        }

        public static List<int> NonStandardToStandard(List<int> ls)
        {
            List<int> ls2 = ls, ret = new List<int>();

            for (; ls2.Count >= 2;)
            {
                int B = ls2[0], P = ls2[1];
                ls2.RemoveAt(0);
                ls2.RemoveAt(0);
                for (int j = 1; j < ls2.Count;)
                {
                    if (ls2[j] == P)
                    {
                        ls2.RemoveAt(j);
                        B += ls[j - 1];
                        ls2.RemoveAt(j - 1);
                    }
                    else
                        j += 2;
                }
                ret.Add(B);
                ret.Add(P);
            }
            Sort(ret);
            return ret;
        }

        public static List<int> PAdd(List<int> A, List<int> B)
        {
            List<int> n = new List<int>();
            int i = 1, j = 1;
            while (i < A.Count && j < B.Count)
            {
                if (A[i] == B[j])
                {
                    int u = B[j - 1] + A[i - 1];
                    if (u != 0)
                    {
                        n.Add(u);
                        n.Add(B[j]);
                    }
                    i += 2;
                    j += 2;
                }
                else if (A[i] < B[j])
                {

                    n.Add(B[j - 1]);
                    n.Add(B[j]);
                    j += 2;
                }
                else
                {
                    n.Add(A[i - 1]);
                    n.Add(A[i]);
                    i += 2;
                }
            }
            while (i < A.Count)
            {

                n.Add(A[i - 1]);
                n.Add(A[i]);
                i += 2;
            }
            while (j < B.Count)
            {

                n.Add(B[j - 1]);
                n.Add(B[j]);
                j += 2;
            }
            return n;
        }

        public static List<int> PMultiply(List<int> A, List<int> B)
        {
            List<int> n = new List<int>();
            int i = 1, j = 1;

            for (; i < A.Count && j < B.Count; j = 1, i += 2)
            {
                for (; j < B.Count;)
                {
                    n.Add(A[i - 1] * B[j - 1]);
                    n.Add(A[i] + B[j]);
                    j += 2;
                }
            }
            return n;
        }
    }
}
