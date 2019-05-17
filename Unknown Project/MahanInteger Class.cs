using System;
using System.Numerics;
using System.Collections.Generic;
namespace Unknown_Project
{
    class MahanInteger
    {
        public static string Sum(string num1, string num2)
        {

            int OneTen = 0;
            change(ref num1, ref num2);
            AddZero(ref num1, ref num2);
            string sum = "";
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int h = int.Parse(num1[i].ToString()) + int.Parse(num2[i].ToString()) + OneTen;
                if (h > 9)
                {
                    OneTen = 1;
                    h -= 10;
                }
                else
                    OneTen = 0;
                sum = h.ToString() + sum;
            }
            if (OneTen != 0)
                sum = OneTen.ToString() + sum;
            DeleteZero(ref sum);
            return sum;
        }
        static void DeleteZero(ref string s)
        {
            for (; s[0] == '0' && s.Length > 1;)
                s = s.Remove(0, 1);
        }
        static void change(ref string s1, ref string s2)
        {
            if (s2.Length > s1.Length)
            {
                string s3 = s2;
                s2 = s1;
                s1 = s3;
            }
        }
        static void AddZero(ref string num1, ref string num2)
        {
            int d = num1.Length - num2.Length;
            string zero = "";
            for (int i = 0; i < d; i++)
                zero += "0";

            if (num1.Length > num2.Length)
                num2 = zero + num2;
            else
                num1 = zero + num1;
        }
        static void AddZeroForMulti(int n, ref string s)
        {
            for (int i = 1; i <= n; i++)
                s += "0";
        }
        public static string MultiPly(string num1, string num2)
        {
            string M = "0";
            change(ref num1, ref num2);
            List<string> ls = new List<string>();
            int c1 = 0;
            for (int i = num2.Length - 1; i >= 0; i--)
            {
                string m = "0";
                int c2 = 0;
                for (int j = num1.Length - 1; j >= 0; j--)
                {
                    string f = (int.Parse(num1[j].ToString()) * int.Parse(num2[i].ToString())).ToString();
                    AddZeroForMulti(c2, ref f);
                    m = Sum(m, f);
                    c2++;
                }
                AddZeroForMulti(c1, ref m);
                ls.Add(m);
                c1++;
            }
            for (int i = 0; i < ls.Count; i++)
                M = Sum(M, ls[i]);
            return M;
        }
        public static string Power(string num1, int num2)
        {
            string l = "1";
            if (num2 % 2 != 0)
            {
                num2--;
                l = num1;
            }
            while (num2 > 2)
            {
                Power2(ref num1, ref num2);
                if (num2 % 2 != 0)
                {
                    l = MultiPly(num1, l);
                    num2--;
                }
            }

            string M = num1;
            for (int s = 1; s != num2; s++)
                M = MultiPly(M, num1);

            M = MultiPly(M, l);
            return M;
        }
        static void Power2(ref string num1, ref int num2)
        {
            num2 /= 2;
            num1 = MultiPly(num1, num1);
        }
        public static int length(string s)
        {
            return s.Length;
        }
        public static int DigitalSum(string s)
        {
            int sum = 0;
            foreach (char chars in s)
                sum += chars - 48;
            return sum;
        }
        public static List<int> ToIntList(string s)
        {
            List<int> l = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                l.Add(s[i] - 48);
            }
            return l;
        }
        static void Reverse(ref string n)
        {
            string s = "";
            for (int i = n.Length - 1; i >= 0; i--)
            {
                s += n[i];
            }
            n = s;
        }
        public static string Subtract(string num1, string num2)
        {
            AddZero(ref num1, ref num2);
            Reverse(ref num1);
            Reverse(ref num2);
            List<int> n1 = ToIntList(num1);
            List<int> n2 = ToIntList(num2);
            string s = "";

            for (int i = 0; i < n1.Count; i++)
            {
                if (n1[i] < n2[i])
                {
                    int k = 1;
                    for (int j = i + 1; j < n1.Count && j > i; j += k)
                    {
                        if (n1[j] == 0)
                            continue;
                        if (k != -1)
                            k = -1;
                        if (j > i)
                            n1[j]--;
                        n1[j - 1] += 10;
                    }
                }
                s += n1[i] - n2[i];
            }
            Reverse(ref s);
            DeleteZero(ref s);
            return s;
        }

        public static string Sqrt(string num)
        {
            string s = "";
            int place = 0;

            place = num.Length % 2 == 0 ? 2 : 1;
            int h = (int)Math.Sqrt(int.Parse(num.Substring(0, place)));
            if ((h * h).ToString() == num)
            {
                return h.ToString();
            }
            num += "00000000";


            s += h.ToString();
            string j = num.Substring(0, place);
            j = Subtract(j, Power(h.ToString(), 2));
            for (int i = 0 + place; i < num.Length; i += 2)
            {
                j += num.Substring(i, 2);
                string b = MultiPly(s, "2");
                string z = LostDigit(j, b).ToString();
                s += z.ToString();
                string k = MultiPly(b + z, z);
                j = Subtract(j, k);
            }
            s = s.Insert(s.Length - 4, ".");
            return s;
        }
        public static string Division(string s, int n)
        {
            int b;
            string a;
            a = Division(s, n, out b);
            return a;
        }
        public static string ChangeBase(string s, int num)
        {
            string bin = "";
            List<long> x = new List<long>();
            long n = long.Parse(s);
            while (n >= 1)
            {
                x.Add(n % num);
                n /= num;
            }
            bin = Hexa(x);
            Reverse(ref bin);
            return bin;
        }
        static string Hexa(List<long> v)
        {
            string ret = "";
            for (int i = 0; i < v.Count; i++)
            {
                if (v[i] >= 10)
                {
                    ret += h(v[i]);
                }
                else
                {
                    ret += v[i];
                }
            }
            return ret;

        }
        static char h(long a)
        {
            char d = (char)a;
            if (a == 10)
                d = 'A';
            if (a == 11)
                d = 'B';
            if (a == 12)
                d = 'C';
            if (a == 13)
                d = 'D';
            if (a == 14)
                d = 'E';
            if (a == 15)
                d = 'F';
            return d;
        }
        public static string Convert(string val, int b1, int b2)
        {
            if (b1 != 10)
                val = ToTenBase(val, b1);
            if (b2 != 10)
                val = ChangeBase(val, b2);
            return val;
        }
        public static string ToTenBase(string s, int num = 2)
        {
            string j = s;
            string[] bin;
            ToStringList(s, out bin);
            double dec1 = 0;
            int h = 1;
            for (int i = bin.Length - 1; i >= 0; i--)
            {
                dec1 += (int.Parse(bin[i])) * h;
                h *= num;
            }
            return dec1.ToString();
        }

        static void ToStringList(string Val, out string[ ] s)
        {
            s = new string[Val.Length];
            for (int i = 0; i < Val.Length; i++)
            {
                s[i] = HexToDec(Val[i].ToString());
            }
        }

        static string HexToDec(string a)
        {
            string d = a;
            if (a == "A")
                d = "10";
            if (a == "B")
                d = "11";
            if (a == "C")
                d = "12";
            if (a == "D")
                d = "13";
            if (a == "E")
                d = "14";
            if (a == "F")
                d = "15";
            return d;
        }

        public static string Division(string s, int n, out int Remainder)
        {
            string s2 = s[0].ToString(), ret = "";
            int remainder = 0;
            for (int i = 1; i < s.Length; i++)
            {
                s2 += s[i];
                int x = int.Parse(s2);
                if (x < n)
                {
                    x = int.Parse(s2);
                }
                int k = x / n;
                ret += k;
                remainder = x - (k * n);
                s2 = remainder.ToString();
            }
            DeleteZero(ref ret);
            Remainder = remainder;
            return ret;
        }
        public static bool IsEqual(string n1,string n2)
        {
            return n1 == n2;
        }
        public static int WhichIsSmaller(string n1,string n2)
        {
            return WhichIsBigger(n2, n1);
        }
        public static int WhichIsBigger(string n1,string n2)
        {
            if (n1.Length > n2.Length)
                return 1;
            else if (n1 == n2)
                return 0;
            else if (n1.Length < n2.Length)
                return -1;
            else
            {
                for(int i = 0; i < n1.Length; i++)
                {
                    if (n1[i] > n2[i])
                        return 1;
                    else if (n1[i] < n2[i])
                        return -1;
                }
            }
            return 0;
        }
        static char LostDigit(string Num, string SadDigits)
        {
            BigInteger big1 = BigInteger.Parse(Num);
            BigInteger big2 = BigInteger.Parse(SadDigits);
            char ret = '0';
            for (int i = 9; i >= 0; i--)
            {
                BigInteger d = BigInteger.Parse(SadDigits + i) * i;
                if (d < big1)
                    return (i).ToString()[0];
            }
            return ret;
        }
    }
}
