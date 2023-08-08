using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePassword
{
    internal class Gui
    {
        Manager mana = new Manager();

        public void StartMenu()
        {
            // Bool to control the menu
            bool startMenu = true;

            while (startMenu)
            {
                Console.Clear();
                Console.WriteLine("==================================================");
                Console.WriteLine("                 Login screen");
                Console.WriteLine("==================================================\n");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Create login");
                Console.WriteLine("3. Exit");
                Console.Write("\r\nPress a number.");

                // Switch case for each menu point
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        LoginMenu();
                        break;
                    case '2':
                        CreateLoginMenu();
                        break;
                    case '3':
                        ExitApplication();
                        break;
                    default:
                        break;
                }
            }
        }

        private void LoginMenu()
        {
            bool loginMenu = true;

            Console.Clear();
            Console.WriteLine("Write your username, press enter twice to go to next step. \n");

            while (loginMenu)
            {
                string username = Console.ReadLine();

                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    bool drilldownMenu = true;

                    Console.WriteLine("Write your password, press enter twice to login. \n");

                    while (drilldownMenu)
                    {
                        string password = Console.ReadLine();

                        if (mana.CheckLogin(username, password))
                        {
                            LoginSuccesfulMenu();
                        }
                        else
                        {
                            LoginUnsuccesfulMenu();
                        }
                    }
                }

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    StartMenu();
                }
            }
        }

        private void CreateLoginMenu()
        {
            bool createLoginMenu = true;

            Console.Clear();
            Console.WriteLine("Write a username, press enter twice to go to next step: \n");

            while (createLoginMenu)
            {
                string username = Console.ReadLine();

                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    bool drilldownMenu = true;

                    Console.Clear();
                    Console.WriteLine("Write a password for the account, press enter twice to save: \n");

                    string password = Console.ReadLine();

                    while (drilldownMenu)
                    {
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            if (mana.CreateLogin(username, password))
                            {
                                LoginCreatedSuccesfullyMenu();
                            }
                            else
                            {
                                LoginCreatedUnsuccesfullyMenu();
                            }
                        }

                        if (Console.ReadKey().Key == ConsoleKey.Escape)
                        {
                            StartMenu();
                        }
                    }
                }
            }
        }

        public void LoginSuccesfulMenu()
        {
            bool loginSuccesfulMenu = true;

            Console.WriteLine("Your login was verified in the database. \n");
            Console.WriteLine("Press enter to go to next step or escape to go back.");

            while (loginSuccesfulMenu)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    AccountSettingsMenu();
                }

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    StartMenu();
                }
            }
        }

        public void LoginUnsuccesfulMenu()
        {
            bool loginSuccesfulMenu = true;

            Console.WriteLine("Your login couldn't be verified in the database, make sure you entered the right credentials or created a user first. \n");
            Console.WriteLine("Press escape to go back.");

            while (loginSuccesfulMenu)
            {
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    StartMenu();
                }
            }
        }

        public void LoginCreatedSuccesfullyMenu()
        {
            bool loginSuccesfulMenu = true;

            Console.WriteLine("Your login was created in the database. \n");
            Console.WriteLine("Press escape to go back and login.");

            while (loginSuccesfulMenu)
            {
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    StartMenu();
                }
            }
        }

        public void LoginCreatedUnsuccesfullyMenu()
        {
            bool loginSuccesfulMenu = true;

            Console.WriteLine("Your login failed to be inserted into the database. \n");
            Console.WriteLine("Press escape to go back.");

            while (loginSuccesfulMenu)
            {
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    StartMenu();
                }
            }
        }

        public void AccountSettingsMenu()
        {
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("                 Account settings");
            Console.WriteLine("==================================================\n");
            Console.WriteLine("1. Update login");
            Console.WriteLine("2. Delete login");
            Console.WriteLine("3. Start menu");
            Console.Write("\r\nPress a number.");

            // Switch case for each menu point
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    UpdateLoginMenu();
                    break;
                case '2':
                    DeleteLoginMenu();
                    break;
                case '3':
                    StartMenu();
                    break;
                default:
                    break;
            }
        }

        private void UpdateLoginMenu()
        {
            bool updateLoginMenu = true;

            Console.Clear();
            Console.WriteLine("Write the username for the account to be updated, press enter twice to go to next step: \n");

            while (updateLoginMenu)
            {
                string username = Console.ReadLine();

                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    bool drilldownMenu = true;

                    Console.WriteLine("Write the old password for the account, press enter twice to go to next step: \n");

                    while (drilldownMenu)
                    {
                    string oldPassword = Console.ReadLine();

                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            bool secondDrilldown = true;

                            Console.WriteLine("Write the new password for the account, press enter twice to save. \n");

                            while (secondDrilldown)
                            {
                                string newPassword = Console.ReadLine();

                                if (Console.ReadKey().Key == ConsoleKey.Enter)
                                {
                                    if (mana.UpdateLogin(username, newPassword))
                                    {
                                        LoginUpdatedSuccesfullyMenu();
                                    }
                                    else
                                    {
                                        LoginUpdatedUnsuccesfullyMenu();
                                    }
                                }

                                if (Console.ReadKey().Key == ConsoleKey.Escape)
                                {
                                    StartMenu();
                                }
                            }
                        }
                    }
                }
            }
        }

        public void LoginUpdatedSuccesfullyMenu()
        {
            bool loginSuccesfulMenu = true;

            Console.WriteLine("Your login was succesfully updated in the database. \n");
            Console.WriteLine("Press escape to go back.");

            while (loginSuccesfulMenu)
            {
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    StartMenu();
                }
            }
        }

        public void LoginUpdatedUnsuccesfullyMenu()
        {
            bool loginSuccesfulMenu = true;

            Console.WriteLine("Your login failed to be updated in the database. \n");
            Console.WriteLine("Press escape to go back.");

            while (loginSuccesfulMenu)
            {
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    StartMenu();
                }
            }
        }

        private void DeleteLoginMenu()
        {
            bool deleteLoginMenu = true;

            Console.Clear();
            Console.WriteLine("Write the username for the account to be deleted, press enter twice to go to next step: \n");

            while (deleteLoginMenu)
            {
                string username = Console.ReadLine();

                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    bool drilldownMenu = true;

                    Console.Clear();
                    Console.WriteLine("Write the password for the account to be deleted, press enter twice to go to next step: \n");

                    string password = Console.ReadLine();

                    while (drilldownMenu)
                    {
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            if (mana.DeleteLogin(username))
                            {
                                LoginDeletedSuccesfullyMenu();
                            }
                            else
                            {
                                LoginDeletedUnsuccesfullyMenu();
                            }
                        }

                        if (Console.ReadKey().Key == ConsoleKey.Escape)
                        {
                            StartMenu();
                        }
                    }
                }
            }
        }

        public void LoginDeletedSuccesfullyMenu()
        {
            bool loginSuccesfulMenu = true;

            Console.WriteLine("Your login was succesfully updated in the database. \n");
            Console.WriteLine("Press escape to go back.");

            while (loginSuccesfulMenu)
            {
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    StartMenu();
                }
            }
        }

        public void LoginDeletedUnsuccesfullyMenu()
        {
            bool loginSuccesfulMenu = true;

            Console.WriteLine("Your login failed to be updated in the database. \n");
            Console.WriteLine("Press escape to go back.");

            while (loginSuccesfulMenu)
            {
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    StartMenu();
                }
            }
        }

        private void ExitApplication()
        {
            Environment.Exit(0);
        }
    }
}
