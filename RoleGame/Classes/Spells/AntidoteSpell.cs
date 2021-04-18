using RoleGame.AbstractClasses;

namespace RoleGame.Classes.Spells {
  public class AntidoteSpell : AbstractSpell {
    public AntidoteSpell(int minManaValueForSpell = 30, bool verbalComponent = false, bool motorComponent = true) :
      base(minManaValueForSpell, verbalComponent, motorComponent) { }

    public override void UseSpell(PlayerWithMagic playerSender, Player player, int power = 0) {
      if (!playerSender.ManaChecker(power)) {
        return;
      }

      if (power >= MinManaValueForSpell) {
        if (player.State == PlayerParams.State.Poisoned) {
          player.HealthCheck();
        }

        playerSender.ManaValue -= MinManaValueForSpell;
      }
    }
  }
}