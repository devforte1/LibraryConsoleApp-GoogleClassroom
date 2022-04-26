using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassLibraryDatabase;

namespace ClassLibraryCommon
{
    public class DataAccess
    {
        // MockDb db = new MockDb();
        SqlServerDb db = new SqlServerDb();
        
        private List<string[]> userList = new List<string[]>();
        private List<string[]> roleList = new List<string[]>();

        private List<UserDTO> userDtoList = new List<UserDTO>();
        private List<RoleDTO> roleDtoList = new List<RoleDTO>();

        //public int GetRoleId()
        //{
        //    return db.GetRoleId();
        //}

        public bool CreateUser(string userName, string password)
        {
            List<UserDTO> users = GetUsers();
            users.Add(new UserDTO(userName, password));

            int userId = users[users.Count - 1].UserId;
            // db.AddUser(userName, password, userId);

            return true;
        }

        public int GetUserId()
        {
            // return db.GetUserId();
            throw new NotImplementedException();
        }

        public List<UserDTO> GetUsers()
        {
            userList = db.GetUsers();
 
            foreach (String[] user in userList)
            {
                var _userId = user[0];
                var _userName = user[1];
                var _password = user[2];
                var _isAdmin = user[3];

                UserDTO userDTO = new UserDTO(_userName, _password, int.Parse(_userId),bool.Parse(_isAdmin));
                userDtoList.Add(userDTO);
            }

            return userDtoList;
        }

        public bool GetUsersFromStoredProcedure()
        {
            bool result = db.TestLibraryAppStoredProcedure();

            //foreach (String[] user in userList)
            //{
            //    var _userId = user[0];
            //    var _userName = user[1];
            //    var _password = user[2];
            //    var _isAdmin = user[3];

            //    UserDTO userDTO = new UserDTO(_userName, _password, int.Parse(_userId), bool.Parse(_isAdmin));
            //    userDtoList.Add(userDTO);
            //}

            //return userDtoList;
            return true;
        }

        public List<RoleDTO> GetRoles()
        {
           //  roleList = db.GetRoles();

            foreach (Object role in roleList)
            {
                Console.WriteLine(role);
                string[] roleItem = (string[])role;

                // roleDtoList.Add(new RoleDTO(roleItem[0], int.Parse(roleItem[1])));
            }

            return roleDtoList;
        }

        public bool AuthenticateUser(string userName, string password)
        {
            List<UserDTO> users = GetUsers();
            foreach (UserDTO user in users)
            {
                if (user.Name.ToString() == userName && user.Password.ToString() == password)
                {
                    return true;
                 }
            }

            return false;
        }

        public bool TestSqlConnection()
        {
            SqlServerDb db = new SqlServerDb();

            bool dbConnectResult = db.TestSqlConnection();

            return dbConnectResult;

        }

        public bool TestLibraryAppSqlConnection()
        {
            SqlServerDb db = new SqlServerDb();

            bool dbConnectResult = db.TestLibraryAppSqlDbAccess();

            return dbConnectResult;
        }
    }
}
