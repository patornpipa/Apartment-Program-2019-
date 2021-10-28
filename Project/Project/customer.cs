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
    public partial class customer : Form
    {
        private SqlConnection connection;
        private DataSet dataSt;
        public customer()
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

            comboBox2.Items.Clear();
            comboBox2.Text = "เลือกชื่อผู้เช่า";
            for (int i = 0; i < dataSt.Tables["Cust"].Rows.Count; i++)
            {
                comboBox2.Items.Add(dataSt.Tables["Cust"].Rows[i]["fname"].ToString());
            }

        }

        private void Customer_Load(object sender, EventArgs e)
        {
            string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB_customer.mdf;Integrated Security=True";

            connection = new SqlConnection(conStr);
            connection.Open();
            selectData();

            dataGridView1.DataSource = dataSt.Tables["Cust"];
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string customerID = textBox1.Text;
            string fname = textBox2.Text;
            string lname = textBox3.Text;
            string phone = textBox4.Text;
            string roomID = textBox6.Text;
            string addreess = textBox5.Text;

            string sql = "INSERT INTO Customer (customerID, fname, lName, phone, roomID, address)VALUES(@customerID, @fname, @lname, @phone, @roomID, @address)";


            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("customerID", customerID);
            command.Parameters.AddWithValue("fname", fname);
            command.Parameters.AddWithValue("lname", lname);
            command.Parameters.AddWithValue("phone", phone);
            command.Parameters.AddWithValue("roomID", roomID);
            command.Parameters.AddWithValue("address", addreess);
            command.ExecuteNonQuery();
            

            selectData();

            dataGridView1.DataSource = dataSt.Tables["cust"];

            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string fn = comboBox1.SelectedItem.ToString();

            string sql = "DELETE FROM Customer WHERE (fName = @fname)";
            SqlCommand command = new SqlCommand(sql, connection);


            command.Parameters.Clear();
            command.Parameters.AddWithValue("fname", fn);

            command.ExecuteNonQuery();


            selectData();

            dataGridView1.DataSource = dataSt.Tables["Cust"];
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string sql2 = @"UPDATE Customer SET fName = @NewFN, lName = @NewLN, phone = @NewP, address = @NewAD WHERE fName = @oldFN";

            SqlCommand command = new SqlCommand(sql2, connection);

            command.Parameters.Clear();
            command.Parameters.AddWithValue("oldFN", comboBox2.SelectedItem.ToString());
            command.Parameters.AddWithValue("NewFN", textBox7.Text);
            command.Parameters.AddWithValue("NewLN", textBox8.Text);
            command.Parameters.AddWithValue("NewP", textBox9.Text);
            command.Parameters.AddWithValue("NewAD", textBox10.Text);

            command.ExecuteNonQuery();

            selectData();
            dataGridView1.DataSource = dataSt.Tables["Cust"];

            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql2 = "SELECT * FROM Customer WHERE fName = @oldFN";

            SqlCommand command = new SqlCommand(sql2, connection);

            command.Parameters.Clear();
            command.Parameters.AddWithValue("oldFN", comboBox2.SelectedItem.ToString());

            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            dataSt = new DataSet();
            adapter.Fill(dataSt, "Cust");

            textBox7.Text = dataSt.Tables["Cust"].Rows[0][1].ToString();
            textBox8.Text = dataSt.Tables["Cust"].Rows[0][2].ToString();
            textBox9.Text = dataSt.Tables["Cust"].Rows[0][3].ToString();
            textBox10.Text = dataSt.Tables["Cust"].Rows[0][4].ToString();
            
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
