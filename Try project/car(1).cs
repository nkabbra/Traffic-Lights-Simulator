

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
namespace Try_project
{ /* road 1 ya3ni li fo2
   road 2 ya2ni li 3al yameen
   road 3 ya3ni li 3al shmel 
   road 4 ya3ni ;li ta7et*/
    class car
    {
        public PictureBox pb =  new PictureBox();
        public int direction, road, road1Ylim = 200, mid = 250, XFINAL=0, YFINAL=0;
        bool cross = false;
        int[] lst;
        int index;

        public car(int X0, int Y0, int r, int dir)
        {
            pb.Size = new Size(Properties.Resources.car.Width, Properties.Resources.car.Height);
           pb.Image = Properties.Resources.car;
            pb.Anchor = AnchorStyles.Left;
            pb.Location = new Point(X0, Y0);
            pb.Visible = true;
            direction = dir;
            road = r;
        }
       
        public bool passed ()
        {
            if (road == 1)
            {
                if (pb.Location.Y >= road1Ylim) return true;
                else return false;
                 
            }


            else
            {
                if (road == 2)
                    if (pb.Location.X <= road1Ylim) return true;
                    else return false;
               
            }
              if (road == 3)
                    if (pb.Location.X >= road1Ylim) return true;
                    else return false;
              if (road == 4)
                  if (pb.Location.Y <= road1Ylim) return true;
                  else return false;
               
            
            return false;
            
           

      }
        
        public bool middle()
        {
            if (road == 1)
                if(pb.Location.Y >= mid) return true;
                else return false;
            
            if (road == 2)
                if (pb.Location.X<= mid) return true;
               
               else return false;

            if (road == 3)
                if (pb.Location.X >= mid) return true;

                else return false;
            if (road == 4)
                if (pb.Location.Y <= mid) return true;

                else return false;
           
            
            
            return false;


        }
        public bool crash()
        {
            if (road == 1 && !passed()&&index > 0)
                    if ((pb.Location.Y + pb.Size.Height + 20) > lst[index-1])
                    {
                        return true;
                    }


            if (road == 2 && !passed() && index > 0)
                if ((pb.Location.X - 10-pb.Size.Width ) < lst[index - 1])
                {
                    return true;
                }

            if (road == 3 && !passed() && index > 0)
                if ((pb.Location.X + pb.Size.Width + 10) > lst[index - 1])
                {
                    return true;
                }
            if (road == 4 && !passed() && index > 0)
                if ((pb.Location.Y -pb.Size .Height -10) < lst[index - 1])
                {
                    return true;
                }

            return false;
        }
        public int move(trafficlight traffic, int[] l,int i)
        {
                lst = l;
                index = i;
                if(road == 1)
                {  
                 if( !crash())
                    if (!passed() || (cross && !middle()))
                        pb.Top += 10;
                    else
                        if (traffic.g.Visible) cross = true;

                    if (middle())
                    {
                        if (direction == 1) // go left
                        { pb.Left -= 20; }
                        if (direction == 2)// go right
                            pb.Left += 20;
                        if (direction == 3)// go straight
                            pb.Top += 20;
                        return 10000;
                    }
                    return pb.Location.Y;                    
                }
                if (road == 2)
                {
                    if (!crash())
                        if (!passed() || (cross && !middle()))
                            pb.Left -= 10;
                        else
                            if (traffic.g.Visible) cross = true;

                    if (middle())
                    {
                        if (direction == 1) // go left
                        { pb.Top += 20; }
                        if (direction == 2)// go right
                            pb.Top -= 20;
                        if (direction == 3)// go straight
                            pb.Left -= 20;
                        return 0;
                    }

                    return pb.Location.X;
                }
                if (road == 3)
                {
                    if (!crash())
                        if (!passed() || (cross && !middle()))
                            pb.Left += 10;
                        else
                            if (traffic.g.Visible) cross = true;

                    if (middle())
                    {
                        if (direction == 1) // go left
                        { pb.Top -= 20; }
                        if (direction == 2)// go right
                            pb.Top += 20;
                        if (direction == 3)// go straight
                            pb.Left += 20;
                        return 10000;
                    }

                    return pb.Location.X;
                }
                if (road == 4)
                {
                    if (!crash())
                        if (!passed() || (cross && !middle()))
                            pb.Top -= 10;
                        else
                            if (traffic.g.Visible) cross = true;

                    if (middle())
                    {
                        if (direction == 1) // go left
                        { pb.Left -= 20; }
                        if (direction == 2)// go right
                            pb.Left += 20;
                        if (direction == 3)// go straight
                            pb.Top-= 20;
                        return 0;
                    }

                    return pb.Location.Y;
                }


               return pb.Location.X;
        }

    }
}
