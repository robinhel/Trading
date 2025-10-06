namespace App;

public class Trade
{
    public User Sender;
    public User Receiver;
    public TradingStatus Status;
    public Item ItemForTrade;
    public Item OfferedItem;


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
