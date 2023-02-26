using System;
using System.Globalization;
using System.Linq;

public class Utis_np
{
    public static double[] Arr_diff(double[] arr)
    {
        double[] diff = new double[arr.Length-1];

        for (int i = 0; i < arr.Length-1; i++)
        {
            diff[i] = arr[i + 1] - arr[i];
        }
        return diff;
    }

    public static double[] Arr_midpoint(double[] dx, double[] x_arr)
    {
        double[] midpoint = new double[dx.Length];
        for (int i = 0; i < dx.Length; i++)
        {
            midpoint[i] = (0.5*dx[i])+x_arr[i];
        }
        return midpoint;
    }
    public static double[] Arrs_arctan(double[] x_arr, double[] y_arr)
    {
        double[] thetas = new double[x_arr.Length];
        for (int i = 0; i < x_arr.Length; i++)
        {
            thetas[i] = Math.Atan2(y_arr[i], x_arr[i]);
        }
        return thetas;
    }
    public static double convert2radians(double angle)
    {
        return (Math.PI / 180) * angle;
    }
    public static double[] linspace(double startval, double endval, int steps)
        // Mimics numpy.linspace func (steps - 1)
    {
        double delta = (endval - startval) / (steps-1);
        double[] linspace = new double[steps];
        for (int i = 0; i < steps; i++)
        {
            linspace[i] = startval + delta * i;
        }
        return linspace;
    }

    public static double[] theta_dist(double [] arr) {
        for (int i = 0; i<arr.Length; i++)
        {
            arr[i] = 0.5 * (1 - Math.Cos(arr[i]));
        }
        return arr;
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
            Console.Write(arr[i].ToString("N5",CultureInfo.InvariantCulture));
            Console.Write(' ');
        }
        Console.Write('\n');
        Console.WriteLine("ARR PRNT DONE");
    }

    public static void prnt_mtrx(double[,] mtrx)
    {
        int rows = mtrx.GetLength(0);
        int cols = mtrx.GetLength(1);
        Console.WriteLine($"BEGIN MTRX PRNT, SHAPE: ({rows},{cols})", rows, cols);
        for (int i =0; i<rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(mtrx[i, j].ToString("N5", CultureInfo.InvariantCulture));
                Console.Write(' ');
            }
            Console.WriteLine();
        }
        Console.WriteLine("MTRX PRNT DONE");
    }

    public static double[] arr_mult_val(double[] arr, double value)
    {
        for (int i = 0; i<arr.Length; i++)
        {
            arr[i] *= value;
        }
        return arr;
    }

    public static double[] appnd_first(double[] arr)
    {
        double[] last_value = new double[] { arr[0] };
        arr = arr.Concat(last_value).ToArray();
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

    public static double[,] mtx_L2G(double beta, bool degrees = false)
    {
        if (degrees)
        {
            beta = Utis_np.convert2radians(beta);
        }
        
        double[,] mtx = new double[2, 2] { { Math.Cos(beta), -Math.Sin(beta) },
        {Math.Sin(beta), Math.Cos(beta) } };
        return mtx;
    }
    public static double[,] mtx_G2L(double beta, bool degrees = false)
    {
        if (degrees)
        {
            beta = Utis_np.convert2radians(beta);
        }
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
            }
        }
        return rotated;
    }
}