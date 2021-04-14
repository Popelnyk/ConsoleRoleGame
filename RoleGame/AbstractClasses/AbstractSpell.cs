using RoleGame.Classes;
using RoleGame.Interfaces;

namespace RoleGame.AbstractClasses
{
    public abstract class AbstractSpell : IMagic {
        public void UseSpell(Player player, int power) {
            //TODO make use spell method
        }

        private int _minManaValueForSpell;
        private bool _verbalComponent;
        private bool _motorComponent;
    }
}