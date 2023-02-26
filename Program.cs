using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main()
    {
        //Def vars
        double[] x_arr;

        //Create x_points array
        //this should become from an user input
        //gen x_arr using theta dist
        x_arr = Utis_np.linspace(Math.PI, 0, 5);
        x_arr = Utis_np.theta_dist(x_arr);

        Profile_NACA4412 Prof_test = new Profile_NACA4412(x_arr); //Init prof obj
        //NewCMD();
        Console.ReadKey();
        

        //double[] vect = Utis_rotvect.vect_sample_2D();
        //double[,] mtx = Utis_rotvect.mtx_G2L(90);
        //vect = Utis_rotvect.rot_vect(vect, mtx);
    }
    static void NewCMD()
    {
        
        ProcessStartInfo p_info = new ProcessStartInfo("CMD.exe");
        p_info.UseShellExecute = true;
        p_info.CreateNoWindow = false;
        p_info.WorkingDirectory = @"D:\proyectos\visual_studio\theo_a_csharp\python_interp";
        string strCmdText;
        strCmdText = "/K D:/Programas/Conde/Scripts/activate.bat D:/Programas/Conde & python test.py & exit";
        //System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        p_info.Arguments = strCmdText;
        Process.Start(p_info);
        Console.ReadKey();
    }
    }