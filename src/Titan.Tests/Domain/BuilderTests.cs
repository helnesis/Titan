using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;

namespace Titan.Tests;

[TestFixture]
public class BuilderTests
{

    [Test]
    public void TestCreatureTemplateBuilder()
    {
        var builder = CreatureTemplate.Builder;

        Assert.Multiple(() =>
        {
            Assert.That(builder, Is.Not.Null);
            Assert.That(builder, Is.InstanceOf<ICreatureTemplateBuilder>());
        });

        var identifier = Identifier.Create(1234);

        var creature = builder
            .WithKillCredits(10, 20)
            .WithMaleName("Arthas Menethil")
            .WithMaleSubName("King of Lordaeron")
            .WithScale(1.0f)
            .Build();

        Assert.Multiple(() =>
        {
            Assert.That(creature, Is.Not.Null);
            Assert.That(creature.KillCredits.ElementAt(0), Is.EqualTo(10));
            Assert.That(creature.KillCredits.ElementAt(1), Is.EqualTo(20));
            Assert.That(creature.MaleName, Is.EqualTo("Arthas Menethil"));
            Assert.That(creature.MaleSubName, Is.EqualTo("King of Lordaeron"));
            Assert.That(creature.Scale, Is.EqualTo(1.0f));
        });
    }

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