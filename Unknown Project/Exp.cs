using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahanStackProject;

namespace Unknown_Project
{
    class Exp
    {
        static int ISP(char c)
        {
            switch (c)
            {
                case '^':
                    return 3;
                case '*':
                    return 2;
                case '/':
                    return 2;
                case '+':
                    return 1;
                case '-':
                    return 1;
                case '(':
                    return 0;
                case '#':
                    return -1;
                default:
                    throw new Exception("Error");
            }
        }
        static int ICP(char c)
        {
            switch (c)
            {
                case '^':
                    return 4;
                case '*':
                    return 2;
                case '/':
                    return 2;
                case '+':
                    return 1;
                case '-':
                    return 1;
                case '(':
                    return 4;
                case '#':
                    return 0;
                default:
                    throw new Exception("Error");
            }
        }
        static char NegPos(char c1, char c2)
        {
            return c1 == c2 ? '+' : '-';
        }
        public static string[] InfixToPostFix(string[] s)
        {

            List<string> ret = new List<string>();
            MahanStack<char> m = new MahanStack<char>(1000);
            m.Push('#');
            bool ex = true;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == "+" || s[i] == "-" || s[i] == "*" || s[i] == "/" || s[i] == "^" || s[i] == "(")
                {
                    if (!ex && (s[i] == "+" || s[i] == "-"))
                    {
                        char op = s[i][0];
                        while (ISP(m.GetTop()) == ICP(op))
                        {
                            char t = m.Pop();
                            s[i] = NegPos(t, op).ToString();
                        }
                    }
                    if ((s[i] == "+" || s[i] == "-"))
                        ex = false;
                    while (ISP(m.GetTop()) >= ICP(s[i][0]))
                        ret.Add(m.Pop().ToString());

                    m.Push(s[i][0]);
                }
                else if (s[i] == ")")
                {
                    while (m.GetTop() != '(')
                        ret.Add(m.Pop().ToString());

                    m.Pop();
                }
                else
                {
                    ret.Add(s[i]);
                    ex = true;
                }
            }
            while (m.GetTop() != '#')
                ret.Add(m.Pop().ToString());
            return ret.ToArray();
        }

        public static double Eval(string[] s)
        {
            MahanStack<double> Stack = new MahanStack<double>(100);
            double a, b, c = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == "+" || s[i] == "-" || s[i] == "*" || s[i] == "/" || s[i] == "^")
                {
                    a = Stack.Pop();
                    b = Stack.Pop();
                    if (s[i] == "-")
                        c = b - a;
                    if (s[i] == "+")
                        c = b + a;
                    if (s[i] == "*")
                        c = b * a;
                    if (s[i] == "/")
                        c = b / a;
                    if (s[i] == "^")
                        c = Math.Pow(b, a);
                    Stack.Push(c);
                }
                else
                {
                    Stack.Push(double.Parse(s[i]));
                }
            }
            return Stack.Pop();
        }
        //public static string[] InfixToPostfixFull(string[] s)
        //{
        //    List<string> ret = new List<string>();
        //    MahanStack<string> m = new MahanStack<string>(1000);
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        if (s[i] == ")")
        //            ret.Add(m.Pop());
        //        else if (s[i] == "+" || s[i] == "-" || s[i] == "*" || s[i] == "/" || s[i] == "^")
        //            m.Push(s[i]);
        //        else if (s[i] != "(")
        //            ret.Add(s[i]);
        //    }
        //    return ret.ToArray();
        //}
        static char OperatorSimplification(string s)
        {

            int NCount = 0;
            for (int i = 0; i < s.Length; i++)
                if (s[i] == '-')
                    NCount++;

            return NCount % 2 == 0 ? '+' : '-';
        }
        static string SimplifyOps(string s)
        {
            string Ret = "";
            string Ops = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '+' || s[i] == '-')
                    Ops += s[i];

                else
                {
                    if (Ops != "")
                    {
                        Ret += OperatorSimplification(Ops);
                        Ops = "";
                    }
                    Ret += s[i];
                }
            }
            return Ret;
        }
        public static string AddSpace(string s)
        {
            s = SimplifyOps(s);
            string ret = "";
            bool b = true;
            int i = 0;
            for (; i < s.Length; i++)
            {
                if (b && (s[i] == '+' || s[i] == '-'))
                {
                    ret += s[i];
                }
                else if (s[i] == '+' || s[i] == '-')
                {
                    ret += " "+s[i] + " ";
                    b = false;                   
                }
                else if ((s[i] == '*' || s[i] == '/' || s[i] == '^' || s[i] == ')' || s[i] == '('))
                {
                    b = true;
                    ret += " "+s[i] + " ";
                }
                else
                {
                    ret += s[i];
                    b = false;
                }
                
            }
            return ret;
        }
    }
}
