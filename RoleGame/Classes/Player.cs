using System;
using RoleGame.AbstractClasses;

namespace RoleGame.Classes {
  public readonly struct PlayerParams {
    public enum State {
      Normal,
      Attenuated,
      Sick,
      Poisoned,
      Paralyzed,
      Dead
    }

    public enum Sex {
      Male,
      Female
    }

    public enum Race {
      Human,
      Goblin,
      Elf,
      Orc,
      Gnome
    }
  }

  public class Player : IComparable<Player> {
    public Player(string name, PlayerParams.Race race, PlayerParams.Sex sex, int age) {
      _id = _lastId++;
      _name = name;
      _race = race;
      _sex = sex;
      _age = age;

      setMaxHealthDependingOnRace(race);
      _health = _maxHealth;

      //TODO: move to constants
      _experience = 0;
      _canSpeak = true;
      _canMove = true;
      _isDead = false;
      _isArmored = false;
      _state = PlayerParams.State.Normal;

      _inventory = new Inventory.Inventory();
    }

    public void StateCheck() {
      if (Health == 0) {
        State = PlayerParams.State.Dead;
      } else if ((double) Health / MaxHealth < 0.1) {
        State = PlayerParams.State.Attenuated;
      } else {
        State = PlayerParams.State.Normal;
      }
    }

    public int CompareTo(Player p) {
      return Experience.CompareTo(p.Experience);
    }

    public override string ToString() {
      return $"Player name: {Name}\n" +
             $"State: {State}\n" +
             $"Can speak: {CanSpeak}\n" +
             $"Can move: {CanMove}\n" +
             $"Race: {Race}\n" +
             $"Sex: {Sex}\n" +
             $"Age: {Age}\n" +
             $"Health: {Health}/{MaxHealth}\n " +
             $"Experience: {Experience}\n";
    }

    public delegate void ReceivedArtifact(Player playerSender, Player playerReciever, int power);

    public void CastArtifact(ReceivedArtifact receivedArtifact, Player playerReciever = null, int power = 0) {
      if (!Inventory.ContainsArtifact((AbstractArtifact)receivedArtifact.Target)) {
        Console.WriteLine("U cant use this artifact");
        return;
      }
      
      if (power < 0) {
        power = 0;
      }

      if (playerReciever == null) {
        playerReciever = this;
      }

      Inventory.Bag.Remove((AbstractArtifact)receivedArtifact.Target);

      receivedArtifact(this, playerReciever, power);
    }

    //TODO: move health to constants
    private void setMaxHealthDependingOnRace(PlayerParams.Race race) {
      switch (race) {
        case PlayerParams.Race.Elf:
          MaxHealth = 50;
          break;
        case PlayerParams.Race.Gnome:
          MaxHealth = 80;
          break;
        case PlayerParams.Race.Goblin:
          MaxHealth = 90;
          break;
        case PlayerParams.Race.Human:
          MaxHealth = 100;
          break;
        case PlayerParams.Race.Orc:
          MaxHealth = 150;
          break;
      }
    }

    private void ChangeHealth(int health) {
      if (EndArmorTime < DateTime.Now) {
        IsArmored = false;
      }

      if (0 <= health && health <= _maxHealth && !IsArmored) {
        _health = health;
      }

      if (State == PlayerParams.State.Normal || State == PlayerParams.State.Attenuated) {
        StateCheck();
      }
    }

    private void ChangeExperience(int experience) {
      if (experience >= 0) {
        _experience = experience;
      }
    }

    public void IncreaseMaxHealth(int maxHealth) {
      if (maxHealth > 0) {
        _maxHealth = maxHealth;
      }
    }

    public string Name => _name;

    public int Id => _id;

    public int Age {
      get => _age;
      set => _age = value;
    }

    public int MaxHealth {
      get => _maxHealth;
      set => IncreaseMaxHealth(value);
    }

    public int Health {
      get => _health;
      set => ChangeHealth(value);
    }

    public int Experience {
      get => _experience;
      set => ChangeExperience(value);
    }

    public bool CanSpeak {
      get => _canSpeak;
      set => _canSpeak = value;
    }

    public bool CanMove {
      get => _canMove;
      set => _canMove = value;
    }

    public bool IsDead {
      get => _isDead;
      set => _isDead = value;
    }

    public PlayerParams.State State {
      get => _state;
      set => _state = value;
    }

    public DateTime EndArmorTime {
      get => _endArmorTime;
      set => _endArmorTime = value;
    }

    public bool IsArmored {
      get => _isArmored;
      set => _isArmored = value;
    }

    public bool IsPlayerHaveMagic {
      get => _isPlayerHaveMagic;
    }

    public PlayerParams.Race Race => _race;

    public PlayerParams.Sex Sex => _sex;

    public Inventory.Inventory Inventory {
      get => _inventory;
      set => _inventory = value;
    }

    private static int _lastId = 0;
    private readonly string _name;
    private readonly int _id;
    private readonly PlayerParams.Race _race;
    private readonly PlayerParams.Sex _sex;
    private PlayerParams.State _state;
    private int _age;
    private int _health;
    private int _maxHealth;
    private int _experience;
    private bool _canSpeak;
    private bool _canMove;
    private bool _isDead;

    private DateTime _endArmorTime;
    private bool _isArmored;

    private readonly bool _isPlayerHaveMagic = false;

    private Inventory.Inventory _inventory;
  }
}