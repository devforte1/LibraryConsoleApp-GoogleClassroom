using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassLibraryCommon;

namespace ConsoleLibrary
{
    public class Program
    {
        // TODO: Update unit tests for ClassLibraryCommon.
        // TODO: Update ConsoleLibrary to implement new features.
 
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
            AuthenticatedAdminUser = 4
        }

        static ViewerStatus _viewerStatus = ViewerStatus.Initial;
        static string _userSelection = "";
        
        static void Main(string[] args)
        {
            // Get Library Helper application data from data store (text files).
            DataAccess dataAccess = new DataAccess();
            List<RoleDTO> roles = dataAccess.GetRoles();
            List<UserDTO> users = dataAccess.GetUsers();

            
            bool authValid = false;
            string[] authUser = new string[4]; // Initialize authUser - will be populated on successful login.

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
            
            do
            {
                if (_viewerStatus == ViewerStatus.Initial) 
                { 
                    DisplayInitialMenuOptions(menuOptions);
                    DisplayMenuPrompt();
                  }

                _userSelection = Console.ReadLine();
                if (_userSelection.Equals("g"))
                {
                    // Display guest options.
                    _viewerStatus = ViewerStatus.Guest;
                    Console.Clear();
                    DisplayLibraryHelperVersion();
                    Console.WriteLine(" ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Welcome, Guest.");
                    Console.WriteLine(" ");
                    Console.ForegroundColor = ConsoleColor.White;
                    DisplayGuestMenuOptions(menuOptions);
                    DisplayMenuPrompt();
                }
                else if (_userSelection.Equals("r"))
                {
                    // Initiate user registration.
                    Console.WriteLine("Enter a Username: ");
                    string userName = Console.ReadLine();

                    Console.WriteLine("Enter a Password: ");
                    string password = null;
                    while (true)
                    {
                        var key = System.Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                            break;
                        password += key.KeyChar;
                    }

                    bool result = dataAccess.ValidateUniqueUserName(userName);
                    if (result)
                    {
                        dataAccess.CreateUser(userName, password);

                        _viewerStatus = ViewerStatus.Registrant;
                        Console.Clear();
                        DisplayLibraryHelperVersion();
                        Console.WriteLine(" ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Welcome, Registrant {userName}.");
                        Console.WriteLine(" ");
                        Console.ForegroundColor = ConsoleColor.White;
                        DisplayRegistrantMenuOptions(menuOptions);
                        DisplayMenuPrompt();
                    }
                    else
                    {
                        Console.Clear();
                        DisplayLibraryHelperVersion();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The entered user name is not available. Please register with a different user name.");
                        Console.WriteLine(" ");
                        Console.ForegroundColor = ConsoleColor.White;
                        DisplayMenuPrompt();
                    }
                }
                else if (_userSelection.Equals("l"))
                {
                    // Initiate user login.
                    Console.WriteLine("Username: ");
                    string userName = Console.ReadLine();

                    Console.WriteLine("Password: ");
                    string password = null;
                    while (true)
                    {
                        var key = System.Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                            break;
                        password += key.KeyChar;
                    }

                    authValid = dataAccess.AuthenticateUser(userName, password);

                    if (authValid)
                    {
                        _viewerStatus = ViewerStatus.AuthenticatedUser;
                        authUser = dataAccess.GetUserByUserName(userName);
                        Console.Clear();
                        DisplayLibraryHelperVersion();
                        Console.WriteLine(" ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Welcome, User {userName}.");
                        Console.WriteLine(" ");
                        Console.ForegroundColor = ConsoleColor.White;
                        DisplayUserMenuOptions(menuOptions,authUser);
                        DisplayMenuPrompt();
                    }
                    else
                    {
                        _viewerStatus = ViewerStatus.Initial;
                        Console.Clear();
                        DisplayLibraryHelperVersion();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid login credentials.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" ");
                        DisplayMenuPrompt();
                    }

                }
                else if (_userSelection.Equals("pp") && authValid)
                {
                    if (authValid)
                    {
                        // Print user profile.
                        Console.Clear();
                        DisplayLibraryHelperVersion();
                        Console.WriteLine(" ");
                        DisplayUserMenuOptions(menuOptions, authUser);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("User Profile:");
                        Console.WriteLine($"UserName: {authUser[1]} | User ID: {authUser[0]} | Is Admin? {authUser[3]}");
                        Console.ForegroundColor = ConsoleColor.White;
                        DisplayMenuPrompt();
                    }
                }
                else if (_userSelection.Equals("pr") && authValid)
                {
                    // Print Library Helper roles.
                    DisplayRoles(menuOptions, authUser);
                }
                else if (_userSelection.Equals("pu"))
                {
                    // Print active Library Helper users.
                    DisplayUsers(menuOptions, authUser);
                }
                else if (_userSelection.Equals("o") && authValid )
                {
                    // Log out of Library Helper.
                    _viewerStatus = (int)ViewerStatus.Initial;
                    _userSelection = "";
                    Console.Clear();
                    DisplayLibraryHelperVersion();
                    Console.WriteLine(" ");
                    DisplayMenuPrompt();
                }
                else if (_userSelection.Equals("x"))
                {
                    // Exit Library Helper application.
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    DisplayLibraryHelperVersion();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter a letter combination from the menu to take an action.");
                    Console.ForegroundColor = ConsoleColor.White;
                    DisplayMenuPrompt();
                };

            } while (_userSelection != "x");

            DisplayMenuPrompt();
        }

        private static void DisplayLibraryHelperVersion()
        {
            Console.WriteLine("Library Helper v2.0");
            Console.WriteLine(" ");
        }

        private static void DisplayMenuPrompt()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Enter one of the displayed letter combinations to select an action:");
            Console.WriteLine(" ");
        }

        private static void DisplayInitialMenuOptions(Dictionary<string, string> menuOptions)
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

        private static void DisplayUserMenuOptions(Dictionary<string, string> menuOptions, string[] user)
        {
            Console.WriteLine($"{menuOptions["PrintUsers"]}");
            Console.WriteLine($"{menuOptions["PrintProfile"]}");
            Console.WriteLine($"{menuOptions["PrintRoles"]}");
            Console.WriteLine($"{menuOptions["Logout"]}");
            Console.WriteLine($"{menuOptions["Exit"]}");
        }

        private static void DisplayUsers(Dictionary<string, string> menuOptions, string[] authUser)
        {
            DataAccess dataAccess = new DataAccess();
            List<UserDTO> users = dataAccess.GetUsers();
            Console.Clear();
            DisplayLibraryHelperVersion();
            DisplayUserMenuOptions(menuOptions, authUser);
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("LibraryHelper Users:");
            Console.WriteLine(" ");
            foreach (UserDTO user in users)
            {
                Console.WriteLine($"Username: {user.Name}, User ID: {user.UserId}");
            }
            Console.ForegroundColor = ConsoleColor.White;
            DisplayMenuPrompt();
        }

        private static void DisplayRoles(Dictionary<string, string> menuOptions, string[] authUser)
        {
            DataAccess dataAccess = new DataAccess();
            List<RoleDTO> roles = dataAccess.GetRoles();
            Console.Clear();
            DisplayLibraryHelperVersion();
            DisplayUserMenuOptions(menuOptions, authUser);
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("LibraryHelper Roles:");
            Console.WriteLine(" ");
            foreach (RoleDTO role in roles)
            {
                Console.WriteLine($"Role Name: {role.Name}, Role ID: {role.RoleId}");
            }
            Console.ForegroundColor = ConsoleColor.White;
            DisplayMenuPrompt();
        }
    }
}
