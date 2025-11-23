using Extends;

namespace Models
{
    public class Player : IEquatable<Player>, IPlayer
    {
        // Prénom
        private string FirstName { get; }
        // Nom
        private string LastName { get; }
        public string Alias { get; }
        public Spaceship BattleShip { get; set; }

        public Player(string firstName, string lastName, string alias )
        {
            FirstName = firstName.Proper();
            LastName = lastName.Proper();
            Alias = alias;
            BattleShip = new ViperMKII();
        }

        public string Name => $"{FirstName} {LastName}";

        public override string ToString() => $"{Alias} ({Name})";

        public override bool Equals(object? obj) => Equals(obj as Player);

        public bool Equals(Player? other)
        {
            return other != null &&
                   Alias == other.Alias;
        }

        public override int GetHashCode()
        {
            return 2061429903 + EqualityComparer<string>.Default.GetHashCode(Alias);
        }
    }
}
