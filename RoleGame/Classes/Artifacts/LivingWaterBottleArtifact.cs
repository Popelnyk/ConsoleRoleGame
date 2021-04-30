using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using RoleGame.AbstractClasses;
using RoleGame.Classes;

namespace RoleGame.Classes.Artifacts {
  public class LivingWaterBottleArtifact : AbstractArtifact {
    public LivingWaterBottleArtifact(ArtifactVolume artifactVolume = ArtifactVolume.Middle, int artifactPower = 0,
      bool reusability = false)
      : base(artifactPower, reusability) {
      _artifactVolume = artifactVolume;
    }

    public int SetVolume() {
      switch (_artifactVolume) {
        case ArtifactVolume.Small:
          return 10;
        case ArtifactVolume.Middle:
          return 25;
        case ArtifactVolume.Big:
          return 50;
      }

      return 0;
    }

    public override void UseMagic(Player playerSender, Player playerReciever, int power = 0) {
      int healthToRestore;
      if (_artifactVolume != ArtifactVolume.None)
        healthToRestore = SetVolume();
      else return;

      if (playerReciever.MaxHealth - playerReciever.Health >= healthToRestore) {
        playerReciever.Health += healthToRestore;
      } else {
        playerReciever.Health = playerReciever.MaxHealth;
      }
      //TODO: add method to delete artifact from inventory;
    }

    public override void UseMagic(Player playerSender, PlayerWithMagic playerReciever, int power = 0) {
      UseMagic(playerSender, playerReciever as Player, power);
    }

    private readonly ArtifactVolume _artifactVolume;
  }
}