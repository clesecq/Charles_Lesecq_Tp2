using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace SpaceInvadersArmory
{
    public class Armory
    {
        #region Pattern singleton
        //implémentation thread safe du pattern singleton
        private static readonly Lazy<Armory> lazy = new(() => new Armory());

        public static Armory Instance => lazy.Value;

        private Armory() { Init(); }
        #endregion Pattern singleton

        private List<WeaponBlueprint> _blueprints = [];
        
        // Empêche une autre entité de modifier la liste de schémas en renvoyant une liste de clone et non les schémas réellement présents dans l'armurerie
        public static List<WeaponBlueprint> Blueprints { get { return Instance._blueprints.Select(a => (WeaponBlueprint)a.Clone()).ToList(); } } 
        
        private void Init()
        {
            _blueprints.Add(new WeaponBlueprint { Name = "Laser", Type = EWeaponType.Direct, MinDamage = 2, MaxDamage = 3, ReloadTime = 2 });
            _blueprints.Add(new WeaponBlueprint { Name = "Hammer", Type = EWeaponType.Explosive, MinDamage = 1, MaxDamage = 8, ReloadTime = 1.5 });
            _blueprints.Add(new WeaponBlueprint { Name = "Torpille", Type = EWeaponType.Guided, MinDamage = 3, MaxDamage = 3, ReloadTime = 2 });
            _blueprints.Add(new WeaponBlueprint { Name = "Mitrailleuse", Type = EWeaponType.Direct, MinDamage = 6, MaxDamage = 8, ReloadTime = 1 });
            _blueprints.Add(new WeaponBlueprint { Name = "EMG", Type = EWeaponType.Explosive, MinDamage = 1, MaxDamage = 7, ReloadTime = 1.5 });
            _blueprints.Add(new WeaponBlueprint { Name = "Missile", Type = EWeaponType.Guided, MinDamage = 4, MaxDamage = 100, ReloadTime = 4 });
        }

        public static void ViewArmory()
        {
            Console.WriteLine("=====            Armurerie            =====");
            Console.WriteLine("===== Liste des shémas de constrution =====");
            foreach (var item in Instance._blueprints)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Seule méthode permettant de créer un schéma d’arme
        /// </summary>
        /// <param name="name">Le nom du shéma</param>
        /// <param name="type">Le type d'arme</param>
        /// <param name="minDamage">Les dommages minimum par défaut de l'arme</param>
        /// <param name="maxDamage">Les dommages maximum par défaut de l'arme</param>
        /// <returns>Le schéma d'arme créé et ajouté à l'armurerie</returns>
        public static WeaponBlueprint CreateBlueprint(string name, EWeaponType type, double minDamage, double maxDamage, double reloadTime)
        {
            WeaponBlueprint blueprint = new WeaponBlueprint { Name = name, Type = type, MinDamage = minDamage, MaxDamage = maxDamage, ReloadTime = reloadTime };
            Instance._blueprints.Add(blueprint);
            return blueprint;
        }

        /// <summary>
        /// La seule méthode pour créer une arme
        /// </summary>
        /// <param name="blueprint">Le shéma provenant de l'armurie et qui défini les caractéristiques de base de l'arme</param>
        /// <returns>Une arme utilisable sur un vaisseau</returns>
        public static Weapon CreateWeapon(WeaponBlueprint blueprint)
        {
            Weapon weapon = new Weapon(blueprint);
            if (!IsWeaponFromArmory(weapon)) { throw new ArmoryException(); }
            return weapon;
        }

        public static bool IsWeaponFromArmory(Weapon weapon)
        {
            return Instance._blueprints.Contains(weapon.Blueprint);
        }
    }
}
