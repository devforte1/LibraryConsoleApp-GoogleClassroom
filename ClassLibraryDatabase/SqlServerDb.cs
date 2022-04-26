using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDatabase
{
    public class SqlServerDb
    {
        public SqlServerDb()
        {

        }

        public bool TestSqlConnection()
        {
            // var connectionString = ConfigurationManager.ConnectionStrings["Data Source=localhost;Initial Catalog=Northwind;Integrated Security=True"].ConnectionString;
            // Data Source = localhost; Initial Catalog = Northwind; Integrated Security = True
            var connectionString = "Data Source = localhost; Initial Catalog = Northwind; Integrated Security = True";


            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM dbo.Customers;";
                var command = new SqlCommand(queryString, cn);
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable myDataTable = new DataTable();

                try
                {
                    cn.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        // while (reader.Read())
                        // {
                        // Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
                        myDataTable.Load(reader);
                        // }
                    }

                    // get all rows
                    var allRows = myDataTable.Rows.Cast<DataRow>();

                    var linqQueryResult = from p in allRows
                                          orderby allRows.ElementAt(0) descending
                                          select p;

                    foreach (DataRow row in linqQueryResult)
                    {
                        Console.WriteLine(row.ItemArray[2].ToString(), row.ItemArray[0].ToString(), row.ItemArray[1]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception occurred during database connection attempt.");
                    Console.WriteLine(ex.Message);
                }

                return true;
            }
        }

        public bool TestLibraryAppSqlDbAccess()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=LibraryConsoleAppDb;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string CommandString = "SELECT * FROM Users;";

                SqlCommand command = new SqlCommand(CommandString, conn);

                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]},{reader[1]},{reader[2]},{reader[3]}");                    
                }

                reader.Close();
                conn.Close();
            }

            return true;
        }

        public bool TestLibraryAppStoredProcedure()
        {


            string connectionString = "Data Source=localhost;Initial Catalog=LibraryConsoleAppDb;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.sp_SelectUsers", conn);
                command.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]},{reader[1]},{reader[2]},{reader[3]}");
                }

                reader.Close();
                conn.Close();
            }

            return true;
        }

        public List<string[]> GetUsers()
        {
            string userVal = "";
            string[] user;
            List<string[]> userList = new List<string[]>();

            string connectionString = "Data Source=localhost;Initial Catalog=LibraryConsoleAppDb;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                
                string CommandString = "SELECT * FROM [USER];";

                SqlCommand command = new SqlCommand(CommandString, conn);

                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]},{reader[1]},{reader[2]},{reader[3]}");

                    int userId = (int)reader[0] ;
                    string userName = (string)reader[1];
                    string userPassword = (string)reader[2];
                    bool isAdmin = (bool)reader[3];

                    userVal = ($"{reader[0]},{reader[1]},{reader[2]},{reader[3]}");
                    user = userVal.Split(',');
                    userList.Add(user);

                }

                reader.Close();
                conn.Close();
            }

            return userList;
        }

        public bool SelectUsers()
        {
            throw new NotImplementedException();
        }

        public bool SelectRoles()
        {
            throw new NotImplementedException();
        }

        public bool SelectUser()
        {
            throw new NotImplementedException();
        }

        public bool SelectRole()
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser()
        {
            throw new NotImplementedException();
        }

        public bool UpdateRole()
        {
            throw new NotImplementedException();
        }

        public bool InsertUser()
        {
            throw new NotImplementedException();
        }

        public bool InsertRole()
        {
            throw new NotImplementedException();
        }
    }

   
}
