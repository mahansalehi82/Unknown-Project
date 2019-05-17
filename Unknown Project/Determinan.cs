using System;
using System.Windows.Forms;
public class DeterminanOp
{

    public static int Determinan(int n, int[ , ] Nums)
    {
        int ret = 0;
        if (n == 1)
            return Nums[0, 0];
        else
        {
            int[,] l = new int[n - 1, n - 1];

            for (int i = 0; i < n; i++)
            {
                int P1 = 1;
                for (int j = 1; j < n; j++)
                {
                    int P2 = 0;
                    for (int k = 0; k < n; k++)
                        if (k == i)
                            P2++;
                        else if (k != i)
                            l[j - P1, k - P2] = Nums[j, k];
                }
                ret += i % 2 == 0 ? Nums[0, i] * Determinan(n - 1, l) : -(Nums[0, i] * Determinan(n - 1, l));
            }
        }
        return ret;
    }
    public static int[,] Inputs(DataGridView DGV,DataGridView DGV_Ans,int n)
    {
        int[,]ret=new int[n,n+1];
        for(int i = 0; i < n; i++)
        {
            for(int j=0;j<n; j++)
            {
                ret[i, j] = int.Parse(DGV[j, i].Value.ToString());
            }
            ret[i, n] = int.Parse(DGV_Ans[0, i].Value.ToString());
        }
        return ret;
    }
    public static void CopyArray(int[ , ] ToCopy, out int[ , ] CopyTo, int n)
    {
        CopyTo = new int[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                CopyTo[i, j] = ToCopy[i, j];
    }
}

