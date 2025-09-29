using System.ComponentModel;
using App;

List<User> Users = new List<User>();

bool Running = true;
User ActiveUser = null;

while (Running)
{
    if (ActiveUser == null)
    {
        Console.WriteLine("---Terminal based trading Center---");
        Console.WriteLine("1. Create a new account");
        Console.WriteLine("2. Log in");
        Console.WriteLine("3. Quit");

        string input = Console.ReadLine();
        switch (input)
        {
            case "1":           //--------------create account--------------
                Console.WriteLine("---Create Account---\n");
                Console.WriteLine("Username: ");
                string C_username = Console.ReadLine();

                Console.WriteLine("Password: ");
                string C_password = Console.ReadLine();

                User newUser = new User(C_username, C_password);
                Users.Add(newUser);
                Console.WriteLine($"Account with Username: {C_username} has been created");

                break;

            case "2":           //------------------log in-----------------

                Console.WriteLine("---Log In---");
                Console.WriteLine("Username: ");
                string username = Console.ReadLine();

                Console.WriteLine("Password: ");
                string password = Console.ReadLine();

                foreach (User user in Users)
                {
                    if (user.TryLogin(username, password))
                    {
                        ActiveUser = user;
                        Console.WriteLine("Login Succesfull!");
                        break;
                    }
                }
                break;
            case "3":
                Console.WriteLine("Goodbye!");
                Running = false;

                break;

        }
    }
    else
    {
        Console.WriteLine("---Welcome to the Trading Center---");
        Console.WriteLine("1. Log out");
        Console.WriteLine("2. ");
        Console.WriteLine("3. Exit");

        string input = Console.ReadLine();
        switch (input)
        {
            case "1":           //--------------create account--------------
                Console.WriteLine("Logging out");
                ActiveUser = null;
                break;





            case "3":
                Console.WriteLine("Goodbye!");
                Running = false;

                break;

        }

    }
}







/*
Features
The following features need to be implemented:------------------------------------------------------------------

A user needs to be able to browse a list of other users items.
A user needs to be able to request a trade for other users items.
A user needs to be able to browse trade requests.
A user needs to be able to accept a trade request.
A user needs to be able to deny a trade request.
A user needs to be able to browse completed requests.


under process----------------------------------------------------------------------------------------------------

A user needs to be able to upload information about the item they wish to trade.


implemented features: --------------------------------------------------------------------------------------------
A user needs to be able to register an account
A user needs to be able to log in.
A user needs to be able to log out.



*/