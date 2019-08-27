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

        public void Attack(Persona persona)
        {
            StatusLine.AddLine(" " + name + " attack " + persona.name + '\n');          
            persona.ReceiveAttack(attack, this);
            if (this is Player)
            {
                if (Game.player.perksSystem.CheckPerk(PerksList.doubleAttackPerk))
                {
                    StatusLine.AddLine(" " + Game.player.name + " do double attack \n");
                    persona.ReceiveAttack(attack, this);
                }
            }
        }

        public void ReceiveAttack(int attack, Persona whoMadeAttack)
        {
            if (DungeonGenerator.random.Next(0, 100) > whoMadeAttack.accuracy)
            {
                StatusLine.AddLine(" " + whoMadeAttack.name + " miss on " + name + "\n");
            }
            else
            {
                if (DungeonGenerator.random.Next(0, 100) < evasion)
                {
                    StatusLine.AddLine(" " + name + " dodged an attack\n");
                }
                else
                {
                    int damage = attack - blocking;
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    StatusLine.AddLine(" " + whoMadeAttack.name + " hit " + name + "\n");
                    if (DungeonGenerator.random.Next(0, 100) < whoMadeAttack.criticalChance)
                    {
                        StatusLine.AddLine(" " + whoMadeAttack.name + " critical hit on" + name + "\n");
                        damage *= 2;
                    }
                    StatusLine.AddLine(" " + name + " received damage " + damage + "\n");
                    if (damage > 0)
                    {
                        helth -= damage;
                    }
                    StatusLine.AddLine(" " + name + " has helth: " + ((helth >= 0) ? Convert.ToString(helth) : "0") + "\n");
                    if (helth <= 0)
                    {
                        StatusLine.AddLine(" " + name + " killed\n");
                        if (!(this is Player))
                        {
                            Game.player.specification.currentExp += (this as Enemy).expectedExp;
                            if (Game.player.specification.currentExp >= Game.player.specification.maxExp)
                            {
                                ++Game.player.specification.levelPoint;
                                ++Game.player.specification.level;
                                int remainder = Game.player.specification.currentExp - Game.player.specification.maxExp;
                                Game.player.specification.currentExp = remainder;
                            }
                            Game.player.currentGold += (this as Enemy).expectedGold;
                            StatusLine.AddLine(" " + Game.player.name + " received" +
                                              ((Game.player.specification.gender == EGender.FEMALE) ? "а " : " ") + "experience: " +
                                              (this as Enemy).expectedExp + ", gold: " + (this as Enemy).expectedGold + "\n");
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
