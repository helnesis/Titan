namespace Titan.Shared;

public static class Utilities
{
    private static bool IsDebug()
    {
#if DEBUG
        return true;
#else
        return false;
#endif
    }

    /// <summary>
    /// Returns whether the application is running in debug mode.
    /// </summary>
    public static readonly bool IsDebugMode = IsDebug();
}
