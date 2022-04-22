using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ClassLibraryCommon
{
    public class UserDTO
    {
        private int _userId;
        private string _userName;
        private string _password;
        private bool _isAdmin;
        private DataAccess dataAccess = new DataAccess();

        public int UserId { get => _userId; }
        public string Name { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
        public bool IsAdmin { get => _isAdmin; set => _isAdmin = value; }

        public UserDTO(string userName,string password,int userId=0,bool isAdmin=false)
        {
            _userName = userName;
            _password = password;
            _isAdmin = isAdmin;

            if (userId == 0)
            {
                _userId = dataAccess.GetUserId();
            }
            else
            {
                _userId = userId;
            }
            
        }
    }
}
