using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using Titan.Shared.Helpers;

namespace Titan.Tests;

[TestFixture]
public class SStrHashTest
{
    private uint _achievementHash = 0xD2EE2CA7;
    private uint _spellHash = 0xE111669E;
    
    [Test]
    public void TestHashTable()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_achievementHash, Is.EqualTo(SStrHash.Hash("Achievement")));
            Assert.That(_spellHash, Is.EqualTo(SStrHash.Hash("Spell")));
        });
    }
}