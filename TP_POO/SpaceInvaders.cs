using Models;
using SpaceInvadersArmory;

namespace ConsoleGame
{
    public class SpaceInvaders
    {
        #region Pattern singleton
        // implémentation thread safe du pattern singleton
        private static readonly Lazy<SpaceInvaders> lazy = new(() => new SpaceInvaders());

        public static SpaceInvaders Instance => lazy.Value;

        private SpaceInvaders() { Init(); }
        #endregion Pattern singleton

        Player _player = new Player("Han", "Solo", "FalconPilot");
        public List<Spaceship> Enemies { get; } = [];
        Random _random = new();
        
        private void Init()
        {
            Enemies.AddRange([
                new Dart(),
                // new BWings(),
                new Rocinante(),
                // new ViperMKII(),
                // new F18(),
                new Tardis()
            ]);
        }

        private void PlayRound()
        {
            if (_player.BattleShip.CurrentShield < _player.BattleShip.Shield)
                _player.BattleShip.RepairShield(_random.Next(3));
            

            foreach (var enemy in Enemies.Where(x => !x.IsDestroyed))
            {
                if (enemy.CurrentShield < enemy.Shield)
                    enemy.RepairShield(_random.Next(3));
                
                enemy.ShootTarget(_player.BattleShip);
            }

            var enemiesLiving = Enemies.Where(x => !x.IsDestroyed).ToList();
            var enemyToShoot = enemiesLiving[_random.Next(enemiesLiving.Count)];
            _player.BattleShip.ShootTarget(enemyToShoot);
        }

        static void Main(string[] args)
        {
            while (Instance.Enemies.Any(x => !x.IsDestroyed) && !Instance._player.BattleShip.IsDestroyed)
            {
                Instance.PlayRound();
                Console.WriteLine(Instance._player.ToString());
                Instance._player.BattleShip.ViewShip();
                Console.WriteLine($"Enemies remaining: {Instance.Enemies.Count(x => !x.IsDestroyed)}");
                Console.ReadKey();
            }
            
            if (Instance._player.BattleShip.IsDestroyed)
            {
                Console.WriteLine("You lost !");
            }
            else
            {
                Console.WriteLine("You won !");
            }
            Console.ReadKey();
        }
    }
}
