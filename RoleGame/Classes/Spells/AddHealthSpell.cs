using System;
using RoleGame.AbstractClasses;

namespace RoleGame.Classes.Spells {
  public class AddHealthSpell : AbstractSpell {
    public AddHealthSpell(int minManaValueForSpell = 0, bool verbalComponent = true, bool motorComponent = false) :
      base(minManaValueForSpell, verbalComponent, motorComponent) { }

    public override void UseSpell(PlayerWithMagic playerSender, Player player, int power = 0) {
      if (!((playerSender.CanSpeak && VerbalComponent) || (playerSender.CanMove && MotorComponent))) {
        //message
        return;
      }

      int healthWillBeRestored;
      if (playerSender.ManaChecker(power)) {
        healthWillBeRestored = power / 2;
      } else {
        healthWillBeRestored = playerSender.ManaValue / 2;
      }

      int healthPlayerNeed = player.MaxHealth - player.Health;
      if (healthPlayerNeed >= healthWillBeRestored) {
        player.Health += healthWillBeRestored;
        playerSender.ManaValue -= healthWillBeRestored * 2;
      } else {
        player.Health = player.MaxHealth;
        playerSender.ManaValue -= healthPlayerNeed * 2;
      }

      player.StateCheck();
    }
  }
}