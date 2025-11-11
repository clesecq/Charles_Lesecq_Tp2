using System;

namespace SpaceInvadersArmory
{
    public class Weapon : IWeapon
    {
        public Guid Id { get; } = new Guid();
        /// <summary>
        /// Le shéma utilisé pour créer l'arme
        /// </summary>
        public WeaponBlueprint Blueprint { get; }
        public string Name { get; set; }
        public EWeaponType Type { get; set; }
        public double MinDamage { get; set; }
        public double MaxDamage { get; set; }
        public double AverageDamage => (MinDamage + MaxDamage) / 2;

        /// <summary>
        /// Constructeur avec une visibilité internal pour que seule l'armurerie puisse créer des armes.
        /// Par ce moyen on s'assure que toutes les armes proviennent l'armurerie
        /// </summary>
        /// <remarks>Exemple d'utilisation de la visibilité internal</remarks>
        internal Weapon(WeaponBlueprint blueprint) 
        {
            Blueprint = blueprint;
            Name = blueprint.Name;
            Type = blueprint.Type;
            MinDamage = blueprint.MinDamage;
            MaxDamage = blueprint.MaxDamage;
        }
   
        public override String ToString()
        {
            return Name + " : " + Type + " (" + MinDamage + "-" + MaxDamage + ")";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Weapon);
        }

        public bool Equals(Weapon other)
        {
            return other != null &&
                   Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        /// <summary>
        /// Compare les arme en fonction de leur shéma
        /// </summary>
        /// <param name="obj">l'objet à comparer</param>
        /// <returns>le resultat de la comparaison</returns>
        public bool EqualsBlueprint(object obj)
        {
            return Equals(obj as Weapon);
        }
        public bool EqualsBlueprint(Weapon other)
        {
            return other != null &&
                   Blueprint.Equals(other.Blueprint);
        }
    }
}
