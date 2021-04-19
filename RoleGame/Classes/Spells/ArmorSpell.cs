using System;
using System.Threading;
using RoleGame.AbstractClasses;

namespace RoleGame.Classes.Spells {
  public class ArmorSpell : AbstractSpell {
    public ArmorSpell(int minManaValueForSpell = 50, bool verbalComponent = false, bool motorComponent = true) :
      base(minManaValueForSpell, verbalComponent, motorComponent) { }

    public override void UseSpell(PlayerWithMagic playerSender, Player player, int power = 0) {
      if (!playerSender.ManaChecker(power)) {
        //message
        return;
      }

      if (!playerSender.CanSpeak) {
        //message
        return;
      }

      DateTime tempEndArmor = DateTime.Now;
      
      if (power >= MinManaValueForSpell) {

        int interval = power / MinManaValueForSpell;
        tempEndArmor = DateTime.Now.AddSeconds(interval);
        playerSender.ManaValue -= MinManaValueForSpell * interval;
        player.EndArmorTime = tempEndArmor;
        player.IsArmored = true;
      }
    }
  }
}