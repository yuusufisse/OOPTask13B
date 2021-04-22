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
                    //Do the work here!
                    string sql = "INSERT INTO Dentist (Name, TelNum) VALUES (@Name, @TelNum)";
                    SqlCommand sqlCommand1 = new SqlCommand(sql, sqlConnection);
                    SqlParameter sqlParameter = new SqlParameter
                    {
                        ParameterName="@Name",
                        Value="Donuld Duck",
                        SqlDbType=System.Data.SqlDbType.NVarChar
                    };
                    sqlCommand1.Parameters.Add(sqlParameter);

                    sqlParameter = new SqlParameter
                    {
                        ParameterName="@TelNum",
                        Value="040678123",
                        SqlDbType = System.Data.SqlDbType.NVarChar
                    };
                    sqlCommand1.Parameters.Add(sqlParameter);

                    int addedOneRow = sqlCommand1.ExecuteNonQuery();
                    if (addedOneRow == 1)
                        Console.WriteLine("New staff member added.");
                    else
                        Console.WriteLine("For some reason nothing happened.");

                    //Did it go?
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
