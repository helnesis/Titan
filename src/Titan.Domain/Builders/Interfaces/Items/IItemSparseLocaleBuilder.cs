using Titan.Domain.Builders.Base;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Items;

namespace Titan.Domain.Builders.Interfaces.Items;

public interface IItemSparseLocaleBuilder : IBuilder<ItemSparseLocale>
{
    IItemSparseLocaleBuilder WithIdentifier(Identifier identifier);

    IItemSparseLocaleBuilder WithDescriptionLang(string? descriptionLang);

    IItemSparseLocaleBuilder WithDisplay3Lang(string? display3Lang);

    IItemSparseLocaleBuilder WithDisplay2Lang(string? display2Lang);

    IItemSparseLocaleBuilder WithDisplay1Lang(string? display1Lang);

    IItemSparseLocaleBuilder WithDisplayLang(string? displayLang);
}