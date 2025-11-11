using System.ComponentModel;

namespace SpaceInvadersArmory
{
    public enum EWeaponType
    {
        [Description("Direct weapon")]
        Direct,
        [Description("Explosive weapon")]
        Explosive,
        [Description("Guided weapon")]
        Guided
    }
}
