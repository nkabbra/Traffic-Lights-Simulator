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
namespace Try_project
{
    public partial class Form2 : Form
    {
      
        public Form2()
        {
            InitializeComponent();
          
          

        }

     

        private void button1_Click(object sender, EventArgs e)
        {
           
            Form3 f3 = new Form3();
            this.Hide();
            f3.ShowDialog();
            this.Close();
          
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           // button1.Location = new Point((this.Width - button1.Width) / 4, 400);
           // button2.Location = new Point((this.Width - button2.Width) /2 , 400);
           // button3.Location = new Point((this.Width - button3.Width)*3/4, 400);

            button4.Location = new Point(0, 800);
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            Form4 f4 = new Form4();
            this.Hide();
            f4.ShowDialog();
            this.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            Form5 f5 = new Form5();
            this.Hide();
            f5.ShowDialog();
            this.Close();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void playsound(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.beep9);
            player.Play();

        }

        public  void PlaySound(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.beep9);
            player.Play();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Form7 f7 = new Form7();
            this.Hide();
            f7.ShowDialog();
            this.Close();
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        
            Form4 f4 = new Form4();
            this.Hide();
            f4.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
          
            Form5 f5 = new Form5();
            this.Hide();
            f5.ShowDialog();
            this.Close();
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           

            Form3 f3 = new Form3();
            this.Hide();
            f3.ShowDialog();
            this.Close();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.beep9);
            player.Play();
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
      
        
            SoundPlayer player = new SoundPlayer(Properties.Resources.beep9);
            player.Play();

        
        }
    }
}
