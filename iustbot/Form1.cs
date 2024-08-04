using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot.Types.ReplyMarkups;
using System.IO;
using System.Net.NetworkInformation;
using Telegram.Bot;

namespace iustbot
{
    public partial class Form1 : Form
    {
        private Thread botthread;
        private Telegram.Bot.TelegramBotClient bot;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            botthread = new Thread(runbot);
            botthread.Start();

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            botthread.Abort();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void runbot()
        {
            bot = new Telegram.Bot.TelegramBotClient("6612754792:AAEs3zDWm0FGEUUsGXprPAs8NQmYt7ohdDM");
            //this.Invoke(new Action(() => {}));
            int offset = 0;
            while (true)
            {
                Telegram.Bot.Types.Update[] updates = bot.GetUpdatesAsync(offset).Result;
                foreach (var up in updates)
                {
                    offset = up.Id + 1;
                    if (up.Message == null) { continue; }
                    var chatid = up.Message.Chat.Id;
                    var payamid = up.Message.MessageId;
                    var aks = up.Message.Photo;
                    var payam = up.Message.Text;
                    if (payam == null) { continue; }
                    var ferestande = up.Message.From;
                    string sub, z = null;
                    string y = null;
                    double avreage = 0, enheraf = 0;
                    double[] x = new double[10];

                    string savepayam = @"D:savepayam.txt";
                    string[] lines = { "id: " + chatid, "name: " + ferestande, "matn: " + payam, "id payam: " + payamid, "zaman: " + up.Message.Date.ToString(), "----------------------- " };
                    File.AppendAllLines(savepayam, lines);

                    if (payam != null)
                    {
                        dataGridView1.Invoke(new Action(() => dataGridView1.Rows.Add(chatid, ferestande, "0", payam.ToString(), up.Message.Date.ToString("yyyy/MM/dd - HH:mm:ss"))));
                    }
                    else
                    {
                        dataGridView1.Invoke(new Action(() => dataGridView1.Rows.Add(chatid, ferestande, "0", "chat id:" + payamid, up.Message.Date.ToString("yyyy/MM/dd - HH:mm:ss"))));
                    }
                    if (payam == "!")
                    {
                        bot.SendTextMessageAsync(chatid, "آز1\n10101=آزمایش شماره یک: آشنایی با تعدادی از وسایل اندازه گیری دقیق");
                    }
                    if (payam.Length <= 3) { break; };
                    if (payam == "/start")
                    {
                        bot.SendTextMessageAsync(chatid, "سلام\nچطوری\nممنون که این بات انتخاب کردی\nبرای کار با این ربات یه قاعده خیلی ساده داریم\nتو خط اول هر پیام یک عدد 5 روقمی وارد میکنیم\nعدد دهزارگان ما شماره آزمایشگاه یعنی آز1 یا آز2\nعدد صدگان و هزارگان که یک عدد دو رقمی هست شماره آزمایش هست\nو در آخر دو رقم آخر شماره فرمول هستش\nحالا بخش مهم اینه که بعد این عدد : یا ؟ بزاری حالا توضیح هر کدوم\n؟ یعنی این چی هست و باید به چه فنتی وارد کنم\n: یعنی یه اینتر بزن و طبق ترتیبی که تو بخس ؟ گفته داده هات وارد کن\n برای دیدن آزمایشات موجود ! بفرست \nروش کار میتونی تو لینک مقابل هم ببینی https://t.me/hadnesab/12 \nو در آخر از همه اینکه در حال توسعه هستیم و سرور نداریم");
                    }
                    //پشتیبانی
                    else if (payam.IndexOf(':') == 8)
                    {
                        bot.SendTextMessageAsync(chatid, "پیام شما برسی خواهد شد ");
                        MessageBox.Show(payam);
                    }
                    //آزمایش اول آز1
                    else if (payam.Substring(0, 3) == "101")
                    {
                        if (payam.Substring(3, 2) == "01")
                        {
                            if (payam.Substring(5, 1) == ":")
                            {
                                payam = payam.Remove(0, 6);
                                try
                                {
                                    for (int i = 0; i < 10; i++)
                                    {
                                        sub = payam.Substring(6 * i, 5);
                                        x[i] = double.Parse(sub);
                                        y = y + "h" + (i + 1) + "= " + x[i].ToString() + "\n";
                                        x[i] = (506.25 / (2 * x[i])) + ((x[i]) / 2);
                                        avreage = avreage + x[i];

                                    }
                                    for (int i = 0; i < 10; i++)
                                    {
                                        z = z + "R" + (i + 1) + "= " + x[i].ToString() + "\n";
                                        enheraf = enheraf + (x[i] - (avreage / 10));
                                    }
                                    enheraf = enheraf / 9;
                                    Math.Sqrt(enheraf);
                                    bot.SendTextMessageAsync(chatid, "https://t.me/hadnesab/8");
                                    bot.SendTextMessageAsync(chatid, y);
                                    bot.SendTextMessageAsync(chatid, z + "R(ave)= " + (avreage / 10).ToString() + "\nانحراف معیار= " + enheraf.ToString());
                                }
                                catch
                                {
                                    bot.SendTextMessageAsync(chatid, "حاجی اشتباه میزنی  \nاگر مشکلی هست اول<پشتیبان:> بنویس بعد مشکلتو مثلا \nپشتیبانی: سلام مشکلم فلانه ", null, null, null, null, null, null, payamid);

                                }
                            }
                            else if (payam.Substring(5) == "؟" || payam.Substring(5) == "?")
                            {
                                bot.SendTextMessageAsync(chatid, "آزمایش شماره یک: آشنایی با تعدادی از وسایل اندازه گیری دقیق\nفرمول مورد نظر در آدرس: https://t.me/hadnesab/8 \nفونت وارد کردن اطلاعات به صورت زیر هستش\n10101:\nh1\nh2\nh3\nh4\nh5\nh6\nh7\nh8\nh9\nh10\nمثال \n10101:\n12.38\n05.30\nنکتش اینه که چهار رقمی بزن و با نقطه اعشار بزن و حتما 10 تا داده بده اگه ندی هیچ نمیشه");
                            }
                            else
                            {
                                bot.SendTextMessageAsync(chatid, "nashod");
                            }
                        }


                    }
                    else if (payam.Substring(0, 3) == "20501:")
                    {
                        payam = payam.Remove(7);
                        bot.SendTextMessageAsync(chatid, AZ2az5.jad1(payam));
                    }
                    else if (payam.Substring(0, 6) == "10201:")
                    {
                         payam = payam.Remove(0,7);
                        bot.SendTextMessageAsync(chatid, AZ1az2.jad1(payam));
                    }
                    else
                    {

                    }
                }
            }

        }
    }
}
