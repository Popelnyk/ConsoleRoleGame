using System;
using RoleGame.AbstractClasses;

namespace RoleGame.Classes.Spells
{
  public class HealSpell : AbstractSpell
  {
    public HealSpell(int minManaValueForSpell = 20, bool verbalComponent = false, bool motorComponent = true) :
      base(minManaValueForSpell, verbalComponent, motorComponent)
    {
    }

    public override void UseMagic(PlayerWithMagic playerSender, Player player, int power = 0)
    {
      if (!playerSender.ManaChecker(power))
      {
        Console.WriteLine("Player haven't got enough mana for spell!");
        return;
      }

      if (!((playerSender.CanSpeak && VerbalComponent) || (playerSender.CanMove && MotorComponent)))
      {
        Console.WriteLine("The player's state does not correspond to the verbal component");
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