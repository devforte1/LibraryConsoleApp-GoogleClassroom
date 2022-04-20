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
        // TODO: 1. Implement unit tests.
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
            Initial = 0,
            Guest = 1,
            Registrant = 2,
            AuthenticatedUser = 3,
            AuthenticatedAdminUser =4
        }

        static int _viewerStatus = 0;
        static string _userSelection = "";

        // TODO: 9. Add authentication validation to method calls for security.
        static void Main(string[] args)
        {
            // Get Library Helper application data.
            MockDb LibraryDb = new MockDb();
            List<RoleDTO> roles = LibraryDb.GetRoles();
            List<UserDTO> users = LibraryDb.GetUsers();
            // TODO: Add GetInventory() method.
            Dictionary<string, string> menuOptions = new Dictionary<string, string>();
            menuOptions.Add("Login", "l - Log into Library Helper with a registered user account.");
            menuOptions.Add("Logout", "o - Log out of Library Helper.");
            menuOptions.Add("Guest", "g - Browse Library Helper as a guest (limited access).");
            menuOptions.Add("Register", "r - Register for a Library Helper user account.");
            menuOptions.Add("Exit", "x - Exit Library Helper.");
            menuOptions.Add("PrintProfile", "pp - Print your Library Helper user profile.");
            menuOptions.Add("PrintUsers", "pu - Print existing Library Helper users.");
            menuOptions.Add("PrintRoles", "pr - Print available Library Helper roles.");

            do
            {
                DisplayMenuHeader();
                if (_viewerStatus == (int)ViewerStatus.Initial) { DisplayInitialMenuOptions(menuOptions); }

                _userSelection = Console.ReadLine();
                if (_userSelection.Equals("g"))
                {
                    // Handle guest action.
                    _viewerStatus = (int)ViewerStatus.Guest;
                    Console.Clear();
                    Console.WriteLine("Welcome, Guest.");
                    DisplayMenuHeader();
                    DisplayGuestMenuOptions(menuOptions);
                }
                else if (_userSelection.Equals("r"))
                {
                    // Handle register action.
                    _viewerStatus = (int)ViewerStatus.Registrant;
                    Console.Clear();
                    DisplayMenuHeader();
                    DisplayRegistrantMenuOptions(menuOptions);
                }
                else if (_userSelection.Equals("l"))
                {
                    // Handle login action.
                    // if user role == admin set viewerStatus admin else..
                    _viewerStatus = (int)ViewerStatus.AuthenticatedUser;
                    Console.Clear();
                    DisplayMenuHeader();
                    DisplayUserMenuOptions(menuOptions,new UserDTO("temp","tempPass"));
                }
                else if (_userSelection.Equals("pp"))
                {
                    // Handle print profile action.
                    // if viewerStatus = user or admin.
                }
                else if (_userSelection.Equals("pr"))
                {
                    // Handle print roles action.
                    // if viewerStatus = admin..
                }
                else if (_userSelection.Equals("pu"))
                {
                    // Handle print users action.
                    // if viewerStatus = admin..
                }
                else if (_userSelection.Equals("o"))
                {
                    // Handle logout action.
                    // TODO: Implement Logout() method.
                    _viewerStatus = (int)ViewerStatus.Initial;
                    Console.Clear();
                }
                else if (_userSelection.Equals("c"))
                {
                    // Handle checkOutItem action.
                    // if viewerStatus = user...
                }
                else if (_userSelection.Equals("ai"))
                {
                    // Handle checkOutItem action.
                    // if viewerStatus = admin...
                }
                else if (_userSelection.Equals("o"))
                {
                    // Handle logout action.
                    // MyGroceryListHelper.ExitGroceryListApp();
                }
                else if (_userSelection.Equals("x"))
                {
                    // Handle application exit action.
                    Environment.Exit(0);
                }
                else if (_userSelection.Equals("au"))
                {
                    // if user is authenticated admin
                    // Handle create user action.
                }
                else
                {
                    Console.WriteLine("Enter a letter combination from the menu to take an action.");
                };

            } while (_userSelection != "x");
        }

        private static void DisplayMenuHeader()
        {
            Console.WriteLine("DisplayMenuHeader()::Display the Library Helper menu header.");
            Console.WriteLine(" ");
            Console.WriteLine("Enter one of the displayed letter combinations to select an action:");
            Console.WriteLine(" ");
        }

        private static void DisplayInitialMenuOptions(Dictionary<string,string>menuOptions)
        {
            // Display initial viewer options.
            Console.WriteLine("DisplayInitialMenuOptions()::Display the initial Library Helper menu options.");
            Console.WriteLine($"{menuOptions["Guest"]}");
            Console.WriteLine($"{menuOptions["Register"]}");
            Console.WriteLine($"{menuOptions["Login"]}");
            Console.WriteLine($"{menuOptions["Exit"]}");
        }

        private static void DisplayGuestMenuOptions(Dictionary<string, string> menuOptions)
        {
            Console.WriteLine("DisplayGuestMenuOptions()::Display the Library Helper guest menu options.");
            Console.WriteLine($"{menuOptions["Register"]}");
            Console.WriteLine($"{menuOptions["Exit"]}");
            //TODO: Implement inventory view method.
        }

        private static void DisplayRegistrantMenuOptions(Dictionary<string, string> menuOptions)
        {
            Console.WriteLine("DisplayRegistrantMenuOptions()::Display the Library Helper registrant menu options.");
            Console.WriteLine($"{menuOptions["Login"]}");
            Console.WriteLine($"{menuOptions["Exit"]}");
        }

        private static void DisplayUserMenuOptions(Dictionary<string, string> menuOptions,UserDTO user)
        {
            Console.WriteLine("DisplayUserMenuOptions()::Display the Library Helper user menu options.");
            if (user.IsAdmin)
            {
                // Write Admin menu options.
                Console.WriteLine($"{menuOptions["PrintUsers"]}");
            }
            
            Console.WriteLine($"{menuOptions["PrintProfile"]}");
            Console.WriteLine($"{menuOptions["PrintRoles"]}");
            Console.WriteLine($"{menuOptions["Logout"]}");
            Console.WriteLine($"{menuOptions["Exit"]}");
        }

        private static bool CreateUser(List<UserDTO> userList)
        {
            Console.WriteLine("Program.CreateUser()::Create new user.");

            string enteredUserName = "";
            string enteredPassword = "";
            MockDb LibraryDb = new MockDb();

            Console.WriteLine("Enter the username: ");
            enteredUserName = Console.ReadLine();

            Console.WriteLine("Enter a password for the user: ");
            enteredPassword = Console.ReadLine();

            UserDTO user = new UserDTO(enteredUserName, enteredPassword);
            bool result = LibraryDb.SaveUser(userList,user);
            if (result) { return true; }
            else
            {
                Console.WriteLine("Error saving user to database.");
                return false;
            }
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
            // TODO: 3. Implement CreateRole().
            throw new NotImplementedException();
        }

        private static bool UpdateRole()
        {
            // TODO: Implement UpdateRole().
            throw new NotImplementedException();
        }

        private static bool RemoveRole() 
        { // TODO: Implement RemoveRole().
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

        private static bool AddInventoryItem(string name, int quantity)
        {
            throw new NotImplementedException();
        }

        private static bool UpdateInventoryItemQuantity(int quantity) { throw new NotImplementedException(); }

        private static bool RemoveInventoryItem(string name) { throw new NotImplementedException(); }

        //TODO: 2. Implement SetAdmin() method.
    }
}
