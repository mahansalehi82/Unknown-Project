using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahanStackProject;
namespace Unknown_Project
{
    enum NodeMode
    {
        Char,Number
    }
    class Node
    {
        public Node LChild, RChild;
        public int Data;
        public NodeMode Mode;
        public Node(int Data,NodeMode Mode)
        {
            this.Data = Data;
            LChild = RChild = null;
            this.Mode = Mode;
        }
    }
    class BST
    {
        public Node Root;
        public bool Search(int Data)
        {
            return Search(Root, Data);
        }
        public static void InOrderNonRecursive(Node Root)
        {
            MahanStack<Node> Parents = new MahanStack<Node>(1000);
            MahanStack<bool> L = new MahanStack<bool>(1000), R = new MahanStack<bool>(1000), M = new MahanStack<bool>(1000);
            Node H1 = Root;
            bool GetOut = false;
            L.Push(false);
            R.Push(false);
            M.Push(false);
            while (!GetOut)
            {
                if (H1 == Root && L.GetTop() && R.GetTop())
                {
                    GetOut = true;
                    break;
                }
                if (H1 == null)
                {
                    H1 = Parents.Pop();
                    L.Pop();
                    R.Pop();
                    M.Pop();
                    continue;
                }
                if (!L.GetTop())
                {
                    Parents.Push(H1);
                    H1 = H1.LChild;
                    L.Pop();
                    L.Push(true);
                    L.Push(false);
                    M.Push(false);
                    R.Push(false);
                    continue;
                }
                if (L.GetTop() && !M.GetTop())
                {
                    Console.Write(H1.Data + " ");
                    M.Pop();
                    M.Push(true);
                }
                if (L.GetTop() && R.GetTop())
                {
                    H1 = Parents.Pop();
                    L.Pop();
                    R.Pop();
                    M.Pop();
                    continue;
                }
                if (!R.GetTop())
                {
                    Parents.Push(H1);
                    H1 = H1.RChild;
                    R.Pop();
                    R.Push(true);
                    L.Push(false);
                    R.Push(false);
                    M.Push(false);
                    continue;
                }
                if (H1.LChild == null && !L.GetTop())
                {
                    L.Pop();
                    L.Pop();

                    L.Push(true);
                    L.Push(true);
                    Console.Write(Parents.GetTop().Data + " ");
                    continue;
                }
                if (H1.RChild == null && !R.GetTop())
                {

                    R.Pop();
                    R.Pop();
                    R.Push(true);
                    R.Push(true);
                    Console.Write(Parents.GetTop().Data + " ");
                }

            }

        }
        bool Search (Node Root,int Data)
        {
            if (Root == null)
                return false;
            else if (Data == Root.Data)
                return true;
            else if (Data < Root.Data)
                return Search(Root.LChild, Data);
            else
                return Search(Root.RChild, Data);
        }
        public void Insert(int Data)
        {
            Insert(ref Root, Data);
        }
        void Insert(ref Node Root, int Data)
        {
            if (Root == null)
                Root = new Node(Data, NodeMode.Number);

            else
                if (Data > Root.Data)
                Insert(ref Root.RChild, Data);
            else if (Data < Root.Data)
                Insert(ref Root.LChild, Data);
        }
        public void InOrder()
        {
            InOrder(Root);

        }
         void InOrder(Node Root)
        {
            if (Root != null)
            {
                InOrder(Root.LChild);
                Console.Write(Root.Data + " ");
                InOrder(Root.RChild);
            }
        }
        public static void InOrder2(Node Root)
        {
            if (Root != null)
            {
                InOrder2(Root.LChild);
                if (Root.Mode == NodeMode.Char)
                    Console.Write((char)Root.Data + " ");
                InOrder2(Root.RChild);
            }
        }
        public static void BinaryCodes(Node Root,string CCode,string[] Sts)
        {
            if (Root != null)
            {
                BinaryCodes(Root.LChild, CCode + "0", Sts);
                if (Root.Mode == NodeMode.Char)
                    Sts[Root.Data] = CCode;
                BinaryCodes(Root.RChild, CCode + "1", Sts);
            }
        }
    }
}
