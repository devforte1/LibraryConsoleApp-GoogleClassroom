using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassLibraryCommon;
using ClassLibraryDatabase;

namespace ConsoleLibrary
{
    public class Program
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
            Initial = 0,
            Guest = 1,
            Registrant = 2,
            AuthenticatedUser = 3,
            AuthenticatedAdminUser =4
        }

        static int _viewerStatus = 0;
        static string _userSelection = "";

        static void Main(string[] args)
        {
            // Get Library Helper application data.
            DataAccess dataAccess = new DataAccess();
            
            List<RoleDTO> roles = dataAccess.GetRoles();
            List<UserDTO> users = dataAccess.GetUsers();

            // TODO: Add GetInventory() method.
            Dictionary<string, string> menuOptions = new Dictionary<string, string>();
            menuOptions.Add("Guest", "g - Browse Library Helper as a guest (limited access).");
            menuOptions.Add("Register", "r - Register for a Library Helper user account.");
            menuOptions.Add("PrintProfile", "pp - Print your Library Helper user profile.");
            menuOptions.Add("PrintRoles", "pr - Print available Library Helper roles.");
            menuOptions.Add("PrintUsers", "pu - Print existing Library Helper users.");
            menuOptions.Add("Login", "l - Log into Library Helper with a registered user account.");
            menuOptions.Add("Logout", "o - Log out of Library Helper.");
            menuOptions.Add("Exit", "x - Exit Library Helper.");


            Console.Clear();
            DisplayLibraryHelperVersion();
            DisplayMenuHeader();

            do
            {
                if (_viewerStatus == (int)ViewerStatus.Initial) { DisplayInitialMenuOptions(menuOptions); }

                _userSelection = Console.ReadLine();
                if (_userSelection.Equals("g"))
                {
                    // Handle guest action.
                    _viewerStatus = (int)ViewerStatus.Guest;
                    Console.Clear();
                    DisplayLibraryHelperVersion();
                    Console.WriteLine(" ");
                    Console.WriteLine("Welcome, Guest.");
                    DisplayMenuHeader();
                    DisplayGuestMenuOptions(menuOptions);
                }
                else if (_userSelection.Equals("r"))
                {
                    // Handle register action.
                    _viewerStatus = (int)ViewerStatus.Registrant;
                    Console.Clear();
                    DisplayLibraryHelperVersion();
                    Console.WriteLine(" ");
                    DisplayMenuHeader();
                    DisplayRegistrantMenuOptions(menuOptions);
                }
                else if (_userSelection.Equals("l"))
                {
                    // Handle login action.
                    UserDTO authUser;
                    bool authStatus = false;
                    Console.WriteLine("Username: ");
                    string userName = Console.ReadLine();

                    Console.WriteLine("Password: ");
                    string password = Console.ReadLine();

                    foreach (UserDTO user in users)
                    {
                        if (user.Name.ToString() == userName && user.Password.ToString() == password)
                        {
                            authStatus = true;
                            authUser = user;

                            _viewerStatus = (int)ViewerStatus.AuthenticatedUser;
                            Console.Clear();
                            DisplayLibraryHelperVersion();
                            Console.WriteLine(" ");
                            Console.WriteLine($"Welcome, {authUser.Name}.");
                            DisplayMenuHeader();
                            DisplayUserMenuOptions(menuOptions, authUser);
                            break;
                        }
                        else
                        {
                            _userSelection = "";
                            Console.Clear();
                            _viewerStatus = (int)ViewerStatus.Initial;

                        }
                    }
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
                    _userSelection = "";
                    Console.Clear();
                    DisplayLibraryHelperVersion();
                    Console.WriteLine(" ");
                    DisplayMenuHeader();
                }
                else if (_userSelection.Equals("x"))
                {
                    // Handle application exit action.
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Enter a letter combination from the menu to take an action.");
                };

            } while (_userSelection != "x");
        }

        private static void DisplayLibraryHelperVersion()
        {
            Console.WriteLine("Library Helper v1.0");
            Console.WriteLine(" ");
        }

        private static void DisplayMenuHeader()
        {
            Console.WriteLine("Enter one of the displayed letter combinations to select an action:");
            Console.WriteLine(" ");
        }

        private static void DisplayInitialMenuOptions(Dictionary<string,string>menuOptions)
        {
            // Display initial viewer options.
            Console.WriteLine($"{menuOptions["Guest"]}");
            Console.WriteLine($"{menuOptions["Register"]}");
            Console.WriteLine($"{menuOptions["Login"]}");
            Console.WriteLine($"{menuOptions["Exit"]}");
        }

        private static void DisplayGuestMenuOptions(Dictionary<string, string> menuOptions)
        {
            Console.WriteLine($"{menuOptions["Register"]}");
            Console.WriteLine($"{menuOptions["Exit"]}");
        }

        private static void DisplayRegistrantMenuOptions(Dictionary<string, string> menuOptions)
        {
            Console.WriteLine($"{menuOptions["Login"]}");
            Console.WriteLine($"{menuOptions["Exit"]}");
        }

        private static void DisplayUserMenuOptions(Dictionary<string,string> menuOptions,UserDTO user)
        {
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
    }
}
