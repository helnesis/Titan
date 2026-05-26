namespace Titan.Frontend.Client.Services.Titan;
public interface IUserService
{
    /// <summary>
    /// Gets the username of the currently logged-in user, or null if no user is logged in.
    /// </summary>
    string? Username { get; }

    /// <summary>
    /// Returns true if a user is currently authenticated (logged in), or false if no user is authenticated.
    /// </summary>
    bool IsAuthenticated { get; }

    /// <summary>
    /// Authenticate the user with the provided username and password. If authentication is successful, the user's information will be stored in the service, and IsAuthenticated will return true. If authentication fails, an exception may be thrown or IsAuthenticated will remain false.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    /// <param name="password">The password of the user.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task LoginAsync(string username, string password);

    /// <summary>
    /// Asynchronously logs the current user out of the application.
    /// </summary>
    /// <returns>A task that represents the asynchronous logout operation.</returns>
    Task LogoutAsync();
}
