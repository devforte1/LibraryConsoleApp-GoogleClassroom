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
        private string connectionString;
        
        public SqlServerDb()
        {
            connectionString = "Data Source=localhost;Initial Catalog=LibraryConsoleAppDb;Integrated Security=True";
        }

        public List<string[]> SelectUsers()
        {
            string userVal = "";
            string[] user;
            List<string[]> userList = new List<string[]>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.sp_SelectUsers", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]},{reader[1]},{reader[2]},{reader[3]}");

                        int userId = (int)reader[0];
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
            }
            catch(Exception ex)
            {
                string customMsg = "SqlServerDb::SelectUsers()::An exception occurred accessing the stored procedure dbo.sp_SelectUsers.";
                LogException(ex, customMsg);
            }
            

            return userList;
        }

        public List<string[]> SelectRoles()
        {
            string roleVal = "";
            string[] role;
            List<string[]> roleList = new List<string[]>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.sp_SelectRoles", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]},{reader[1]}");

                        int roleId = (int)reader[0];
                        string roleName = (string)reader[1];

                        roleVal = ($"{reader[0]},{reader[1]}");
                        role = roleVal.Split(',');
                        roleList.Add(role);
                    }

                    reader.Close();
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                string customMsg = "SqlServerDb::SelectRoles()::An exception occurred accessing the stored procedure dbo.sp_SelectRoles.";
                LogException(ex, customMsg);
            }

            return roleList;
        }

        public string[] SelectUser(int userId)
        {
            string userVal = "";
            string[] user = new string[1];

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.sp_SelectUser", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userId", SqlDbType.Int).Value = userId;
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]},{reader[1]},{reader[2]},{reader[3]}");

                        // int userId = (int)reader[0];
                        string userName = (string)reader[1];
                        string userPassword = (string)reader[2];
                        bool isAdmin = (bool)reader[3];

                        userVal = ($"{reader[0]},{reader[1]},{reader[2]},{reader[3]}");
                        user = userVal.Split(',');
                    }

                    reader.Close();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                string customMsg = "SqlServerDb::SelectUser()::An exception occurred accessing the stored procedure dbo.sp_SelectUser.";
                LogException(ex, customMsg);
            }

            return user;
        }

        public string[] SelectUserByUserName(string userName)
        {
            string userVal = "";
            string[] user = new string[1];

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.sp_SelectUserByUserName", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = userName;
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int userId = (int)reader[0];
                        string name = (string)reader[1];
                        string userPassword = (string)reader[2];
                        bool isAdmin = (bool)reader[3];

                        userVal = ($"{reader[0]},{reader[1]},{reader[2]},{reader[3]}");
                        user = userVal.Split(',');
                    }

                    reader.Close();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                string customMsg = "SqlServerDb::SelectUserByName()::An exception occurred accessing the stored procedure dbo.sp_SelectUser.";
                LogException(ex, customMsg);
            }

            return user;
        }

        public string[] SelectRole(int roleId)
        {
            string roleVal = "";
            string[] role = new string[1];

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.sp_SelectRole", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@roleId", SqlDbType.Int).Value = roleId;
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]},{reader[1]}");

                        string roleName = (string)reader[1];

                        roleVal = ($"{reader[0]},{reader[1]}");
                        role = roleVal.Split(',');
                    }

                    reader.Close();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                string customMsg = "SqlServerDb::SelectRole()::An exception occurred accessing the stored procedure dbo.sp_SelectRole.";
                LogException(ex, customMsg);
            }

            return role;
        }

        public bool UpdateUser(int userId, string name, string password, bool isAdmin)
        {
            int result = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.sp_UpdateUser", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", SqlDbType.Int).Value = userId;
                    command.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = name;
                    command.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = password;
                    command.Parameters.AddWithValue("@IsAdmin", SqlDbType.NVarChar).Value = isAdmin;

                    conn.Open();
                    result = command.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                string customMsg = "SqlServerDb::UpdateUser()::An exception occurred accessing the stored procedure dbo.sp_UpdateUser.";
                LogException(ex, customMsg);
            }

            if (result > 0)
            { return true; }
            else
            { return false; }
        }

        public bool UpdateRole(int roleId, string name)
        {
            int result = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.sp_UpdateRole", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleId", SqlDbType.Int).Value = roleId;
                    command.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = name;

                    conn.Open();
                    result = command.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                string customMsg = "SqlServerDb::UpdateRole()::An exception occurred accessing the stored procedure dbo.sp_UpdateRole.";
                LogException(ex, customMsg);
            }

            if (result > 0)
            { return true; }
            else
            { return false; }
        }

        public bool InsertUser(string name, string password, bool isAdmin)
        {
            int result = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.sp_InsertUser", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = name;
                    command.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = password;
                    command.Parameters.AddWithValue("@IsAdmin", SqlDbType.NVarChar).Value = isAdmin;

                    conn.Open();
                    result = command.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                string customMsg = "SqlServerDb::InsertUser()::An exception occurred accessing the stored procedure dbo.sp_InsertUser.";
                LogException(ex, customMsg);
            }

            if (result > 0)
            { return true; }
            else
            { return false; }
        }

        public bool InsertRole(string name)
        {
            int result = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.sp_InsertRole", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = name;

                    conn.Open();
                    result = command.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                string customMsg = "SqlServerDb::InsertRole()::An exception occurred accessing the stored procedure dbo.sp_InsertRole.";
                LogException(ex, customMsg);
            }

            if (result > 0)
            { return true; }
            else
            { return false; }
        }

        public bool DeleteUser(int userId)
        {
            int result = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.sp_DeleteUser", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", SqlDbType.Int).Value = userId;
                    conn.Open();
                    result = command.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                string customMsg = "SqlServerDb::DeleteUser()::An exception occurred accessing the stored procedure dbo.sp_DeleteUser.";
                LogException(ex, customMsg);
            }

            if (result > 0)
            { return true; }
            else
            { return false; }
        }

        public bool DeleteUserByUserName(string userName)
        {
            int result = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.sp_DeleteUserByUserName", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = userName;
                    conn.Open();
                    result = command.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                string customMsg = "SqlServerDb::DeleteUserByUserName()::An exception occurred accessing the stored procedure dbo.sp_DeleteUserByUserName.";
                LogException(ex, customMsg);
            }

            if (result > 0)
            { return true; }
            else
            { return false; }
        }

        public bool DeleteRole(int roleId)
        {
            int result = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.sp_DeleteRole", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleId", SqlDbType.Int).Value = roleId;
                    conn.Open();
                    result = command.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                string customMsg = "SqlServerDb::DeleteRole()::An exception occurred accessing the stored procedure dbo.sp_DeleteRole.";
                LogException(ex, customMsg);
            }

            if (result > 0)
            { return true; }
            else
            { return false; }
        }

        public List<string[]> SelectMediaInventory()
        {
            string mediaVal = "";
            string[] media;
            List<string[]> mediaList = new List<string[]>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.sp_SelectMediaInventory", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]},{reader[1]},{reader[2]}");

                        int mediaId = (int)reader[0];
                        string mediaType = (string)reader[1];
                        string mediaName = (string)reader[2];

                        mediaVal = ($"{reader[0]},{reader[1]},{reader[2]}");
                        media = mediaVal.Split(',');
                        mediaList.Add(media);
                    }

                    reader.Close();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                string customMsg = "SqlServerDb::SelectMediaInventory()::An exception occurred accessing the stored procedure dbo.sp_SelectMediaInventory.";
                LogException(ex, customMsg);
            }

            return mediaList;
        }

        public bool InsertMedia(string mediaType, string mediaName)
        {
            int result = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.sp_InsertMedia", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Type", SqlDbType.NVarChar).Value = mediaType;
                    command.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = mediaName;
                    conn.Open();
                    result = command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                string customMsg = "SqlServerDb::InsertMedia()::An exception occurred accessing the stored procedure dbo.sp_InsertMedia.";
                LogException(ex, customMsg);
            }

            if (result > 0)
            { return true; }
            else
            { return false; }
        }

        public bool CheckOutMedia(int userId, int mediaId)
        {
            int result = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.sp_CheckOutMediaItem", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", SqlDbType.Int).Value = userId;
                    command.Parameters.AddWithValue("@MediaId", SqlDbType.NVarChar).Value = mediaId;

                    conn.Open();
                    result = command.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                string customMsg = "SqlServerDb::CheckoutMedia()::An exception occurred accessing the stored procedure dbo.sp_CheckOutMediaItem.";
                LogException(ex, customMsg);
            }

            if (result > 0)
            { return true; }
            else
            { return false; }
        }

        public bool CheckInMedia(int userId, int mediaId)
        {
            int result = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.sp_CheckInMediaItem", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", SqlDbType.Int).Value = userId;
                    command.Parameters.AddWithValue("@MediaId", SqlDbType.NVarChar).Value = mediaId;

                    conn.Open();
                    result = command.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                string customMsg = "SqlServerDb::CheckInMedia()::An exception occurred accessing the stored procedure dbo.sp_CheckInMediaItem.";
                LogException(ex, customMsg);
            }

            if (result > 0)
            { return true; }
            else
            { return false; }
        }

        public bool LogException(Exception ex, string customMsg = "")
        {
            int result = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.sp_InsertException", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ExceptionSource", SqlDbType.NVarChar).Value = ex.Source;
                    command.Parameters.AddWithValue("@ExceptionType", SqlDbType.NVarChar).Value = ex.GetType();
                    command.Parameters.AddWithValue("@CustomMsg", SqlDbType.NVarChar).Value = customMsg;
                    command.Parameters.AddWithValue("@SystemMsg", SqlDbType.NVarChar).Value = ex.Message;

                    conn.Open();
                    result = command.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex2)
            {
                string customMsg2 = "SqlServerDb::LogException()::An exception occurred accessing the stored procedure dbo.sp_InsertException.";
                Console.WriteLine(customMsg2);
                Console.WriteLine(ex2.Message);
            }

            if (result > 0)
            { return true; }
            else
            { return false; }

        }

        public bool ValidateUniqueUser(string userName)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    
                    SqlCommand command = new SqlCommand("dbo.sp_ValidateUniqueUserName", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = userName;
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        result = false;
                    }
                    else
                    {
                        result = true;
                    }
                    reader.Close();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                string customMsg = "SqlServerDb::ValidateUniqueUsername()::An exception occurred accessing the stored procedure dbo.sp_ValidateUniqueUserName.";
                LogException(ex, customMsg);
            }

            return result;
        }

        public bool LoadTestData()
        {
            int result = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.sp_LoadTestData", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    result = command.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                string customMsg = "SqlServerDb::LoadTestData()::An exception occurred accessing the stored procedure dbo.sp_LoadTestData.";
                LogException(ex, customMsg);
            }

            if (result > 0)
            { return true; }
            else
            { return false; }
        }
    }
}

