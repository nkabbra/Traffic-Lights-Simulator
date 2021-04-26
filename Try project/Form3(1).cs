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
using System.Threading;
using System.Diagnostics;
using System.Media;

namespace Try_project
{
    public partial class Form3 : Form
    {
        Queue q1 = new Queue();
        Queue q2 = new Queue();
      
        pedestrialight pl1, pl2;
        trafficlight tl1, tl2;
        Stopwatch stopwatch;
        double direction;

        int carnb = -1;
        car[] cars;

        int carnb2 = -1;
        car[] cars2;

        int[] lst;
        int[] lst2;

        public Form3()
        {
            stopwatch = new Stopwatch();
            InitializeComponent();
            q1 = Expo(10, 10);
            q2 = Expo(10, 10);
            tl1 = new trafficlight(RED1, GREEN1, YELLOW1, q1);
            tl2 = new trafficlight(RED2, GREEN2, YELLOW2, q2);
            pl1 = new pedestrialight(PRED1, PGREEN1, tl1);
            pl2 = new pedestrialight(PRED2, PGREEN2, tl2);
            tl2.g.Visible = true;
            tl2.r.Visible = false;
            tl2.y.Visible = false;
            pl1.g.Visible = true;
            pl1.r.Visible = false;

            stopwatch.Start();
      

            cars = new car[q1.Count];
            lst = new int[q1.Count];
            for (int i = 0; i < q1.Count; i++) lst[i] = 10000;

            cars2 = new car[q2.Count];
            lst2 = new int[q2.Count];
            for (int i = 0; i < q2.Count; i++) lst2[i] = 10000;








        }

        public void PlaySound(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.beep9);
            player.Play();
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

        private void Form3_Load(object sender, EventArgs e)
        {
            button1.Location = new Point((this.Width - button1.Width) / 16, (this.ClientSize.Height - button1.Height) * 7 / 8);
            button1.MouseEnter += PlaySound;
            /*ROAD1.Location = new Point((this.Width - ROAD1.Width) / 2, (this.ClientSize.Height - ROAD1.Height) / 2);
            SQUARE.Location = new Point((this.Width - SQUARE.Width) / 2, (this.ClientSize.Height - SQUARE.Height) / 2);
            ROAD2.Location = new Point((this.Width - ROAD2.Width) / 2, (this.ClientSize.Height - ROAD2.Height) / 2);
            GREEN1.Location = new Point(770, 200);
            GREEN2.Location = new Point(490, 475);
            YELLOW1.Location = new Point(770, 200);
            YELLOW2.Location = new Point(490, 475);
            RED1.Location = new Point(770, 200);
            RED2.Location = new Point(490, 475);
            PRED1.Location = new Point(800,140);
            PGREEN1.Location = new Point(800, 140);
            PRED2.Location = new Point(425, 475);
            PGREEN2.Location = new Point(425, 475);
*/

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void YELLOW1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void ROAD2_Click(object sender, EventArgs e)
        {

        }

        private void ROAD1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_2(object sender, EventArgs e)
        {

        }

        private void RED2_Click(object sender, EventArgs e)
        {

        }

        private void GREEN1_Click(object sender, EventArgs e)
        {

        }

        private void PRED1_Click(object sender, EventArgs e)
        {

        }

        private void PRED2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }




        private void timer1_Tick(object sender, EventArgs e)
        {

            mario.Visible = true;
            mario2.Visible = true;

            mario222.Visible = true;
          
            mario1.Visible = true;


            tl1.counter++;
            tl1.switchcolor();
            pl1.counter++;
            pl1.switchcolor();
            tl2.counter++;
            tl2.switchcolor();

            pl2.counter++;
            pl2.switchcolor();
            if (pl2.g.Visible == true)
            {

                mario.Left += 27;







                mario1.Left += 27;
               

                if (mario.Left > 700)
                {
                    mario.Visible = false;
                    mario1.Visible = false;
             
                    mario.Left = 485;
               
                    mario1.Left = 485;
                }
            }
            if (pl1.g.Visible == true)
            {
                mario2.Top -= 27;


                mario222.Top -= 27;


                if (mario2.Top < 220)
                {
                    mario2.Visible = false;

                    mario222.Visible = false;
                    mario2.Top = 425;
                    mario222.Top = 425;

                }


            }
        }

        private void RED1_Click(object sender, EventArgs e)
        {

        }

        private void mario_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void mario2_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (q1.Count != 0)// road 2
            {
                double d2 = (double)q1.Peek() * 60000;
                if (stopwatch.ElapsedMilliseconds > (int)(d2))
                {
                    q1.Dequeue();
                    carnb++;
                    Random g2 = new Random();
                    direction = g2.NextDouble();
                  
                    if (direction >= 0.3)// go right
                    {
                        car aux = new car(1050, 320, 2, 2);
                        aux.mid = 600;
                        aux.XFINAL = 5000;
                        aux.YFINAL = aux.mid;
                        aux.road1Ylim = 785;
                      
                        cars[carnb] = aux;
                    }
                    else // go straight
                    {
                        car aux = new car(1050, 320, 2, 3);
                        aux.YFINAL = 2000;
                        aux.XFINAL = 555;
                        aux.road1Ylim = 785;
                        aux.mid = 600;
                     
                        cars[carnb] = aux;
                    }
                    this.Controls.Add(cars[carnb].pb);
                    cars[carnb].pb.BringToFront();
                }


            }
            if (q2.Count != 0)// road 4
            {
                double d = (double)q2.Peek() * 60000;
                if (stopwatch.ElapsedMilliseconds > (int)(d))
                {
                    q2.Dequeue();
                    carnb2++;
                    Random g = new Random();
                    direction = g.NextDouble();
                    if (direction < 0.3) //go left 
                    {
                        car aux = new car(600, 650, 4, 1);
                        aux.XFINAL = -50;
                        aux.YFINAL = aux.mid;
                        aux.mid = 320;
                        aux.road1Ylim = 500;
                        aux.pb.Image = Properties.Resources.lefrturn;
                      

                        cars2[carnb2] = aux;
                    }
                   
                    else// go straight
                    {
                        car aux = new car(600, 650, 4, 3);
                        aux.YFINAL = 2000;
                        aux.XFINAL = 555;
                        aux.mid = 320;
                        aux.road1Ylim = 500;
                       
                        cars2[carnb2] = aux;
                    }
                    this.Controls.Add(cars2[carnb2].pb);
                    cars2[carnb2].pb.BringToFront();
                }
            }


        }

        private void cartimere_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < carnb2 + 1; i++)
            {

                lst2[i] = cars2[i].move(tl2, lst2, i);


            }
            for (int i = 0; i < carnb + 1; i++)
            {

                lst[i] = cars[i].move(tl1, lst, i);


            }
        }
    }


}


    

