using System;
using RoleGame.AbstractClasses;

namespace RoleGame.Classes.Artifacts
{
  public class LightningStaffArtifact : AbstractArtifact
  {
    public LightningStaffArtifact(int powerOfArtifact = 0, bool reusabilityOfArtifact = true) 
      : base(powerOfArtifact, reusabilityOfArtifact) {
      PowerOfArtifact = powerOfArtifact;
      ReusabilityOfArtifact = true;
    }

    public override void UseArtifact(Player playerSender, Player playerReciever = null, int power = 0) {
      if ((playerReciever.Health - power >= 0) && PowerOfArtifact != 0) {
        playerReciever.Health -= power;
        PowerOfArtifact -= power;
      }
      else if (playerReciever.Health - power < 0){
        playerReciever.Health = 0;
      }
      else {
        //TODO: Add some messages; power == 0;
      }
    }
    //TODO: Interaction with inventory 
    public override void UseArtifact(Player playerSender, PlayerWithMagic playerReciever = null, int power = 0) {
      UseArtifact(playerSender, playerReciever as Player, power);
    }
  }
}