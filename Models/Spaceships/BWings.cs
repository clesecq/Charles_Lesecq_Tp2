using SpaceInvadersArmory;

namespace Models;

public class BWings : Spaceship
{
    // TODO: Un B-Wings ne tient pas compte du temps de chargement d’une arme de type “Explosive” et peut utiliser ces armes à chaque tour.
    
    public BWings()
    {
        Name = "BWings";
        MaxStructure = 30;
        MaxShield = 0;

        var blueprint = Armory.Blueprints.Find(b => b.Name == "Hammer");
        if (blueprint == null)
            throw new Exception("Blueprint not found");

        var weapon = Armory.CreateWeapon(blueprint);
        Weapons.Add(weapon);
    }
}