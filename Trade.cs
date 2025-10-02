namespace App;

class Trade
{
    public User Sender;
    public User Receiver;
    public TradingStatus Status;
    public List<Item> Itemsfortrade = new List<Item>();


    public Trade(User sender, User receiver, List<Item>? itemsfortrade = null)
    {
        Sender = sender;
        Receiver = receiver;
        Status = TradingStatus.Pending;
        Itemsfortrade = itemsfortrade ?? new List<Item>();
    }

    public void UploadItem(Item item)
    {
        Itemsfortrade.Add(item);
    }

    public List<Item> GetAllItemsForTrade()
    {
        return Itemsfortrade;
    }

}
