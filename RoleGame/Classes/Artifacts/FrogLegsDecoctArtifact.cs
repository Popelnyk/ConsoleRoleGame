using RoleGame.AbstractClasses;

namespace RoleGame.Classes.Artifacts {
  public class FrogLegsDecoctArtifact : AbstractArtifact {
    public FrogLegsDecoctArtifact(int powerOfArtifact = 0, bool reusabilityOfArtifact = false)
      : base(powerOfArtifact, reusabilityOfArtifact) {
    }

    public override void UseMagic(Player playerSender, Player playerReciever, int power = 0) {
      if (playerReciever.State == PlayerParams.State.Poisoned) {
        playerReciever.State = PlayerParams.State.Attenuated;
      } else {
        //TODO: Add some messages
      }
    }

    public override void UseMagic(Player playerSender, PlayerWithMagic playerReciever, int power = 0) {
      UseMagic(playerSender, playerReciever as Player, 0);
    }
  }
}