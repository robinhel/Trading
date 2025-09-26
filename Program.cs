using System.ComponentModel;
using App;

List<User> Users = new List<User>();

bool Running = true;
bool ActiveUser = false;

while (Running)
{
    if (ActiveUser == false)
    {
        Console.WriteLine("---Welcome to a Trading platform!---");
        Console.WriteLine("1. Create an account");
        Console.WriteLine("");
        Console.WriteLine("");

        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                Console.WriteLine("Username: ");
                string username = Console.ReadLine();

                Console.WriteLine("Password: ");
                string _password = Console.ReadLine();

                User users = new User(username, _password);

                break;
        }



        /*
                Console.WriteLine("Username: ");
                string username = Console.ReadLine();

                Console.WriteLine("Password: ");
                string password = Console.ReadLine();
        */

    }




}






/*
Features
The following features need to be implemented:------------------------------------------------------------------

A user needs to be able to log out.
A user needs to be able to log in.
A user needs to be able to upload information about the item they wish to trade.
A user needs to be able to browse a list of other users items.
A user needs to be able to request a trade for other users items.
A user needs to be able to browse trade requests.
A user needs to be able to accept a trade request.
A user needs to be able to deny a trade request.
A user needs to be able to browse completed requests.


under process----------------------------------------------------------------------------------------------------
A user needs to be able to register an account




implemented features: --------------------------------------------------------------------------------------------
*/