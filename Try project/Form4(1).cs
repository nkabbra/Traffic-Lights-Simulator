using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;

namespace Try_project
{
    public partial class Form4 : Form
    {
        Queue c1 = new Queue();
        Queue c2 = new Queue();
        Queue c3 = new Queue();
        trafficlight tl;
        trafficlight t2;
        trafficlight t3;
        double direction;
        Stopwatch stopwatch = new Stopwatch();
      
        int carnb = -1;
        car[] cars;

        int carnb2 = -1;
        car[] cars2;

        int carnb3 = -1;
        car[] cars3;


        int[] lst;
        int[] lst2;
        int[] lst3;
      

        public Form4()
        {
            InitializeComponent();
        
            c1 = Expo(20, 1);
            c2 = Expo(10, 1);
            c3 = Expo(10, 1);
            tl = new trafficlight(RED1, GREEN1, YELLOW1, c1);
            t2 = new trafficlight(RED2, GREEN2, YELLOW2, c2);
            t3 = new trafficlight(RED3, GREEN3, YELLOW3, c3);
            this.ROAD1.SendToBack();
            this.ROAD2.SendToBack();
            pictureBox1.SendToBack();
         
            stopwatch.Start();
      

            cars = new car[c1.Count];
            lst = new int[c1.Count];
            for (int i = 0; i < c1.Count; i++) lst[i] = 10000;

            cars2 = new car[c2.Count];
            lst2 = new int[c2.Count];
            for (int i = 0; i < c2.Count; i++) lst2[i] = 10000;

            cars3 = new car[c3.Count];
            lst3 = new int[c3.Count];
            for (int i = 0; i < c3.Count; i++) lst3[i] = 10000;

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            button1.Location = new Point((this.Width - button1.Width) / 16, (this.ClientSize.Height - button1.Height) * 7 / 8);
            /* ROAD1.Location = new Point((this.Width - ROAD1.Width) / 2, (this.ClientSize.Height - ROAD1.Height) / 2);
             ROAD2.Location = new Point(((this.Width - ROAD2.Width) / 2)+600, (this.ClientSize.Height - ROAD2.Height) / 2);
             SQUARE.Location = new Point(((this.Width - SQUARE.Width) / 2)+3, (this.ClientSize.Height - SQUARE.Height) / 2);
             GREEN1.Location = new Point(490, 130);
             GREEN2.Location = new Point(770, 155);
             GREEN3.Location = new Point(750, 470);
             YELLOW1.Location = new Point(490, 130);
             YELLOW2.Location = new Point(770, 155);
             YELLOW3.Location = new Point(750, 470);
             RED1.Location = new Point(490, 130);
             RED2.Location = new Point(770, 155);
             RED3.Location = new Point(750, 470);
            */
        }
        public static Queue Expo(double mean, double period)
        {

            Queue q = new Queue();
            Random g = new Random();
            double current_time = 0.0, u, inter;
            while (current_time < period)
            {
                u = g.NextDouble(); // u in [0,1]
                inter = -1.0 / mean * Math.Log(1 - u);
                current_time += inter;
                if (current_time < period) q.Enqueue(current_time);
            }
            return q;
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void PGREEN2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
            this.Close();
        }

        private void GREEN1_Click(object sender, EventArgs e)
        {

        }

        private void YELLOW1_Click(object sender, EventArgs e)
        {

        }

        private void RED1_Click(object sender, EventArgs e)
        {

        }

        private void YELLOW2_Click(object sender, EventArgs e)
        {

        }

        private void RED2_Click(object sender, EventArgs e)
        {

        }
       

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tl.total > 0)
            {
                tl.counter++;

                tl.total--;



                tl.change();


            }
            else
            {

                if (t2.total > 0)
                {
                    t2.counter++;

                    t2.total--;

                    t2.change();


                }
                else
                {
                    if (t3.total > 0)
                    {
                        t3.counter++;

                        t3.total--;
                        t3.change();

                    }
                    if (t3.total == 0)
                    {
                        t3.total = t3.yellowtime + t3.greentime;
                        tl.total = tl.yellowtime + tl.greentime;
                        t2.total = t2.yellowtime + t2.greentime;
                    }

                }

            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (c1.Count != 0)// road 1
            {
                double d = (double)c1.Peek() * 60000;
                if (stopwatch.ElapsedMilliseconds > (int)(d))
                {
                    c1.Dequeue();
                    carnb++;
                    Random g = new Random();
                    direction = g.NextDouble();
                   
                    if (direction >= 0.3 )// go right
                    {
                        car aux = new car(380, 0, 1, 2);
                        aux.mid = 350;
                        aux.XFINAL = 5000;
                        aux.YFINAL = aux.mid;
                        aux.pb.Image = Properties.Resources.rightrun;
                        cars[carnb] = aux;
                    }
                    else// go straight
                    {
                        car aux = new car(380, 0, 1, 3);
                        aux.YFINAL = 2000;
                        aux.XFINAL = 555;
                        cars[carnb] = aux;
                    }
                    this.Controls.Add(cars[carnb].pb);
                    cars[carnb].pb.BringToFront();
                }

            }
            if (c2.Count != 0)// road 2
            {
                double d2 = (double)c2.Peek() * 60000;
                if (stopwatch.ElapsedMilliseconds > (int)(d2))
                {
                    c2.Dequeue();
                    carnb2++;
                    Random g2 = new Random();
                    direction = g2.NextDouble();
                    if (direction < 0.3) //go left 
                    {
                        car aux = new car(1050, 280, 2, 1);
                        aux.XFINAL = -50;
                        aux.YFINAL = aux.mid;
                        aux.mid = 380;
                        aux.road1Ylim = 540;
                        cars2[carnb2] = aux;
                    }
                    else// go right
                    {
                        car aux = new car(1050, 280, 2, 2);
                        aux.mid = 470;
                        aux.XFINAL = 5000;
                        aux.YFINAL = aux.mid;
                        aux.road1Ylim = 540;
                        cars2[carnb2] = aux;
                    }
                  

                    this.Controls.Add(cars2[carnb2].pb);
                    cars2[carnb2].pb.BringToFront();
                }

            }
            if (c3.Count != 0)// road 4
            {
                double d = (double)c3.Peek() * 60000;
                if (stopwatch.ElapsedMilliseconds > (int)(d))
                {
                    c3.Dequeue();
                    carnb3++;
                    Random g = new Random();
                    direction = g.NextDouble();
                  
                    if (direction >= 0.3)// go right
                    {
                        car aux = new car(470, 650, 4, 2);
                        aux.mid = 370;
                        aux.road1Ylim = 450;
                        aux.XFINAL = 5000;
                        aux.YFINAL = aux.mid;
                        aux.pb.Image = Properties.Resources.rightrun;
                        cars3[carnb3] = aux;
                    }
                    else // go straight
                    {
                        car aux = new car(470, 650, 4, 3);
                        aux.YFINAL = 2000;
                        aux.XFINAL = 555;
                        aux.mid = 280;
                        aux.road1Ylim = 450;
                        cars3[carnb3] = aux;
                    }
                    this.Controls.Add(cars3[carnb3].pb);
                    cars3[carnb3].pb.BringToFront();
                }

            }
     

        }

        private void ROAD1_Click(object sender, EventArgs e)
        {

        }

        private void cartimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < carnb + 1; i++)
            {

                lst[i] = cars[i].move(tl, lst, i);


            }
            for (int i = 0; i < carnb3 + 1; i++)
            {

                lst3[i] = cars3[i].move(t3, lst3, i);


            }
            for (int i = 0; i < carnb2 + 1; i++)
            {

                lst2[i] = cars2[i].move(t2, lst2, i);


            }
          
       }
        
    }
}

