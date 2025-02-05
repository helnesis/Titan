using System.Net;
using System.Text;
using System.Xml;
using Titan.SOAP.Base.Command;
using Titan.SOAP.Settings;

namespace Titan.SOAP.Base.Client;


public sealed class TrinitySoap(SoapSettings settings) : ISoapClient
{
    private const string GetResultTag = "result";
    private const string GetErrorTag = "faultstring";
    public string Endpoint => $"http://{settings.Host}:{settings.Port}/";

    public AuthCommand AuthCommand => new(this);
    
    public WorldCommand WorldCommand => new WorldCommand(this);
    
    public async Task<SoapResponse> SendAsync(string action, params string[] args)
    {
        if (string.IsNullOrEmpty(action)) return SoapResponse.FailureResponse("Parameter \"$action\" is required.");
        
        using var client = new HttpClient();
        using var request = new HttpRequestMessage(HttpMethod.Post, Endpoint);
        request.Headers.Add("Authorization", $"Basic {BuildAuthToken}");
        request.Content = CreateSoapEnvelope(action, args);
        
        var response = await client.SendAsync(request);

        if (response.StatusCode is < HttpStatusCode.OK or >= HttpStatusCode.Ambiguous) return SoapResponse.SuccessResponse(response.StatusCode.ToString()); ;
        
        var content = await response.Content.ReadAsStringAsync();
        
        XmlDocument document = new();
        document.LoadXml(content);
        
        return new SoapResponse(
            Result: document.GetElementsByTagName(GetResultTag).Item(0)?.InnerText ?? "",
            Error: document.GetElementsByTagName(GetErrorTag).Item(0)?.InnerText ?? ""
            );
    }


    private static StringContent CreateSoapEnvelope(string action, params string[] args)
    {
        return new StringContent(
            $"<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ns1=\"urn:TC\">\r\n<SOAP-ENV:Body>\r\n<ns1:executeCommand>\r\n<command>{action} {string.Join(" ", args)}</command>\r\n</ns1:executeCommand>\r\n</SOAP-ENV:Body>\r\n</SOAP-ENV:Envelope>",
            null,
            "application/xml"
        );
    }
    
    private string BuildAuthToken
        => Convert.ToBase64String(Encoding.UTF8.GetBytes($"{settings.Username}:{settings.Password}"));
}