using System.Security.Claims;

namespace Titan.API.Helpers;

public class JwtParser
{
    /// <summary>
    /// Returns the username through the claims of the JWT (Json Web Token)
    /// </summary>
    /// <param name="ctx">Http Context</param>
    /// <returns>Username</returns>
    public static string? GetUsername(HttpContext ctx)
    {
        return ctx.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Name)?.Value;
    }
    
    
    /// <summary>
    /// Returns the game token through the claims of the JWT (Json Web Token)
    /// </summary>
    /// <param name="ctx">Http Context</param>
    /// <returns>TC Game Token</returns>
    public static string? GetGameToken(HttpContext ctx)
    {
        return ctx.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Sid)?.Value;
    }
    
    
}