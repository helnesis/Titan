using Titan.Domain.Builders.Base;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Items;

namespace Titan.Domain.Builders.Interfaces.Items;

public interface IItemNameDescriptionLocaleBuilder : IBuilder<ItemNameDescriptionLocale>
{
    IItemNameDescriptionLocaleBuilder WithIdentifier(Identifier identifier);

    IItemNameDescriptionLocaleBuilder WithDescriptionLang(string? descriptionLang);
}