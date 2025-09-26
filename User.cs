namespace App;

class User
{
    public string Name;
    string _password;


    public User(string name, string password)
    {
        Name = name;
        _password = password;
    }

    public bool TryLogin(string username, string password)
    {
        return username == Name && password == _password;
    }
}

