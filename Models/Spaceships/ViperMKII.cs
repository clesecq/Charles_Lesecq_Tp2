using SpaceInvadersArmory;

namespace Models;

public class ViperMKII : Spaceship
{
    // TODO: Un ViperMKII utilise une seule des armes rechargée (avec un compteur de rechargement à zéro) par tour (si plusieurs armes disponible au même tour une seule peut servir). A vous de voir comment faire pour ne pas toujours utiliser la mitrailleuse !
    
    public ViperMKII()
    {
        Name = "BWings";
        MaxStructure = 30;
        MaxShield = 0;

        string[] weaponNames = ["Mitrailleuse", "EMG", "Missile"];
        foreach (string weaponName in weaponNames)
        {
            var blueprint = Armory.Blueprints.Find(b => b.Name == weaponName);
            if (blueprint == null)
                throw new Exception("Blueprint not found");

            var weapon = Armory.CreateWeapon(blueprint);
            Weapons.Add(weapon);
        }
    }
}