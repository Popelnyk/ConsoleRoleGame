using System.Threading;
using RoleGame.Classes;
using RoleGame.Interfaces;

namespace RoleGame.AbstractClasses {
  public abstract class AbstractArtifact : IMagic {
    public AbstractArtifact(int powerOfArtifact, bool reusabilityOfArtifact) {
      ArtifactPower = powerOfArtifact;
      Reusability = reusabilityOfArtifact;
    }

    public void UseMagic(PlayerWithMagic playerSender, Player playerReciever, int power = 0) {
      UseMagic(playerSender as Player, playerReciever, power);
    }

    public abstract void UseMagic(Player playerSender, Player playerReciever, int power = 0);
    public abstract void UseMagic(Player playerSender, PlayerWithMagic playerReciever, int power = 0);

    public enum ArtifactVolume {
      None,
      Small,
      Middle,
      Big
    }
    public int ArtifactPower {
      get => _artifactPower;
      set {
        if (value >= 0)
          _artifactPower = value;
      }
    }

    public bool Reusability {
      get => _reusability;
      set => _reusability = value;
    }

    private int _artifactPower;
    private bool _reusability;
  }
}