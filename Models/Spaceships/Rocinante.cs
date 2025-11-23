using SpaceInvadersArmory;

namespace Models;

public class Rocinante : Spaceship
{
    private Random _random = new();
    
    public Rocinante()
    {
        Name = "Rocinante";
        Structure = 3;
        CurrentStructure = 3;
        Shield = 5;
        CurrentShield = 5;

        var blueprint = Armory.Blueprints.Find(b => b.Name == "Torpille");
        if (blueprint == null)
            throw new ArmoryException();
        
        var weapon = Armory.CreateWeapon(blueprint);
        Weapons.Add(weapon);
    }

    public override void TakeDamages(double damages)
    {
        if (_random.Next(2) == 0)
            base.TakeDamages(damages);
    }
}