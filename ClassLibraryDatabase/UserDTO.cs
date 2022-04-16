using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDatabase
{
    public class UserDTO
    {
        private string _userName;

        public string Name { get => _userName; set => _userName = value; }

        public UserDTO(string userName)
        {
            _userName = userName;
        }
    }
}
