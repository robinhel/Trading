namespace App;

public class Trade
{
    public User Sender { get; set; }
    public User Receiver { get; set; }
    public TradingStatus Status { get; set; }
    public Item ItemForTrade { get; set; }
    public Item OfferedItem { get; set; }


    public Trade(User sender, User? receiver = null, Item? itemForTrade = null)
    {
        Sender = sender;
        Status = TradingStatus.ForSale;

        // Om det inte finns någon receiver sätt den annars null
        if (receiver != null)
        {
            Receiver = receiver;
        }


        // Lägg till item for trade om det finns
        if (itemForTrade != null)
        {
            ItemForTrade = itemForTrade;
        }

    }

    public void UploadItem(Item item)
    {
        if (item != null)
        {
            ItemForTrade = item;
            Console.WriteLine($"Item {item.ItemName} added to trade");
        }
        else
        {
            Console.WriteLine("No item to add to trade");
            return;
        }

    }

    public Item GetItemForTrade()
    {
        return ItemForTrade;
    }

}
