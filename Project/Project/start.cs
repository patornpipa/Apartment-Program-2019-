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
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
        }

        private void ToolStripTextBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripTextBox1_Click(object sender, EventArgs e)
        {
            customer cus = new customer();
            cus.MdiParent = this;
            cus.Dock = DockStyle.Fill;
            cus.TopMost = true;
            cus.TopLevel = false;
            cus.AutoScroll = true;
            this.panel2.Controls.Add(cus);
            cus.Show();
        }

        private void ToolStripTextBox2_Click(object sender, EventArgs e)
        {
            rent RT = new rent();
            RT.MdiParent = this;
            RT.Dock = DockStyle.Fill;
            RT.TopMost = true;
            RT.TopLevel = false;
            RT.AutoScroll = true;
            this.panel2.Controls.Add(RT);
            RT.Show();
        }

        private void ToolStripTextBox3_Click(object sender, EventArgs e)
        {
            print PT = new print();
            PT.MdiParent = this;
            PT.Dock = DockStyle.Fill;
            PT.TopMost = true;
            PT.TopLevel = false;
            PT.AutoScroll = true;
            this.panel2.Controls.Add(PT);
            PT.Show();
        }
    }
}
