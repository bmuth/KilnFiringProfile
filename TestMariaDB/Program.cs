using System;
using System.Data;
using MySqlConnector;

namespace TestMariaDB
{
    internal class Program
    {
        static void Main (string[] args)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "192.168.1.4",
                Port = 3306,
                UserID = "root",
                Password = "red",
                Database = "Kiln"
            };

            // open a connection asynchronously
            using (var con = new MySqlConnection (builder.ConnectionString))
            {
                con.Open ();

                using (MySqlCommand cmd = new MySqlCommand ("SELECT * FROM FiringRun", con))
                {
                    MySqlDataReader reader = cmd.ExecuteReader ();
                    while (reader.Read ())
                    {
                        //You can get values from column names
                        Console.WriteLine (reader["title"].ToString ());
                        //Or return the value from the columnID, in this case, 0
                        Console.WriteLine (reader.GetInt32 (0));
                    }
                }
            }
            using (var con = new MySqlConnection (builder.ConnectionString))
            {
                con.Open ();
                DataSet ds = new DataSet ();
                {
                    using (MySqlCommand cmd = con.CreateCommand ())
                    {
                        cmd.CommandText = "select * from FiringRun";
                        MySqlDataAdapter adapter = new MySqlDataAdapter (cmd);
                        adapter.Fill (ds);
                    }
                }
                con.Close ();
            }
        }
    }
}
