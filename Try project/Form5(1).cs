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
namespace Try_project
{
    public partial class Form5 : Form
    {
  
        
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
            c1 = Expo(20, 10);
            c2 = Expo(10,10);
            c3 = Expo(10, 10);
            c4 = Expo(10, 10);
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

            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
            this.Close();
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


            /* ROAD1.Location = new Point((this.Width - ROAD1.Width) / 2, (this.ClientSize.Height - ROAD1.Height) / 2);
             ROAD2.Location = new Point((this.Width - ROAD2.Width) / 2, (this.ClientSize.Height - ROAD2.Height) / 2);
             SQUARE.Location = new Point((this.Width - SQUARE.Width) / 2, (this.ClientSize.Height - SQUARE.Height) / 2);
             GREEN1.Location = new Point(490,130);
             GREEN2.Location = new Point(770, 155);
             GREEN3.Location = new Point(470,445);
             GREEN4.Location = new Point(750,470);
             YELLOW1.Location = new Point(490, 130);
             YELLOW2.Location = new Point(770, 155);
             YELLOW3.Location = new Point(470, 445);
             YELLOW4.Location = new Point(750, 470);
             RED1.Location = new Point(490, 130);
             RED2.Location = new Point(770, 155);
             RED3.Location = new Point(470, 445);
             RED4.Location = new Point(750, 470);
             * */
        }
        public void PlaySound(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.beep9);
            player.Play();
        }
      

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }



        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
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
                    if (direction < 0.3) //go left 
                    {
                       car aux = new car(555,0,1,1);
                       aux.XFINAL = -50;
                       aux.YFINAL =aux.mid;
                       aux.pb.Image = Properties.Resources.lefrturn;
                       cars[carnb] = aux;
                    }
                    if (direction >= 0.3 && direction <= 0.6)// go right
                    {
                        car aux = new car(555, 0, 1, 2);
                        aux.mid = 350;
                        aux.XFINAL = 5000;
                        aux.YFINAL = aux.mid;
                        aux.pb.Image = Properties.Resources.rightrun;
                        cars[carnb] = aux;                                                    
                     }
                    if(direction > 0.6) // go straight
                    {
                       car aux = new car(555, 0, 1, 3);
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
                        aux.mid = 555;
                        aux.road1Ylim = 755;
                        cars2[carnb2] = aux;
                    }
                    if (direction >= 0.3 && direction <= 0.6)// go right
                    {
                        car aux = new car(1050, 280, 2, 2);
                        aux.mid = 630;
                        aux.XFINAL = 5000;
                        aux.YFINAL = aux.mid;
                        aux.road1Ylim = 755;
                        cars2[carnb2] = aux;
                    }
                    if (direction > 0.6) // go straight
                    {
                        car aux = new car(1050, 280, 2, 3);
                        aux.YFINAL = 2000;
                        aux.XFINAL = 555;
                        aux.road1Ylim = 755;
                        aux.mid = 630;
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
                        car aux = new car(0, 350, 3, 1);
                        aux.XFINAL = -50;
                        aux.YFINAL = aux.mid;
                        aux.mid = 640;
                        aux.road1Ylim = 473;
                        cars3[carnb3] = aux;
                    }
                    if (direction >= 0.3 && direction <= 0.6)// go right
                    {
                        car aux = new car(0, 350, 3, 2);
                        aux.mid = 555;
                        aux.XFINAL = 5000;
                        aux.YFINAL = aux.mid;
                        aux.road1Ylim = 473;
                        cars3[carnb3] = aux;
                    }
                    if (direction > 0.6) // go straight
                    {
                        car aux = new car(0, 350, 3, 3);
                        aux.YFINAL = 2000;
                        aux.XFINAL = 555;
                        aux.road1Ylim = 473;
                        aux.mid = 555;
                        cars3[carnb3] = aux;
                    }
                    this.Controls.Add(cars3[carnb3].pb);
                    cars3[carnb3].pb.BringToFront();
                }



             }
            if (c4.Count != 0)// road 4
            {
                double d = (double)c4.Peek() * 60000;
                if (stopwatch.ElapsedMilliseconds > (int)(d))
                {
                    c4.Dequeue();
                    carnb4++;
                    Random g = new Random();
                    direction = g.NextDouble();
                    if (direction < 0.3) //go left 
                    {
                        car aux = new car(650, 650, 4, 1);
                        aux.XFINAL = -50;
                        aux.YFINAL = aux.mid;
                        aux.mid = 280;
                        aux.road1Ylim = 420;
                        aux.pb.Image = Properties.Resources.lefrturn;
                        cars4[carnb4] = aux;
                    }
                    if (direction >= 0.3 && direction <= 0.6)// go right
                    {
                        car aux = new car(650, 650 , 4, 2);
                        aux.mid = 370;
                        aux.road1Ylim = 420;
                        aux.XFINAL = 5000;
                        aux.YFINAL = aux.mid;
                        aux.pb.Image = Properties.Resources.rightrun;
                        cars4[carnb4] = aux;
                    }
                    if (direction > 0.6) // go straight
                    {
                        car aux = new car(650,650, 4, 3);
                        aux.YFINAL = 2000;
                        aux.XFINAL = 555;
                        aux.mid = 280;
                        aux.road1Ylim = 420;
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

             /* if (cars[i].direction==1) 
               {
                if(cars[i].pb.Location.X<=cars[i].XFINAL)j++;
               }
                
                if(cars[i].direction==2)
               { if(cars[i].pb.Location.X>=cars[i].XFINAL)j++;
               }
               
               if(cars[i].direction==3)
               { if(cars[i].pb.Location.Y>cars[i].YFINAL)j++;
               }        
              * */
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

        private void ROAD1_Click(object sender, EventArgs e)
        {

        }

   





        }

}


    


   

        
    

