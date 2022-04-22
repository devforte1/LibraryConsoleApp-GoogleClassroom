using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibraryDatabase
{   
    public class MockDb
    {
        private string _rolesFilePath = "ConsoleAppRoles.txt";
        private string _usersFilePath = "ConsoleAppUsers.txt";

        public List<string[]> GetUsers()
        {
            List<string[]> userList = new List<string[]>();

            if ((File.Exists(_usersFilePath) && (!(File.ReadAllText(_usersFilePath) == ""))))
            {
                string userVal = "";
                string[] user;

                using (StreamReader UserListReader = new StreamReader(_usersFilePath))
                {
                    try
                    {
                        while (!UserListReader.EndOfStream)
                        {
                            userVal = UserListReader.ReadLine();
                            user = userVal.Split(',');
                            userList.Add(user);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Unable to access User datastore.");
                    }
                    finally
                    {
                        UserListReader.Close();
                        UserListReader.Dispose();
                    }
                }
            }

            return userList;
        }


        public List<string[]> GetRoles()
        {
            List<string[]> roleList = new List<string[]>();

            if ((File.Exists(_rolesFilePath) && (!(File.ReadAllText(_rolesFilePath) == ""))))
            {
                StreamReader RoleListReader = new StreamReader(_rolesFilePath);

                try
                {
                    while (!RoleListReader.EndOfStream)
                    {
                        string roleVal = RoleListReader.ReadLine();
                        string[] role = roleVal.Split(',');
                        roleList.Add(role);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to access User datastore.");
                }
                finally
                {
                    RoleListReader.Close();
                    RoleListReader.Dispose();
                    RoleListReader = null;
                }
            }
            
            return roleList;
     }

        public int GetRoleId()
        {
            int maxId = 0;

            // Access User file.
            StreamReader MyRoleListReader = new StreamReader(_rolesFilePath);

            // Increment and return the next unique value.
            while (!MyRoleListReader.EndOfStream)
            {
                string roleVal = MyRoleListReader.ReadLine();
                string[] roleProperties = roleVal.Split(',');

                if (int.Parse(roleProperties[1]) > maxId)
                {
                    maxId = int.Parse(roleProperties[1]);
                }
            }

            MyRoleListReader.Close();
            MyRoleListReader.Dispose();

            return (maxId + 1);
        }

        public int GetUserId()
        {
            int maxId = 0;

            // Access User file.
            StreamReader MyUserListReader = new StreamReader(_usersFilePath);

            // Increment and return the next unique value.
            while (!MyUserListReader.EndOfStream)
            {
                string userVal = MyUserListReader.ReadLine();
                string[] userProperties = userVal.Split(',');

                if (int.Parse(userProperties[2]) > maxId)
                {
                    maxId = int.Parse(userProperties[2]);
                }
            }

            MyUserListReader.Close();
            MyUserListReader.Dispose();

            return (maxId + 1);
        }
    }
}
