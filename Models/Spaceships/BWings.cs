using SpaceInvadersArmory;

namespace Models;

public class BWings : Spaceship
{
    public BWings()
    {
        Name = "BWings";
        Structure = 30;
        CurrentStructure = 30;
        Shield = 0;
        CurrentShield = 0;

        var blueprint = Armory.Blueprints.Find(b => b.Name == "Hammer");
        if (blueprint == null)
            throw new Exception("Blueprint not found");

        var weapon = Armory.CreateWeapon(blueprint);
        Weapons.Add(weapon);
    }

    public override void AddWeapon(Weapon weapon)
    {
        if (weapon.Type == EWeaponType.Explosive)
        {
            weapon.ReloadTime = 0;
        }
        base.AddWeapon(weapon);
    }
}