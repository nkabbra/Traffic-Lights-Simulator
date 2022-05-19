using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.Media;
using System.Diagnostics;

namespace Try_project
{
    public partial class Form7 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public Form7()
        {
            InitializeComponent();
            label1.Location = new Point(650, 800);
            label2.Location = new Point(657, 850);
            label3.Location = new Point(662, 900);
            button3.Location = new Point((this.Width - button3.Width) / 16, 750);
            button9.Location = new Point((this.Width - button9.Width) / 16, 750);
            label4.BringToFront();
          
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label1.BringToFront();
            label2.BringToFront();
            label3.BringToFront();
            button3.Visible = false;
            player.URL = "allmusicmp3.mp3";
            player.controls.play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
            this.Close();
     

        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            timer1.Enabled = true;
            label4.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button4.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            button3.Visible = true;
            
        }
        public void PlaySound(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.beep9);
            player.Play();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        
            
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Top -= 5;
            label2.Top -= 5;
            label3.Top -= 5;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            player.controls.play();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = true;
            label1.Location = new Point(650, 800);
            label2.Location = new Point(657, 850);
            label3.Location = new Point(662, 900);
            label1.BringToFront();
            label2.BringToFront();
            label3.BringToFront();
            timer1.Enabled = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = false;
            button4.Visible = true;
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.beep9);
            player.Play();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        int i = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            i = 0;
            button4.Visible = false;
            pictureBox2.Visible = true;
           
            button9.Visible = true;
            button1.Visible = false;
            button2.Visible = false;

            timer2.Enabled = true;

        }
      
        Random g = new Random();
        double d;
        private void timer2_Tick(object sender, EventArgs e)
        {
            i++;
            if(i==5)
            {
                pictureBox2.Visible = false;
                pictureBox4.Visible = true;
                timer2.Enabled = false;
                button5.Visible = true;
                d = g.NextDouble();
                if(d<0.3)
                {
                    button6.Visible = true;
                }
                  else
                  {
                    if (d < 0.6)
                    {
                        button7.Visible = true;
                    }
                    else button8.Visible = true;
                  }
                i = 0;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            i = 0;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            pictureBox2.Visible = true;
            pictureBox4.Visible = false;
            timer2.Enabled = true;
           
          

        }

        private void button8_Click(object sender, EventArgs e)
        {
            player.controls.stop();

            Form5 f5 = new Form5();
            this.Hide();
            f5.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            Form4 f4 = new Form4();
            this.Hide();
            f4.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            Form3 f3 = new Form3();
            this.Hide();
            f3.ShowDialog();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            player.controls.play();
            timer2.Enabled = false;
            button9.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button4.Visible = true;
           
            i = 0;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            pictureBox4.Visible = false ;
            pictureBox2.Visible = false;
          
        }
        
      
    }
}
