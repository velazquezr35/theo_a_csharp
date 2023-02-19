using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.ComponentModel;

class Program
{
    static void Main()
    {
        //Def vars
        float[] x_arr;

        //Create x_points array
        //this should become from an user input
        x_arr = Utis_np.linspace(0, 10, 5);
        Profile_NACA4412 Prof_test = new Profile_NACA4412(x_arr); //Init prof obj
        Console.ReadKey();
    }
    static void NewCMD()
    {
        
        ProcessStartInfo p_info = new ProcessStartInfo("CMD.exe");
        p_info.UseShellExecute = true;
        p_info.CreateNoWindow = false;
        p_info.WorkingDirectory = @"D:\proyectos\visual_studio\theo_a_csharp\python_interp";
        string strCmdText;
        strCmdText = "/K D:/Programas/Conde/Scripts/activate.bat D:/Programas/Conde & python test.py";
        //System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        p_info.Arguments = strCmdText;
        Process.Start(p_info);
    }
    }