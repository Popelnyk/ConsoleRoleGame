namespace RoleGame.Classes
{
    public readonly struct PlayerParams
    {
        public enum State
        {
            Normal,
            Attenuated,
            Sick,
            Poisoned,
            Paralyzed,
            Dead
        }

        public enum Sex
        {
            Male,
            Female
        }

        public enum Race
        {
            Human,
            Goblin,
            Elf,
            Orc,
            Gnome
        }
    }
    
    public class Player
    {
        Player(string name, PlayerParams.Race race, PlayerParams.Sex sex, int age)
        {
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
            _state = PlayerParams.State.Normal;
        }

        public void SetMaxHealth(int health)
        {
            _maxHealth = health;
        }
        
        //TODO: move health to constants
        void setMaxHealthDependingOnRace(PlayerParams.Race race)
        {
            switch (race)
            {
                case PlayerParams.Race.Elf:
                    _maxHealth = 50;
                    break;
                case PlayerParams.Race.Gnome:
                    _maxHealth = 80;
                    break;
                case PlayerParams.Race.Goblin:
                    _maxHealth = 90;
                    break;
                case PlayerParams.Race.Human:
                    _maxHealth = 100;
                    break;
                case PlayerParams.Race.Orc:
                    _maxHealth = 150;
                    break;
            }
        }

        public string Name => _name;

        public int Id => _id;
        
        public int Age
        {
            get => _age;
            set => _age = value;
        }

        public int Health
        {
            get => _health;
            set => _health = value;
        }

        public int Experience
        {
            get => _experience;
            set => _experience = value;
        }

        public bool CanSpeak
        {
            get => _canSpeak;
            set => _canSpeak = value;
        }

        public bool CanMove
        {
            get => _canMove;
            set => _canMove = value;
        }
        
        public bool IsDead
        {
            get => _isDead;
            set => _isDead = value;
        }

        public PlayerParams.State State
        {
            get => _state;
            set => _state = value;
        }

        public PlayerParams.Race Race => _race;

        public PlayerParams.Sex Sex => _sex;
        
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
    }
}