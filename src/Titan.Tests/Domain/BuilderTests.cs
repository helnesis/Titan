using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;

namespace Titan.Tests;

[TestFixture]
public class BuilderTests
{
    [Test]
    public void TestCreatureTemplateSparringBuilder()
    {
        var builder = CreatureTemplateSparring.Builder;
        
        Assert.Multiple(() =>
        {
            Assert.That(builder, Is.Not.Null);
            Assert.That(builder, Is.InstanceOf<ICreatureTemplateSparringBuilder>());
        });

        var identifier = Identifier.Create(24434);
        var npcHealth = 125.0f;

        var creatureSparring = builder
            .WithCreatureEntry(identifier)
            .WithNoNpcDamageBelowHealthPct(npcHealth)
            .Build();
        
        Assert.Multiple(() =>
        {
            Assert.That(creatureSparring, Is.Not.Null);
            Assert.That(creatureSparring.CreatureEntry, Is.EqualTo(identifier));
            Assert.That(creatureSparring.NoNpcDamageBelowHealthPct, Is.EqualTo(npcHealth));
        });

    }
    

    [Test]
    public void TestCreatureTemplateSpellBuilder()
    {
        var builder = CreatureTemplateSpell.Builder;
        
        Assert.Multiple(() =>
        {
            Assert.That(builder, Is.Not.Null);
            Assert.That(builder, Is.InstanceOf<ICreatureTemplateSpellBuilder>());
        });

        var identifier = Identifier.Create(22234);
        var spellIdentifier = Identifier.Create(20000);
        var index = 1;
        
        var creatureSpell = builder
            .WithCreatureEntry(identifier)
            .WithSpellEntry(spellIdentifier)
            .WithIndex(1)
            .Build();
        
        Assert.Multiple(() =>
        {
            Assert.That(creatureSpell, Is.Not.Null);
            Assert.That(creatureSpell.Index, Is.EqualTo(index));
            Assert.That(creatureSpell.CreatureEntry, Is.EqualTo(identifier));
            Assert.That(creatureSpell.SpellEntry, Is.EqualTo(spellIdentifier));
        });
    }
}