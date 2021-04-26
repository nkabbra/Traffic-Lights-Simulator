using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using MetriCam;
using System.Media;
using System.Drawing;
using System.IO;
namespace take_pic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            camera = new WebCam();

        }
        private WebCam camera;
        //creating object from class backgroundworker
     // calling runworker starts the thread and fires the doworkevent handler
         private void Form1_Load(object sender, EventArgs e)
         {
             try
             {
                 camera.Connect();
                 backgroundWorker1.RunWorkerAsync();

             }
             catch
             {
                 MessageBox.Show("error connecting with webcam");
                 this.Close();
             }


         }

         //cancellationPending - Indicates if an application has requested cancellation of a BackgroundWorker.
        //update captures a new frame
        //calcbitmap gets the current frame
         private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
         {
             while(!backgroundWorker1.CancellationPending)
             {
                 camera.Update();
                 pictureBox1.BackgroundImage = camera.CalcBitmap();
             }
         }
         private void button1_Click(object sender, EventArgs e)
         {
             try
             {
                 Image image = camera.GetBitmap();
                 image.Save("My Pic.Bmp", ImageFormat.Bmp);
                 this.Close();
             }
             catch
             {
                 MessageBox.Show("failed to save the picture");
                 this.Close();

             }
         }




    }
}
