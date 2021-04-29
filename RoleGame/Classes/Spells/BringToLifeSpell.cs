using RoleGame.AbstractClasses;

namespace RoleGame.Classes.Spells
{
  public class BringToLifeSpell : AbstractSpell
  {
    public BringToLifeSpell(int minManaValueForSpell = 150, bool verbalComponent = true, bool motorComponent = true) :
      base(minManaValueForSpell, verbalComponent, motorComponent)
    {
    }

    public override void UseMagic(PlayerWithMagic playerSender, Player player, int power = 0)
    {
      if (!playerSender.ManaChecker(power))
      {
        //message
        return;
      }

      if (!(playerSender.CanSpeak && VerbalComponent) || !(playerSender.CanMove && MotorComponent))
      {
        //message
        return;
      }

      if (power >= MinManaValueForSpell)
      {
        if (player.State == PlayerParams.State.Dead)
        {
          player.Health = 1;
          player.StateCheck();
        }

        playerSender.ManaValue -= MinManaValueForSpell;
      }
    }
  }
}