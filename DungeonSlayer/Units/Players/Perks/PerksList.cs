using System;
using System.Collections.Generic;

namespace DungeonSlayer.Units.Players.Perks
{
    enum EPerkValue
    {
        EMPTY_PERK,
        DAGGER_PERK,
        AXE_PERK,
        MACE_PERK,
        SWORD_PERK,
        STAFF_PERK,
        SPEAR_PERK,
        EVASION_PERK,
        CRITICAL_PERK,
        WEAPON_PERK,
        TRADER_PERK,
        DOUBLE_ATTACK_PERK,
        CANNIBAL_PERK,
        RECEIVER_PERK,
        LUCK_PERK,
        HEAL_PERK,
        HP_PERK,
        MANA_PERK,
        BLOCKING_PERK,
        SPELL_POWER_PERK,
        ALL_RECOVER_HP_PERK,
        ALL_RECOVER_MANA_PERK,
        GIVES_MORE_CHEST_PERK,
        DOUBLE_MISS_PERK
    }

    static class PerksList
    {
        //TODO: Add new perks
        static public Perk daggerPerk = new Perk(EPerkValue.DAGGER_PERK, "Plus 1 attack for Dagger", 5);
        static public Perk macePerk = new Perk(EPerkValue.MACE_PERK, "Plus 1 attack for Mace", 5);
        static public Perk axePerk = new Perk(EPerkValue.AXE_PERK, "Plus 1 attack for Axe", 5);
        static public Perk swordPerk = new Perk(EPerkValue.SWORD_PERK, "Plus 1 attack for Sword", 5);
        static public Perk staffPerk = new Perk(EPerkValue.STAFF_PERK, "Plus 1 attack for Staff", 5);
        static public Perk spearPerk = new Perk(EPerkValue.SPEAR_PERK, "Plus 1 attack for Spear", 5);

        static public Perk traderPerk = new Perk(EPerkValue.TRADER_PERK, "Sale in shops is 10% more effective", 10);
        static public Perk receiverPerk = new Perk(EPerkValue.RECEIVER_PERK, "Plus 20% for all gold and exp that you get", 10);
        static public Perk luckPerk = new Perk(EPerkValue.LUCK_PERK, "Chance get more cool items", 10);
        static public Perk healPerk = new Perk(EPerkValue.HEAL_PERK, "Plus 5 HP and Mana after drink bottles", 10);
        static public Perk hpPerk = new Perk(EPerkValue.HP_PERK, "Plus 20 max HP", 10);
        static public Perk manaPerk = new Perk(EPerkValue.MANA_PERK, "Plus 20 max Mana", 10);

        static public Perk weaponPerk = new Perk(EPerkValue.WEAPON_PERK, "Plus 2 attack for all weapons", 15);
        static public Perk evasionPerk = new Perk(EPerkValue.EVASION_PERK, "Plus 5% evasion enemys attack", 15);
        static public Perk blockingPerk = new Perk(EPerkValue.BLOCKING_PERK, "Plus 3 blocking", 15);
        static public Perk spellPowerPerk = new Perk(EPerkValue.SPELL_POWER_PERK, "Plus 2 spell power", 15);
        static public Perk criticalPerk = new Perk(EPerkValue.CRITICAL_PERK, "Plus 4% critical hit", 15);
        static public Perk cannibalPerk = new Perk(EPerkValue.CANNIBAL_PERK, "Heal 20% HP after kill enemyes", 15);

        static public Perk doubleAttackPerk = new Perk(EPerkValue.DOUBLE_ATTACK_PERK, "Double attack ", 20);
        static public Perk allRecoverHPPerk = new Perk(EPerkValue.ALL_RECOVER_HP_PERK, "Recover all HP after go to new Portal", 20);
        static public Perk allRecoverManaPerk = new Perk(EPerkValue.ALL_RECOVER_MANA_PERK, "Recover all Mana after go to new Portal", 20);
        static public Perk givesMoreChestPerk = new Perk(EPerkValue.GIVES_MORE_CHEST_PERK, "Increase number of chest in every dungeon", 20);
        static public Perk doubleMissPerk = new Perk(EPerkValue.DOUBLE_MISS_PERK, "You have two change for evasion damage", 20);

        static public List<Perk> perks = new List<Perk>()
        {
            daggerPerk,
            macePerk,
            axePerk,
            swordPerk,
            staffPerk,
            spearPerk,
            traderPerk,
            receiverPerk,
            luckPerk,
            healPerk,
            hpPerk,
            manaPerk,
            weaponPerk,
            evasionPerk,
            blockingPerk,
            spellPowerPerk,
            criticalPerk,
            cannibalPerk,
            doubleAttackPerk,
            allRecoverHPPerk,
            allRecoverManaPerk,
            givesMoreChestPerk,
            doubleMissPerk
        };

        static public Perk GetPerkByPerkValue(EPerkValue value)
        {
            for (int i = 0; i < perks.Count; ++i)
            {
                if (perks[i].value == value)
                {
                    return perks[i];
                }
            }
            return perks[0];
        }
    }
}
