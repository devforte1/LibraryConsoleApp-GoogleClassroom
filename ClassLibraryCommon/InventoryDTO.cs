using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibraryCommon
{
    public class InventoryDTO
    {
        private int _inventoryId;
        const string _filePath = "c:\\temp\\ConsoleAppInventory.txt";

        public int InventoryId { get => _inventoryId; }

        public InventoryDTO(int inventoryId=0)
        {
            
            if (inventoryId == 0)
            {
                _inventoryId = GetInventoryId(_filePath);
            }
            else
            {
                _inventoryId = inventoryId;
            }
        }

        private int GetInventoryId(string filePath)
        {
            int maxId = 0;

            // Access Role file.
            StreamReader InventoryListReader = new StreamReader(filePath);

            // Iterate the Role file to determine highest id value.
            while (!InventoryListReader.EndOfStream)
            {
                string inventoryVal = InventoryListReader.ReadLine();
                string[] inventoryProperties = inventoryVal.Split(',');

                if (int.Parse(inventoryProperties[0]) > maxId)
                {
                    maxId = int.Parse(inventoryProperties[0]);
                }
            }

            // Increment and return the next unique value.
            return (maxId + 1);
        }
    }
}
