using Titan.Domain.Builders.Interfaces.Items;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Items;
using Titan.Domain.Enums;

namespace Titan.Domain.Builders.Implementations.Items;

public sealed class ItemNameDescriptionLocaleBuilder : IItemNameDescriptionLocaleBuilder
{
    public Identifier Identifier { get; private set;}
    private string? _descriptionLang;
    private Locale _locale;

    public IItemNameDescriptionLocaleBuilder WithIdentifier(Identifier identifier)
    {
        Identifier = identifier;
        return this;
    }

    public IItemNameDescriptionLocaleBuilder WithLocale(Locale locale)
    {
        _locale = locale;
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
            _locale,
            _descriptionLang);
    }
}