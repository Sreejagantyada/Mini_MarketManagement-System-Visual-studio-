using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mini_MarketManagement_System
{
    internal class Class1
    {
        private SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sreej\OneDrive\Documents\product.mdf;Integrated Security=True;Connect Timeout=30");
        public SqlConnection getinf()
        {
            return connection;
        }
        public void openconn()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
           
        }
        public void closeconn()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
