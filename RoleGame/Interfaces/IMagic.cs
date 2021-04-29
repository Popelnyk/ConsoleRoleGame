using RoleGame.Classes;

namespace RoleGame.Interfaces
{
  public interface IMagic
  {
    public void UseMagic(PlayerWithMagic playerSender, Player player, int power = 0);
  }
}