namespace RoleGame.Classes {
  public class PlayerWithMagic : Player {

    public PlayerWithMagic(string name, PlayerParams.Race race, PlayerParams.Sex sex, int age) : base(name, race, sex, age){
      SetMaxManaDependingOnRace(race);
    }
    
    public void SetMaxMana(int maxMana) {
      _maxMana = maxMana;
    }

    void SetMaxManaDependingOnRace(PlayerParams.Race race) {
      switch (race) {
        case PlayerParams.Race.Elf:
          _maxMana = 350;
          break;
        case PlayerParams.Race.Gnome:
          _maxMana = 260;
          break;
        case PlayerParams.Race.Goblin:
          _maxMana = 120;
          break;
        case PlayerParams.Race.Human:
          _maxMana = 100;
          break;
        case PlayerParams.Race.Orc:
          _maxMana = 60;
          break;
      }
    }
    
    public int ManaValue {
      get => _mana;
      set => _mana = value;
    }

    private int _mana;
    private int _maxMana;
    
  }
}