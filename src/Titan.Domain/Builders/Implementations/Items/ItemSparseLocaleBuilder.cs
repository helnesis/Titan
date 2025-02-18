using Titan.Domain.Builders.Interfaces.Items;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Items;
using Titan.Domain.Enums;

namespace Titan.Domain.Builders.Implementations.Items;

public sealed class ItemSparseLocaleBuilder : IItemSparseLocaleBuilder
{
    public Identifier Identifier { get; private set;}
    private string? _locale;
    private string? _descriptionLang;
    private string? _display3Lang;
    private string? _display2Lang;
    private string? _display1Lang;
    private string? _displayLang;

    public IItemSparseLocaleBuilder WithLocale(string locale)
    {
        _locale = locale;
        return this;
    }
    
    public IItemSparseLocaleBuilder WithIdentifier(Identifier identifier)
    {
        Identifier = identifier;
        return this;
    }

    public IItemSparseLocaleBuilder WithDescriptionLang(string? descriptionLang)
    {
        _descriptionLang = descriptionLang;
        return this;
    }

    public IItemSparseLocaleBuilder WithDisplay3Lang(string? display3Lang)
    {
        _display3Lang = display3Lang;
        return this;
    }

    public IItemSparseLocaleBuilder WithDisplay2Lang(string? display2Lang)
    {
        _display2Lang = display2Lang;
        return this;
    }

    public IItemSparseLocaleBuilder WithDisplay1Lang(string? display1Lang)
    {
        _display1Lang = display1Lang;
        return this;
    }

    public IItemSparseLocaleBuilder WithDisplayLang(string? displayLang)
    {
        _displayLang = displayLang;
        return this;
    }
    public ItemSparseLocale Build()
    {
        return new ItemSparseLocale(Identifier,
            _locale,
            _descriptionLang,
            _display3Lang,
            _display2Lang,
            _display1Lang,
            _displayLang);
    }
}