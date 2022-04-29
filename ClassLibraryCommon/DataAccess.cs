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
        SqlServerDb db = new SqlServerDb();

        private List<string[]> userList = new List<string[]>();
        private List<string[]> roleList = new List<string[]>();
        private List<string> mediaList = new List<string>();

        private List<UserDTO> userDtoList = new List<UserDTO>();
        private List<RoleDTO> roleDtoList = new List<RoleDTO>();
        private List<MediaDTO> mediaDtoList = new List<MediaDTO>();

        public bool CreateUser(string userName, string password)
        {
            bool result = db.InsertUser(userName, password, false);
            if (result)
            {
                userDtoList = GetUsers();
            }

            return result;
        }

        public bool CreateRole(string roleName)
        {
            bool result = db.InsertRole(roleName);
            return result;
        }

        public bool CreateMediaItem(string mediaType, string mediaName)
        {
            bool result = db.InsertMedia(mediaType, mediaName);
            return result;
        }

        public List<UserDTO> GetUsers()
        {
            userList = db.SelectUsers();

            foreach (String[] user in userList)
            {
                int _userId = int.Parse(user[0]);
                string _userName = user[1];
                string _password = user[2];
                bool _isAdmin = bool.Parse(user[3]);

                UserDTO userDTO = new UserDTO(_userId, _userName, _password, _isAdmin);
                userDtoList.Add(userDTO);
            }

            return userDtoList;
        }

        public List<RoleDTO> GetRoles()
        {
            roleList = db.SelectRoles();

            foreach (Object role in roleList)
            {
                Console.WriteLine(role);
                string[] roleItem = (string[])role;

                roleDtoList.Add(new RoleDTO(int.Parse(roleItem[0]), roleItem[1]));
            }

            return roleDtoList;
        }

        public bool CheckOutMediaItem(int userId, int mediaId)
        {
            bool result = db.CheckOutMedia(userId, mediaId);
            return result;
        }

        public bool CheckInMediaItem(int userId, int mediaId)
        {
            bool result = db.CheckOutMedia(userId, mediaId);
            return result;
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

        public bool ValidateUniqueUserName(string userName)
        {
            bool result = db.ValidateUniqueUser(userName);
            return result;
        }

        public bool RegisterUser(string userName, string password)
        {
            bool result = ValidateUniqueUserName(userName);
            if (result)
            {
                db.InsertUser(userName, password, false);
            }

            return result;
        }

        public string[] GetUserByUserName(string userName)
        {
            string[] result = new string[4];

            result = db.SelectUserByUserName(userName);

            return result;
        }
    }
}
