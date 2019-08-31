using System.Collections.Generic;

namespace DungeonSlayer.Units.Players.Magics
{
    static class MagicList
    {
        static public Magic emptyMagic = new Magic("Empty magic", "You have not active magic", 0, Empty);
        static public Magic healMagic = new Magic("Heal", "Heal (20 + Spell Power)) hp", 20, Heal);
        static public Magic powerfulHealMagic = new Magic("Powerful Heal", "Heal (20 + (Spell Power * 2))) hp", 50, PowerfulHeal);
        static public Magic buffAttackMagic = new Magic("Buff Attack", "Increase attack on 3", 30, BuffAttack);
        static public Magic buffEvasionMagic = new Magic("Buff Evasion", "Increase evasion on 5", 10, BuffEvasion);
        static public Magic stunMagic = new Magic("Echo Stun", "Stun enemyes around hero for next step", 15, EchoStun);
        static public Magic fireBlastMagic = new Magic("Fire blast", "Attack enemyes on two cells around the hero. Damage (2 + Spell Power)", 10, FireBlast);
        static public Magic buffBlockMagic = new Magic("Buff Blocking", "Increase blocking damage on you Spell Power", 40, BuffBlocking);
        static public Magic huricaneBlastMagic = new Magic("Huricane Blast", "Attack enemyes on two cells around the hero. Damage (2 * spellPower)", 20, HuricaneBlast);
        static public Magic totalBuffMagic = new Magic("Total Buff", "Buff Attack, Evasion, Blocking (does not stack with other buff)", 110, TotalBuff);
        static public Magic meteorFlameMagic = new Magic("Meteor Flame", "Attack enemyes and stun them)", 25, MeteorFlame);

        static public List<Magic> magics = new List<Magic>()
        {
            healMagic,
            buffAttackMagic,
            buffEvasionMagic,
            stunMagic,
            fireBlastMagic,
            buffBlockMagic,
            huricaneBlastMagic,
            totalBuffMagic,
            meteorFlameMagic
        };       

        static public Magic GetMagicByName(string name)
        {
            for (int i = 0; i < magics.Count; ++i)
            {
                if (magics[i].name == name)
                {
                    return magics[i];
                }
            }
            return magics[0];
        }

        static public void Empty()
        {

        }

        static public void Heal()
        {
            Game.player.helth += (20 + Game.player.specification.spellPower);
            if (Game.player.helth > Game.player.maxHelth)
            {
                Game.player.helth = Game.player.maxHelth;
            }
        }

        static public void PowerfulHeal()
        {
            Game.player.helth += (20 + Game.player.specification.spellPower * 2);
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

        static public void BuffBlocking()
        {
            if (!Game.player.magicSystem.isBuffBlocking)
            {
                Game.player.magicSystem.isBuffBlocking = true;
                Game.player.blocking += Game.player.specification.spellPower;
            }
        }

        static public void TotalBuff()
        {
            if (!Game.player.magicSystem.isBuffEvasion)
            {
                Game.player.magicSystem.isBuffEvasion = true;
                Game.player.evasion += (5 + Game.player.specification.spellPower);
            }
            if (!Game.player.magicSystem.isBuffAttack)
            {
                Game.player.magicSystem.isBuffAttack = true;
                Game.player.attack += (3 + Game.player.specification.spellPower);
            }
            if (!Game.player.magicSystem.isBuffBlocking)
            {
                Game.player.magicSystem.isBuffBlocking = true;
                Game.player.blocking += Game.player.specification.spellPower;
            }
        }

        static public void EchoStun()
        {
            for (int i = -1; i < 2; ++i)
            {
                for (int j = -1; j < 2; ++j)
                {
                    var enemy = Game.world.dungeon.GetEnemyOverPosition((int)Game.player.GetPosition().X + i,
                                                                        (int)Game.player.GetPosition().Y + j);
                    if (enemy != null)
                    {
                        StatusLine.AddLine(" You stun: " + enemy.name);
                        enemy.inStun = true;
                    }
                }
            }
        }

        static public void MeteorFlame()
        {
            for (int i = -1; i < 2; ++i)
            {
                for (int j = -1; j < 2; ++j)
                {
                    var enemy = Game.world.dungeon.GetEnemyOverPosition((int)Game.player.GetPosition().X + i,
                                                                        (int)Game.player.GetPosition().Y + j);
                    if (enemy != null)
                    {
                        StatusLine.AddLine(" You use Meteor Flame on" + enemy.name );
                        enemy.inStun = true;
                        enemy.ReceiveAttack(Game.player.specification.spellPower, Game.player);
                    }
                }
            }
        }

        static public void FireBlast()
        {
            for (int i = -2; i < 3; ++i)
            {
                for (int j = -2; j < 3; ++j)
                {
                    var enemy = Game.world.dungeon.GetEnemyOverPosition((int)Game.player.GetPosition().X + i,
                                                                        (int)Game.player.GetPosition().Y + j);
                    if (enemy != null)
                    {
                        StatusLine.AddLine(" You use Fire Blast on " + enemy.name);
                        enemy.ReceiveAttack(Game.player.specification.spellPower + 2, Game.player);
                    }
                }
            }
        }

        static public void HuricaneBlast()
        {
            for (int i = -3; i < 4; ++i)
            {
                for (int j = -3; j < 4; ++j)
                {
                    var enemy = Game.world.dungeon.GetEnemyOverPosition((int)Game.player.GetPosition().X + i,
                                                                        (int)Game.player.GetPosition().Y + j);
                    if (enemy != null)
                    {
                        StatusLine.AddLine(" You use Huricane Blast on " + enemy.name);
                        enemy.ReceiveAttack(Game.player.specification.spellPower * 2, Game.player);
                    }
                }
            }
        }
    }
}
