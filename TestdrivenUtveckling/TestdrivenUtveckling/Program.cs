using System.Reflection.Metadata;

public interface IDatabase
{
    public void AddUser(User user);
    public void RemoveUser(int userId);
    public User GetUser(int userId);
}

// Define the User class
public class User
{
    // Define properties of the User class
    public int UserId { get; set; }
    public string UserName { get; set; }

}

// Implement the UserManager class
public class UserManager : IDatabase
{
    private readonly IDatabase _database;

    // Constructor injection to pass IDatabase dependency
    public UserManager(IDatabase database)
    {
        _database = database ?? throw new ArgumentNullException(nameof(database));
    }

    public void AddUser(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        _database.AddUser(user);        
    }

    public void RemoveUser(int userId)
    {
        _database.RemoveUser(userId);
    }

    public User GetUser(int userId)
    {
        return _database.GetUser(userId);
    }
}