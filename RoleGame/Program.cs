using System;
using RoleGame.Classes;
using RoleGame.Classes.Spells;

namespace RoleGame {
  class Program {
    static void Main(string[] args) {
      ArmorSpell spell = new ArmorSpell();
      
      PlayerWithMagic playerWithMagic =
        new PlayerWithMagic("Gena", PlayerParams.Race.Elf, PlayerParams.Sex.Female, 19);
      PlayerWithMagic player = new PlayerWithMagic("Lexa", PlayerParams.Race.Orc, PlayerParams.Sex.Male, 25);
      
      Console.WriteLine(playerWithMagic.ToString());
      Console.WriteLine(player.ToString());
      
      player.Health = 160;
      
      Console.WriteLine(player.ToString());

      player.Health = 140;
      
      playerWithMagic.CastSpell(spell.UseSpell, player, 40);

      player.Health = 120;
      
      Console.WriteLine(player.ToString());

      player.Health = 100;
      Console.WriteLine(player.ToString());

      
    }
  }
}