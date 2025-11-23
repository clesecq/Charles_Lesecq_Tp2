using SpaceInvadersArmory;

namespace Models;

public class Rocinante : Spaceship
{
    // TODO: Le Rocinante est plus rapide et esquive beaucoup mieux les tirs. Il a deux fois moins de chance de se faire toucher qu’un vaisseau normal. 
    
    public Rocinante()
    {
        Name = "Rocinante";
        MaxStructure = 3;
        MaxShield = 5;

        var blueprint = Armory.Blueprints.Find(b => b.Name == "Torpille");
        if (blueprint == null)
            throw new ArmoryException();
        
        var weapon = Armory.CreateWeapon(blueprint);
        Weapons.Add(weapon);
    }
}