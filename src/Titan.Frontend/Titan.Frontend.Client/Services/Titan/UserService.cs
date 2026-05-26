namespace Titan.Frontend.Client.Services.Titan;

public sealed class UserService : IUserService
{
    public string? Username { get; private set; }
    public bool IsAuthenticated 
    { 
        get => field = Username is not null; 
        private set; 
    }

    public async Task LoginAsync(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) return;
       
    }

    public async Task LogoutAsync()
    {
        // User is already disconnected.
        if (!IsAuthenticated) return;
    }
}
