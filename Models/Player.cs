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
            BattleShip = Spaceship.DefaultSpaceship();
        }

        public string Name { get { return FirstName + " " + LastName; } }

        public override string ToString()
        {
            return Alias + " (" + Name + ")";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Player);
        }

        public bool Equals(Player other)
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
