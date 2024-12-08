using Titan.Domain.Entities.Base;

namespace Titan.Tests;

[TestFixture]
public class IdentifierTests
{
    
    [Test]
    public void TestIdentifier()
    {
        var emptyIdentifier = Identifier.Empty;
        Identifier identifierFromInteger = 22234;
        uint integerFromIdentifier = Identifier.Create(10);
        
        Assert.Multiple(() =>
        {
            Assert.That(emptyIdentifier.Value, Is.EqualTo(0));
            Assert.That(identifierFromInteger.Value, Is.EqualTo(22234));
            Assert.That(integerFromIdentifier, Is.EqualTo(10));
        });
    }
}