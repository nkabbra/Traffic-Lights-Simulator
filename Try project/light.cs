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
    class light
    {
        public PictureBox r;


        public PictureBox g;

        public int redtime = 8;
        public int greentime = 5;
        public int counter = 0;


        public light(PictureBox red, PictureBox green)
        {
            r = red;
            g = green;


            r.Visible = true;
            green.Visible = false;

        }
        public virtual void turnongreen()
        {
            r.Visible = false;
            g.Visible = true;



        }
        public virtual void turnonred()
        {

            r.Visible = true;
            g.Visible = false;


        }
        public virtual void change()
        {
            if (r.Visible == true)
            {
                turnongreen();

            }
            else
            {
                if (g.Visible == true && counter == greentime)
                {
                    turnonred();
                    counter = 0;
                }


            }
        }
        public virtual void switchcolor()
        {
            if (r.Visible == true && redtime == counter)
            {
                turnongreen();
                counter = 0;

            }
            else
            {

                if (g.Visible == true && greentime == counter)
                {
                    turnonred();

                    counter = 0;
                }

            }
        }
    }
}
