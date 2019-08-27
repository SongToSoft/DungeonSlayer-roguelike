using DungeonSlayer.Units.Players;
using DungeonSlayer.Units.Players.Inventory;
using DungeonSlayer.Units.Players.Inventory.Armores;
using DungeonSlayer.Units.Players.Inventory.Helmets;
using DungeonSlayer.Units.Players.Inventory.Weapons;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DungeonSlayer.FileSystem
{
    [DataContract]
    class JsonHero
    {
        [DataMember]
        private int dungeonLevel, attack, evasion, blocking, accuracy, criticalChance, spellPower, levelPoint,
                    gold, level, helth, maxHelth, mana, maxMana, currentExp, maxExp, strength, agility, intelligence,
                    strengthMultiply, agilityMultiply, intelligenceMultiply, itemsCount;
        [DataMember]
        private string name, activeHelmet, activeArmor, activeWeapon;
        [DataMember]
        private EGender gender;
        [DataMember]
        private EClass specialization;
        [DataMember]
        private ERaсe race;
        [DataMember]
        private List<string> itemsName;

        public JsonHero()
        {
            dungeonLevel = Game.maxDungeonLevel;

            name = Game.player.name;
            attack = Game.player.attack;
            evasion = Game.player.evasion;
            blocking = Game.player.blocking;
            accuracy = Game.player.accuracy;
            criticalChance = Game.player.criticalChance;
            gold = Game.player.currentGold;
            level = Game.player.specification.level;
            helth = Game.player.helth;
            maxHelth = Game.player.maxHelth;
            mana = Game.player.mana;
            maxMana = Game.player.maxMana;
            currentExp = Game.player.specification.currentExp;
            maxExp = Game.player.specification.maxExp;
            gender = Game.player.specification.gender;
            specialization = Game.player.specification.specialization;
            race = Game.player.specification.race;
            strength = Game.player.specification.strength;
            agility = Game.player.specification.agility;
            intelligence = Game.player.specification.intelligence;
            spellPower = Game.player.specification.spellPower;
            levelPoint = Game.player.specification.levelPoint;
            strengthMultiply = Game.player.specification.strengthMultiply;
            agilityMultiply = Game.player.specification.agilityMultiply;
            intelligenceMultiply = Game.player.specification.intelligenceMultiply;
            activeHelmet = Game.player.inventory.activeHelmet.name;
            activeArmor = Game.player.inventory.activeArmor.name;
            activeWeapon = Game.player.inventory.activeWeapon.name;

            itemsCount = Game.player.inventory.items.Count;
            itemsName = new List<string>();
            for (int i = 0; i  < itemsCount; ++i)
            {
                itemsName.Add(Game.player.inventory.items[i].name);
            }
        }

        public void SetValuesInPlayer()
        {
            Game.maxDungeonLevel = dungeonLevel;
            Game.player.name = name;

            Game.player.attack = attack;
            Game.player.evasion = evasion;
            Game.player.blocking = blocking;
            Game.player.accuracy = accuracy;
            Game.player.criticalChance = criticalChance;

            Game.player.currentGold = gold;
            Game.player.specification.level = level;
            Game.player.helth = helth;
            Game.player.maxHelth = maxHelth;
            Game.player.mana = mana;
            Game.player.maxMana = maxMana;
            Game.player.specification.currentExp = currentExp;
            Game.player.specification.maxExp = maxExp;
            Game.player.specification.gender = gender;
            Game.player.specification.specialization = specialization;
            Game.player.specification.race = race;
            Game.player.specification.strength = strength;
            Game.player.specification.agility = agility;
            Game.player.specification.intelligence = intelligence;
            Game.player.specification.spellPower = spellPower;
            Game.player.specification.levelPoint = levelPoint;
            Game.player.specification.strengthMultiply = strengthMultiply;
            Game.player.specification.agilityMultiply = agilityMultiply;
            Game.player.specification.intelligenceMultiply = intelligenceMultiply;
            Game.player.inventory.activeHelmet = (Helmet)ItemsList.GetItemByName(activeHelmet);
            Game.player.inventory.activeArmor = (Armor)ItemsList.GetItemByName(activeArmor);
            Game.player.inventory.activeWeapon = (Weapon)ItemsList.GetItemByName(activeWeapon);
            for (int i = 0; i < itemsCount; ++i)
            {
                Game.player.inventory.items.Add(ItemsList.GetItemByName(itemsName[i]));
            }
        }
    }
}
