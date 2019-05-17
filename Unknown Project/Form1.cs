using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;
using static Unknown_Project.HuffmanCompress;

namespace Unknown_Project
{
    public partial class Form1 : Form
    {
        int[][,] ReadyToUseMaze = new int[][,] {
            new int[,]{ { 0, 1, 0, 0, 0, 1, 0, 0, 0 },{ 0, 1, 0, 1, 0, 1, 0, 1, 0 },{ 0, 1, 0, 1, 0, 1, 0, 1, 0 },{ 0, 1, 0, 1, 0, 1, 0, 1, 0 },{ 0, 1, 0, 1, 0, 1, 0, 1, 0 },{ 0, 1, 0, 1, 0, 1, 0, 1, 0 },{ 0, 1, 0, 1, 0, 1, 0, 1, 0 },{ 0, 1, 0, 1, 0, 1, 0, 1, 0 },{ 0, 0, 0, 1, 0, 0, 0, 1, 0 } },
            new int[,]{ { 0, 1, 1, 1, 0, 0, 0, 1, 1 },{ 1, 0, 1, 0, 1, 1, 1, 0, 1 },{ 0, 1, 1, 1, 0, 1, 0, 1, 1 },{ 1, 0, 1, 0, 1, 1, 1, 0, 1 },{ 0, 1, 1, 1, 0, 1, 0, 1, 1 },{ 1, 0, 1, 0, 1, 1, 1, 0, 1 },{ 0, 1, 1, 1, 0, 1, 0, 1, 1 },{ 1, 0, 1, 0, 1, 1, 1, 0, 1 },{ 0, 1, 0, 1, 0, 1, 0, 1, 0 } },
            new int[,]{ { 0, 0, 1, 0, 0, 0, 1, 0 },{ 1, 0, 1, 0, 1, 1, 1, 0 },{ 0, 0, 1, 0, 0, 1, 0, 1 },{ 1, 0, 0, 1, 1, 0, 1, 0 },{ 0, 1, 0, 0, 1, 1, 1, 0 },{ 0, 0, 0, 1, 0, 0, 1, 0 },{ 0, 1, 0, 1, 1, 0, 1, 1 },{ 1, 0, 1, 0, 0, 0, 1, 0 } },
            new int[,]{ { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },{ 1, 0, 0, 1, 1, 1, 1, 1, 0, 1, 0 },{ 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 },{ 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 0 },{ 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0 },{ 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0 },{ 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0 },{ 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } }
        };
        int[] Dimensions = new int[] { 9, 9, 8, 11 };
        bool IsDown = false;
        public Form1()
        {
            InitializeComponent();
        }
        int W = 0, H = 0, W3 = 0;
        Panel[,] PanelsArray, PanelsKnight;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine(textBox1.Text + " Determinan Generate");
                int n = int.Parse(textBox1.Text);
                dataGridView1.ColumnCount = n;
                dataGridView1.RowCount = n;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine("Determinan Calculate");
                int n = int.Parse(textBox1.Text);
                int[,] contents = new int[n, n];

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (dataGridView1[j, i].Value != null)
                            contents[i, j] = int.Parse(dataGridView1[j, i].Value.ToString());
                        else
                            contents[i, j] = 0;
                        Application.DoEvents();
                    }
                }
                int ans = DeterminanOp.Determinan(n, contents);
                MessageBox.Show(ans.ToString());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine(textBox2.Text + " Sum " + textBox3.Text);
                string Ans = MahanInteger.Sum(textBox2.Text, textBox3.Text);
                textBox4.Text = Ans;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine(textBox2.Text + " Subtract " + textBox3.Text);
                string Ans = MahanInteger.Subtract(textBox2.Text, textBox3.Text);
                textBox4.Text = Ans;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine(textBox2.Text + " Power " + textBox3.Text);
                string Ans = MahanInteger.Power(textBox2.Text, int.Parse(textBox3.Text));
                textBox4.Text = Ans;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine(textBox2.Text + " Multiply " + textBox3.Text);
                string Ans = MahanInteger.MultiPly(textBox2.Text, textBox3.Text);
                textBox4.Text = Ans;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine(textBox2.Text + " Division " + textBox3.Text);
                string Ans = MahanInteger.Division(textBox2.Text, int.Parse(textBox3.Text));
                textBox4.Text = Ans;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine(textBox2.Text + " Mudolo " + textBox3.Text);
                string Ans = MahanInteger.Subtract(textBox2.Text, MahanInteger.MultiPly(textBox3.Text, MahanInteger.Division(textBox2.Text, int.Parse(textBox3.Text))));
                textBox4.Text = Ans;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine(textBox2.Text + " Digit Sum ");
                int Ans = MahanInteger.DigitalSum(textBox2.Text);
                textBox4.Text = Ans.ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine(textBox2.Text + " Digit Count ");
                int Ans = MahanInteger.length(textBox2.Text);
                textBox4.Text = Ans.ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine(textBox5.Text + " PolySum " + textBox6.Text);
                List<int> WI = new List<int>(), WI2 = new List<int>(), Result1 = new List<int>();
                string s1 = " " + textBox5.Text, s2;
                s2 = " " + textBox6.Text;
                Polynomial.StandardToArray(s1, 'x', out WI);
                Polynomial.StandardToArray(s2, 'x', out WI2);
                Polynomial.Sort(WI);
                Polynomial.Sort(WI2);
                Application.DoEvents();
                WI = Polynomial.NonStandardToStandard(WI);
                WI2 = Polynomial.NonStandardToStandard(WI2);
                Application.DoEvents();
                Result1 = Polynomial.PAdd(WI, WI2);
                string s = Polynomial.ResultFormatter(Result1, 'x');
                InsertToComboBox(s1, s2);
                textBox7.Text = s;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine(textBox5.Text + " PolyMulti " + textBox6.Text);
                List<int> WI = new List<int>(), WI2 = new List<int>(), Result1 = new List<int>();
                string s1 = " " + textBox5.Text, s2;
                s2 = " " + textBox6.Text;
                Polynomial.StandardToArray(s1, 'x', out WI);
                Polynomial.StandardToArray(s2, 'x', out WI2);
                Polynomial.Sort(WI);
                Application.DoEvents();
                Polynomial.Sort(WI2);
                WI = Polynomial.ToStandardForMultiply(WI);
                Application.DoEvents();
                WI2 = Polynomial.ToStandardForMultiply(WI2);
                Result1 = Polynomial.PMultiply(WI, WI2);
                Result1 = Polynomial.ToStandardForMultiply(Result1);
                Application.DoEvents();
                string s = Polynomial.ResultFormatter2(Result1, 'x');
                InsertToComboBox(s1, s2);
                textBox7.Text = s;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        void InsertToComboBox(string s1, string s2)
        {
            comboBox1.Items.Add(s1);
            comboBox2.Items.Add(s1);
            comboBox1.Items.Add(s2);
            comboBox2.Items.Add(s2);
            DeleteSameItems();
        }

        void DeleteSameItems()
        {
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                for (int j = 0; j < comboBox1.Items.Count && i < comboBox1.Items.Count; j++)
                {
                    if (i != j && comboBox1.Items[i].ToString() == comboBox1.Items[j].ToString())
                    {
                        comboBox1.Items.RemoveAt(j);
                        comboBox2.Items.RemoveAt(j);
                        Application.DoEvents();
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.Text = comboBox1.Items[comboBox1.SelectedIndex].ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.Text = comboBox1.Items[comboBox1.SelectedIndex].ToString();
        }



        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine(numericUpDown1.Value.ToString() + " Maze Create " + numericUpDown2.Value.ToString());
                DeleteOldPanels(PanelsArray, W, H);
                W = int.Parse(numericUpDown1.Value.ToString());
                H = int.Parse(numericUpDown2.Value.ToString());
                GC.Collect();
                Application.DoEvents();
                PanelsArray = new Panel[W, H];
                int A = button13.Left + button13.Width + 50, B = button13.Top;
                InsertPanels(PanelsArray, W, H, tabPage4, A, B, 30, 30, true);
                button14.Enabled = true;
                if (W * H <= 90)
                    button31.Enabled = true;
                else
                    button31.Enabled = false;
                button38.Enabled = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        void DeleteOldPanels(Panel[,] Panels, int w, int h)
        {
            if (Panels != null)
                for (int i = 0; i < w; i++)
                    for (int j = 0; j < h; j++)
                    {
                        Application.DoEvents();
                        Panels[i, j].Dispose();
                    }

            Application.DoEvents();
        }

        void InsertPanelsGraph(Panel[,] Panels, int w, int h, TabPage Parent, int A, int B, int PW, int PH, bool EventBool)
        {
            for (int i = 0; i < w; i++)
            {
                int A2 = A;
                for (int j = 0; j < h; j++)
                {
                    Panels[i, j] = new Panel();
                    Panels[i, j].Parent = Parent;
                    Panels[i, j].Width = PW;
                    Panels[i, j].Height = PH;
                    Panels[i, j].Left = A2;
                    Panels[i, j].Top = B;
                    Panels[i, j].BackColor = Color.White;
                    Panels[i, j].BorderStyle = BorderStyle.FixedSingle;
                    Panels[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    if (EventBool)
                        Panels[i, j].Click += Form1_Click1;
                    A2 += PW;
                    Application.DoEvents();
                }
                B += PH;
            }
        }

        int GraphN = 0;

        private void Form1_Click1(object sender, EventArgs e)
        {
            Panel p = sender as Panel;
            if (p.BackColor == Color.Blue)
            {
                p.BackColor = Color.White;
                GraphN--;
            }
            else
            {
                p.BackColor = Color.Blue;
                GraphN++;
            }

        }

        void InsertPanels(Panel[,] Panels, int w, int h, TabPage Parent, int A, int B, int PW, int PH, bool EventBool)
        {

            for (int i = 0; i < w; i++)
            {
                int A2 = A;
                for (int j = 0; j < h; j++)
                {
                    Panels[i, j] = new Panel();
                    Panels[i, j].Parent = Parent;
                    Panels[i, j].Width = PW;
                    Panels[i, j].Height = PH;
                    Panels[i, j].Left = A2;
                    Panels[i, j].Top = B;
                    Panels[i, j].BackColor = Color.White;
                    Panels[i, j].BorderStyle = BorderStyle.FixedSingle;
                    Panels[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    if (EventBool)
                    {
                        Panels[i, j].Click += Form1_Click;
                        Panels[i, j].MouseDown += Form1_MouseDown1;
                        Panels[i, j].MouseUp += Form1_MouseUp1;
                        Panels[i, j].MouseMove += Form1_MouseMove1;
                    }
                    A2 += PW;
                    Application.DoEvents();
                }
                B += PH;
            }
        }

        private void Form1_MouseMove1(object sender, MouseEventArgs e)
        {
            //Panel p = sender as Panel;
            //p.BackColor = p.BackColor == Color.Blue ? Color.White : Color.Blue;
        }

        private void Form1_MouseUp1(object sender, MouseEventArgs e)
        {
            //IsDown = false;
        }

        private void Form1_MouseDown1(object sender, MouseEventArgs e)
        {
            //IsDown = true;
        }

        void InsertPanels(Panel[,] Panels, int w, int h, TabPage Parent, int A, int B, int PW, int PH, bool EventBool, int[,] Road)
        {

            for (int i = 0; i < w; i++)
            {
                int A2 = A;
                for (int j = 0; j < h; j++)
                {
                    Panels[i, j] = new Panel();
                    Panels[i, j].Parent = Parent;
                    Panels[i, j].Width = PW;
                    Panels[i, j].Height = PH;
                    Panels[i, j].Left = A2;
                    Panels[i, j].Top = B;
                    if (Road[i, j] == 0)
                        Panels[i, j].BackColor = Color.White;
                    else
                        Panels[i, j].BackColor = Color.Blue;
                    Panels[i, j].BorderStyle = BorderStyle.FixedSingle;
                    Panels[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    if (EventBool)
                        Panels[i, j].Click += Form1_Click;
                    A2 += PW;
                    Application.DoEvents();
                }
                B += PH;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine(numericUpDown1.Value.ToString() + " Maze Go " + numericUpDown2.Value.ToString());
                ResetPanels(PanelsArray, W, H);
                Maze.Way = Maze.MakeArrayFromPanels(PanelsArray, W, H);
                Maze.WayBackUp = Maze.Copy2DArray(Maze.Way, W, H);
                Maze.Way[0, 0] = 2;
                Maze.MC = 0;
                GC.Collect();
                Application.DoEvents();
                Maze.FindWays(W, H, 0, 0, PanelsArray);
                //if (Maze.Way[W - 1, H - 1] == 2)
                //    for (int i = 0; i < W; i++)
                //    {
                //        for (int j = 0; j < H; j++)
                //        {
                //            if (Maze.Way[i, j] == 2)
                //            {
                //                PanelsArray[i, j].BackColor = Color.Green;
                //                Application.DoEvents();
                //                Thread.Sleep(200);
                //            }
                //        }
                //    }
                //else
                //    MessageBox.Show("No Way Found");
                if (Maze.MC == 0)
                    MessageBox.Show("The way is blocked");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }


        void ResetPanels(Panel[,] Panels, int W, int H)
        {
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    if (Panels[i, j].BackColor != Color.Blue)
                        Panels[i, j].BackColor = Color.White;
                }
            }
        }

        List<Panel> A, B, C;
        bool ResetHanoi = false;
        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine(numericUpDown3.Value.ToString() + " Hanoi Go ");
                if (ResetHanoi)
                    numericUpDown3_ValueChanged(numericUpDown3, e);
                int Disks = (int)numericUpDown3.Value, M = (int)Math.Pow(2, Disks) - 1;
                Hanoi.Index = 0;
                Hanoi.Storage = new char[M, 2];
                Hanoi.hanoi(Disks, 'A', Temp, Dest);
                ResetHanoi = true;
                for (int i = 0; i < M; i++)
                    MovePanel(Hanoi.Storage[i, 0] == 'A' ? A : Hanoi.Storage[i, 0] == 'B' ? B : C, Hanoi.Storage[i, 1] == 'A' ? A : Hanoi.Storage[i, 1] == 'B' ? B : C, Hanoi.Storage[i, 1] == 'A' ? ATower : Hanoi.Storage[i, 1] == 'B' ? BTower : CTower);


                GC.Collect();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        void MovePanel(List<Panel> Start, List<Panel> Finish, Panel FTower)
        {
            int Step = -1, PanelIndex = Start.Count - 1;
            if (FTower.Left > Start[PanelIndex].Left)
                Step = 1;
            Application.DoEvents();
            Thread.Sleep(100);
            int Limit = FTower.Top - 15;
            while (Start[PanelIndex].Top > Limit)
            {
                Start[PanelIndex].Top--;
                if (Start[PanelIndex].Top % 4 == 0)
                    Thread.Sleep(1);
            }
            Application.DoEvents();
            Thread.Sleep(100);
            Limit = FTower.Left - ((Start[PanelIndex].Width - FTower.Width) / 2);
            while (Start[PanelIndex].Left != Limit)
            {
                Start[PanelIndex].Left += Step;
                if (Start[PanelIndex].Left % 4 == 0)
                    Thread.Sleep(1);
            }
            Application.DoEvents();
            Thread.Sleep(100);
            Limit = FTower.Top + FTower.Height - (Finish.Count * 11 + 11);
            while (Start[PanelIndex].Top < Limit)
            {
                Start[PanelIndex].Top++;
                if (Start[PanelIndex].Top % 4 == 0)
                    Thread.Sleep(1);
            }
            Application.DoEvents();
            Thread.Sleep(100);
            Finish.Add(Start[PanelIndex]);
            Start.RemoveAt(PanelIndex);
            Thread.Sleep(300);
        }

        char Dest = 'C', Temp = 'B';
        Random Rnd = new Random();
        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                //for (int i = 0; i < 8; i++)
                //    for (int j = 0; j < 8; j++)
                //    {
                Debug.WriteLine(numericUpDown4.Value.ToString() + " " + numericUpDown5.Value.ToString() + " Knight Go ");
                int W2 = int.Parse(numericUpDown4.Value.ToString()) - 1;
                int H2 = int.Parse(numericUpDown5.Value.ToString()) - 1;
                KnightMove.Way = new int[8, 8];
                KnightMove.Count = 1;
                KnightMove.WayBackUp = KnightMove.Copy2DArray(KnightMove.Way);
                ResetPanelsKnight(PanelsKnight, 8, 8);
                KnightMove.Scoring();
                GC.Collect();
                KnightMove.Way[W2, H2] = 1;
                PanelsKnight[W2, H2].BackColor = Color.FromArgb(255, 255, 255);
                PanelsKnight[W2, H2].BackgroundImage = Properties.Resources.Picture11;
                Thread.Sleep(250);
                KnightMove.UpdateScore(W2, H2);
                KnightMove.BestMoves(W2, H2, PanelsKnight);
                MessageBox.Show(KnightMove.Count.ToString() /*+ "  " + i + "  " + j*/);
                //}
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        void ResetPanelsKnight(Panel[,] P, int W, int H)
        {
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    if (P[i, j].BackColor != Color.White)
                    {
                        P[i, j].BackColor = Color.White;
                        P[i, j].BackgroundImage = null;
                        Application.DoEvents();
                    }
                }
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown3.Enabled = false;
            int Count = int.Parse(numericUpDown3.Value.ToString());
            CreatePanelsForHanoi(tabPage5, Count, ATower);
            button17.Enabled = true;
            numericUpDown3.Enabled = true;
            GC.Collect();
            ResetHanoi = false;
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine(textBox2.Text + " SQRT ");
                textBox4.Text = MahanInteger.Sqrt(textBox2.Text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine(textBox8.Text + " Generate NE ");
                int n = int.Parse(textBox8.Text);
                dataGridView2.ColumnCount = 1;
                dataGridView3.ColumnCount = n;
                dataGridView3.RowCount = n;
                dataGridView2.RowCount = n;
                GC.Collect();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine("Calaculate NE");
                int n = int.Parse(textBox8.Text);
                int[,] l, NewL;
                l = DeterminanOp.Inputs(dataGridView3, dataGridView2, n);
                int[,] ListOfNums = new int[n, n];
                int[] equ = new int[n];

                for (int i = 0; i < n; i++)
                {
                    equ[i] = l[i, n];
                    for (int j = 0; j < n; j++)
                        ListOfNums[i, j] = l[i, j];
                    Application.DoEvents();
                }
                int Delta = DeterminanOp.Determinan(n, ListOfNums);
                textBox9.Text = "";
                for (int i = 0; i < n; i++)
                {
                    Application.DoEvents();
                    DeterminanOp.CopyArray(ListOfNums, out NewL, n);
                    for (int j = 0; j < n; j++)
                        NewL[j, i] = equ[j];
                    double ans = DeterminanOp.Determinan(n, NewL);
                    textBox9.Text += (char)(i + 65) + " = " + ans / Delta + "     " + ans + "/" + Delta + "\r\n";
                }
                GC.Collect();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine(textBox2.Text + " Bigger " + textBox3.Text);
                int Result = MahanInteger.WhichIsBigger(textBox2.Text, textBox3.Text);
                if (Result == 1)
                    textBox4.Text = textBox2.Text;
                if (Result == 0)
                    textBox4.Text = textBox2.Text + " = " + textBox3.Text;
                if (Result == -1)
                    textBox4.Text = textBox3.Text;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine(textBox2.Text + " Smaller " + textBox3.Text);
                int Result = MahanInteger.WhichIsSmaller(textBox2.Text, textBox3.Text);
                if (Result == 1)
                    textBox4.Text = textBox2.Text;
                if (Result == 0)
                    textBox4.Text = textBox2.Text + " = " + textBox3.Text;
                if (Result == -1)
                    textBox4.Text = textBox3.Text;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine(textBox2.Text + " Equal " + textBox3.Text);
                bool Result = MahanInteger.IsEqual(textBox2.Text, textBox3.Text);
                if (Result)
                    textBox4.Text = textBox2.Text + " = " + textBox3.Text;
                if (!Result)
                    textBox4.Text = textBox2.Text + " != " + textBox3.Text;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(" Feedback ");
            System.Diagnostics.Process.Start("http://www.easypolls.net/poll.html?p=5acf57d2e4b038074b0da00c");
        }
        static Panel[,] QueenPanels;

        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentAnswer < NQueen.Count - 1)
                {
                    button26.Enabled = false;
                    button27.Enabled = false;
                    Debug.WriteLine(" NQueen Next " + CurrentAnswer);
                    Application.DoEvents();
                    CurrentAnswer++;
                    int A = button25.Left + button25.Width + 10, B = button25.Top;
                    DeleteOldPanels(QueenPanels, W3, W3);
                    QueenPanels = new Panel[W3, W3];
                    InsertPanels(QueenPanels, W3, W3, tabPage9, A, B, 40, 40, false);
                    ITPQh(QueenPanels, W3, NQueen.QueensPlace[CurrentAnswer]);
                    Application.DoEvents();
                    button26.Enabled = true;
                    button27.Enabled = true;
                }
                else
                    Debug.WriteLine(" NQueen End");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        int CurrentAnswer = 0;
        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine(numericUpDown6.Value.ToString() + " NQueen Generate");
                DeleteOldPanels(QueenPanels, W3, W3);
                W3 = int.Parse(numericUpDown6.Value.ToString());
                int A = button25.Left + button25.Width + 10, B = button25.Top;
                int[] In2 = new int[W3];
                for (int i = 0; i < W3; i++)
                    In2[i] = i;
                NQueen.QueensPlace = new List<List<int>>();
                NQueen.Count = 0;
                Application.DoEvents();
                NQueen.A2(W3, In2, 0);
                button26.Enabled = true;
                button27.Enabled = true;
                CurrentAnswer = 0;
                QueenPanels = new Panel[W3, W3];
                InsertPanels(QueenPanels, W3, W3, tabPage9, A, B, 40, 40, false);
                ITPQh(QueenPanels, W3, NQueen.QueensPlace[CurrentAnswer]);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            try
            {

                if (CurrentAnswer != 0)
                {
                    button26.Enabled = false;
                    button27.Enabled = false;
                    Debug.WriteLine(" NQueen Previous " + CurrentAnswer);
                    CurrentAnswer--;
                    int A = button25.Left + button25.Width + 10, B = button25.Top;
                    DeleteOldPanels(QueenPanels, W3, W3);
                    QueenPanels = new Panel[W3, W3];
                    Application.DoEvents();
                    InsertPanels(QueenPanels, W3, W3, tabPage9, A, B, 40, 40, false);
                    ITPQh(QueenPanels, W3, NQueen.QueensPlace[CurrentAnswer]);
                    button26.Enabled = true;
                    button27.Enabled = true;
                }
                else
                    Debug.WriteLine(" NQueen -1");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine(" Exp Start");
                string In = textBox10.Text;

                In = Exp.AddSpace(In);
                string[] s = In.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), s2;
                s2 = Exp.InfixToPostFix(s);
                string Post = "";
                foreach (string a in s2)
                    Post += (a + " ");
                Debug.WriteLine(Post + " Exp ");
                textBox12.Text = Post;
                double x;
                x = Exp.Eval(s2);
                textBox11.Text = x.ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void button29_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button30_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Minimized;
        }
        bool MouseIsDown = false;
        int x, y;

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseIsDown = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseIsDown)
            {
                Left += e.X - x;
                Top += e.Y - y;
            }
        }

        private void button30_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button29_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label33_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(" Go To About Page");
            tabControl1.SelectTab(tabPage8);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/mahansalehi82/AliSalehi-Programming-Problems");
        }

        private void button32_Click(object sender, EventArgs e)
        {
            ChangeTheme(Color.Gray, Color.White);
        }

        void ChangeTheme(Color BackColor, Color ForeColor)
        {
            Debug.WriteLine(BackColor + " " + ForeColor);
            for (int i = 0; i < tabControl1.TabCount; i++)
            {
                tabControl1.TabPages[i].BackColor = BackColor;
                tabControl1.TabPages[i].ForeColor = ForeColor;
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            ChangeTheme(Color.White, Color.Black);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            ChangeTheme(Color.Black, Color.White);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            ChangeTheme(Color.Green, Color.White);
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("Go To Tab " + tabControl1.SelectedIndex);
        }

        private void button31_Click(object sender, EventArgs e)
        {

            Debug.WriteLine(numericUpDown1.Value.ToString() + " Maze Best2 " + numericUpDown2.Value.ToString());
            Maze.Best3 = null;
            ResetPanels(PanelsArray, W, H);
            GC.Collect();

            Maze.Way = Maze.MakeArrayFromPanels(PanelsArray, W, H);
            Maze.WayBackUp = Maze.Copy2DArray(Maze.Way, W, H);
            Maze.Way[0, 0] = 2;
            Maze.Best = W * H;
            Maze.FindWays3(W, H, 0, 0, 0); ;
            if (Maze.Best3 == null)
            {
                MessageBox.Show("The way is blocked");
            }
            else if (Maze.Best3[W - 1, H - 1] == 2)
                for (int i = 0; i < W; i++)
                {
                    for (int j = 0; j < H; j++)
                    {
                        if (Maze.Best3[i, j] == 2)
                        {
                            PanelsArray[i, j].BackColor = Color.Green;
                            Application.DoEvents();
                        }
                    }
                }
            else
                MessageBox.Show("No Way Found");
        }

        private void button34_Click_1(object sender, EventArgs e)
        {
            Graph.InsertWays(textBox13.Text, int.Parse(textBox14.Text), ref Graph.L);
            string[,] h;
            int Val;
            Graph.Floyd(int.Parse(textBox14.Text), Graph.L, listBox1, out h, out Val);
        }


        //  ********************************************************
        //  ********************************************************
        //  ********************** Mahan File **********************
        //  ********************************************************
        //  ********************************************************
        //                         IIIIIIIIII
        //                         VVVVVVVVVV

        string Path = "";

        byte[] AllToByte(string G)
        {
            int h = G.Length % 8;
            int ZeroCounts = 0;
            if (h > 0)
                for (int i = 1; i <= 8 - h; i++)
                {
                    G += "0";
                    ZeroCounts++;
                }
            string H = Convert.ToString(ZeroCounts, 2);
            AddNeededBits(ref H, 8);
            G = H + G;
            byte[] Ret = new byte[G.Length / 8];
            int n = G.Length;
            for (int i = 0; i <= G.Length - 8; i += 8)
                Ret[i / 8] = ToByte(GetString(i, 8, G));
            return Ret;
        }
        void Print(string[] Ls)
        {
            for (int i = 0; i < Ls.Length; i++)
                if (Ls[i] != null)
                    Console.WriteLine(i + " = " + Ls[i]);
        }
        string MakeBinaryString(byte[] Bytes)
        {
            string Ret = "";
            foreach (byte b in Bytes)
            {
                string L = Convert.ToString(b, 2);
                AddNeededBits(ref L, 8);
                Ret += L;
            }
            return Ret;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DialogResult DR = OpenMahanFile.ShowDialog();
            if (DR == DialogResult.OK)
            {
                Path = OpenMahanFile.FileName;
                bool b = Path.EndsWith(".mah");
                button36.Enabled = true;
                if (b)
                    button37.Enabled = true;
            }
        }


        private void button36_Click(object sender, EventArgs e)
        {
            DialogResult Dr = saveFileDialog1.ShowDialog();
            if (Dr == DialogResult.OK)
            {
                int First, Last, LC;
                byte[] s = File.ReadAllBytes(Path);
                int[] Cs = CountLetters(s, out First, out Last, out LC);
                string[] Ls = new string[256];
                BST.BinaryCodes(Compress(Cs, First, Last), "", Ls);
                progressBar1.Maximum = s.Length;
                byte[] B = AllToByte(FormatTheOutput(LC, Ls, s, progressBar1));

                File.WriteAllBytes(saveFileDialog1.FileName, B);
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            DialogResult Dr = OpenMahanFile.ShowDialog();
            if (Dr == DialogResult.OK)
            {
                byte[] p = File.ReadAllBytes(OpenMahanFile.FileName), p2;
                string a = MakeBinaryString(p);
                p2 = Decompress(a).ToArray();
                Dr = saveFileDialog1.ShowDialog();
                if (Dr == DialogResult.OK)
                    File.WriteAllBytes(saveFileDialog1.FileName, p2);


            }

        }
        //                         ^^^^^^^^^^
        //                         IIIIIIIIII
        //  ********************************************************
        //  ********************************************************
        //  ********************** Mahan File **********************
        //  ********************************************************
        //  ********************************************************

        //private void button38_Click(object sender, EventArgs e)
        //{
        //    string s = "{";
        //    for (int i = 0; i < numericUpDown2.Value; i++)
        //    {
        //        s += "{";
        //        for (int j = 0; j < numericUpDown1.Value; j++)
        //        {
        //            if (PanelsArray[i, j].BackColor == Color.Blue)
        //                s += "1";
        //            else
        //                s += "0";
        //            if (j != numericUpDown1.Value-1)
        //                s += ",";
        //        }
        //        s += "},";
        //    }
        //    s += "}";
        //    Clipboard.SetText(s);
        //}

        /////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////
        ///////////////// Maze Picture Box //////////////////////
        /////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////


        int PictureBoxIndex = 0;
        void ChangeMazeIndex(int Index)
        {
            pictureBox11.Image = imageList1.Images[Index];
            PictureBoxIndex = Index;
            comboBox4.SelectedIndex = Index;
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeMazeIndex(comboBox4.SelectedIndex);
        }

        private void button39_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine(numericUpDown1.Value.ToString() + " Maze Create " + numericUpDown2.Value.ToString());
                DeleteOldPanels(PanelsArray, W, H);
                W = Dimensions[PictureBoxIndex];
                H = W;
                GC.Collect();
                Application.DoEvents();
                PanelsArray = new Panel[W, H];
                int A = button13.Left + button13.Width + 50, B = button13.Top;
                InsertPanels(PanelsArray, W, H, tabPage4, A, B, 30, 30, true, ReadyToUseMaze[PictureBoxIndex]);
                button14.Enabled = true;
                button31.Enabled = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(numericUpDown1.Value.ToString() + " Maze Best Floyd " + numericUpDown2.Value.ToString());
            ResetPanels(PanelsArray, W, H);
            GC.Collect();
            int[,] maze = Maze.MakeArrayFromPanels(PanelsArray, W, H);
            maze = MakeFloydArray(maze, W, H);
            string[,] Ways;
            int Val;
            Graph.Floyd(W * H, maze, listBox1, out Ways, out Val);
            listBox1.Items.Clear();
            if (Val < 1000)
                ColorPanels(Val, Ways[0, W * H - 1], H);
            else
                MessageBox.Show("Way is blocked");
        }
        void ColorPanels(int Val, string Way, int H)
        {
            string[] Way1 = Way.Split('>');
            for (int i = 0; i < Way1.Length; i++)
            {
                int N = int.Parse(Way1[i]);
                int j = N % H;
                int i1 = N / H;
                PanelsArray[i1, j].BackColor = Color.Green;
            }
        }
        void FillArray(int[,] N, int W, int H)
        {
            for (int i = 0; i < W; i++)
                for (int j = 0; j < H; j++)
                {
                    N[i, j] = 10000;
                }
        }
        int[,] MakeFloydArray(int[,] Maze, int W, int H)
        {
            int n = W * H;
            int[,] Ret = new int[n, n];
            FillArray(Ret, n, n);
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    if (Maze[i, j] != 1)
                    {
                        int CurrentN = (i * H + j);
                        if (IsValidTile(W, H, i - 1, j - 1) && Maze[i - 1, j - 1] != 1)
                        {

                            int CurrentNum = ((i - 1) * H + (j - 1));
                            Ret[CurrentN, CurrentNum] = 1;
                        }
                        if (IsValidTile(W, H, i - 1, j) && Maze[i - 1, j] != 1)
                        {
                            int CurrentNum = ((i - 1) * H + j);
                            Ret[CurrentN, CurrentNum] = 1;
                        }
                        if (IsValidTile(W, H, i - 1, j + 1) && Maze[i - 1, j + 1] != 1)
                        {
                            int CurrentNum = ((i - 1) * H + (j + 1));
                            Ret[CurrentN, CurrentNum] = 1;
                        }
                        if (IsValidTile(W, H, i, j - 1) && Maze[i, j - 1] != 1)
                        {
                            int CurrentNum = (i * H + (j - 1));
                            Ret[CurrentN, CurrentNum] = 1;
                        }
                        if (IsValidTile(W, H, i, j + 1) && Maze[i, j + 1] != 1)
                        {
                            int CurrentNum = (i * H + (j + 1));
                            Ret[CurrentN, CurrentNum] = 1;
                        }
                        if (IsValidTile(W, H, i + 1, j - 1) && Maze[i + 1, j - 1] != 1)
                        {
                            int CurrentNum = ((i + 1) * H + (j - 1));
                            Ret[CurrentN, CurrentNum] = 1;
                        }
                        if (IsValidTile(W, H, i + 1, j) && Maze[i + 1, j] != 1)
                        {
                            int CurrentNum = ((i + 1) * H + j);
                            Ret[CurrentN, CurrentNum] = 1;
                        }
                        if (IsValidTile(W, H, i + 1, j + 1) && Maze[i + 1, j + 1] != 1)
                        {
                            int CurrentNum = ((i + 1) * H + (j + 1));
                            Ret[CurrentN, CurrentNum] = 1;
                        }
                    }

                }
            }
            return Ret;
        }
        bool IsValidTile(int W, int H, int IW, int IH)
        {
            if (W <= IW || H <= IH || IW <= -1 || IH <= -1)
                return false;
            return true;
        }

        private void button40_Click(object sender, EventArgs e)
        {

        }

        /////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////
        ///////////////// Maze Picture Box //////////////////////
        /////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseIsDown = true;
            y = e.Y;
            x = e.X;
        }

        void ITPQh(Panel[,] P, int n, List<int> Places)
        {
            for (int i = 0; i < n; i++)
            {
                Application.DoEvents();
                P[i, Places[i]].BackgroundImage = Properties.Resources.Queen;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
            ChangeMazeIndex(0);
            comboBox3.SelectedIndex = 0;
            PanelsKnight = new Panel[8, 8];
            int A = button18.Left + button18.Width + 10, B = button18.Top;
            InsertPanels(PanelsKnight, 8, 8, tabPage6, A, B, 45, 45, false);
            Application.DoEvents();
            int Count = int.Parse(numericUpDown3.Value.ToString());
            CreatePanelsForHanoi(tabPage5, Count, ATower);
            button17.Enabled = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                Dest = 'B';
                Temp = 'C';
            }
            else
            {
                Dest = 'C';
                Temp = 'B';
            }
            Debug.WriteLine("Hanoi Dest " + comboBox3.Items[comboBox3.SelectedIndex]);
        }

        void CreatePanelsForHanoi(TabPage Parent, int Count, Panel Tower)
        {
            DeleteOldPanelsHanoi(A);
            DeleteOldPanelsHanoi(B);
            DeleteOldPanelsHanoi(C);
            A = new List<Panel>();
            B = new List<Panel>();
            C = new List<Panel>();
            int Size = 20 + Count * 7;
            Random x = new Random();
            int top = Tower.Top + Tower.Height;
            for (int i = 0; i < Count; i++)
            {
                Panel p = new Panel();
                p.Width = Size;
                p.Height = 10;
                p.BackColor = Color.FromArgb(Rnd.Next(0, 256), Rnd.Next(0, 256), Rnd.Next(0, 256));
                p.Left = Tower.Left - (Size - Tower.Width) / 2;
                top -= 11;
                p.Top = top;
                p.Parent = Parent;
                p.BringToFront();
                A.Add(p);
                Size -= 7;
            }
        }

        void DeleteOldPanelsHanoi(List<Panel> Panels)
        {
            if (Panels != null)
                for (int i = 0; i < Panels.Count; i++)
                    Panels[i].Dispose();
            Application.DoEvents();

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Panel p = sender as Panel;
            p.BackColor = p.BackColor == Color.Blue ? Color.White : Color.Blue;
        }
    }
}
