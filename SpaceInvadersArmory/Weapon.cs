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
        public double ReloadTime { get; set; }
        public double TimeBeforeReload { get; set; }
        
        public bool IsReload => TimeBeforeReload > 0;
        
        /// <summary>
        /// Constructeur avec une visibilité internal pour que seule l'armurerie puisse créer des armes.
        /// Par ce moyen, on s'assure que toutes les armes proviennent l'armurerie
        /// </summary>
        /// <remarks>Exemple d'utilisation de la visibilité internal</remarks>
        internal Weapon(WeaponBlueprint blueprint) 
        {
            Blueprint = blueprint;
            Name = blueprint.Name;
            Type = blueprint.Type;
            MinDamage = blueprint.MinDamage;
            MaxDamage = blueprint.MaxDamage;
            ReloadTime = blueprint.ReloadTime;
            TimeBeforeReload = blueprint.ReloadTime;
        }
   
        public override String ToString() => $"{Name} : {Type} ({MinDamage}-{MaxDamage})";

        public override bool Equals(object? obj)
        {
            return Equals(obj as Weapon);
        }

        public bool Equals(Weapon? other)
        {
            return other != null &&
                   Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        /// <summary>
        /// Compare les armes en fonction de leur shéma
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
        
        public double Shoot()
        {
            // gérer les tours
            if (IsReload)
            {
                return 0;
            }
            TimeBeforeReload = ReloadTime;
            
            // Une arme de type guidée touche toujours, mais avec les dégâts minimums
            if (Type == EWeaponType.Guided)
                return MinDamage;
            
            // Aléatoire
            var rand = new Random();
            
            // Si l’arme est de type direct alors ,elle a 1 chance sur 10 de rater sa cible (0 dégât)
            if (Type == EWeaponType.Direct && rand.Next(10) == 0)
                return 0;
            
            var damage = rand.NextDouble() * (MaxDamage - MinDamage) + MinDamage;

            // Une arme de type explosif multiplie le résultat et le temps de rechargement par 2, et a 1 chance sur 4 de rater ;
            if (Type == EWeaponType.Explosive)
                return rand.Next(4) != 0 ? damage * 2 : 0;
            
            return damage;
        }
    }
}
