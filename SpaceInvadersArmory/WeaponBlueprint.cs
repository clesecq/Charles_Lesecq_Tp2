using System;

namespace SpaceInvadersArmory
{
    public class WeaponBlueprint: ICloneable, IEquatable<WeaponBlueprint>
    {
        public Guid Id { get; private set; } = new Guid();
        public string Name { get; set; }
        public double MinDamage { get; set; }
        public double MaxDamage { get; set; }
        public double ReloadTime { get; set; }

        public EWeaponType Type { get; set; }

        /// <summary>
        /// Constructeur avec une visibilité internal pour que seule l'armurerie puisse créer de nouveaux shémas.
        /// Par ce moyen on s'assure que tout les shéma créé sont contenu dans l'armurerie
        /// </summary>
        /// <remarks>Exemple d'utilisation de la visibilité internal</remarks>
        internal WeaponBlueprint() { }

        public override bool Equals(object obj)
        {
            return Equals(obj as WeaponBlueprint);
        }

        public bool Equals(WeaponBlueprint other)
        {
            return other != null &&
                   Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        /// <summary>
        /// Methode servant à créer un clone du shéma pour éviter une modification du chéma contenu dans l'armurerie
        /// </summary>
        /// <returns>Un shéma cloné</returns>
        public object Clone()
        {
            return new WeaponBlueprint { Id = Id, Name = Name, Type = Type, MinDamage = MinDamage, MaxDamage = MaxDamage, ReloadTime = ReloadTime};
        }
        public override String ToString()
        {
            return Name + " : " + Type + " (" + MinDamage + "-" + MaxDamage + ")";
        }
    }
}
