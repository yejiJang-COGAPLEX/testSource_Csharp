using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testSplashScreen
{
    public partial class Main1 : Form
    {
        public Main1()
        {
            SplashScreen screen = new SplashScreen("cat.jpeg", 2000);
            Task splashScreen = Task.Run(screen.loadPicture);

            InitializeComponent();  //생성자 로딩 

            screen.closePicture(splashScreen);
        }
    }
}
