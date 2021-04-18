using RoleGame.Classes.Spells;

namespace RoleGame.Classes {
  public class PlayerWithMagic : Player {
    public PlayerWithMagic(string name, PlayerParams.Race race, PlayerParams.Sex sex, int age) : base(name, race, sex,
      age) {
      SetMaxManaDependingOnRace(race);
      ManaValue = _maxMana;
    }

    public bool ManaChecker(int power) {
      return ManaValue >= power;
    }

    public delegate void ReceivedSpell(PlayerWithMagic playerSender, Player player, int power);

    public void CastSpell(ReceivedSpell receivedSpell, Player player = null, int power = 0) {
      if (power < 0) {
        power = 0;
      }

      if (player == null) {
        player = this;
      }

      receivedSpell(this, player, power);
    }

    void SetMaxManaDependingOnRace(PlayerParams.Race race) {
      switch (race) {
        case PlayerParams.Race.Elf:
          MaxMana = 350;
          break;
        case PlayerParams.Race.Gnome:
          MaxMana = 260;
          break;
        case PlayerParams.Race.Goblin:
          MaxMana = 120;
          break;
        case PlayerParams.Race.Human:
          MaxMana = 100;
          break;
        case PlayerParams.Race.Orc:
          MaxMana = 60;
          break;
      }
    }

    public override string ToString() {
      return $"Player name: {Name}\n" +
             $"State: {State}\n" +
             $"Can speak: {CanSpeak}\n" +
             $"Can move: {CanMove}\n" +
             $"Race: {Race}\n" +
             $"Sex: {Sex}\n" +
             $"Age: {Age}\n" +
             $"Health: {Health}\n" +
             $"Max health: {MaxHealth}\n" +
             $"Experience: {Experience}\n" +
             $"Mana: {ManaValue}\n" +
             $"Max mana: {_maxMana}\n";
    }

    private void ChangeMana(int mana) {
      if (0 <= mana && mana <= MaxMana) {
        _mana = mana;
        HealthCheck();
      }
    }

    public void IncreaseMaxMana(int maxMana) {
      if (maxMana > 0) {
        _maxMana = maxMana;
      }
    }

    public int MaxMana {
      get => _maxMana;
      set => IncreaseMaxMana(value);
    }

    public int ManaValue {
      get => _mana;
      set => ChangeMana(value);
    }

    private int _mana;
    private int _maxMana;
  }
}