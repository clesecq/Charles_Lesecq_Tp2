using Extends;

namespace Models
{
    public class Player(string firstName, string lastName, string alias) : IEquatable<Player>, IPlayer
    {
        // Prénom
        private string FirstName { get; } = firstName.Proper();

        // Nom
        private string LastName { get; } = lastName.Proper();
        public string Alias { get; } = alias;
        public Spaceship BattleShip { get; set; } = new ViperMKII();

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
