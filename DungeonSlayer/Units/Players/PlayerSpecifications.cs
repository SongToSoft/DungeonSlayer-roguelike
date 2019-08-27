using DungeonSlayer.Units.Players.Inventory;
using DungeonSlayer.Units.Players.Magics;
using DungeonSlayer.Units.Players.Perks;
using System;

namespace DungeonSlayer.Units.Players
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
        VAMPIRE,
        MAG,
        WARLOCK,
        NOBODY
    }
    
    enum ERaсe
    {
        HUMAN,
        ELF,
        DWARF,
        ORC,
        TROLL,
        GOBLIN,
    }

    class PlayerSpecifications
    {
        public int level = 1;
        public int currentExp = 0;
        public int maxExp = 10;
        public EGender gender = EGender.MALE;
        public EClass specialization = EClass.KNIGHT;
        public ERaсe race = ERaсe.HUMAN;
        public int strength = 1, agility = 1, intelligence = 1;
        public int spellPower = 1;
        public int levelPoint = 0;
        public int perkMultiply = 0, strengthMultiply = 0, agilityMultiply = 0, intelligenceMultiply = 0;
        public int perkMultiplyMax = 5, strengthMultiplyMax = 2, agilityMultiplyMax = 4, intelligenceMultiplyMax = 3;

        public void SetGender(EGender _gender)
        {
            gender = _gender;
            switch (gender)
            {
                case EGender.MALE:
                    IncreaseStrength(1);
                    break;
                case EGender.FEMALE:
                    IncreaseAgility(1);
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
                    Game.player.inventory.SetActiveArmor(ItemsList.ironArmor);
                    Game.player.inventory.SetActiveHelmet(ItemsList.ironHelmet);
                    Game.player.inventory.SetActiveWeapon(ItemsList.ironSword);
                    break;
                case EClass.BARBARIAN:
                    IncreaseStrength(2);
                    Game.player.inventory.SetActiveArmor(ItemsList.leatherArmor);
                    Game.player.inventory.SetActiveWeapon(ItemsList.ironMace);
                    break;
                case EClass.PATHFINDER:
                    IncreaseAgility(2);
                    Game.player.inventory.SetActiveArmor(ItemsList.leatherArmor);
                    Game.player.inventory.SetActiveHelmet(ItemsList.leatherHelmet);
                    Game.player.inventory.SetActiveWeapon(ItemsList.ironDagger);
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
                    IncreaseAgility(1);
                    IncreaseIntelligence(1);
                    Game.player.perksSystem.AddPerk(PerksList.daggerPerk);
                    break;
                case ERaсe.DWARF:
                    IncreaseStrength(2);
                    Game.player.perksSystem.AddPerk(PerksList.macePerk);
                    Game.player.perksSystem.AddPerk(PerksList.axePerk);
                    break;
                case ERaсe.ORC:
                    IncreaseStrength(5);
                    Game.player.perksSystem.AddPerk(PerksList.macePerk);
                    Game.player.blocking = 5;
                    Game.player.evasion = 0;
                    break;                   
                case ERaсe.TROLL:
                    //TODO: End of this race
                    Game.player.perksSystem.AddPerk(PerksList.spearPerk);
                    Game.player.perksSystem.AddPerk(PerksList.doubleAttackPerk);
                    Game.player.criticalChance = 10;
                    break;
                case ERaсe.GOBLIN:
                    IncreaseAgility(3);
                    Game.player.maxHelth -= 30;
                    Game.player.helth -= 30;
                    Game.player.evasion += 3;
                    Game.player.magicSystem.AddSpell(MagicList.healMagic);
                    break;
            }
        }

        public void IncreaseStrength(int value, bool isItem = false)
        {
            strength += value;
            Game.player.maxHelth += (value * 3);
            if (!isItem)
            {
                ++strengthMultiply;
                if (strengthMultiply == strengthMultiplyMax)
                {
                    ++Game.player.attack;
                    strengthMultiply = 0;
                    Console.WriteLine(" +1 Attack");
                }
            }
        }

        public void IncreaseAgility(int value, bool isItem = false)
        {
            agility += value;
            if (!isItem)
            {
                ++agilityMultiply;
                if (agilityMultiply == agilityMultiplyMax)
                {
                    if (race != ERaсe.ORC)
                    {
                        ++Game.player.evasion;
                        Console.WriteLine(" +1 Evasion");
                    }
                    ++Game.player.criticalChance;
                    Console.WriteLine(" +1 Critical chance");
                }
            }     
        }

        public void IncreaseIntelligence(int value, bool isItem = false)
        {
            intelligence += value;
            Game.player.maxMana += (value * 4);
            if (!isItem)
            {
                ++intelligenceMultiply;
                if (intelligenceMultiply == intelligenceMultiplyMax)
                {
                    Console.WriteLine(" +1 Spell power");
                    ++spellPower;
                }
                if (intelligenceMultiply == (intelligenceMultiplyMax * 2))
                {
                    ++spellPower;
                    ++Game.player.magicSystem.magicPoint;
                    Console.WriteLine(" +1 New Spell");
                    intelligenceMultiply = 0;
                }
            }
        }

        public void LevelUp()
        {
            if (levelPoint > 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Game.consoleBuffer = new char[Game.consoleHeight, Game.consoleWidth];
                ++perkMultiply;
                Console.WriteLine(" Your have level points: " + levelPoint);
                Console.WriteLine(" Chose stat for UP:");
                Console.WriteLine(" [1] - Strength: +3 for Max Helth, Up attack: " + strengthMultiply + " / " + strengthMultiplyMax);
                Console.WriteLine(" [2] - Agility: Up critical chance" + ((race != ERaсe.ORC) ? ": " : "and critical chance: ") + agilityMultiply + " / " + agilityMultiplyMax);
                Console.WriteLine(" [3] - Intelligence: +4 for Max Mana, Up spell power: " +
                                   (intelligenceMultiply % 3) + " / " + intelligenceMultiplyMax +
                                   ", Get new Spell: " + intelligenceMultiply + " / " + (intelligenceMultiplyMax * 2));
                Console.WriteLine(" Every 5 lelev you get new perk");
                bool choseStat = true;
                while (choseStat)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    char command = Console.ReadKey(true).KeyChar;
                    int attributeIndex = command - '0';
                    if ((attributeIndex > 0) && (attributeIndex < 4))
                    {
                        switch (attributeIndex)
                        {
                            case 1:
                                Console.WriteLine(" Increase Strength");
                                IncreaseStrength(1);
                                break;
                            case 2:
                                Console.WriteLine(" Increase Agility");
                                IncreaseAgility(1);
                                break;
                            case 3:
                                Console.WriteLine(" Increase Intelligence");
                                IncreaseIntelligence(1);
                                break;
                        }
                        --levelPoint;
                        if (perkMultiply == perkMultiplyMax)
                        {
                            ++Game.player.perksSystem.perksPoint;
                            perkMultiply = 0;
                            Console.WriteLine(" You can chose new Perk in Perks List");
                        }
                        maxExp += 5;
                        choseStat = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorrect value");
                    }
                }
                Console.ReadKey();
            }
        }
    }
}
