namespace App;

public class Item
{
    public string ItemName;
    public string Description;
    public User Owner;

    public Item(string itemname, string description, User owner)
    {
        ItemName = itemname;
        Description = description;
        Owner = owner;
    }
}