using Titan.Domain.Builders.Interfaces.Items;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Items;

namespace Titan.Domain.Builders.Implementations.Items;

public sealed class ItemNameDescriptionLocaleBuilder : IItemNameDescriptionLocaleBuilder
{
    public Identifier Identifier { get; private set;}
    private string? _descriptionLang;

    public IItemNameDescriptionLocaleBuilder WithIdentifier(Identifier identifier)
    {
        Identifier = identifier;
        return this;
    }

    public IItemNameDescriptionLocaleBuilder WithDescriptionLang(string? descriptionLang)
    {
        _descriptionLang = descriptionLang;
        return this;
    }
    public ItemNameDescriptionLocale Build()
    {
        return new ItemNameDescriptionLocale(Identifier,
            _descriptionLang);
    }
}