#define DISTRI
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
        public static NotifyIcon Notifier { get{ return notifyIcon; } }
        private static NotifyIcon notifyIcon;
        public Main1()
        {
#if DISTRI
            SplashScreen screen = new SplashScreen("splash_window.png");
            Task splashScreen = screen.ShowScreen(2500);
#endif
            InitializeComponent();  //생성자 로딩 
            notifyIcon = this.notifyIcon1;
            FormClosing += new FormClosingEventHandler(closing);
#if DISTRI
            splashScreen.Wait();
#endif
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == "Form2")
                {
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        openForm.WindowState = FormWindowState.Normal;
                        openForm.Owner = this;
                    }
                    openForm.Activate();
                    return;
                }
            }
            Form2 f2 = new Form2();
            f2.Location = new Point(this.Location.X + this.Size.Width, this.Location.Y);
            f2.Show(); 
        }

        
        private void Main1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon.ShowBalloonTip(1000,"hello","mainform",ToolTipIcon.Info);
                this.WindowState = FormWindowState.Minimized;
            }
        }

        
        private void closing(object sender, FormClosingEventArgs e) 
        {
            if (MessageBox.Show("종료하시겠습니까?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;    //event 취소
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
            }
            this.Activate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            Application.Exit();
        }

        private void mainFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            
            this.Activate();
        }

        private void form2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == "Form2")
                {
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        openForm.WindowState = FormWindowState.Normal;
                        openForm.Owner = this;
                    }
                    openForm.Activate();
                    return;
                }

            }
            Form2 form2 = new Form2();
            form2.Location = new Point(this.Location.X + this.Size.Width, this.Location.Y);
            form2.Show();
        }
    }
}

