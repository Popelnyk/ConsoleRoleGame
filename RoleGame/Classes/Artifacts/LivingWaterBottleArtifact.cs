using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using RoleGame.AbstractClasses;
using RoleGame.Classes;

namespace RoleGame.Classes.Artifacts
{

  public class LivingWaterBottleArtifact : AbstractArtifact
  {
    public LivingWaterBottleArtifact(ArtifactVolume artifactVolume = ArtifactVolume.Middle, int powerOfArtifact = 0,
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
    
    public override void UseArtifact(Player playerSender, Player playerReciever = null, int power = 0) {
      int healthToRestore;
      if (_artifactVolume != ArtifactVolume.None)
        healthToRestore = SetVolume();
      else return;
      
      if (playerReciever.MaxHealth - playerReciever.Health >= healthToRestore) {
        playerReciever.Health += healthToRestore;
      }
      else {
        playerReciever.Health = playerReciever.MaxHealth;
      }
      //TODO: add method to delete artifact from inventory;
    }

    public override void UseArtifact(Player playerSender, PlayerWithMagic playerReciever = null, int power = 0) {
      UseArtifact(playerSender, playerReciever as Player, power);
    }
    private readonly ArtifactVolume _artifactVolume;
  }
   
}