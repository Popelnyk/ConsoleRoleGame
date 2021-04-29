using RoleGame.AbstractClasses;

namespace RoleGame.Classes.Artifacts {
  public class PoisonousSalivaArtifact : AbstractArtifact {
    public PoisonousSalivaArtifact(int powerOfArtifact = 0, bool reusabilityOfArtifact = true)
      : base(powerOfArtifact, reusabilityOfArtifact) {
    }

    public override void UseMagic(Player playerSender, Player playerReciever, int power = 0) {
      if (playerReciever.State == PlayerParams.State.Attenuated || playerReciever.State == PlayerParams.State.Normal) {
        if (playerReciever.Health - power >= 0) {
          playerReciever.State = PlayerParams.State.Poisoned;
          playerReciever.Health -= power;
          PowerOfArtifact -= power;
        } else {
          playerReciever.Health = 0;
          //TODO: some messages
        }
      } else {
        //TODO: Some messages
      }
    }

    public override void UseMagic(Player playerSender, PlayerWithMagic playerReciever, int power = 0) {
      UseMagic(playerSender, playerReciever as Player, 0);
    }
  }
}