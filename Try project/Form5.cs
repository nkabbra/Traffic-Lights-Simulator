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
using System.Media;
using System.Diagnostics;
using WMPLib;

namespace Try_project
{
    public partial class Form5 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        bool musicon = true;
        Queue c1= new Queue();
        Queue c2 = new Queue();
        Queue c3 = new Queue();
        Queue c4 = new Queue();
        trafficlight tl;
        trafficlight t2;
        trafficlight t3;
        trafficlight t4;
        int turn = 1;
        double direction;
        emerg emerg;
        Stopwatch stopwatch = new Stopwatch();
        int carnb = -1;
        car[] cars ;

        int carnb2 = -1;
        car[] cars2;

        int carnb3 = -1;
        car[] cars3;

        int carnb4 = -1;
        car[] cars4;

        int[] lst;
        int[] lst2;
        int[] lst3;
        int[] lst4;
        
        

        public Form5()
        {
            InitializeComponent();
            player.URL = "indila.mpeg";
            player.controls.play();
            c1 = Expo(6, 5);
            c2 = Expo(6,5);
            c3 = Expo(6, 5);
            c4 = Expo(6, 5);
            ROAD1.SendToBack();
            ROAD2.SendToBack();
            tl = new trafficlight(RED1, GREEN1, YELLOW1, c1);
            t2 = new trafficlight(RED2, GREEN2, YELLOW2, c2);
            t3 = new trafficlight(RED3, GREEN3, YELLOW3, c3);
            t4 = new trafficlight(RED4, GREEN4, YELLOW4, c4);
            emerg = new emerg();
            
            cars = new car[c1.Count];
            lst = new int[c1.Count];
            for (int i = 0; i < c1.Count; i++) lst[i] = 10000;

            cars2 = new car[c2.Count];
            lst2 = new int[c2.Count];
            for (int i = 0; i < c2.Count; i++) lst2[i] = 10000;

            cars3 = new car[c3.Count];
            lst3= new int[c3.Count];
            for (int i = 0; i < c3.Count; i++) lst3[i] = 10000;

            cars4 = new car[c4.Count];
            lst4= new int[c4.Count];
            for (int i = 0; i < c4.Count; i++) lst4[i] = 10000;
      
             
                stopwatch.Start();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
            this.Close();
        }
        private void playsound(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.Ambulance_SoundBible_com_1013640058);
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
        private void Form5_Load(object sender, EventArgs e)
        {
            button1.Location = new Point((this.Width - button1.Width) / 16, (this.ClientSize.Height - button1.Height) * 7 / 8);

        }
        public void PlaySound(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.beep9);
            player.Play();
        }



        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

     

        private void RED1_Click(object sender, EventArgs e)
        {

        }

        private void YELLOW4_Click(object sender, EventArgs e)
        {

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            /* 
             * initial turn=1
               
             * switch case 
             *  case turn=1 ..... if t1.total=0 if !emergency.state turn=2 else turn =  emergency.value
             *  case turn=2......if t2.total=0 turn+=1
             *  ..
             *  
             *  .
               jerrabta ma3 e wa7deh am amrar bi3alle2 w hon nafs lshi leh
             */
            switch (turn)
            {
                case 1:
                    {
                        tl.counter++;
                        tl.total--;


                        tl.change();
                        // logic of chosing next T.Light
                        if (tl.total == 0)
                        {
                            tl.total = tl.yellowtime + tl.greentime;

                            if (emerg.state != true)
                            {
                                turn = 2;
                            }
                            else
                            {
                                turn = (int)emerg.value.Dequeue();
                                if (emerg.value.Count == 0) emerg.state = false;
                            }

                        }
                    }
                    break;

                case 2:
                    {
                        t2.counter++;
                        t2.total--;

                        t2.change();
                        if (t2.total == 0)
                        {

                            t2.total = t2.yellowtime + t2.greentime;
                            if (emerg.state != true)
                            {
                                turn = 3;
                            }
                            else
                            {
                                turn = (int)emerg.value.Dequeue();
                                if (emerg.value.Count == 0) emerg.state = false;
                            }

                        }
                    }

                    break;
                case 3:
                    {
                        t3.counter++;
                        t3.total--;
                        t3.change();
                        if (t3.total == 0)
                        {

                            t3.total = t3.yellowtime + t3.greentime;
                            if (emerg.state != true)
                            {
                                turn = 4;
                            }
                            else
                            {
                                turn = (int)emerg.value.Dequeue();
                                if (emerg.value.Count == 0) emerg.state = false;
                            }


                        }


                    }

                    break;
                case 4:
                    {
                        t4.counter++;
                        t4.total--;
                        t4.change();
                        if (t4.total == 0)
                        {
                            t4.total = t4.yellowtime + t4.greentime;

                            if (emerg.state != true)
                            {
                                turn = 1;
                            }
                            else
                            {
                                turn = (int)emerg.value.Dequeue();
                                if (emerg.value.Count == 0) emerg.state = false;
                            }


                        }

                    }
                    break;


            }



        }

        private void GREEN2_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            emerg.state = true;
            emerg.value.Enqueue(1);

        }




        private void button7_Click(object sender, EventArgs e)
        {
            emerg.state = true;
            emerg.value.Enqueue(4);


        }

        private void button6_Click(object sender, EventArgs e)
        {
            emerg.state = true;
            emerg.value.Enqueue(2);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            emerg.state = true;
            emerg.value.Enqueue(3);

        }

        private void GREEN3_Click(object sender, EventArgs e)
        {

        }
        //interval te3 timer2 1 ms
        Random g2;
        double d,d2;
        Random g;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (c1.Count != 0)// road 1
            {
                 d = (double)c1.Peek() * 60000;
                if (stopwatch.ElapsedMilliseconds > (int)(d))
                {
                    c1.Dequeue();
                    carnb++;                   
                    g = new Random();
                    direction = g.NextDouble();                    
                    if (direction < 0.3) //go left 
                    {
                       car aux = new car(545,-60,1,1);
                       aux.XFINAL = -50;
                       aux.YFINAL =aux.mid;
                       aux.pb.Image = Properties.Resources.leftt;
                       aux.pb.Size = new Size(60, 50);
                       cars[carnb] = aux;
                    }
                    if (direction >= 0.3 && direction <= 0.6)// go right
                    {
                        car aux = new car(545, -60, 1, 2);
                        aux.mid = 350;
                        aux.XFINAL = 5000;
                        aux.YFINAL = aux.mid;
                        aux.pb.Image = Properties.Resources.rightt;
                        aux.pb.Size = new Size(60, 50);
                        cars[carnb] = aux;                                                    
                     }
                    if(direction > 0.6) // go straight
                    {
                       car aux = new car(545, -60, 1, 3);
                       aux.YFINAL = 2000;
                       aux.XFINAL = 555;
                       aux.pb.Image = Properties.Resources.up;
                       aux.pb.Size = new Size(60, 50);
                       cars[carnb] = aux;

                    }
                  this.Controls.Add(cars[carnb].pb);
                  cars[carnb].pb.BringToFront();     
                 }
                
              }
            if (c2.Count != 0)// road 2
            {
                 d2 = (double)c2.Peek() * 60000;
                if (stopwatch.ElapsedMilliseconds > (int)(d2))
                {
                    c2.Dequeue();
                    carnb2++;
                     g2 = new Random();
                    direction = g2.NextDouble();
                    if (direction < 0.3) //go left 
                    {
                        car aux = new car(1900, 280, 2, 1);
                        aux.XFINAL = -50;
                        aux.YFINAL = aux.mid;
                        aux.mid = 555;
                        aux.road1Ylim = 755;
                        aux.pb.Image = Properties.Resources.leftt;
                        aux.pb.Size = new Size(60, 50);
                        cars2[carnb2] = aux;
                    }
                    if (direction >= 0.3 && direction <= 0.6)// go right
                    {
                        car aux = new car(1900, 280, 2, 2);
                        aux.mid = 630;
                        aux.XFINAL = 5000;
                        aux.YFINAL = aux.mid;
                        aux.road1Ylim = 755;
                        aux.pb.Image = Properties.Resources.rightt;
                        aux.pb.Size = new Size(60, 50);
                        cars2[carnb2] = aux;
                    }
                    if (direction > 0.6) // go straight
                    {
                        car aux = new car(1900, 280, 2, 3);
                        aux.YFINAL = 2000;
                        aux.XFINAL = 555;
                        aux.road1Ylim = 755;
                        aux.mid = 630;
                        aux.pb.Image = Properties.Resources.cute2;
                        aux.pb.Size = new Size(60, 50);
                        cars2[carnb2] = aux;
                    }
                    this.Controls.Add(cars2[carnb2].pb);
                    cars2[carnb2].pb.BringToFront();
                }

            }



            if (c3.Count != 0)// road 3
            {
                double d2 = (double)c3.Peek() * 60000;
                if (stopwatch.ElapsedMilliseconds > (int)(d2))
                {
                    c3.Dequeue();
                    carnb3++;
                    Random g2 = new Random();
                    direction = g2.NextDouble();
                    if (direction < 0.3) //go left 
                    {
                        car aux = new car(-60, 350, 3, 1);
                        aux.XFINAL = -50;
                        aux.YFINAL = aux.mid;
                        aux.mid = 640;
                        aux.road1Ylim = 464;
                        aux.pb.Image = Properties.Resources.leftt;
                        aux.pb.Size = new Size(60, 50);
                        cars3[carnb3] = aux;
                    }
                    if (direction >= 0.3 && direction <= 0.6)// go right
                    {
                        car aux = new car(-60, 350, 3, 2);
                        aux.mid = 555;
                        aux.XFINAL = 5000;
                        aux.YFINAL = aux.mid;
                        aux.road1Ylim = 464;
                        aux.pb.Image = Properties.Resources.rightt;
                        aux.pb.Size = new Size(60, 50);
                        cars3[carnb3] = aux;
                    }
                    if (direction > 0.6) // go straight
                    {
                        car aux = new car(-60, 350, 3, 3);
                        aux.YFINAL = 2000;
                        aux.XFINAL = 555;
                        aux.road1Ylim = 464;
                        aux.mid = 555;
                        aux.pb.Image = Properties.Resources.cute;
                        aux.pb.Size = new Size(60, 50);
                        cars3[carnb3] = aux;
                    }
                    this.Controls.Add(cars3[carnb3].pb);
                    cars3[carnb3].pb.BringToFront();
                }



             }
            if (c4.Count != 0)// road 4
            {
                 d = (double)c4.Peek() * 60000;
                if (stopwatch.ElapsedMilliseconds > (int)(d))
                {
                    c4.Dequeue();
                    carnb4++;
                     g = new Random();
                    direction = g.NextDouble();
                    if (direction < 0.3) //go left 
                    {
                        car aux = new car(640, 1000, 4, 1);
                        aux.XFINAL = -50;
                        aux.YFINAL = aux.mid;
                        aux.mid = 280;
                        aux.road1Ylim = 420;
                        aux.pb.Image = Properties.Resources.leftt;
                        aux.pb.Size = new Size(60, 50);
                        cars4[carnb4] = aux;
                    }
                    if (direction >= 0.3 && direction <= 0.6)// go right
                    {
                        car aux = new car(640, 1000 , 4, 2);
                        aux.mid = 370;
                        aux.road1Ylim = 420;
                        aux.XFINAL = 5000;
                        aux.YFINAL = aux.mid;
                        aux.pb.Image = Properties.Resources.rightt;
                        aux.pb.Size = new Size(60, 50);
                        cars4[carnb4] = aux;
                    }
                    if (direction > 0.6) // go straight
                    {
                        car aux = new car(640,1000, 4, 3);
                        aux.YFINAL = 2000;
                        aux.XFINAL = 555;
                        aux.mid = 280;
                        aux.road1Ylim = 420;
                        aux.pb.Image = Properties.Resources.taxidown;
                        aux.pb.Size = new Size(60, 50);
                        cars4[carnb4] = aux;
                    }
                    this.Controls.Add(cars4[carnb4].pb);
                    cars4[carnb4].pb.BringToFront();
                }

            }
     




        }



            

        private void cartimer_Tick(object sender, EventArgs e)
        {
          
          for(int i=0; i<carnb+1; i++)
          {
              try
              {
                  lst[i] = cars[i].move(tl, lst, i);
              }
              catch { }

         
          }
          for (int i = 0; i < carnb2 + 1; i++)
          {
             
                  lst2[i] = cars2[i].move(t2, lst2, i);
            

          }
          for (int i = 0; i < carnb3 + 1; i++)
          {

              lst3[i] = cars3[i].move(t3, lst3, i);


          }
          for (int i = 0; i < carnb4 + 1; i++)
          {

              lst4[i] = cars4[i].move(t4, lst4, i);


          }

          this.Refresh();
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
              
        
            SoundPlayer player = new SoundPlayer(Properties.Resources.Ambulance_SoundBible_com_1013640058);
            player.Play();

        
        }

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {

        
            SoundPlayer player = new SoundPlayer(Properties.Resources.Ambulance_SoundBible_com_1013640058);
            player.Play();

        
        }

        private void button8_MouseClick(object sender, MouseEventArgs e)
        {
          
        
            SoundPlayer player = new SoundPlayer(Properties.Resources.Ambulance_SoundBible_com_1013640058);
            player.Play();

        
        }

        private void button7_MouseClick(object sender, MouseEventArgs e)
        {

            SoundPlayer player = new SoundPlayer(Properties.Resources.Ambulance_SoundBible_com_1013640058);
            player.Play();

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {

            SoundPlayer player = new SoundPlayer(Properties.Resources.beep9);
            player.Play();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (musicon)
            {
                button3.BackgroundImage = Properties.Resources.off;

                player.controls.pause();
                musicon = false;
            }
            else
            {
                button3.BackgroundImage = Properties.Resources.on;
                player.controls.play();
                musicon = true;
            }

        }

   





        }

}


    


   

        
    

