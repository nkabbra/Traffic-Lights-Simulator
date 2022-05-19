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
    class pedestrialight : light
    {
        public trafficlight tl;
        public pedestrialight(PictureBox red, PictureBox green, trafficlight traffic)
            : base(red, green)
        {
            tl = traffic;
            redtime = traffic.greentime + traffic.yellowtime;
            greentime = traffic.redtime;
        }
    }
    
    
}
