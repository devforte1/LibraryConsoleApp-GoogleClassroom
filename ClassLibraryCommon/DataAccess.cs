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
        MockDb db = new MockDb();
        
        private List<string[]> userList = new List<string[]>();
        private List<string[]> roleList = new List<string[]>();

        private List<UserDTO> userDtoList = new List<UserDTO>();
        private List<RoleDTO> roleDtoList = new List<RoleDTO>();

        public int GetRoleId()
        {
            return db.GetRoleId();
        }

        public int GetUserId()
        {
            return db.GetUserId();
        }

        public List<UserDTO> GetUsers()
        {
            userList = db.GetUsers();
 
            foreach (String[] user in userList)
            {
                var item1 = user[0];
                var item2 = user[1];
                var item3 = user[2];

                UserDTO userDTO = new UserDTO(item1, item2, int.Parse(item3));
                userDtoList.Add(userDTO);
            }

            return userDtoList;
        }

        public List<RoleDTO> GetRoles()
        {
            roleList = db.GetRoles();

            foreach (Object role in roleList)
            {
                Console.WriteLine(role);
                string[] roleItem = (string[])role;

                roleDtoList.Add(new RoleDTO(roleItem[0], int.Parse(roleItem[1])));
            }

            return roleDtoList;
        }
    }
}
