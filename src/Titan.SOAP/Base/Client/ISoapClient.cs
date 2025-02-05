namespace Titan.SOAP.Base.Client;

public sealed record SoapResponse(string Result, string Error)
{
    public static SoapResponse SuccessResponse(string result) => new(result, string.Empty);
    public static SoapResponse FailureResponse(string error) => new(string.Empty, error);
    
    public bool IsSuccess => string.IsNullOrEmpty(Error);
    
    public bool Failure => !IsSuccess;

    public string FailureMessage => Error;
    
    public string SuccessMessage => Result;
}
public interface ISoapClient
{
    
    /// <summary>
    /// Get the SOAP server endpoint.
    /// </summary>
    string Endpoint { get; }
    
    /// <summary>
    /// Send a SOAP request to the server.
    /// </summary>
    /// <param name="action">Action (e.g : command name).</param>
    /// <param name="args">Action params (e.g : kick args)</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the response from the server.
    /// </returns>
    Task<SoapResponse> SendAsync(string action, params string[] args);
}