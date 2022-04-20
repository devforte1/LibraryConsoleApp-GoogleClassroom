using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassLibraryCommon;
using ClassLibraryDatabase;

namespace ConsoleLibrary
{
    internal class Program
    {
        enum MenuOption
        {
            Guest,
            Register,
            Login,
            PrintProfile,
            PrintRoles,
            PrintUsers,
            Logout
        }
        enum ViewerStatus
        {
            Guest=1,
            Registrant=2,
            User=3
        }


        // TODO: Add authentication validation to method calls for security.
        // TODO: Implement Console UI logic.
        static void Main(string[] args)
        {
            // Get Library Helper application data.
            MockDb LibraryDb = new MockDb();
            List<RoleDTO> roles = LibraryDb.GetRoles();
            List<UserDTO> users = LibraryDb.GetUsers();
            // TODO: Add GetInventory() method.
            string userSelection = "";
            int viewerStatus = 0;
            
            do
            {
                userSelection = DisplayOptionsMenu();

                if (userSelection.Equals("g"))
                {
                    // Handle guest action.
                    viewerStatus = (int)ViewerStatus.Guest;
                }
                else if (userSelection.Equals("r"))
                {
                    // Handle register action.
                    viewerStatus = (int)ViewerStatus.Registrant;
                }
                else if (userSelection.Equals("l"))
                {
                    // Handle login action.
                    // if user role == admin set viewerStatus admin else..
                    viewerStatus = (int)ViewerStatus.User;
                }
                else if (userSelection.Equals("pp"))
                {
                    // Handle print profile action.
                    // if viewerStatus = user or admin..
                }
                else if (userSelection.Equals("pr"))
                {
                    // Handle print roles action.
                    // if viewerStatus = admin..
                }
                else if (userSelection.Equals("pu"))
                {
                    // Handle print users action.
                    // if viewerStatus = admin..
                }
                else if (userSelection.Equals("o"))
                {
                    // Handle logout action.
                    // MyGroceryListHelper.ExitGroceryListApp();
                }
                else if (userSelection.Equals("c"))
                {
                    // Handle checkOutItem action.
                    // if viewerStatus = user...
                }
                else if (userSelection.Equals("ai"))
                {
                    // Handle checkOutItem action.
                    // if viewerStatus = admin...
                }
                else if (userSelection.Equals("o"))
                {
                    // Handle logout action.
                    // MyGroceryListHelper.ExitGroceryListApp();
                }
                else
                {
                    Console.WriteLine("Enter a letter combination from the menu to take an action.");
                };

            } while (true);

            Console.WriteLine("Let's pause here.");
        }

        private static string DisplayOptionsMenu()
        {
            Console.WriteLine("DisplayOptionsMenu()::Display the Library Helper menu options.");
            Console.WriteLine(" ");
            Console.WriteLine("Enter one of the displayed letter combinations to select an action:");
            Console.WriteLine(" ");

            Console.WriteLine("g - Access Library Helper as a guest (limited access).");
            Console.WriteLine("r - Register for a Library Helper user account.");
            Console.WriteLine("l - Log into Library Helper with a registered user account.");
            Console.WriteLine("pp - Print your Library Helper profile.");
            Console.WriteLine("pr - Print available Library Helper roles.");
            Console.WriteLine("pr - Print registered Library Helper users.");
            Console.WriteLine("o - Log out of Library Helper.");

            var userSelection = Console.ReadLine();

            return userSelection;
        }

        private static bool CreateUser()
        {
            // TODO: Implement CreateUser().
            throw new NotImplementedException();
            
        }

        private static bool UpdateUser()
        {
            // TODO: Implement UpdateUser().
            throw new NotImplementedException();

        }

        private static bool RemoveUser(int userId)
        {
            // TODO: Implement RemoveUser().
            throw new NotImplementedException();

        }

        private static bool CreateRole()
        {
            // TODO: Implement CreateRole().
            throw new NotImplementedException();
        }

        private static bool UpdateRole()
        {
            // TODO: Implement UpdateRole().
            throw new NotImplementedException();
        }

        private static bool RemoveRole()
        {
            // TODO: Implement RemoveRole().
            throw new NotImplementedException();
        }

        private static bool AuthenticateUser(string userName, string password)
        {
            // TODO: Implement AuthenticateUser().
            throw new NotImplementedException();
        }

        private static bool IssueLibraryCard() { throw new NotImplementedException(); }

        private static bool CheckoutItem() { throw new NotImplementedException(); }

        private static bool CheckInItem() { throw new NotImplementedException(); }

        private static bool AddInventoryItem(string name,int quantity)
        {
            throw new NotImplementedException();
        }

        private static bool UpdateInventoryItemQuantity(int quantity) { throw new NotImplementedException(); }

        private static bool RemoveInventoryItem(string name) { throw new NotImplementedException(); }



        
    }
}
