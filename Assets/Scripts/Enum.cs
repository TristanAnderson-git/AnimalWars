// Collection of Global Enums used in game...
// Placed in one file for ease of editing in the future.

namespace BuildingAspect
{
    // List of Building Types
    public enum BuildingType
    {
        Production,
        Defence,
        Trap,
        Base
    };

    // List of Production Types
    public enum ProductionType
    {
        None,
        Food,
        Material,
        Unit
    };
}

// For building Action keys dynamically with the CreateAction tool
// Leave this enum at the bottom of the code - add any new enums above
namespace GOAP
{
    // List of Action Keys
    public enum ActionKey
    {
        StayAlive,
        KillEnemy,
        DestroyBase,
        DefendBase,
        HarvestResource,
        GatherResource,
    };
}
