using RoleGame.AbstractClasses;

namespace RoleGame.Classes.Artifacts
{
  public class PoisonousSalivaArtifact : AbstractArtifact
  {
    public PoisonousSalivaArtifact(int powerOfArtifact = 0, bool reusabilityOfArtifact = false) 
      : base(powerOfArtifact, reusabilityOfArtifact) {
      PowerOfArtifact = powerOfArtifact;
      ReusabilityOfArtifact = false;
    }

    public override void UseArtifact(Player playerSender, Player playerReciever = null, int power = 0) {
      if (playerReciever.State == PlayerParams.State.Attenuated || playerReciever.State == PlayerParams.State.Normal) {
        if (playerReciever.Health - power >= 0) {
          playerReciever.State = PlayerParams.State.Poisoned;
          playerReciever.Health -= power;
          PowerOfArtifact -= power;
        }
        else {
          playerReciever.Health = 0;
          //TODO: some messages
        }
      }
      else {
        //TODO: Some messages
      }
    }

    public override void UseArtifact(Player playerSender, PlayerWithMagic playerReciever = null, int power = 0) {
      UseArtifact(playerSender, playerReciever, 0);
    }
  }
}