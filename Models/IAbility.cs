namespace Models;

public interface IAbility
{
    // TODO: Au début de chaque tour de jeu, avant que le premier vaisseau ne tire, chaque vaisseau qui a une aptitude spéciale l’utilise.
    void UseAbility(List<Spaceship> spaceships);
}