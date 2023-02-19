﻿using System;

class Profile_NACA4412
{
    decimal c;
    decimal t;
    int M;
    int N;

    public Profile_NACA4412(float[] x_arr)
    {
        Console.WriteLine("PROF NACA: x-arr based constructor called for {0} points", x_arr.Length);
        gen_eqs(x_arr);
    }

    void gen_eqs(float[] x_arr)
    {
        Console.WriteLine("Gen_eqs method called...");
        float[] loc_test = new float[x_arr.Length];
        loc_test = Utis_np.arr_mult_val(x_arr, 2);
        Utis_np.prnt_arr(loc_test);
        Utis_np.prnt_arr(x_arr);
    }
}