using DungeonSlayer.Units.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer
{
    class Persona : MapObjects.Unit
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
            StatusLine.AddLine(" " + name + " атакует " + persona.name + '\n');
            persona.ReceiveAttack(attack, this);
        }

        public void ReceiveAttack(int attack, Persona whoMadeAttack)
        {
            if (DungeonGenerator.random.Next(0, 100) > whoMadeAttack.accuracy)
            {
                StatusLine.AddLine(" " + whoMadeAttack.name + " промахнулся по " + name + "\n");
            }
            else
            {
                if (DungeonGenerator.random.Next(0, 100) < evasion)
                {
                    StatusLine.AddLine(" " + name + " уклонился от удара\n");
                }
                else
                {
                    int damage = attack - blocking;
                    StatusLine.AddLine(" " + whoMadeAttack.name + " попал по " + name + "\n");
                    if (DungeonGenerator.random.Next(0, 100) < whoMadeAttack.criticalChance)
                    {
                        StatusLine.AddLine(" " + whoMadeAttack.name + " нанёс критический удар по " + name + "\n");
                        damage *= 2;
                    }
                    StatusLine.AddLine(" " + name + " получил урон " + damage + "\n");
                    if (damage > 0)
                    {
                        helth -= damage;
                    }
                    StatusLine.AddLine(" У " + name + " осталось жизней " + ((helth >= 0) ? Convert.ToString(helth) : " 0") + "\n");
                    if (helth <= 0)
                    {
                        StatusLine.AddLine(" " + name + " убит\n");
                        if (!(this is Player))
                        {
                            Game.player.specification.currentExp += (this as Enemy).expectedExp;
                            if (Game.player.specification.currentExp >= Game.player.specification.maxExp)
                            {
                                ++Game.player.specification.level;
                                ++Game.player.specification.levelPoint;
                                int remainder = Game.player.specification.currentExp - Game.player.specification.maxExp;
                                Game.player.specification.currentExp = remainder;
                            }
                            Game.player.currentGold += (this as Enemy).expectedGold;
                            StatusLine.AddLine(" " + Game.player.name + " получил" +
                                              ((Game.player.specification.gender == EGender.FEMALE) ? "а " : " ") + "опыт: " +
                                              (this as Enemy).expectedExp + ", деньги: " + (this as Enemy).expectedGold + "\n");
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
