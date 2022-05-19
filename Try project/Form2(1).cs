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
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public Form2()
        {
            InitializeComponent();
          
            player.URL = "allmusicmp3.mp3";

        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            Form3 f3 = new Form3();
            this.Hide();
            f3.ShowDialog();
            this.Close();
          
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button1.Location = new Point((this.Width - button1.Width) / 4, (this.ClientSize.Height - button1.Height)*7/ 8);
            button2.Location = new Point((this.Width - button2.Width) /2 , (this.ClientSize.Height - button2.Height)*7 / 8);
            button3.Location = new Point((this.Width - button3.Width)*3/4, (this.ClientSize.Height - button3.Height) *7/ 8);
           

            player.controls.play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            Form4 f4 = new Form4();
            this.Hide();
            f4.ShowDialog();
            this.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            player.controls.stop();
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
    }
}
