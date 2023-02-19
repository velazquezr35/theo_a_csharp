using System;

public class Utis_np
{
    public static float[] linspace(float startval, float endval, int steps)
    {
        float delta = Math.Abs(startval - endval) / steps;
        float[] linspace = new float[steps];
        for (int i = 0; i < steps; i++)
        {
            linspace[i] = startval + delta * i;
        }
        Console.WriteLine(delta);
        return linspace;
    }
    public static void prnt_arr(float[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]);
        }
        Console.WriteLine("/n");
        Console.WriteLine("Done!");
    }

    public static float[] arr_mult_val(float[] arr, float value)
    {
        //float[] loc_test = new float[arr.Length];
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

}