using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iustbot
{
    class AZ1az2
    {
        public static string jad1(string payam)
        {

            try
            {

                double M, t,Tave=0,Enhraf = 0,Kave = 0,dTave = 0;
                M = ((double.Parse(payam.Substring(0, 5))) / 1000);
                payam = payam.Remove(0, 5);
                double[] k = new double[((payam.Length) / 4)];
                double[] T = new double[((payam.Length) / 4)];
                double x = 0;
                x = ((payam.Length)/4);
                for (int i = 0; i < ((payam.Length)/4); i++)
                {
                    t = double.Parse(payam.Substring(4 * i, 4));

                    T[i] = ((t) / 10);
                    Tave = Tave + T[i];
                    k[i] = (4 * (Math.Pow(Math.PI, 2)) * M) / (Math.Pow(T[i], 2));
                }
                Tave = (Tave / ((payam.Length) / 4));
                string javab = null;
                for (int i = 0; i < ((payam.Length) / 4); i++)
                {
                    Enhraf = Enhraf + (Math.Pow((k[i] - Kave),2));
                    Kave = Kave + k[i];
                    javab = javab + k[i].ToString() + "\n" ;
                    dTave = dTave + Math.Pow(T[i] - Tave,2);
                }

                javab = javab + "dK= " +
                    (((4 * (Math.Pow(Math.PI, 2))) /
                    (Math.Pow(Tave, 2))) * 0.0001 +
                    ((8 * M * (Math.Pow(Math.PI, 2))) /
                    (Math.Pow(Tave, 3))) * 0.01)
                    + "\nKave= " +
                    (Kave / ((payam.Length) / 4)).ToString()
                    + "\ndTave= " +
                    (Math.Sqrt(dTave / (x * (x - 1)))).ToString()
                    + "\nK(Tave)= " +
                    ((4 * M * Math.Pow(Math.PI, 2)) / (Math.Pow(Tave, 2))).ToString()
                    + "\nTave= " +
                    Tave.ToString()
                    + "\n انحراف معیار= " +
                    (Math.Sqrt(Enhraf / (x - 1))).ToString();
                    ;
                return javab ;
            }
            catch 
            {
                return "حاجی اشتباه میزنی";
                
            }
            
        }
    }
}
