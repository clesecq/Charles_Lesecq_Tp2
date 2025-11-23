namespace Models;

public class Tardis : Spaceship, IAbility
{
    private Random _random = new();
    
    public Tardis()
    {
        Name = "Tardis";
        MaxStructure = 1;
        MaxShield = 0;
    }
    
    /// <summary>
    /// L’aptitude spéciale du Tardis est de déplacer un vaisseau au hasard et de le mettre à un autre endroit dans la liste, toujours au hasard.
    /// </summary>
    /// <param name="spaceships">Liste des vaisseaux</param>
    public void UseAbility(List<Spaceship> spaceships)
    {
        Spaceship shipToMove = spaceships[_random.Next(spaceships.Count)];
        spaceships.Remove(shipToMove);
        int newIndex = _random.Next(spaceships.Count + 1);
        spaceships.Insert(newIndex, shipToMove);
    }
}