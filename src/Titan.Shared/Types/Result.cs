namespace Titan.Shared.Types;

public readonly ref struct Result<T> where T : class 
{
    /// <summary>
    /// Gets the value contained in the current instance.
    /// </summary>
    public readonly T Value { get; init; }

    /// <summary>
    /// Gets the error message if the operation failed, or null if the operation succeeded.
    /// </summary>
    public readonly string? Error { get; init; }

    /// <summary>
    /// Gets a value indicating whether the operation completed successfully.
    /// </summary>
    public readonly bool IsSuccess { get; init; }

    private Result(bool isSuccess, T value, string? error) =>
        (IsSuccess, Value, Error) = (isSuccess, value, error);

    /// <summary>
    /// Creates a successful result containing the specified value.
    /// </summary>
    /// <param name="value">The value to be encapsulated in the successful result. Can be null if the result type allows null values.</param>
    /// <returns>A result object representing a successful operation with the provided value.</returns>
    public static Result<T> Ok(T value) => new(true, value, null);

    /// <summary>
    /// Creates a failed result with the specified error message.
    /// </summary>
    /// <param name="error">The error message that describes the reason for the failure. Cannot be null or empty.</param>
    /// <returns>A result object representing a failure, containing the specified error message.</returns>
    public static Result<T> Failure(string error) => new(false, null!, error);
}
