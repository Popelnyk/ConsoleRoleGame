using RoleGame.AbstractClasses;

namespace RoleGame.Classes.Artifacts {
  public class PoisonousSalivaArtifact : AbstractArtifact {
    public PoisonousSalivaArtifact(int artifactPower = 0, bool reusability = true)
      : base(artifactPower, reusability) { }

    public override void UseMagic(Player playerSender, Player playerReciever, int power = 0) {
      if (!(playerReciever.State == PlayerParams.State.Attenuated ||
            playerReciever.State == PlayerParams.State.Normal)) {
        //message
        return;
      }

      if (playerReciever.Health - power >= 0) {
        playerReciever.State = PlayerParams.State.Poisoned;
        playerReciever.Health -= power;
        ArtifactPower -= power;
      } else {
        playerReciever.Health = 0;
        //messages
      }
    }

    public override void UseMagic(Player playerSender, PlayerWithMagic playerReciever, int power = 0) {
      UseMagic(playerSender, playerReciever as Player, 0);
    }
  }
}