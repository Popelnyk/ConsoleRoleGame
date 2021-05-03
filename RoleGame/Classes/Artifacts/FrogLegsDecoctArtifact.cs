using RoleGame.AbstractClasses;

namespace RoleGame.Classes.Artifacts {
  public class FrogLegsDecoctArtifact : AbstractArtifact {
    public FrogLegsDecoctArtifact(int artifactPower = 0, bool reusability = false)
      : base(artifactPower, reusability) {
    }

    public override void UseMagic(Player playerSender, Player playerReciever, int power = 0) {
      if (playerReciever.State == PlayerParams.State.Poisoned) {
        playerReciever.State = PlayerParams.State.Attenuated;
        playerSender.Inventory.ThrowAwayArtifact(this);
      } else {
        //TODO: Add some messages
      }
    }

    public override void UseMagic(Player playerSender, PlayerWithMagic playerReciever, int power = 0) {
      UseMagic(playerSender, playerReciever as Player, 0);
    }
  }
}