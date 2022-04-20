using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibraryDatabase
{
    public class UserDTO
    {
        private int _userId;
        private string _userName;
        private string _password;
        const string _filePath = "c:\\temp\\ConsoleAppUsers.txt";

        public int UserId { get => _userId; }
        public string Name { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }

        public UserDTO(string userName,string password,int userId=0)
        {
            _userName = userName;
            _password = password;

            if (userId == 0)
            {
                _userId = GetUserId(_filePath);
            }
            else
            {
                _userId = userId;
            }
            
        }

        private int GetUserId(string filePath)
        {
             int maxId = 0;

            // Access User file.
            StreamReader MyUserListReader = new StreamReader(filePath);

            // Increment and return the next unique value.
            while (!MyUserListReader.EndOfStream)
            {
                string userVal = MyUserListReader.ReadLine();
                string[] userProperties = userVal.Split(',');

                if (int.Parse(userProperties[0]) > maxId)
                {
                    maxId = int.Parse(userProperties[0]);
                }
            }

            return (maxId + 1);
        }
    }
}
