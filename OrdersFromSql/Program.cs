using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SqlOrders;

namespace OrdersFromSql
{
    public class Program
    {

        static void Main(string[] args)
        {
            GetOrders ord = new GetOrders();
            List<OrderSql> ords = ord.List();
            foreach (OrderSql ordSql in ords)
            {
                Console.WriteLine($"{ordSql.Id} , {ordSql.Date} , {ordSql.Amount} , {ordSql.CustomerId}");
            }
            Console.ReadKey();
        }
    }
}
