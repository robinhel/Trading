using System.ComponentModel;
using System.Security.AccessControl;
using App;

List<User> Users = new List<User>();
var ADS = new Dictionary<string, List<object>>();


Users.Add(new User("test", "pass"));

bool Running = true;
User activeUser = null;
List<Trade> marketplace = new List<Trade>();


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
        Console.WriteLine($"Welcome {activeUser.Name}!");
        Console.WriteLine("---Trading Center---");
        Console.WriteLine("1. Log out");
        Console.WriteLine("2. Add item");
        Console.WriteLine("3. advertise an item");
        Console.WriteLine("4. Show items for trade ");
        Console.WriteLine("5. ");
        Console.WriteLine("6. ");
        Console.WriteLine("7. ");
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

                Item newItem = new Item(ItemName, ItemDescription, activeUser);
                activeUser.addItem(newItem);

                Console.WriteLine($"you Succesfully added {ItemName}");

                break;

            case "3": //------------------------ADVETISEMENT----------------------------------
                activeUser.addItem(new Item("bike", "blue", activeUser));
                activeUser.addItem(new Item("xbox", "green", activeUser));


                int i = 0;
                foreach (Item item in activeUser.Items)
                {
                    Console.WriteLine($"avalable items are {i} {item.ItemName}");
                    i++;
                }

                Console.WriteLine("pick an index of the item you wish to publish");
                int ItemIndex = Convert.ToInt32(Console.ReadLine());

                // Skapa variabler för Trade object
                User sender = activeUser;
                User reciever = activeUser; // TODO: Behöver ändras till en reciever USER som finns.
                Item itemsForTrade = activeUser.Items[ItemIndex]; // Är ingen lista, detta är ett Item object.

                // Skapa ett object av Trade
                Trade trade = new Trade(sender: sender, receiver: reciever, itemsfortrade: null);

                Console.WriteLine($"itemsForTrade: {itemsForTrade.ItemName}");

                // Lägg till item i Trade objectet
                trade.UploadItem(itemsForTrade);

                Console.WriteLine($"You have succesfully advertised {itemsForTrade.ItemName} for trade!");
                Console.WriteLine($"Trade object looks like this: sender:{trade.Sender.Name} receiver:{trade.Receiver.Name} itemsfortrade:{trade.Itemsfortrade[0].ItemName} itemTradeStatus:{trade.Status}");


                break;

            case "4":
                // int ii = 0;

                // List<Item> allItemsForSale = marketplace.GetAllItemsForTrade();

                // foreach (Item itemForSale in allItemsForSale)
                // {
                //     Console.WriteLine($"Item: {itemForSale.ItemName} in pos: {ii}");
                //     ii++;
                // }

                break;



        }

    }
}







// /*
// Features
// The following features need to be implemented:------------------------------------------------------------------

// A user needs to be able to browse trade requests.
// A user needs to be able to accept a trade request.
// A user needs to be able to deny a trade request.
// A user needs to be able to browse completed requests.


// under process----------------------------------------------------------------------------------------------------

// A user needs to be able to request a trade for other users items.


// implemented features: --------------------------------------------------------------------------------------------
// A user needs to be able to register an account
// A user needs to be able to log in.
// A user needs to be able to log out.
// A user needs to be able to browse a list of other users items.
// A user needs to be able to upload information about the item they wish to trade.



// */