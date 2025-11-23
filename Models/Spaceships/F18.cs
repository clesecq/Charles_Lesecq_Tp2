namespace Models;

public class F18: Spaceship, IAbility
{
    public F18()
    {
        Name = "F18";
        Structure = 15;
        CurrentStructure = 15;
        Shield = 0;
        CurrentShield = 0;
    }

    /// <summary>
    /// Un F-18 ne possède pas d’armes, mais s’il est au contact avec le vaisseau joueur, il explose et lui fait 10 points de dégâts.
    /// </summary>
    /// <param name="spaceships">Liste des vaisseaux</param>
    public void UseAbility(List<Spaceship> spaceships)
    {
        var index = spaceships.IndexOf(this);
        
        if (index == -1)
            return;

        if (index > 0 && CurrentStructure > 0)
        {
            var shipBefore = spaceships[index - 1];
            if (shipBefore.BelongsPlayer)
            {
                shipBefore.CurrentStructure -= 10;
                CurrentStructure = 0;
            }
        }
        
        if (index < spaceships.Count - 1 && CurrentStructure > 0)
        {
            var shipAfter = spaceships[index + 1];
            if (shipAfter.BelongsPlayer)
            {
                shipAfter.CurrentStructure -= 10;
                this.CurrentStructure = 0;
            }
        }
    }
}