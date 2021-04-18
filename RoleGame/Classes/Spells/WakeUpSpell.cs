using RoleGame.AbstractClasses;

namespace RoleGame.Classes.Spells {
  public class WakeUpSpell : AbstractSpell {
    public WakeUpSpell(int minManaValueForSpell = 85, bool verbalComponent = true, bool motorComponent = false) :
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
        if (player.State == PlayerParams.State.Paralyzed) {
          player.Health = 1;
          player.HealthCheck();
        }

        playerSender.ManaValue -= MinManaValueForSpell;
      }
    }
  }
}