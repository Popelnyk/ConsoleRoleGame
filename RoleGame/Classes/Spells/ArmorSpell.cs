using RoleGame.AbstractClasses;

namespace RoleGame.Classes.Spells {
  public class ArmorSpell : AbstractSpell {
    public ArmorSpell(int minManaValueForSpell = 85, bool verbalComponent = true, bool motorComponent = false) :
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

      if (power >= MinManaValueForSpell) {
        //TODO make armor spell
      }
    }
  }
}