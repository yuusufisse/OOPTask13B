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
                    string queryString = "SELECT * FROM Dentist";
                    SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);
                    using(SqlDataReader sqlDataReader=sqlCommand.ExecuteReader())
                    {
                        if(sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                //Save it to a generic collection??
                                Console.WriteLine(String.Format("{0}, {1}, {2}", 
                                    sqlDataReader[0], sqlDataReader[1], sqlDataReader[2]));
                            }
                        }
                        else
                            Console.WriteLine("Sorry, empty table.");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
