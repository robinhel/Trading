using System.ComponentModel;
using App;

List<User> Users = new List<User>();





Users.Add(new User("test", "pass"));

bool Running = true;
User activeUser = null;

while (Running)
{
    if (activeUser == null)//----------------------------------fist menu--------------------------------------
    {
        Console.Clear();
        Console.WriteLine("---Terminal based trading Center---");
        Console.WriteLine("1. Create a new account");
        Console.WriteLine("2. Log in");
        Console.WriteLine("3. Quit");

        string input = Console.ReadLine();
        switch (input)
        {
            case "1":           //--------------create account--------------
                Console.Clear();
                Console.WriteLine("---Create Account---\n");


                Console.Clear();
                Console.WriteLine("Username: ");
                string C_username = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Password: ");
                string C_password = Console.ReadLine();

                User newUser = new User(C_username, C_password);
                Users.Add(newUser);
                Console.WriteLine($"Account with Username: {C_username} has been created");

                break;

            case "2":           //------------------log in-----------------

                Console.Clear();
                Console.WriteLine("---Log In---");
                Console.WriteLine("Username: ");
                string username = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Password: ");
                string password = Console.ReadLine();

                foreach (User user in Users)
                {
                    if (user.tryLogin(username, password))
                    {
                        activeUser = user;
                        Console.WriteLine("Login Succesfull!");
                        break;
                    }
                }
                break;
            case "3":

                Console.Clear();
                Console.WriteLine("Goodbye!");
                Running = false;

                break;

        }
    }
    else //------------------------------------------LOGGED IN MENU---------------------------------------------
    {
        Console.Clear();
        Console.WriteLine($"Welcome {activeUser.Name}!");
        Console.WriteLine("---Trading Center---");
        Console.WriteLine("1. Log out");
        Console.WriteLine("2. Add item");
        Console.WriteLine("3. advertise an item");
        Console.WriteLine("4. Add ");

        string input = Console.ReadLine();
        switch (input)
        {
            case "1":           //--------------Log out--------------

                Console.Clear();
                Console.WriteLine("Logging out");
                activeUser = null;
                break;


            case "2": //------------------add Item------------------------
                Console.Clear();
                Console.WriteLine("---Add Item---");
                Console.WriteLine("What would you like to add?");
                string ItemName = Console.ReadLine();

                Console.WriteLine("Description of the item:");
                string ItemDescription = Console.ReadLine();
                Item newItem = new Item(ItemName, ItemDescription);
                activeUser.addItem(newItem);
                Console.WriteLine($"you Succesfully added {ItemName}");


                break;

            case "3": //------------------------ADVETISEMENT----------------------------------

                foreach (Item item in activeUser.Items)
                {
                    Console.WriteLine($"avalable items are {item.ItemName}");

                }
                Console.WriteLine("press ENTER to continue");
                Console.ReadLine();


                break;

            case "4":

                break;



        }

    }
}







/*
Features
The following features need to be implemented:------------------------------------------------------------------

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
A user needs to be able to browse a list of other users items.



*/