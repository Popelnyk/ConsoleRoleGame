using System;
using RoleGame.AbstractClasses;

namespace RoleGame.Classes.Artifacts {
  public class LightningStaffArtifact : AbstractArtifact {
    public LightningStaffArtifact(int artifactPower = 0, bool reusability = true)
      : base(artifactPower, reusability) {
    }

    public override void UseMagic(Player playerSender, Player playerReciever, int power = 0) {
      if ((playerReciever.Health - power >= 0) && ArtifactPower != 0) {
        playerReciever.Health -= power;
        ArtifactPower -= power;
      } else if (playerReciever.Health - power < 0) {
        playerReciever.Health = 0;
      } else {
        //TODO: Add some messages; power == 0;
      }
    }

    //TODO: Interaction with inventory 
    public override void UseMagic(Player playerSender, PlayerWithMagic playerReciever, int power = 0) {
      UseMagic(playerSender, playerReciever as Player, power);
    }
  }
}