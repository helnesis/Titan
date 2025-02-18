using Titan.Domain.Builders.Base;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Items;
using Titan.Domain.Enums;

namespace Titan.Domain.Builders.Interfaces.Items;

public interface IItemNameDescriptionLocaleBuilder : IBuilder<ItemNameDescriptionLocale>
{
    IItemNameDescriptionLocaleBuilder WithIdentifier(Identifier identifier);
    IItemNameDescriptionLocaleBuilder WithLocale(string locale);
    IItemNameDescriptionLocaleBuilder WithDescriptionLang(string? descriptionLang);
}