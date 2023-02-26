using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

class Discr_Airfoil
{
//Coming soon...
}
class Profile_NACA4412 : Discr_Airfoil
{
    
    double[] pow_coefs = new double[] { 0.298222773, -0.127125232, -0.357907906, 0.291984971, -0.105174606 };
    double[] pow_exps = new double[] {0.5, 1, 2, 3, 4};
    double ys_finalcoef = 0.594689181 / 1.008930411365;
    double[] x_arr;
    double[] y_arr;
    double[] x_points;
    double[] y_points;
    double[] dx;
    double[] dy;
    double[] dL;
    double[] thetas;
    double[] x_mid;
    double[] y_mid;
    double[,] norms;
    double[,] tgs;
    CSV_Exporter exporter;
    int M, N;

    public Profile_NACA4412(double[] x_arr)
    {
        this.x_arr = x_arr;
        this.exporter = new CSV_Exporter(); //May send string fileloc here
        Console.WriteLine("PROF NACA4412 CONSTRUCTOR CALLED FOR {0} POINTS", x_arr.Length);
        gen_eqs();
        update();
    }
    public Profile_NACA4412()
    {
        this.exporter = new CSV_Exporter(); //May send string fileloc here
        gen_dummy();
        update();
    }

    public void export_gen_info()
    {
        this.exporter.Export_arrs_csv(new List<double[]>() { this.x_arr, this.y_arr }, new List<string>() { "X_P", "Y_P" });
    }
double[] prep_fliparr(double[] arr, bool y_flag = false)
    {
        double[] temp_arr = new double[arr.Length - 1];
        for (int i = arr.Length - 1; i > 0; i--)
        {
            temp_arr[arr.Length - 1 - i] = arr[i - 1];
        }
        if (y_flag)
        {
            arr = Utis_np.arr_mult_val(arr, -1);
        }
        arr = arr.Concat(temp_arr).ToArray();
        return arr;
    }

    void gen_dummy() {
        Console.WriteLine("GEN DUMMY METHOD CALLED");
        List<double[]> loc_points = ROT_tests.twoP_vpanel();
        this.x_arr = loc_points[0];
        this.y_arr = loc_points[1];
    }
    void gen_eqs()
    {
        Console.WriteLine("GEN EQS METHOD CALLED");
        this.y_arr = new double[this.x_arr.Length];
        for (int i =0; i<this.x_arr.Length; i++)
        {
            this.y_arr[i] = ys_x(this.x_arr[i]);
        }
        this.x_arr = prep_fliparr(this.x_arr);
        this.y_arr = prep_fliparr(this.y_arr, true);
        
    }

    void update()
    {
        this.x_points = this.x_arr; //Utis_np.appnd_last(this.x_arr);
        this.y_points = this.y_arr; //Utis_np.appnd_last(this.y_arr);
        this.dx = Utis_np.Arr_diff(this.x_points);
        this.dy = Utis_np.Arr_diff(this.y_points);

        this.thetas = Utis_np.Arrs_arctan(this.dx, this.dy);
        this.x_mid = Utis_np.Arr_midpoint(this.dx, this.x_points);
        this.y_mid = Utis_np.Arr_midpoint(this.dy, this.y_points);
        this.M = this.x_mid.Length;
        this.N = this.x_points.Length;
        calc_panel_lenght();
        gen_nts();
    }
    void calc_panel_lenght()
    {
        this.dL = new double[this.M];
        for (int i = 0; i < this.M; i++)
        {
            this.dL[i] = Math.Sqrt(Math.Pow(this.dx[i],2) + Math.Pow(this.dy[i],2));
    }
        }

    void gen_nts()
    {
        this.norms = new double[this.M, 2];
        this.tgs = new double[this.M, 2];
        double[] tg_samp = Utis_rotvect.vect_sample_2D(0);
        double[] norm_samp = Utis_rotvect.vect_sample_2D(1);
        for (int i = 0; i < this.M; i++) {
            double[,] loc_mtg = Utis_rotvect.mtx_L2G(this.thetas[i]);
            double[] loc_norm = Utis_rotvect.rot_vect(norm_samp, loc_mtg);
            double[] loc_tg = Utis_rotvect.rot_vect(tg_samp, loc_mtg);
            this.norms[i,0] = loc_norm[0];
            this.norms[i,1] = loc_norm[1];
            this.tgs[i, 0] = loc_tg[0];
            this.tgs[i, 1] = loc_tg[1];
        }
    }

    double ys_x(double x_loc)
    {
        double ys = 0;
        for (int i = 0; i < this.pow_exps.Length; i++)
        {
            ys += this.pow_coefs[i] * Math.Pow(x_loc, this.pow_exps[i]);
        }
        ys *= this.ys_finalcoef;
        return ys;
    }
    }
class CSV_Exporter
    {
        string export_path;
        public CSV_Exporter(string export_path = @"D:\proyectos\visual_studio\theo_a_csharp\python_interp\")
        {
            this.export_path = export_path;
        }
    public void Export_arrs_csv(List<double[]> arr_lst, List<string> headers, string filename = "default.csv")
    {
        string header;
        StreamWriter exporter = new StreamWriter(this.export_path + filename);
        foreach (string item in headers)
        {
            exporter.Write(item);
            exporter.Write(";");
        }
        exporter.WriteLine();
        
        for (int i = 0; i < arr_lst[0].Length; i++)
        {
            string loc_line = "";
            foreach (double[] loc_arr in arr_lst)
            {
                loc_line += loc_arr[i].ToString(CultureInfo.InvariantCulture);
                loc_line += ";";
            }
            exporter.WriteLine(loc_line);
            exporter.Flush();
        }
        exporter.Close();
    }
}