using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibraryDatabase
{
    public class RoleDTO
    {
        private int _roleId;
        private string _name;
        const string _filePath = "c:\\temp\\ConsoleAppRoles.txt";

        public int RoleId { get=>_roleId; }
        public string Name { get => _name; set => _name = value; }
        
        public RoleDTO(string name, int roleId = 0)
        {
            if (roleId == 0)
            {
                _roleId = GetRoleId(_filePath);
            }
            else
            {
                _roleId = roleId;
            }
            
            _name = name;
        }

        private int GetRoleId(string filePath)
        {
            int maxId = 0;

            // Access Role file.
            StreamReader MyRoleListReader = new StreamReader(filePath);

            // Iterate the Role file to determine highest id value.
            while (!MyRoleListReader.EndOfStream)
            {
                string roleVal = MyRoleListReader.ReadLine();
                string[] roleProperties = roleVal.Split(',');
                
                if(int.Parse(roleProperties[0]) > maxId)
                {
                    maxId = int.Parse(roleProperties[0]);
                }
            }

            // Increment and return the next unique value.
            return (maxId + 1);
        }
    }
}
