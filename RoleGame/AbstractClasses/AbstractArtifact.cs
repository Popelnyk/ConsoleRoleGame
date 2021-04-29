using RoleGame.Classes;
using RoleGame.Interfaces;

namespace RoleGame.AbstractClasses {
  public abstract class AbstractArtifact : IMagic {
    public AbstractArtifact(int powerOfArtifact, bool reusabilityOfArtifact) {
      PowerOfArtifact = powerOfArtifact;
      ReusabilityOfArtifact = reusabilityOfArtifact;
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

    public int PowerOfArtifact {
      get => _powerOfArtifact;
      set {
        if (value >= 0)
          _powerOfArtifact = value;
      }
    }

    public bool ReusabilityOfArtifact {
      get => _reusabilityOfArtifact;
      set => _reusabilityOfArtifact = value;
    }

    private int _powerOfArtifact;
    private bool _reusabilityOfArtifact;
  }
}