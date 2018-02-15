using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SqlOrders
{
    public class GetOrders
    {
        public List<OrderSql> List()
        {
            string connStr = @"server=DESKTOP-S0MROQ6\SQLEXPRESS;database=SqlTutorial;Trusted_connection=true";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            if (conn.State != System.Data.ConnectionState.Open)
            {
                Console.WriteLine("**No Connection Made**");
                return null;
            }

            string sql = "Select * from [Order]";
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                Console.WriteLine("No Rows Dectected");
                return null;
            }

            List<OrderSql> orders = new List<OrderSql>();
            while (reader.Read())
            {
                //id date amount customerid
                int id = reader.GetInt32(reader.GetOrdinal("Id"));
                DateTime dateTime = reader.GetDateTime(reader.GetOrdinal("Date"));
                decimal amount = reader.GetDecimal(reader.GetOrdinal("Amount"));
                int customerid = reader.GetInt32(reader.GetOrdinal("CustomerId"));


                //this puts the data into an instance called Order
                OrderSql order = new OrderSql();
                order.Id = id;
                order.Date = dateTime;
                order.Amount = amount;
                order.CustomerId = customerid;

                orders.Add(order);


            }
            conn.Close();
            return orders;


        }
    }
}
