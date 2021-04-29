using System;
using System.Diagnostics;
using RoleGame.AbstractClasses;

namespace RoleGame.Classes.Artifacts {
  public class DeathWaterBottleArtifact : AbstractArtifact {
    public DeathWaterBottleArtifact(ArtifactVolume artifactVolume = ArtifactVolume.Middle, int powerOfArtifact = 0,
      bool reusabilityOfArtifact = false)
      : base(powerOfArtifact, reusabilityOfArtifact) {
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
      //message
    }

    public override void UseMagic(Player playerSender, PlayerWithMagic playerReciever, int power = 0) {
      //some messages about power
      int manToRestore;
      if (_artifactVolume != ArtifactVolume.None)
        manToRestore = SetVolume();
      else return;
      if (playerReciever.MaxMana - playerReciever.ManaValue >= manToRestore) {
        playerReciever.ManaValue += manToRestore;
      } else {
        playerReciever.ManaValue = playerReciever.MaxMana;
      }
    }

    private readonly ArtifactVolume _artifactVolume;
  }
}