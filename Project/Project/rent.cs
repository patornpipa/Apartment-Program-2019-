using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project
{
    public partial class rent : Form
    {
        private SqlConnection connection;
        private DataSet dataSt;
        public int WP, PP, RP, PU, WU, TP, WPU, PPU;

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public rent()
        {
            InitializeComponent();
        }
        private void selectData()
        {
            string sql = "SELECT  * FROM  Customer";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            dataSt = new DataSet();
            adapter.Fill(dataSt, "Cust");

            comboBox1.Items.Clear();
            comboBox1.Text = "เลือกชื่อ";
            for (int i = 0; i < dataSt.Tables["Cust"].Rows.Count; i++)
            {
                comboBox1.Items.Add(dataSt.Tables["Cust"].Rows[i]["fname"].ToString());
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            
            
            label1.Text = " ";
            label2.Text = " ";
            label3.Text = " ";
            label4.Text = " ";
            label7.Text = " ";
            label12.Text = " ";
            

            PU = (int)numericUpDown2.Value;
            WU = (int)numericUpDown1.Value;
            PP = PPU * PU;
            WP = WPU * WU;
            TP = RP + WP + PP;

            string sql2 = @"UPDATE Customer SET roomprice = @NewRP, powerprice = @NewPP, waterprice = @NewWP, totalprice = @NewTP WHERE fName = @oldFN";

            SqlCommand command = new SqlCommand(sql2, connection);

            command.Parameters.Clear();
            command.Parameters.AddWithValue("oldFN", comboBox1.SelectedItem.ToString());
            command.Parameters.AddWithValue("NewRP", RP);
            command.Parameters.AddWithValue("NewPP", PP);
            command.Parameters.AddWithValue("NewWP", WP);
            command.Parameters.AddWithValue("NewTP", TP);

            command.ExecuteNonQuery();
            selectData();
           
            label22.Text = Convert.ToString(RP);
            label23.Text = Convert.ToString(WP);
            label24.Text = Convert.ToString(PP);
            label25.Text = Convert.ToString(TP);

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            pictureBox1.Image = null;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql2 = "SELECT * FROM Customer WHERE fname = @oldFN";

            SqlCommand command = new SqlCommand(sql2, connection);

            command.Parameters.Clear();
            command.Parameters.AddWithValue("oldFN", comboBox1.SelectedItem.ToString());

            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            dataSt = new DataSet();
            adapter.Fill(dataSt, "Cust");

            label1.Text = dataSt.Tables["Cust"].Rows[0][1].ToString();
            label2.Text = dataSt.Tables["Cust"].Rows[0][2].ToString();
            label3.Text = dataSt.Tables["Cust"].Rows[0][3].ToString();
            label4.Text = dataSt.Tables["Cust"].Rows[0][4].ToString();
            label7.Text = dataSt.Tables["Cust"].Rows[0][0].ToString();
            label12.Text = dataSt.Tables["Cust"].Rows[0][5].ToString();

            label22.Text = " ";
            label23.Text = " ";
            label24.Text = " ";
            label25.Text = " ";
        }

        private void Rent_Load(object sender, EventArgs e)
        {
            string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB_customer.mdf;Integrated Security=True";

            connection = new SqlConnection(conStr);
            connection.Open();
            selectData();

   
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                pictureBox1.Load("Single.jpg");
                RP = 2500;
                PPU = 5;
                WPU = 4;
            }               
            else if (radioButton2.Checked == true)
            {
                pictureBox1.Load("Double.jpg");
                RP = 3200;
                PPU = 6;
                WPU = 5;
            }               
            else if (radioButton3.Checked == true)
            {
                pictureBox1.Load("Triple.jpg");
                RP = 4000;
                PPU = 7;
                WPU = 6;
            }
                
        }
    }
}
