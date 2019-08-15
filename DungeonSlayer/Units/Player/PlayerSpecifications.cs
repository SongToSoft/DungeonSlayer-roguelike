using DungeonSlayer.Units.Player.Inventory.Armores;
using DungeonSlayer.Units.Player.Inventory.Helmets;
using DungeonSlayer.Units.Player.Inventory.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer
{
    enum EGender
    {
        MALE,
        FEMALE
    }

    enum EClass
    {
        KNIGHT,
        BARBARIAN,
        PATHFINDER,
        NOBODY
    }
    
    enum ERaсe
    {
        HUMAN,
        ELF,
        DWARF
    }

    class PlayerSpecifications
    {
        public int level = 1;
        public int currentExp = 0;
        public int maxExp = 100;
        public EGender gender = EGender.MALE;
        public EClass specialization = EClass.KNIGHT;
        public ERaсe race = ERaсe.HUMAN;
        public int strength = 1, agility = 1, intelligence = 1;
        public int spellPower = 1;

        public int strengthMultiply = 0, agilityMultiply = 0, intelligenceMultiply = 0;
        public void SetGender(EGender _gender)
        {
            gender = _gender;
            switch (gender)
            {
                case EGender.MALE:
                    ++strength;
                    break;
                case EGender.FEMALE:
                    ++agility;
                    break;
            }
        }

        public void SetSpecialization(EClass _specialization)
        {
            specialization = _specialization;
            switch (specialization)
            {
                case EClass.KNIGHT:
                    IncreaseStrength(1);
                    IncreaseAgility(1);
                    Game.player.inventory.SetActiveArmor(ArmorList.ironArmor);
                    Game.player.inventory.SetActiveHelmet(HelmetList.ironHelmet);
                    Game.player.inventory.SetActiveWeapon(WeaponList.ironSword);
                    break;
                case EClass.BARBARIAN:
                    IncreaseStrength(2);
                    Game.player.inventory.SetActiveArmor(ArmorList.leatherArmor);
                    Game.player.inventory.SetActiveWeapon(WeaponList.ironMace);
                    break;
                case EClass.PATHFINDER:
                    IncreaseAgility(2);
                    Game.player.inventory.SetActiveArmor(ArmorList.leatherArmor);
                    Game.player.inventory.SetActiveHelmet(HelmetList.leatherHelmet);
                    Game.player.inventory.SetActiveWeapon(WeaponList.ironDagger);
                    break;
                case EClass.NOBODY:
                    break;
            }
        }

        public void SetRace(ERaсe _race)
        {
            race = _race;
            switch (race)
            {
                case ERaсe.HUMAN:
                    Game.player.maxHelth += 20;
                    Game.player.helth += 20;
                    Game.player.maxMana += 20;
                    Game.player.mana += 20;
                    break;
                case ERaсe.ELF:
                    ++agility;
                    ++intelligence;
                    break;
                case ERaсe.DWARF:
                    strength += 2;
                    break;
            }
        }

        public void IncreaseStrength(int value)
        {
            strength += value;
            Game.player.helth += (value * 3);
            ++strengthMultiply;
            if (strengthMultiply == 4)
            {
                ++Game.player.attack;
                strengthMultiply = 0;
            }
        }

        public void IncreaseAgility(int value)
        {
            agility += value;
            ++agilityMultiply;
            if (agilityMultiply == 2)
            {
                ++Game.player.attack;
            }
            else
            {
                if (agilityMultiply == 4)
                {
                    ++Game.player.attack;
                    ++Game.player.evasion;
                    agilityMultiply = 0;
                }
            }          
        }

        public void IncreaseIntelegence(int value)
        {
            intelligence += value;
            Game.player.mana += (value * 4);
            ++intelligenceMultiply;
            if (intelligenceMultiply == 3)
            {
                ++spellPower;
                intelligenceMultiply = 0;
            }
        }
    }
}
