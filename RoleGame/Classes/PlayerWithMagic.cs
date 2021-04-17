using RoleGame.Classes.Spells;

namespace RoleGame.Classes {
  public class PlayerWithMagic : Player {

    public PlayerWithMagic(string name, PlayerParams.Race race, PlayerParams.Sex sex, int age) : base(name, race, sex, age){
      SetMaxManaDependingOnRace(race);
      ManaValue = _maxMana;
    }

    public bool ManaChecker(int power) {
      return ManaValue >= power;
    }
    
    public void UseAddHealthSpell(Player player = null, int power = 0) {
      if (power < 0) {
        power = 0;
      }

      AddHealthSpell addHealthSpell = new AddHealthSpell(this);
      addHealthSpell.UseSpell(player, power);
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
      HealthCheck();
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

    public int MaxMana {
      get => _maxMana;
      set => _maxMana = value;
    }
    
    public int ManaValue {
      get => _mana;
      set => _mana = value;
    }

    private int _mana;
    private int _maxMana;
    
  }
}