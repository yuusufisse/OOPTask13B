using System;
using System.Data.SqlClient;

namespace OOPTask13B
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Thursday;Integrated Security=true;";
            using (SqlConnection sqlConnection= new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    Console.WriteLine("State: {0}", sqlConnection.State);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
