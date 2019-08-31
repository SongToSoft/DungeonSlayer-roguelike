using DungeonSlayer.Units.Enemies;
using DungeonSlayer.Units.Players;
using DungeonSlayer.Units.Players.Perks;
using System;

namespace DungeonSlayer.Units
{
    class Persona : Unit
    {
        public string name;
        public int helth = 100, maxHelth = 100;
        public int mana = 100, maxMana = 100;
        public int attack = 1;
        public int evasion = 1;
        public int blocking = 0;
        public int accuracy = 95;
        public int criticalChance = 0;
        public bool inStun = false;

        public void Attack(Persona persona)
        {
            StatusLine.AddLine(" " + name + " attack " + persona.name);          
            persona.ReceiveAttack(attack, this);
            if (this is Player)
            {
                if (Game.player.perksSystem.CheckPerk(PerksList.doubleAttackPerk) && (persona.helth > 0))
                {
                    StatusLine.AddLine(" " + Game.player.name + " do double attack");
                    persona.ReceiveAttack(attack, this);
                }
            }
        }

        public void ReceiveAttack(int attack, Persona whoMadeAttack)
        {
            if (DungeonGenerator.random.Next(0, 100) > whoMadeAttack.accuracy)
            {
                StatusLine.AddLine(" " + whoMadeAttack.name + " miss on " + name);
            }
            else
            {
                if (DungeonGenerator.random.Next(0, 100) < evasion)
                {
                    StatusLine.AddLine(" " + name + " dodged an attack");
                }
                else
                {
                    if ((this is Player) &&
                         Game.player.perksSystem.CheckPerk(PerksList.doubleMissPerk) &&
                         (DungeonGenerator.random.Next(0, 100) < evasion))
                    {
                        StatusLine.AddLine(" " + name + " dodged an attack due to perk");
                    }
                    else
                    {
                        int damage = attack - blocking;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        StatusLine.AddLine(" " + whoMadeAttack.name + " hit " + name);
                        if (DungeonGenerator.random.Next(0, 100) < whoMadeAttack.criticalChance)
                        {
                            StatusLine.AddLine(" " + whoMadeAttack.name + " critical hit on " + name);
                            damage *= 2;
                        }
                        StatusLine.AddLine(" " + name + " received damage " + damage);
                        if (damage > 0)
                        {
                            helth -= damage;
                        }
                        StatusLine.AddLine(" " + name + " has helth: " + ((helth >= 0) ? Convert.ToString(helth) : "0"));
                        if (helth <= 0)
                        {
                            StatusLine.AddLine(" " + name + " killed");
                            if (!(this is Player))
                            {
                                int expectedExp = (this as Enemy).expectedExp;
                                int expectedGold = (this as Enemy).expectedGold;
                                if (Game.player.perksSystem.CheckPerk(PerksList.receiverPerk))
                                {
                                    expectedExp += (int)(expectedExp * 0.2);
                                    expectedGold += (int)(expectedGold * 0.2);
                                }
                                Game.player.specification.currentExp += expectedExp;
                                Game.player.currentGold += expectedGold;
                                if (Game.player.specification.currentExp >= Game.player.specification.maxExp)
                                {
                                    ++Game.player.specification.levelPoint;
                                    ++Game.player.specification.level;
                                    int remainder = Game.player.specification.currentExp - Game.player.specification.maxExp;
                                    Game.player.specification.currentExp = remainder;
                                    Game.player.specification.maxExp += 5;
                                }
                                StatusLine.AddLine(" " + Game.player.name + " received experience: " +
                                                  expectedExp + ", gold: " + expectedGold);
                                if (this.name == "Diablo")
                                {
                                    StatusLine.AddLine(" YOU KILL DIABLO, AND NOW YOU END OF GAME");
                                    Console.ReadKey();
                                    Game.EndGame(true);
                                }
                                if (Game.player.perksSystem.CheckPerk(PerksList.cannibalPerk))
                                {
                                    int canHeal = (int)(Game.player.maxHelth * 0.2);
                                    Game.player.helth += canHeal;
                                    if (Game.player.helth > Game.player.maxHelth)
                                    {
                                        Game.player.helth = Game.player.maxHelth;
                                    }
                                    StatusLine.AddLine(" " + Game.player.name + " after kill " + this.name + " heal " + canHeal);
                                }
                            }
                            else
                            {
                                (this as Player).isDead = true;
                                Game.EndGame();
                            }
                            if (this is Enemy)
                            {
                                Game.world.dungeon.enemyes.Remove(this as Enemy);
                            }
                        }
                    }                    
                }
            }
        }

        public void MoveRight()
        {
            if (Game.world.map[(int)position.X, (int)position.Y + 1] == '.')
            {
                ++position.Y;
            }
        }

        public void MoveLeft()
        {
            if (Game.world.map[(int)position.X, (int)position.Y - 1] == '.')
            {
                --position.Y;
            }
        }

        public void MoveUp()
        {
            if (Game.world.map[(int)position.X - 1, (int)position.Y] == '.')
            {
                --position.X;
            }
        }

        public void MoveDown()
        {
            if (Game.world.map[(int)position.X + 1, (int)position.Y] == '.')
            {
                ++position.X;
            }
        }
    }
}
