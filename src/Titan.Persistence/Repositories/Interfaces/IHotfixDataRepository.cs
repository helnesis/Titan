using Titan.Domain.Entities;
using Titan.Domain.Entities.Hotfixes;
using Titan.Persistence.Repositories.Base;

namespace Titan.Persistence.Repositories.Interfaces;

public interface IHotfixDataRepository : ISharedRepository<HotfixData>
{
    public Task<HotfixData?> GetHotfixDataByRecordIdentifierAsync(Identifier recordIdentifier);
}