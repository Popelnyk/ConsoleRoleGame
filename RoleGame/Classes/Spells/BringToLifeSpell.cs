using RoleGame.AbstractClasses;

namespace RoleGame.Classes.Spells {
  public class BringToLifeSpell : AbstractSpell {
    public BringToLifeSpell(int minManaValueForSpell = 150, bool verbalComponent = false, bool motorComponent = true) :
      base(minManaValueForSpell, verbalComponent, motorComponent) { }

    public override void UseSpell(PlayerWithMagic playerSender, Player player, int power = 0) {
      if (!playerSender.ManaChecker(power)) {
        return;
      }

      if (power >= MinManaValueForSpell) {
        if (player.State == PlayerParams.State.Dead) {
          player.Health = 1;
          player.HealthCheck();
        }

        playerSender.ManaValue -= MinManaValueForSpell;
      }
    }
  }
}