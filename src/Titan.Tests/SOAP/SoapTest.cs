using Titan.SOAP.Base;
using Titan.SOAP.Base.Client;
using Titan.SOAP.Settings;

namespace Titan.Tests.SOAP;

[TestFixture]
public class SoapTest
{
    private readonly SoapSettings _settings = new SoapSettings("soap", "admin123", "localhost", 7878);
    
    [Test]
    public async Task TestSendCommand()
    {
        var client = new TrinitySoap(_settings);
        var result = await client.SendAsync("announce", "test");
        
        if (result.IsSuccess)
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail(result.Error);
        }
    }
}