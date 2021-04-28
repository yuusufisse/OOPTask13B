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
                    string sql = "DELETE FROM Dentist WHERE Id = 9 AND Name <> 'Gyro Gearloose'";
                    SqlCommand sqlCommand1 = new SqlCommand(sql, sqlConnection);

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
