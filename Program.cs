using System.ComponentModel;
using System.Security.AccessControl;
using App;

List<User> Users = Helpers.LoadUsersFromFile();
bool Running = true;
User activeUser = null;
List<Trade> marketplace = Helpers.LoadAdsFromFile();
List<Trade> completedTrades = Helpers.LoadCompletedTradesFromFile();


while (Running)
{
    if (activeUser == null)//----------------------------------fist menu--------------------------------------
    {
        //Console.Clear();
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

                Helpers.SaveUsersToFile(Users);

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
        Console.WriteLine("=== Trading Center ===");
        Console.WriteLine("1. Log out");
        Console.WriteLine("2. Add item to inventory");
        Console.WriteLine("3. Remove item from inventory");
        Console.WriteLine("4. Show items for trade");
        Console.WriteLine("5. Request trade");
        Console.WriteLine("6. Advertise item for trade");
        Console.WriteLine("7. Remove advertised item");
        Console.WriteLine("8. Review trade requests");
        Console.WriteLine("9. Show completed trades");

        string input = Console.ReadLine();
        switch (input)
        {
            case "1":           //--------------Log out--------------

                Console.Clear();
                Console.WriteLine("Logging out");
                activeUser = null;
                break;


            case "2":           //------------------add Item------------------------
                Console.Clear();
                Console.WriteLine("---Add Item---");
                Console.WriteLine("What would you like to add?");
                string ItemName = Console.ReadLine();

                Console.WriteLine("Description of the item:");
                string ItemDescription = Console.ReadLine();

                Item newItem = new Item(ItemName, ItemDescription, activeUser);
                activeUser.addItem(newItem);

                Console.WriteLine($"you Succesfully added {ItemName}");

                Console.WriteLine("press ENTER to continue");
                Console.ReadLine();

                break;

            case "3":           //------------------------Remove item----------------------------------
                if (activeUser.Items.Count == 0)
                {
                    Console.WriteLine("no items to remove");
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadLine();
                    break;
                }

                Console.WriteLine("Wich item would you like to remove");
                for (int j = 0; j < activeUser.Items.Count; j++)
                {
                    Console.WriteLine($"Item index: {j}, Item Name: {activeUser.Items[j].ItemName}");
                }
                Console.WriteLine("Pick the index of the item you wish to remove!");

                // Vilket index i listan är det vi ska ta bort?


                if (int.TryParse(Console.ReadLine(), out int removeItemIndex))
                {

                    // Ta bort från listan med index värdet som är valt
                    // Tar bort från Items listan för activeUser, inte vi klassens funktion.
                    activeUser.Items.RemoveAt(removeItemIndex);

                    Console.WriteLine($"Item in position {removeItemIndex} has been removed!");//ItemName[RemoveItemIndex] 
                    Console.WriteLine("press ENTER to continue");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Please enter valid index");
                    Console.WriteLine("press ENTER to continue");
                    Console.ReadLine();
                }
                break;

            case "4":           //----------------------show items for trade-------------------------------

                // Lista alla items som är tillgängliga för trade
                // Dvs alla Trade object i marketplace listan
                if (marketplace.Count == 0)
                {
                    Console.WriteLine("No items available for trade.");
                    Console.WriteLine("press ENTER to continue");
                    Console.ReadLine();
                    break;

                }

                int ii = 0;
                foreach (Trade TradeInList in marketplace)
                {
                    Console.WriteLine($"avalable items are {ii} {TradeInList.ItemForTrade.ItemName}");
                    ii++;
                }

                Console.WriteLine("press ENTER to continue");
                Console.ReadLine();

                break;

            case "5":                       //---------------------requst a trade----------------------

                if (marketplace.Count == 0)
                {
                    Console.WriteLine("No items available for trade.");
                    Console.WriteLine("press ENTER to continue");
                    Console.ReadLine();
                    break;
                }

                int iii = 0;
                foreach (Trade TradeInList in marketplace)
                {
                    Console.WriteLine($"Item index: {iii}\nItem: {TradeInList.ItemForTrade.ItemName}\nOwner: {TradeInList.Sender.Name}\nstatus: {TradeInList.Status}\n");
                    iii++;
                }

                Console.WriteLine("\nPick Item index:");


                if (int.TryParse(Console.ReadLine(), out int TradeIndex))
                {

                    Trade chosenTrade = marketplace[TradeIndex];

                    Console.WriteLine("Your Items avaliable for trading:");
                    for (int j = 0; j < activeUser.Items.Count; j++)
                    {
                        Console.WriteLine($"Item index: {j}, Item Name: {activeUser.Items[j].ItemName}");
                    }
                    Console.WriteLine("Pick the index of the item you wish to send a trade Request for!");
                    int TradeRequistIndex = Convert.ToInt32(Console.ReadLine());

                    chosenTrade.Receiver = activeUser;
                    chosenTrade.OfferedItem = activeUser.Items[TradeRequistIndex];
                    chosenTrade.Status = TradingStatus.Pending;

                    Console.WriteLine($"You {activeUser.Name} requseted {chosenTrade.ItemForTrade.ItemName} for {marketplace[TradeIndex].OfferedItem.ItemName}");
                }
                else
                {
                    Console.WriteLine("Please enter valid number");
                }
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
                break;

            case "6":           //---------------------------------------advertise trade-----------------------------------
                if (activeUser.Items.Count == 0)
                {
                    Console.WriteLine("No items to advertise");
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadLine();
                    break;
                }
                //activeUser.addItem(new Item("bike", "blue", activeUser));
                //activeUser.addItem(new Item("xbox", "green", activeUser));


                int i = 0;
                foreach (Item item in activeUser.Items)
                {
                    Console.WriteLine($"avalable items are {i} {item.ItemName}");
                    i++;
                }

                Console.WriteLine("pick an index of the item you wish to publish");

                if (int.TryParse(Console.ReadLine(), out int ItemIndex))
                {

                    // Skapa variabler för Trade object
                    User sender = activeUser;
                    Item itemForTrade = activeUser.Items[ItemIndex]; // Är ingen lista, detta är ett Item object.

                    // Skapa ett object av Trade
                    Trade trade = new Trade(sender: sender, itemForTrade: itemForTrade);


                    // Lägg till Trade object i marketplace listan
                    // Då blir denna trade synlig för andra users
                    // dvs den är "advertised"
                    marketplace.Add(trade);

                    Helpers.SaveAdsToFile(marketplace);


                    Console.WriteLine($"You have succesfully advertised {trade.ItemForTrade.ItemName} for trade!");
                    Console.WriteLine($"Trade object looks like this: sender:{trade.Sender.Name}\nitemsfortrade:{trade.ItemForTrade.ItemName}");//TODO: fix trade.itemfortrade index . itemname
                }
                else
                {
                    Console.WriteLine("please enter valid number");
                }
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
                break;



            case "7":           //------------------------------remove advertisement----------------------------------
                if (marketplace.Count == 0)
                {
                    Console.WriteLine("YMarketplace is empty");
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadLine();
                    break;
                }

                Console.WriteLine("Wich item would you like to remove from the marketplace");
                for (int j = 0; j < marketplace.Count(); j++)
                {
                    Console.WriteLine($"Item index: {j}, Item Name: {marketplace[j].ItemForTrade.ItemName}");
                }
                Console.WriteLine("Pick the index of the item you wish to remove!");

                if (int.TryParse(Console.ReadLine(), out int removeADIndex))
                {
                    marketplace.RemoveAt(removeADIndex);
                    Helpers.SaveAdsToFile(marketplace);

                    Console.WriteLine($"Item in position {removeADIndex} has been removed!");
                }
                else
                {
                    Console.WriteLine("please enter valid number");
                }
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
                break;

            case "8":                   //---------------------------------------review trade requsts------------------------------
                if (marketplace.Count == 0)
                {
                    Console.WriteLine("Marketplace is empty");
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadLine();
                    break;
                }
                bool showAcceptDeny = false;
                Console.WriteLine("trade requst for you: ");
                for (int j = 0; j < marketplace.Count(); j++)
                {
                    // Filtrera för att enbart se trade´s i pending status och trade requests där activeUser är mottagaren
                    if (marketplace[j].Status == TradingStatus.Pending && marketplace[j].Sender == activeUser)
                    {
                        Console.WriteLine($"Item index: {j}, Item Name: {marketplace[j].ItemForTrade.ItemName}");
                        showAcceptDeny = true;
                    }
                }

                if (showAcceptDeny)
                {
                    Console.WriteLine("Wich one of these would you like to handle?");

                    if (int.TryParse(Console.ReadLine(), out int tradeReqIndex))
                    {
                        Console.WriteLine("What would you like to do with this one?");
                        Console.WriteLine("1. Accept");
                        Console.WriteLine("2. Deny");
                        Console.WriteLine("3. Exit");
                        string TradeInput = Console.ReadLine();
                        switch (TradeInput)
                        {
                            case "1": //------------------------accept trade--------------------------------

                                Console.WriteLine($"You Accepted trade for {marketplace[tradeReqIndex].ItemForTrade.ItemName}.");


                                // ta bort items från gamla ägare
                                marketplace[tradeReqIndex].Sender.Items.Remove(marketplace[tradeReqIndex].ItemForTrade);
                                marketplace[tradeReqIndex].Receiver.Items.Remove(marketplace[tradeReqIndex].OfferedItem);

                                // byt ägare
                                marketplace[tradeReqIndex].ItemForTrade.Owner = marketplace[tradeReqIndex].Receiver;
                                marketplace[tradeReqIndex].OfferedItem.Owner = marketplace[tradeReqIndex].Sender;

                                // lägg till i nya ägares listor
                                marketplace[tradeReqIndex].Receiver.Items.Add(marketplace[tradeReqIndex].ItemForTrade);
                                marketplace[tradeReqIndex].Sender.Items.Add(marketplace[tradeReqIndex].OfferedItem);

                                // ändra status till accepterad
                                marketplace[tradeReqIndex].Status = TradingStatus.Accepted;

                                // lägg till i färdiga trades lista
                                completedTrades.Add(marketplace[tradeReqIndex]);

                                Helpers.SaveCompletedTradesToFile(completedTrades);

                                // ta bort anons
                                marketplace.RemoveAt(tradeReqIndex);

                                Helpers.SaveAdsToFile(marketplace);

                                Console.WriteLine("Press ENTER to continue");
                                Console.ReadLine();
                                break;
                            case "2":   //----------------------------------decline trade--------------------------

                                Console.WriteLine($"You denied trade for {marketplace[tradeReqIndex].ItemForTrade.ItemName}.");
                                marketplace[tradeReqIndex].Status = TradingStatus.Denied;
                                Helpers.SaveAdsToFile(marketplace);


                                Console.WriteLine("Press ENTER to continue");
                                Console.ReadLine();
                                break;

                            case "3":
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("please enter a valid number");
                        Console.WriteLine("Press ENTER to continue.");
                        Console.ReadLine();
                    }
                }

                break;
            case "9":               //------------------------------------show completed trades-------------------------------------
                if (completedTrades.Count == 0)
                {
                    Console.WriteLine("You have no completed trades");
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    for (int j = 0; j < completedTrades.Count(); j++)
                    {
                        Console.WriteLine($"{completedTrades[j].Sender.Name} traded {completedTrades[j].ItemForTrade.ItemName} with {completedTrades[j].Receiver.Name} for {completedTrades[j].OfferedItem.ItemName}");
                    }
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadLine();
                }
                break;


        }

    }
}


// /*
// Features
// The following features need to be implemented:------------------------------------------------------------------
// under process----------------------------------------------------------------------------------------------------




// implemented features: --------------------------------------------------------------------------------------------

// A user needs to be able to register an account
// A user needs to be able to log in.
// A user needs to be able to log out.
// A user needs to be able to browse a list of other users items.
// A user needs to be able to upload information about the item they wish to trade.
// A user needs to be able to request a trade for other users items.
// remove item
// remove ad
// A user needs to be able to browse trade requests.
// A user needs to be able to accept a trade request.
// A user needs to be able to deny a trade request.
// A user needs to be able to browse completed requests.

//The program needs to save relevant data to the computers file system whenever a state change is made.

//The program needs to be able to start and then automatically load all relevant data so it can function as if it was never closed.


// */
