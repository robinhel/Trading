namespace App;

class User
{
    public string Name;
    string Password;


    public List<Item> Items = new List<Item>();


    public User(string name, string password)
    {
        Name = name;
        Password = password;
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

