using System;
using System.Linq;

class Profile_NACA4412
{
    decimal c;
    decimal t;
    int M;
    int N;

    public Profile_NACA4412(double[] x_arr)
    {
        Console.WriteLine("PROF NACA4412 CONSTRUCTOR CALLED FOR {0} POINTS", x_arr.Length);
        gen_eqs(x_arr);
    }

    double[] prep_xps(double[] arr)
    {
        double[] temp_arr = new double[arr.Length-1];
        for (int i = arr.Length-1; i > 0; i--)
        {
            Console.WriteLine(i);
            temp_arr[arr.Length-1-i] = arr[i-1];
        }
        Utis_np.prnt_arr(temp_arr);
        arr = arr.Concat(temp_arr).ToArray();
        return arr;
    }
    void gen_eqs(double[] x_arr)
    {
        Console.WriteLine("GEN EQS METHOD CALLED");
        Utis_np.prnt_arr(prep_xps(x_arr));
    }
}