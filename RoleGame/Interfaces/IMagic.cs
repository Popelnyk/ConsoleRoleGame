using RoleGame.Classes;

namespace RoleGame.Interfaces
{
    public interface IMagic {
        public void UseSpell(Player player = null, int power = 0);
    }
}