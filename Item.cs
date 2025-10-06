namespace App;

public class Item
{
    public string ItemName { get; set; }
    public string Description { get; set; }
    public User Owner { get; set; }

    public Item(string itemname, string description, User owner)
    {
        ItemName = itemname;
        Description = description;
        Owner = owner;
    }
}