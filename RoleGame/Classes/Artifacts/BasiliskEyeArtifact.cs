using RoleGame.AbstractClasses;

namespace RoleGame.Classes.Artifacts {
  public class BasiliskEyeArtifact : AbstractArtifact {
    public BasiliskEyeArtifact(int powerOfArtifact = 0, bool reusabilityOfArtifact = false)
      : base(powerOfArtifact, reusabilityOfArtifact) {
    }

    public override void UseMagic(Player playerSender, Player playerReciever, int power = 0) {
      if (playerReciever.State != PlayerParams.State.Dead) {
        playerReciever.State = PlayerParams.State.Paralyzed;
      } else {
        //TODO: some messages
      }
    }

    public override void UseMagic(Player playerSender, PlayerWithMagic playerReciever, int power = 0) {
      UseMagic(playerSender, playerReciever as Player, 0);
    }
  }
}