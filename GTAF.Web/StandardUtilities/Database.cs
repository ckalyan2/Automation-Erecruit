using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace StandardUtilities
{
   public class Database
    {
        public static DataSet ExecuteSqlCommand(string connectionstring,string command)
        {
            connectionstring = GetConnectionString();
            var resultDataSet = new DataSet();
            using (var connection = new SqlConnection(connectionstring))
            {
                using (var sqlCommand = new SqlCommand { CommandText = command, Connection = connection })
                {
                    try
                    {
                        const int iConnRetries = 3;
                        for(var iConnRetry=1; iConnRetry<= iConnRetries; iConnRetry++)
                        {
                            Console.WriteLine("Connecting to Sql Database,retry #[{0}]", iConnRetry);
                            connection.Open();
                            if(connection.State==ConnectionState.Open)
                            {
                                Console.WriteLine("Successfully Connected to database after [{0}] retries", iConnRetry);
                                break;
                            }
                        }
                        using (var dataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            dataAdapter.Fill(resultDataSet);
                        } 
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return resultDataSet;
        }
        static private string GetConnectionString()
        {
           
            return "Data Source=dev-sql01;Initial Catalog=qa01;"
                + "Integrated Security=true;";
        }

    }
}
