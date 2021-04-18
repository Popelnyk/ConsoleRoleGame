using RoleGame.AbstractClasses;

namespace RoleGame.Classes.Spells {
  public class HealSpell : AbstractSpell {
    public HealSpell(int minManaValueForSpell = 20, bool verbalComponent = true, bool motorComponent = true) :
      base(minManaValueForSpell, verbalComponent, motorComponent) { }

    public override void UseSpell(PlayerWithMagic playerSender, Player player, int power = 0) {

      if (!playerSender.ManaChecker(power)) {
        return;
      }

      while (power > MinManaValueForSpell) {
        if (player.State == PlayerParams.State.Sick) {
          player.State = PlayerParams.State.Attenuated;
        } else if (player.State == PlayerParams.State.Attenuated) {
          player.State = PlayerParams.State.Normal;
        } else {
          break;
        }
        playerSender.ManaValue -= MinManaValueForSpell;
        power -= MinManaValueForSpell;
      }
    }
  }
}