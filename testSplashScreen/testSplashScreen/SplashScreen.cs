using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testSplashScreen
{
    public partial class SplashScreen : Form
    {
        private string imgPath;

        public SplashScreen()
        {
            InitializeComponent();
        }

        public SplashScreen(string imgName)
        {
            
            imgPath = @"..\..\Resources\" + imgName;
            InitializeComponent();

            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if (!File.Exists(imgPath))
            {
                Console.WriteLine("File Not Found.");
            }
            else 
            {
                Image img = Image.FromFile(imgPath);
                int width = img.Width;
                int height = img.Height;
                this.pictureBox1.Size = new Size(width, height);
                this.Size = new Size(width, height);
                this.pictureBox1.Load(imgPath);
            }
            this.Show();
        }

        public SplashScreen(Image img) 
        {
            InitializeComponent();
            int width = img.Width;
            int height = img.Height;
            this.pictureBox1.Size = new Size(width, height);
            this.Size = new Size(width, height);
            this.pictureBox1.Image = img;
        }

        public Task ShowScreen(int loadTime)
        {
            this.Show();
            return Task.Run(async() => 
            {
                await Task.Delay(loadTime);
                this.Close(); //splash screen close
            });
        }
    }
}
