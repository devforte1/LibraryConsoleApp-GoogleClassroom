using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using ClassLibraryCommon;

namespace ClassLibraryCommon
{
    public class RoleDTO
    {
        private int _roleId;
        private string _name;
        private DataAccess dataAccess = new DataAccess();

        public int RoleId { get=>_roleId; }
        public string Name { get => _name; set => _name = value; }
        
        //public RoleDTO(string name, int roleId = 0)
        //{
        //    if (roleId == 0)
        //    {
        //        _roleId = dataAccess.GetRoleId();
        //    }
        //    else
        //    {
        //        _roleId = roleId;
        //    }
            
        //    _name = name;
        //}
    }
}
