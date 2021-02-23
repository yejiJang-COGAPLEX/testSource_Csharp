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
        private int loadTime;
        public SplashScreen()
        {
            InitializeComponent();
        }
        public SplashScreen(string imgName, int loadTime)
        {
            imgPath = @"..\..\Resources\" + imgName;
            this.loadTime = loadTime;
            InitializeComponent();
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            try
            {
                this.pictureBox1.Load(imgPath);
            }
            catch (FileNotFoundException)
            {
                imgPath = @"..\..\Resources\splash_window.png";
                this.pictureBox1.Load(imgPath);
                Console.WriteLine("Error : File Not Found");
            }
            finally
            {
                Console.WriteLine("Show Splash Screen");
                this.Show();
            }
        }
        public async Task loadPicture()
        {
            Console.WriteLine("SplashScreen Sleep {0} seconds..", (float)loadTime / 1000);
            Console.WriteLine("Initialize load...");
            Thread.Sleep(this.loadTime);
        }

        public void closePicture(Task splashScreen)
        {
            Console.WriteLine("Initialize Complete");
            splashScreen.Wait();    //호출한 스레드 작업이 완료 될 때까지 대기
            this.Close(); //splash screen close
            Console.WriteLine("SplashScreen Closed and Show Main1");
        }
    }
}
