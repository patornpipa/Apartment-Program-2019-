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
    public partial class print : Form
    {
        private SqlConnection connection;
        private DataSet dataSt;
        public string roomtype;
        public print()
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
            comboBox1.Text = "เลือกห้อง";
            for (int i = 0; i < dataSt.Tables["Cust"].Rows.Count; i++)
            {
                comboBox1.Items.Add(dataSt.Tables["Cust"].Rows[i]["roomID"].ToString());
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql2 = "SELECT * FROM Customer WHERE roomID = @oldFN";

            SqlCommand command = new SqlCommand(sql2, connection);

            command.Parameters.Clear();
            command.Parameters.AddWithValue("oldFN", comboBox1.SelectedItem.ToString());

            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            dataSt = new DataSet();
            adapter.Fill(dataSt, "Cust");

            label4.Text = dataSt.Tables["Cust"].Rows[0][1].ToString() + "  " + dataSt.Tables["Cust"].Rows[0][2].ToString();
            label5.Text = dataSt.Tables["Cust"].Rows[0][3].ToString();
            label6.Text = dataSt.Tables["Cust"].Rows[0][4].ToString();

            label7.Text = " ";
            label8.Text = " ";
            label9.Text = " ";
            label10.Text = " ";
            label11.Text = " ";
            label12.Text = " ";
            label13.Text = " ";
            label14.Text = " ";
            if ((int)dataSt.Tables["Cust"].Rows[0][6] == 2500)
                roomtype = "Single";
            else if((int)dataSt.Tables["Cust"].Rows[0][6] == 3200)
                roomtype = "Double";
            else if ((int)dataSt.Tables["Cust"].Rows[0][6] == 4000)
                roomtype = "Triple";

        }

        private void Print_Load(object sender, EventArgs e)
        {
            string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB_customer.mdf;Integrated Security=True";

            connection = new SqlConnection(conStr);
            connection.Open();
            selectData();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        { 
            label7.Text = "ห้อง: " + dataSt.Tables["Cust"].Rows[0][5].ToString() + "       ห้องประเภท: " + roomtype;
            label8.Text = "ชื่อ: คุณ " + dataSt.Tables["Cust"].Rows[0][1].ToString() + "  " + dataSt.Tables["Cust"].Rows[0][2].ToString();
            label9.Text = "ค่าน้ำ: " + dataSt.Tables["Cust"].Rows[0][8].ToString() + " บาท";
            label10.Text = "ค่าไฟ: " + dataSt.Tables["Cust"].Rows[0][7].ToString() + " บาท";
            label11.Text = "ค่าห้อง: " + dataSt.Tables["Cust"].Rows[0][6].ToString() + " บาท";
            label12.Text = "รวมทั้งสิ้น: " + dataSt.Tables["Cust"].Rows[0][9].ToString() + " บาท";
            label13.Text = "รายการ------------------------------------------------------------";
            label14.Text = "-----------------------------------------------------------------";
            selectData();

            label4.Text = " ";
            label5.Text = " ";
            label6.Text = " ";
            
        }
    }
}
