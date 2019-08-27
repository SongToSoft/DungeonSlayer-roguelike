using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer.Units.Players.Magics
{
    static class MagicList
    {
        static public Magic healMagic = new Magic("Heal", "Heal 20 hp", 20, Heal);
        static public Magic buffAttackMagic = new Magic("Buff Attack", "Increase attack on 3", 30, BuffAttack);
        static public Magic buffEvasionMAgic = new Magic("Buff Evasion", "Increase evasion on 5", 10, BuffEvasion);

        static public List<Magic> magics = new List<Magic>()
        {
            healMagic,
            buffAttackMagic,
            buffEvasionMAgic
        };

        static public void Heal()
        {
            Game.player.helth += (20 + Game.player.specification.spellPower);
            if (Game.player.helth > Game.player.maxHelth)
            {
                Game.player.helth = Game.player.maxHelth;
            }
        }

        static public void BuffAttack()
        {
            if (!Game.player.magicSystem.isBuffAttack)
            {
                Game.player.magicSystem.isBuffAttack = true;
                Game.player.attack += (3 + Game.player.specification.spellPower);
            }
        }

        static public void BuffEvasion()
        {
            if (!Game.player.magicSystem.isBuffEvasion)
            {
                Game.player.magicSystem.isBuffEvasion = true;
                Game.player.evasion += (5 + Game.player.specification.spellPower);
            }
        }
    }
}
