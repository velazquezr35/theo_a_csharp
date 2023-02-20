using System;

public class Utis_np
{
    public static double ConvertToRadians(double angle)
    {
        return (Math.PI / 180) * angle;
    }
    public static double[] linspace(double startval, double endval, int steps)
    {
        double delta = Math.Abs(startval - endval) / steps;
        double[] linspace = new double[steps];
        for (int i = 0; i < steps; i++)
        {
            linspace[i] = startval + delta * i;
        }
        Console.WriteLine(delta);
        return linspace;
    }
    public static void prnt_arr(double[] arr, string optionalname = "")
    {
        if (optionalname == "")
        {
            Console.WriteLine("BEGIN ARR PRNT");
        }
        else
        {
            Console.WriteLine("BEGIN ARR PRNT: " + optionalname);
        }
        
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]);
            Console.Write(' ');
        }
        Console.Write('\n');
        Console.WriteLine("ARR PRNT DONE");
    }

    public static void prnt_mtrx(double[,] mtrx)
    {
        int rows = mtrx.GetLength(0);
        int cols = mtrx.GetLength(1);
        Console.WriteLine("BEGIN MTRX PRNT, MTRX SHAPE: ({rows},{cols})");
        for (int i =0; i<rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(mtrx[i, j].ToString("N"));
                Console.Write(' ');
            }
            Console.WriteLine();
        }
        Console.WriteLine("MTRX PRNT DONE");
    }

    public static double[] arr_mult_val(double[] arr, double value)
    {
        //double[] loc_test = new double[arr.Length];
        for (int i = 0; i<arr.Length; i++)
        {
            //loc_test[i] = arr[i]*value;
            arr[i] *= value;
        }
        return arr;
    }
}
public class Utis_rotvect
{
    public static double[] vect_sample_2D(int opt = 0)
    {
        if (opt > 2 || opt < 0)
        {
            opt = 0;
        }
        double[] sample = new double[2];
        sample[opt] = 1;
        return sample;
    }

    public static double[,] mtx_L2G(double beta)
    {
        beta = Utis_np.ConvertToRadians(beta);
        double[,] mtx = new double[2, 2] { { Math.Cos(beta), -Math.Sin(beta) },
        {Math.Sin(beta), Math.Cos(beta) } };
        return mtx;
    }
    public static double[,] mtx_G2L(double beta)
    {
        beta = Utis_np.ConvertToRadians(beta);
        double[,] mtx = new double[2, 2] { { Math.Cos(beta), Math.Sin(beta) },
        {-Math.Sin(beta), Math.Cos(beta) } };
        return mtx;
    }
    public static double[] rot_vect(double[] vect, double[,] mtrx)
    {
        int l_col = vect.Length;
        double[] rotated = new double[l_col];
        for (int i = 0 ; i < l_col; i++)
        {
            for (int j = 0; j < l_col; j++)
            {
                rotated[i] += vect[j] * mtrx[i,j];
                Console.WriteLine(vect[j]);
                Console.WriteLine(mtrx[j,i]);
            }
        }
        return rotated;
    }
}