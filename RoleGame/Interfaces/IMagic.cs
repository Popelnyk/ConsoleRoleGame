using RoleGame.Classes;

namespace RoleGame.Interfaces
{
    public interface IMagic {
        public void UseSpell(Player player, int power);
        public void UseSpell(Player player);
        public void UseSpell(int power);
        public void UseSpell();
    }
}