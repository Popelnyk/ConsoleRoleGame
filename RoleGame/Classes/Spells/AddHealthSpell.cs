using System;
using RoleGame.AbstractClasses;

namespace RoleGame.Classes.Spells
{
    public class AddHealthSpell : AbstractSpell
    {
        public AddHealthSpell(PlayerWithMagic playerSender) : base(playerSender, 0, true, false) { }

        public override void UseSpell(Player player = null, int power = 0) {
            if (player == null) {
                if (PlayerSender.ManaChecker(power)) {
                    PlayerSender.ManaValue -= power;
                } else {
                    PlayerSender.ManaValue = 0;
                }
                return;
            }
            
            int healthWillBeRestored;
            if (PlayerSender.ManaChecker(power)) {
                healthWillBeRestored = power / 2;
                
            } else {
                healthWillBeRestored = PlayerSender.ManaValue / 2;
            }
            
            int healthPlayerNeed = player.MaxHealth - player.Health;
            if (healthPlayerNeed >= healthWillBeRestored) {
                player.Health += healthWillBeRestored;
                PlayerSender.ManaValue -= healthWillBeRestored * 2;
            } else {
                player.Health = player.MaxHealth;
                PlayerSender.ManaValue -= healthPlayerNeed * 2;
            }
        }
    }
}