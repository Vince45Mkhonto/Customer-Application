using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApplication
{
    public class SQLClass
    {
        private const string connStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=Customer;Integrated Security=True";

        public bool InsertData(string sql)                      //Inserting Data
        {
            SqlConnection scon = new SqlConnection(connStr);   //scon
            SqlCommand scom = new SqlCommand();                //scom
            scon.Open();                                      //scon.Open();
            scom.Connection = scon;                            
            scom.CommandText = sql;
          

            scon.Close();
            return true;

           
        }


        public DataTable GetDataTable(string sql)
        {
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            return dt;
        }
    }
}
