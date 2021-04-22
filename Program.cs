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
                    string sql = "UPDATE Dentist SET Telnum = '050 987654321' WHERE Name = Gyro";
                    SqlCommand sqlCommand1 = new SqlCommand(sql);

                    string queryString = "SELECT * FROM Dentist";
                    SqlCommand sqlCommand2 = new SqlCommand(queryString, sqlConnection);
                    using(SqlDataReader sqlDataReader=sqlCommand2.ExecuteReader())
                    {
                        if(sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                
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
