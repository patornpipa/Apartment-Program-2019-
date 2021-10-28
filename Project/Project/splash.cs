using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1500;
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            start ST = new start();
            ST.Show();

            this.Hide();
            timer1.Stop();
        }
    }
}
