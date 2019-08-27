using System;
using System.Collections.Generic;

namespace DungeonSlayer.Units.Players.Perks
{
    enum EPerkValue
    {
        EMPTY_PERK,
        //WEAPON_PERKS
        DAGGER_PERK,
        AXE_PERK,
        MACE_PERK,
        SWORD_PERK,
        STAFF_PERK,
        SPEAR_PERK,
        //PASSIVE_PERK
        EVASION_PERK,
        CRITICAL_PERK,
        WEAPON_PERK,
        //OTHER_PERK
        TRADER_PERK,
        DOUBLE_ATTACK_PERK
    }

    static class PerksList
    {
        static public Perk daggerPerk = new Perk(EPerkValue.DAGGER_PERK, "Plus 1 attack for Dagger", 1);
        static public Perk macePerk = new Perk(EPerkValue.MACE_PERK, "Plus 1 attack for Mace", 1);
        static public Perk axePerk = new Perk(EPerkValue.AXE_PERK, "Plus 1 attack for Axe", 1);
        static public Perk swordPerk = new Perk(EPerkValue.SWORD_PERK, "Plus 1 attack for Sword", 1);
        static public Perk staffPerk = new Perk(EPerkValue.STAFF_PERK, "Plus 1 attack for Staff", 1);
        static public Perk traderPerk = new Perk(EPerkValue.TRADER_PERK, "Sale in shops is 10% more effective", 1);
        static public Perk spearPerk = new Perk(EPerkValue.SPEAR_PERK, "Plus 1 attack for Spear", 10);
        static public Perk evasionPerk = new Perk(EPerkValue.EVASION_PERK, "Plus 5% evasion enemys attack", 15);
        static public Perk criticalPerk = new Perk(EPerkValue.CRITICAL_PERK, "Plus 4% critical hit", 20);
        static public Perk weaponPerk = new Perk(EPerkValue.WEAPON_PERK, "Plus 2 attack for all weapons", 25);
        static public Perk doubleAttackPerk = new Perk(EPerkValue.DOUBLE_ATTACK_PERK, "Double attack ", 30);

        static public List<Perk> perks = new List<Perk>()
        {
            daggerPerk,
            macePerk,
            axePerk,
            swordPerk,
            staffPerk,
            spearPerk,
            evasionPerk,
            criticalPerk,
            weaponPerk,
            traderPerk,
            doubleAttackPerk
        };
    }
}
