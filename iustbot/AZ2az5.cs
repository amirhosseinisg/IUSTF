using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iustbot
{
    class AZ2az5
    {
        public static string jad1(string payam)
        {
            try
            {
                String Y = null;
                int x = ((payam.Length) / 4);
                double V, I, sum = 0;
                double[] R = new double[x];
                double[] ro = new double[x];
                for (int i = 0; i < x; i++)
                {
                    V = double.Parse(payam.Substring(0,4));
                    I = double.Parse(payam.Substring(4,4));
                    payam = payam.Remove(8);
                    R[i] = V / I;
                    ro[i] = R[i] * 0.2;
                    sum = sum + R[i];

                    
                }
                for (int i = 0; i < x; i++)
                {

                    Y = Y + ("dR" + (i + 1) + "=" + ((sum / x) - R[i]) + "\n" + "hamoon = " + ((((sum / x) - R[i]) / R[i]) * 100) + "\n" + "R" + (i + 1) + "=" + R[i] + "\n"+"رو= " + ro[i] + "\n");
                }
                return Y + "Rave=" + (sum / x).ToString() + "\n";
            }
            catch
            {

                return "حاجی اشتباه میزنی  \nاگر مشکلی هست اول<پشتیبان:> بنویس بعد مشکلتو مثلا \nپشتیبانی: سلام مشکلم فلانه \nفونت وارد کردن به صورت زیر است\n20501\nA\nI1\nI2\nI3\nI4\nI5\nI6\nI7\nI8\nI9\nI10\nI11\nمثال\n0.3\n0.03\n2.02\nنکتش اینه که عداد باید حتما سه رقم داشته باشه و با نقطه اعشار بزنی دوازده تا داده آمپر هم یادت نره";
            }
        }
    }
}
