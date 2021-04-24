using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerApplication
{
    public partial class DATABASE : Form
    {

        private const string connStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=Customer;Integrated Security=True";

        private SQLClass Sql = new SQLClass();

        public DATABASE()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            DataTable dt = Sql.GetDataTable("Select * from customer");
            dataGridView1.DataSource = dt.DefaultView;

          
        }

        public void ClearTxtAreas()
        {
            txtName.Text = "";
            txtSurname.Text = "";
            txtAddress.Text = "";

        }


        private void button1_Click(object sender, EventArgs e)            //Insert btn
        {
            Customer customer = new Customer();    
            customer.FirstName = txtName.Text;                           //Assigning the Class "Customer properties to The GUI properties.
            customer.LastName = txtSurname.Text;
            customer.Address = txtAddress.Text;

            //string sql = @"INSERT INTO Customer (fld_FName,fld_LName,fld_Address) VALUES ('" + customer.FirstName + "','" + customer.Address + "','" + customer.LastName + "')";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            SqlCommand sqlCommand = new SqlCommand("InsertData",conn);

            
            sqlCommand.CommandType = CommandType.StoredProcedure;
          
            sqlCommand.Parameters.AddWithValue("@fld_Fname", customer.FirstName);
            sqlCommand.Parameters.AddWithValue("@fld_Address ", customer.LastName);
            sqlCommand.Parameters.AddWithValue("@fld_Lname", customer.Address);

            

            if (customer.FirstName == "" || customer.LastName == "" || customer.Address == "")
            {
                ClearTxtAreas();
                MessageBox.Show("Please Fill in All Fields ! ");
            }

           
            else

               
            {
                //Sql.InsertData("InsertData");
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Data Inserted Sucessfully ");

                ClearTxtAreas();

            }
           
        }





        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void txtName_TextChanged(object sender, EventArgs e) //Name txtArea
        {

        }


        private void button2_Click(object sender, EventArgs e) //Clear Btn
        {
          
            ClearTxtAreas();

        }


        private void button3_Click(object sender, EventArgs e) //Exit Btn
        {
            this.Close();
        }


        private void txtAddress_TextChanged(object sender, EventArgs e) //Address txtArea
        {

        }


        private void txtSurname_TextChanged(object sender, EventArgs e) //Suranme txtArea
        {

        }


        public void InsertData_Click(object sender, EventArgs e) 

        {
/*
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "Select * From Customers";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
*/


        }

        private void Address_Click(object sender, EventArgs e)
        {

        }


        private void Surname_Click(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button4_Click(object sender, EventArgs e) //
        {
            dataGridView1.Show();
            DataTable dt = Sql.GetDataTable("SelectAllCustomers");
            dataGridView1.DataSource = dt.DefaultView;
        }
    }

}
