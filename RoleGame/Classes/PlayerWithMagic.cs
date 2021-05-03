using System;
using System.Collections.Generic;
using RoleGame.AbstractClasses;
using RoleGame.Classes.Spells;

namespace RoleGame.Classes {
  public class PlayerWithMagic : Player {
    public PlayerWithMagic(string name, PlayerParams.Race race, PlayerParams.Sex sex, int age) : base(name, race, sex,
      age) {
      SetMaxManaDependingOnRace(race);
      ManaValue = _maxMana;
      KnownSpells = new List<AbstractSpell>();
    }

    public bool ManaChecker(int power) {
      return ManaValue >= power;
    }

    public delegate void ReceivedSpell(PlayerWithMagic playerSender, Player player, int power);

    public void CastSpell(ReceivedSpell receivedSpell, Player player = null, int power = 0) {
      if (!KnownSpells.Contains((AbstractSpell) receivedSpell.Target)) {
        Console.WriteLine("Character doesn't know this spell!");
        return;
      }

      if (power < 0) {
        power = 0;
      }

      if (player == null) {
        player = this;
      }

      receivedSpell(this, player, power);
    }

    public new delegate void ReceivedArtifact(Player playerSender, PlayerWithMagic playerReciever, int power);

    public void CastArtifact(ReceivedArtifact receivedArtifact, PlayerWithMagic playerReciever = null, int power = 0) {
      if (!Inventory.ContainsArtifact((AbstractArtifact) receivedArtifact.Target)) {
        //message;
        return;
      }

      if (power < 0) {
        power = 0;
      }

      if (playerReciever == null) {
        playerReciever = this;
      }

      Inventory.Bag.Remove((AbstractArtifact) receivedArtifact.Target);

      receivedArtifact(this, playerReciever, power);
    }

    public void LearnSpell(AbstractSpell spell) {
      if (!KnownSpells.Contains(spell)) {
        KnownSpells.Add(spell);
      }
    }

    public void ForgetSpell(AbstractSpell spell) {
      if (KnownSpells.Contains(spell)) {
        KnownSpells.Remove(spell);
      } else {
        Console.WriteLine("Character doesn't know this spell!");
      }
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
             $"Health: {Health}/{MaxHealth}\n" +
             $"Experience: {Experience}\n" +
             $"Mana: {ManaValue}/{MaxMana}\n";
    }

    private void ChangeMana(int mana) {
      if (0 <= mana && mana <= MaxMana) {
        _mana = mana;
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

    public List<AbstractSpell> KnownSpells {
      get => _knownSpells;
      set => _knownSpells = value;
    }

    private int _mana = 0;
    private int _maxMana = 0;

    private List<AbstractSpell> _knownSpells;
  }
}