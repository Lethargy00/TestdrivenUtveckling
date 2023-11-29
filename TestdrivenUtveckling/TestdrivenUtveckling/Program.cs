using System.Reflection.Metadata;

// Interface representing a database with user-related operations.
public interface IDatabase
{
    /// <summary>
    /// Adds a new user to the database.
    /// </summary>
    /// <param name="user">The user to be added.</param>
    public void AddUser(User user);

    /// <summary>
    /// Removes a user from the database based on the user's ID.
    /// </summary>
    /// <param name="userId">The ID of the user to be removed.</param>
    public void RemoveUser(int userId);

    /// <summary>
    /// Retrieves a user from the database based on the user's ID.
    /// </summary>
    /// <param name="userId">The ID of the user to be retrieved.</param>
    /// <returns>The user with the specified ID, or null if not found.</returns>
    public User GetUser(int userId);
}

/// <summary>
/// Represents a user in the system.
/// </summary>
public class User
{
    /// <summary>
    /// Gets or sets the unique identifier of the user.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Gets or sets the name of the user.
    /// </summary>
    public string UserName { get; set; }

}

/// <summary>
/// Implement the UserManager class
/// Manages user-related operations using an underlying database.
/// </summary>
public class UserManager : IDatabase
{
    private readonly IDatabase _database;

    // Constructor injection to pass IDatabase dependency
    /// <summary>
    /// Initializes a new instance of the UserManager class.
    /// </summary>
    /// <param name="database">The database used for user-related operations.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public UserManager(IDatabase database)
    {
        // If the database is null, throw and ArgumentNullException.
        _database = database ?? throw new ArgumentNullException(nameof(database));
    }

    public void AddUser(User user)
    {
        // If the user is null, throw an ArgumentNullException.
        ArgumentNullException.ThrowIfNull(user);

        // Add the user to the database.
        _database.AddUser(user);        
    }

    public void RemoveUser(int userId)
    {
        // Remove the user from the database.
        _database.RemoveUser(userId);
    }

    public User GetUser(int userId)
    {

        // Gets user Id or sends an exception message if it's null.
        var user = _database.GetUser(userId) ?? throw new ArgumentException($"User with ID {userId} does not exist.");

        // Retrieve the user from the database.
        return user;
    }
}