using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;


namespace Key_Dispatcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
     
        string devicname;
        private void Form1_Load(object sender, EventArgs e)
        {
           //search for the camera name it is independent from the camera start
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                devicname = filterInfo.Name;
            captureDevice = new VideoCaptureDevice(filterInfoCollection[0].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
           
            captureDevice.Start();
            
            timer1.Start();

        }

        private void btnName_Click(object sender, EventArgs e)
        {
            panelleft.Height = btnInicio.Height;
            panelleft.Top = btnInicio.Top;
            
        }

        private void btnKey_Click(object sender, EventArgs e)
        {
            panelleft.Height = btnKey.Height;
            panelleft.Top = btnKey.Top;

        }

        private void btnDatos_Click(object sender, EventArgs e)
        {
            panelleft.Height = btnDatos.Height;
            panelleft.Top = btnDatos.Top;
        }

       

        private void btnStart_Click(object sender, EventArgs e)
        {
           
          

        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (captureDevice.IsRunning)
                captureDevice.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1!=null)
            {
                
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result;
                if ((Bitmap)pictureBox1.Image != null) 
                {
                    int i;
                    result = barcodeReader.Decode((Bitmap)pictureBox1.Image);
                        
                        i = 1;
                        
                           switch(i)
                        {
                            case 1 :
                            if (result != null)
                            {
                                string resultado = result.ToString();
                                timer1.Stop();


                                pictureBox4.Image = Properties.Resources.tag;
                                label1.Text = "Paso 2: Scanear Llaves";
                                i++;
                            }
                                break;
                            case 2:
                            if (result != null)
                            {
                                timer1.Start();
                                string resultado2 = result.ToString();
                                i++;
                            } 

                                break;
                        }
                           

                                
                        
                    
                   

                }
                
                 

               
            }
        }

        private void title(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
