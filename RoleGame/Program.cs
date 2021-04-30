using System;
using RoleGame.AbstractClasses;
using RoleGame.Classes;
using RoleGame.Classes.Artifacts;
using RoleGame.Classes.Spells;

namespace RoleGame {
  class Program {
    static void Main(string[] args) {
      // BringToLifeSpell spell = new BringToLifeSpell();
      //
      // PlayerWithMagic playerWithMagic =
      //   new PlayerWithMagic("Gena", PlayerParams.Race.Elf, PlayerParams.Sex.Female, 19);
      // PlayerWithMagic player = new PlayerWithMagic("Lexa", PlayerParams.Race.Orc, PlayerParams.Sex.Male, 25);
      //
      // Console.WriteLine(playerWithMagic.ToString());
      // Console.WriteLine(player.ToString());
      //
      // player.Health = 160;
      //
      // Console.WriteLine(player.ToString());
      //
      // player.Health = 0;
      //
      // playerWithMagic.CastSpell(spell.UseSpell, player, 150);
      //
      //
      // Console.WriteLine(playerWithMagic.ToString());
      // Console.WriteLine(player.ToString());


      // Player player = new Player("Galya", PlayerParams.Race.Orc, PlayerParams.Sex.Male, 25);
      // player.Health = 30; 
      // LivingWaterBottleArtifact artifact1 = new LivingWaterBottleArtifact(AbstractArtifact.ArtifactVolume.Middle);
      // player.CastArtifact(artifact1.UseArtifact, player);
      // Console.WriteLine(player.ToString());

      // PlayerWithMagic player2 =
      //   new PlayerWithMagic("Gena", PlayerParams.Race.Elf, PlayerParams.Sex.Female, 19);
      // playerWithMagic.Health = 10;
      // LivingWaterBottleArtifact artifact2 = new LivingWaterBottleArtifact(AbstractArtifact.ArtifactVolume.Middle);
      // playerWithMagic.CastArtifact(artifact2.UseArtifact, playerWithMagic);
      // Console.WriteLine(playerWithMagic.ToString());

      // Player p = new Player("Galya", PlayerParams.Race.Orc, PlayerParams.Sex.Male, 25);
      // DeathWaterBottleArtifact artifact3 = new DeathWaterBottleArtifact(AbstractArtifact.ArtifactVolume.Middle);
      // p.ManaValue = 42;
      // p.CastArtifact(artifact3.UseArtifact); 
      // Console.WriteLine(p);

      // Player player1 = new Player("Galya", PlayerParams.Race.Orc, PlayerParams.Sex.Male, 25);
      // LightningStaffArtifact artifact4 = new LightningStaffArtifact(40);
      // player1.Health = 19;
      // player1.CastArtifact(artifact4.UseMagic);
      // Console.WriteLine(player1.ToString());
    }
  }
}