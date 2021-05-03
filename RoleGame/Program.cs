using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using RoleGame.AbstractClasses;
using RoleGame.Classes;
using RoleGame.Classes.Artifacts;
using RoleGame.Classes.Inventory;
using RoleGame.Classes.Spells;

namespace RoleGame {
  class Program {
    static void Main(string[] args) {
      //spells
      AddHealthSpell addHealthSpell = new AddHealthSpell();
      AntidoteSpell antidoteSpell = new AntidoteSpell();
      ArmorSpell armorSpell = new ArmorSpell();
      BringToLifeSpell bringToLifeSpell = new BringToLifeSpell();
      HealSpell healSpell = new HealSpell();
      WakeUpSpell wakeUpSpell = new WakeUpSpell();
      
      //artifacts
      BasiliskEyeArtifact basiliskEyeArtifact = new BasiliskEyeArtifact();
      
      DeathWaterBottleArtifact deathWaterBottleArtifactSmall = new DeathWaterBottleArtifact(AbstractArtifact.ArtifactVolume.Small);
      DeathWaterBottleArtifact deathWaterBottleArtifactMiddle = new DeathWaterBottleArtifact();
      DeathWaterBottleArtifact deathWaterBottleArtifactLarge = new DeathWaterBottleArtifact(AbstractArtifact.ArtifactVolume.Big);
      
      FrogLegsDecoctArtifact frogLegsDecoctArtifact = new FrogLegsDecoctArtifact();
      LightningStaffArtifact lightningStaffArtifact = new LightningStaffArtifact();
      
      LivingWaterBottleArtifact livingWaterBottleArtifactSmall = new LivingWaterBottleArtifact(AbstractArtifact.ArtifactVolume.Small);
      LivingWaterBottleArtifact livingWaterBottleArtifactMiddle = new LivingWaterBottleArtifact();
      LivingWaterBottleArtifact livingWaterBottleArtifactLarge = new LivingWaterBottleArtifact(AbstractArtifact.ArtifactVolume.Big);
     
      PoisonousSalivaArtifact poisonousSalivaArtifact = new PoisonousSalivaArtifact();

      PlayerWithMagic wizard = new PlayerWithMagic("Alex", PlayerParams.Race.Elf, PlayerParams.Sex.Female, 19);

      /*while (true) {
      }*/
      
    }
  }
}