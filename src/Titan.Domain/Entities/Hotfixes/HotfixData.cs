using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Hotfixes;

public enum HotfixStatus
{
    NotSet,
    Valid,
    RecordRemoved,
    Invalid,
    NotPublic
}

public sealed record HotfixData(Identifier Identifier, Identifier UniqueIdentifier, uint TableHash, Identifier RecordIdentifier, HotfixStatus Status) : Entity(Identifier);