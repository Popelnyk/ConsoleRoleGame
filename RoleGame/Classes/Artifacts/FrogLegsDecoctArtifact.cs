using RoleGame.AbstractClasses;

namespace RoleGame.Classes.Artifacts {
  public class FrogLegsDecoctArtifact : AbstractArtifact {
    public FrogLegsDecoctArtifact(int powerOfArtifact = 0, bool reusabilityOfArtifact = false) 
      : base(powerOfArtifact, reusabilityOfArtifact) {
      PowerOfArtifact = 0;
      reusabilityOfArtifact = false;
    }

    public override void UseArtifact(Player playerSender, Player playerReciever = null, int power = 0) {
      if (playerReciever.State == PlayerParams.State.Poisoned) {
        playerReciever.State = PlayerParams.State.Attenuated;
      }
      else {
        //TODO: Add some messages
      }
    }

    public override void UseArtifact(Player playerSender, PlayerWithMagic playerReciever = null, int power = 0) {
      UseArtifact(playerSender, playerReciever as Player, 0);
    }
  }
}