
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
{
    class trafficlight
    : light
    {


        public PictureBox y;
        public int yellowtime = 3;

        public int total;



        public trafficlight(PictureBox red1, PictureBox green1, PictureBox yellow1, Queue queue)
            : base(red1, green1)
        {


            y = yellow1;
            total = yellowtime + greentime;



            y.Visible = false;
        }
        public override void turnongreen()
        {
            base.turnongreen();
            y.Visible = false;
        }
        public override void turnonred()
        {
            y.Visible = false;
            base.turnonred();
        }
        public void turnonyellow()
        {

            r.Visible = false;
            g.Visible = false;
            y.Visible = true;

        }
        public override void change()
        {
            if (r.Visible == true)
            {
                turnongreen();

            }
            else
            {
                if (g.Visible == true && counter == greentime)
                {
                    turnonyellow();

                    counter = 0;
                }
                else
                {
                    if (y.Visible == true && counter == yellowtime)
                    {
                        turnonred();
                       
                        counter = 0;
                    }
                }
            }
        }
        public override void switchcolor()
        {
            if (r.Visible == true && redtime == counter)
            {
                turnongreen();
                counter = 0;

            }
            else
            {
                if (g.Visible == true && counter == greentime)
                {
                    turnonyellow();
                   
                    counter = 0;
                }
                else
                {
                    if (y.Visible == true && counter == yellowtime)
                    {
                        turnonred();
                     
                        counter = 0;
                    }
                }
            }
        }
    }
}

