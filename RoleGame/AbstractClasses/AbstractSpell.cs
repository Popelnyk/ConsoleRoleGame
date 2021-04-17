using RoleGame.Classes;
using RoleGame.Interfaces;

namespace RoleGame.AbstractClasses
{
    public abstract class AbstractSpell : IMagic {

        public AbstractSpell(PlayerWithMagic playerSender, int minManaValueForSpell, bool verbalComponent, bool motorComponent) {
            PlayerSender = playerSender;
            MinManaValueForSpell = minManaValueForSpell;
            VerbalComponent = verbalComponent;
            MotorComponent = motorComponent;
        }

        public abstract void UseSpell(Player player = null, int power = 0);

        public PlayerWithMagic PlayerSender {
            get => _playerSender;
            set => _playerSender = value;
        }

        public int MinManaValueForSpell {
            get => _minManaValueForSpell;
            set => _minManaValueForSpell = value;
        }

        public bool VerbalComponent {
            get => _verbalComponent;
            set => _verbalComponent = value;
        }

        public bool MotorComponent {
            get => _motorComponent;
            set => _motorComponent = value;
        }

        private PlayerWithMagic _playerSender;
        private int _minManaValueForSpell;
        private bool _verbalComponent;
        private bool _motorComponent;
    }
}