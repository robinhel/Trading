namespace App;

public class User
{
    public string Name { get; set; }
    public string Password { get; set; }
    public List<Item> Items { get; set; }


    public User(string name, string password)
    {
        Name = name;
        Password = password;
        Items = new List<Item>();
    }
    public void addItem(Item item)
    {
        Items.Add(item);
    }

    public bool tryLogin(string username, string password)
    {
        return username == Name && password == Password;
    }
}

