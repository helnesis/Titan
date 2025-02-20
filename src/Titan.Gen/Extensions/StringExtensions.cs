namespace Titan.Gen.Extensions;

public static class StringExtensions
{
    private static readonly string[] NewLines = ["\r\n", "\r", "\n"];

    /// <summary>
    /// Splits the specified <paramref name="value"/> based on line ending.
    /// </summary>
    /// <param name="value">The input string to split.</param>
    /// <returns>An array of each line in the string.</returns>
    public static string[] GetLines(this string value) => string.IsNullOrWhiteSpace(value) ? [] : value.Split(NewLines, StringSplitOptions.None);
}