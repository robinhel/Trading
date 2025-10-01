namespace App;

class Trade
{
    public User Sender;
    public User Receiver;
    public TradingStatus Status;
    public List<Item> Itemsforsale = new List<Item>();



    public void UploadItem(Item item)
    {
        Itemsforsale.Add(item);
    }
    public void ShowItems()
    {
        int x = 0;
        foreach (Item i in Itemsforsale)
        {
            Console.WriteLine($"item for sale is {i.ItemName} index is {x}, Owner is {i.Owner.Name}");
            x++;
        }

    }

}
