

namespace RoleGame {
  class Program {
    static void Main(string[] args)
    {
      Game game = Game.GetInstance();
      game.Start();
    }
  }
}