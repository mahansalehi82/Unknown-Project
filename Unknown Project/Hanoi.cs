using System.Windows.Forms;
using System;
public class Hanoi
{
    public static char[,] Storage;
    public static int Index=0;
    public static void hanoi(int nDisk, char start, char temp, char finish)
    {
        if (nDisk == 1)
        {
            Application.DoEvents();
            Storage[Index, 0] = start;
            Storage[Index, 1] = finish;
            Console.WriteLine("Hanoi Move " + Storage[Index, 0] + " To " + Storage[Index, 1]);
            Index++;
        }
        else
        {
            Application.DoEvents();
            hanoi(nDisk - 1, start, finish, temp);
            Storage[Index, 0] = start;
            Storage[Index, 1] = finish;
            Console.WriteLine("Hanoi Move " + Storage[Index, 0] + " To " + Storage[Index, 1]);
            Index++;
            hanoi(nDisk - 1, temp, start, finish);
        }
    }
}
