using RoleGame.Classes;
using RoleGame.Interfaces;

namespace RoleGame.AbstractClasses
{
    public abstract class AbstractSpell : IMagic {

        public AbstractSpell(int minManaValueForSpell, bool verbalComponent, bool motorComponent) {
            MinManaValueForSpell = minManaValueForSpell;
            VerbalComponent = verbalComponent;
            MotorComponent = motorComponent;
        }

        public abstract void UseSpell(Player player, int power);
        public abstract void UseSpell(Player player);
        public abstract void UseSpell(int power);
        public abstract void UseSpell();

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

        private int _minManaValueForSpell;
        private bool _verbalComponent;
        private bool _motorComponent;
    }
}