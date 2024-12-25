using Titan.Domain.Enums;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplateFlags
{
    public CreatureExtraFlags ExtraFlags { get; init; }
    
    public CreatureFlags CreatureFlags { get; init; }
    
    public CreatureUnitFlags UnitFlags { get; init; }
    
    public CreatureUnitFlags2 UnitFlags2 { get; init; }
    
    public CreatureUnitFlags3 UnitFlags3 { get; init; }


    internal CreatureTemplateFlags(CreatureExtraFlags extraFlags, CreatureFlags flags, CreatureUnitFlags unitFlags,
        CreatureUnitFlags2 unitFlags2, CreatureUnitFlags3 unitFlags3)
        => (ExtraFlags, CreatureFlags, UnitFlags, UnitFlags2, UnitFlags3) =
            (extraFlags, flags, unitFlags, unitFlags2, unitFlags3);
}
