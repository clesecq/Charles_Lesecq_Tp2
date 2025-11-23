using Models;
using SpaceInvadersArmory;

namespace ConsoleGame
{
    public class SpaceInvaders
    {
        #region Patern singleton
        //implémentation thread safe du patern singleton
        private static readonly Lazy<SpaceInvaders> lazy =
        new Lazy<SpaceInvaders>(() => new SpaceInvaders());

        public static SpaceInvaders Instance { get { return lazy.Value; } }

        private SpaceInvaders() { Init(); }
        #endregion Patern singleton

        public List<Player> Players { get; } = new List<Player>();

        private void Init()
        {
            Players.Add(new Player("MaXiMe", "haRlé", "Per6fleur"));
            Players.Add(new Player("Guillaume", "urban", "LaGrandeRoutière"));
            Players.Add(new Player("kintali asish-kumar", "PRusty", "DxC"));
        }
        static void Main(string[] args)
        {
            Armory.ViewArmory();
            foreach (var item in Instance.Players)
            {
                Console.WriteLine(item.ToString());
                item.BattleShip.ViewShip();
            }
            Console.ReadKey();
        }
    }
}
