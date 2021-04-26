using RoleGame.AbstractClasses;

namespace RoleGame.Classes.Spells
{
  public class HealSpell : AbstractSpell
  {
    public HealSpell(int minManaValueForSpell = 20, bool verbalComponent = false, bool motorComponent = true) :
      base(minManaValueForSpell, verbalComponent, motorComponent)
    {
    }

    public override void UseSpell(PlayerWithMagic playerSender, Player player, int power = 0)
    {
      if (!playerSender.ManaChecker(power))
      {
        //message
        return;
      }

      if (!((playerSender.CanSpeak && VerbalComponent) || (playerSender.CanMove && MotorComponent)))
      {
        //message
        return;
      }

      if (power >= MinManaValueForSpell)
      {
        if (player.State == PlayerParams.State.Sick)
        {
          player.StateCheck();
        }

        playerSender.ManaValue -= MinManaValueForSpell;
      }
    }
  }
}