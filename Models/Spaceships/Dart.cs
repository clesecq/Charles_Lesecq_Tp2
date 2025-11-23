using SpaceInvadersArmory;

namespace Models;

public class Dart : Spaceship
{
    // TODO:  Un Dart ne tient pas compte du temps de chargement d’une arme de type “Direct” et peut utiliser ces armes à chaque tour.
    
    public Dart()
    {
        Name = "Dart";
        MaxStructure = 10;
        MaxShield = 3;

        var blueprint = Armory.Blueprints.Find(b => b.Name == "Laser");
        if (blueprint == null)
            throw new ArmoryException();
        
        var weapon = Armory.CreateWeapon(blueprint);
        Weapons.Add(weapon);
    }
}