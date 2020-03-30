// Collection of Global Enums used in game...
// Placed in one file for ease of editing in the future.

public enum ResourceType
{
    Food,
    Water,
    Wood,
    Stone,
    All
};

public enum OrderControls
{
    Unknown = 0,
    Attack = 1,
    Gather = 2,
    Follow = 3
}

// For building Action keys dynamically with the CreateAction tool
// Leave this enum at the bottom of the code - add any new enums above
namespace GOAP
{
    // List of Action Keys
    public enum ActionKey
    {
        None = 0,
        StayAlive,
        KillEnemy,
        DestroyBase,
        DefendBase,
        HarvestResource,
        GatherResource,
		AttackTarget,
		FollowPlayer,
    };
}
