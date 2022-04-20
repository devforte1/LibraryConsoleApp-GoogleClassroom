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
        private string _rolesFilePath = "c:\\temp\\ConsoleAppRoles.txt";
        private string _usersFilePath = "c:\\temp\\ConsoleAppUsers.txt";

        public List<UserDTO> GetUsers()
        {
            Console.WriteLine($"GetUsers()::Get saved users from {_usersFilePath}");
            List<UserDTO> userList = new List<UserDTO>();

            if ((File.Exists(_usersFilePath) && (!(File.ReadAllText(_usersFilePath) == ""))))
            {
                StreamReader UserListReader = new StreamReader(_usersFilePath);

                try
                {
                    while (!UserListReader.EndOfStream)
                    {
                        string userVal = UserListReader.ReadLine();
                        string[] userProperties = userVal.Split(',');
                        UserDTO user = new UserDTO(userProperties[0],userProperties[1]);
                        userList.Add(user);
                        Console.WriteLine($"User {user.Name} retrieved from {_usersFilePath}.");
                    }
                    Console.WriteLine(" ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to access User datastore.");
                }
                finally
                {
                    UserListReader.Close();
                    UserListReader.Dispose();
                    UserListReader = null;

                }
            }

            return userList;

        }

        public List<RoleDTO> GetRoles()
        {
            Console.WriteLine($"GetRoles()::Get saved roles from {_rolesFilePath}");
            List<RoleDTO> roleList = new List<RoleDTO>();

            if ((File.Exists(_rolesFilePath) && (!(File.ReadAllText(_rolesFilePath) == ""))))
            {
                StreamReader RolesListReader = new StreamReader(_rolesFilePath);
                
                try
                {
                    while (!RolesListReader.EndOfStream)
                    {
                        string roleVal = RolesListReader.ReadLine();
                        string[] roleProperties = roleVal.Split(',');
                        RoleDTO role = new RoleDTO(roleProperties[0]);
                        roleList.Add(role);
                        Console.WriteLine($"Role {role.Name} retrieved from {_rolesFilePath}.");
                    }
                    Console.WriteLine(" ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to access Role datastore.");
                }
                finally
                {
                    RolesListReader.Close();
                    RolesListReader.Dispose();
                    RolesListReader = null;

                }
            }

            return roleList;
        }

        bool SaveUserList(List<UserDTO> userList,string filePath)
        {
             Console.WriteLine($"SaveUsers()::Write UserList to file {filePath}.");

            if ((File.Exists(_usersFilePath) && (!(File.ReadAllText(_usersFilePath) == ""))))
            {
                try
                {
                    StreamWriter UserListWriter = new StreamWriter(filePath);
                    foreach (UserDTO item in userList)
                    {
                        UserListWriter.WriteLine($"{item.Name}, {item.Password}, {item.UserId}");
                    }
                    Console.WriteLine(" ");
                    UserListWriter.Close();
                    UserListWriter.Dispose();
                    UserListWriter = null;
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"SaveUsers()::Unable to write UserList to file { filePath }");
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

            return true;
        }

        public bool SaveUser(List<UserDTO> userList, UserDTO newUser)
        {
            Console.WriteLine($"MockDb.SaveUser()::Save user to file {_usersFilePath}.");

            
            
            try
            {
                StreamWriter UserDtoWriter = new StreamWriter(_usersFilePath);
                UserDtoWriter.WriteLine(newUser.UserId.ToString(), newUser.Name, newUser.Password);

                UserDtoWriter.Close();
                UserDtoWriter.Dispose();
                UserDtoWriter = null;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Exception occurred during user save to file {_usersFilePath}.");
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

        bool SaveRoleList(List<RoleDTO> roleList, string filePath)
        {
            Console.WriteLine($"SaveRoles()::Write RoleList to file {filePath}.");

            if (File.Exists(filePath) && (!(File.ReadAllText(filePath) == "")))
            {
                try
                {
                    StreamWriter RoleListWriter = new StreamWriter(filePath);
                    foreach (RoleDTO item in roleList)
                    {
                        RoleListWriter.WriteLine($"{item.Name},  {item.RoleId}");
                    }
                    Console.WriteLine(" ");
                    RoleListWriter.Close();
                    RoleListWriter.Dispose();
                    RoleListWriter = null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"SaveUsers()::Unable to write UserList to file { filePath }.");
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

            return true;
        }

        UserDTO GetUser(string name)
{
throw new NotImplementedException();
}

        RoleDTO GetRole(string roleName)
{ throw new NotImplementedException(); 
}
    }
}
