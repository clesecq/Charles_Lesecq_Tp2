using SpaceInvadersArmory;

namespace Models;

public class Dart : Spaceship
{
    public Dart()
    {
        Name = "Dart";
        Structure = 10;
        CurrentStructure = 10;
        Shield = 3;
        CurrentShield = 3;

        var blueprint = Armory.Blueprints.Find(b => b.Name == "Laser");
        if (blueprint == null)
            throw new ArmoryException();
        
        var weapon = Armory.CreateWeapon(blueprint);
        Weapons.Add(weapon);
    }
    
    public override void AddWeapon(Weapon weapon)
    {
        if (weapon.Type == EWeaponType.Direct)
        {
            weapon.ReloadTime = 0;
        }
        base.AddWeapon(weapon);
    }
}