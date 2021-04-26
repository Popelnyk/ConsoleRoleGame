using RoleGame.AbstractClasses;

namespace RoleGame.Classes.Artifacts
{
  public class BasiliskEyeArtifact : AbstractArtifact
  {
    public BasiliskEyeArtifact(int powerOfArtifact = 0, bool reusabilityOfArtifact = true) 
      : base(powerOfArtifact, reusabilityOfArtifact) {
      PowerOfArtifact = 0;
      ReusabilityOfArtifact = true;
    }

    public override void UseArtifact(Player playerSender, Player playerReciever = null, int power = 0) {
      if (playerReciever.State != PlayerParams.State.Dead) {
        playerReciever.State = PlayerParams.State.Paralyzed;
      }
      else {
        //TODO: some messages
      }
    }

    public override void UseArtifact(Player playerSender, PlayerWithMagic playerReciever = null, int power = 0) {
      UseArtifact(playerSender, playerReciever as Player, 0);
    }
  }
}