using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlDataReader_Class_ConsoleApp
{
    //Source https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqldatareader?view=dotnet-plat-ext-5.0#:~:text=To%20create%20a%20SqlDataReader%2C%20you,SqlConnection%20other%20than%20closing%20it.   //ok


    class Program
    {
        static void Main()
        {
            string str = "Data Source=(local);Initial Catalog=Northwind;"
                         + "Integrated Security=SSPI";
            ReadOrderData(str);
        }

        private static void ReadOrderData(string connectionString)
        {
            string queryString =
                "SELECT OrderID, CustomerID FROM dbo.Orders;";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    ReadSingleRow((IDataRecord) reader);
                }

                // Call Close when done reading.
                reader.Close();
            }
        }

        private static void ReadSingleRow(IDataRecord record)
        {
            Console.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
        }
    }

}