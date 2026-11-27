internal class Program
{
    /*
     * gladiatorernas egenskaper påverkar vilka strategier som fungerar
     * 
     * vapen, rustning och specialförmågor samverkar,
     * 
     * motståndarens AI analyserar situationen och fattar olika beslut,
     * 
     * sparad information påverkar spelet när det startas igen,
     * 
     * ett prestationssystem håller reda på spelarens framsteg,
     * 
     * flera Dictionaries används för att modellera spelets information,
     */
    #region Variables
    bool singelplayer;

    /* hp: hit points
     * ahp: armor points
     * cowardice: how cowardly you are
     * bravery: how agressive you are
     * favor: crowd mood
     * gadget: which gadget the player is using
     * stamina: stamina
     */
    int hPP1;
    int aHPP1;
    double cowardiceP1;
    double braveryP1;
    double favorP1;
    int gadgetP1;
    double staminaP1;

    // Ditto, but for player 2 or ai.
    int hPP2;
    int aHPP2;
    double cowardiceP2;
    double braveryP2;
    double favorP2;
    int gadgetP2;
    double staminaP2;

    //Only used for AI matches. Used for keeping track of which classes the player and AI are playing
    int aiGladiator;
    int playerGladiator;

    //Cowardice and Bravery are used for predicting moves for AI, and affects crowd favor.
    #endregion

    #region Gladiators
    Dictionary<string, int> gladiatorHP = new()
    {
        {"Light", 125},
        {"Medium", 175},
        {"Heavy", 250}
    };

    Dictionary<string, double> gladiatorStamina = new()
    {
        {"Light", 4.5},
        {"Medium", 4},
        {"Heavy", 3.5}
    };

    Dictionary<int, string> gladiatorNameAndPlaystyle = new()
    {
        {0, "Light\nHigh damage, nimble, and very fragile. More dodging. Glass cannon."},
        {1, "Medium\nModerate damage, moderate mobility, moderate health. More gadgets, can have two at once. Jack of all trades."},
        {2, "Heavy\nHigh damage, low mobility, high health. More defense. The wall."}
    };
    #endregion

    #region Gadgets

    //After gadgets are triggered they take three rounds to recharge unless stated otherwise
    #region LightGadgets
    string doubleOrNothingDesc = "Double or nothing!\nActive\nDo two attacks, but for each one that gets blocked or dodged you take 10 damage";
    string punishDesc = "Punish!\nActive\nNext round if your opponent attacks you, you counter, dealing 20% of the enemies HP, regardless of AHP. Shows up as a normal wait.";
    string cower = "Cower.\nPassive\nWhen at or below 10% hp pull back and heal for 20%. Greatly reduces crowd favor.";
    #endregion

    #region MediumGadgets
    string starFingerDesc = "Poke!\nActive\nPoke your enemy in the eye, their accuracy is reduced by 20% for their next attack. Deals 1 damage.";
    string midFightSnackDesc = "Mid fight snack.\nActive\nHeal yourself, and recover some stamina. can only be used twice.";
    string onARollDesc = "On a roll!\nActive\nWhen you have succesfully hit your opponent two times you can break through guards once, 50% of your damage will penetrate guards and AHP. Does not stack, no cooldown.";
    string slamDesc = "Slam!\nActive\nSlam into and shove your opponent, their stance is broken, unable to dodge next turn. Deals 10 damage.";
    string oneFootInTheGrave = "One foot in the grave!\nPassive\nYour damage starts out half as effective, but ramps up to 1.2x when at 60% HP. At 20% HP your damage multiplier becomes 2.5x, but your stamina is halved.";
    #endregion

    #region HeavyGadgets
    string hookNChainDesc = "Hook n' chain!\nActive.\nPull your opponent towards you with a hook on a chain. Opponent is unable to dodge next attack, but so are you.";
    string rampItUpDesc = "Ramp it up!\nPassive\nThe less hp you have, the harder you hit. Health percantage subtracted from a multiplier and rounded down, starts at 0.8 mult.";
    string breakthroughDesc = "Breakthrough!\nActive\nBreak through shields, bypass AHP. Builds up when your hits are blocked, usable after two hits blocked. Does not stack. No cooldown.";
    #endregion

    #endregion

    #region Weapons

    #region Light weapons

    #region Short sword
    string shortSwordDesc = "Standard short sword, nothing special.";
    Dictionary<string, int> shortSwordADamage = new()
    {
        {"Stab", 60},
        {"kick", 40}
    };
    Dictionary<string, double> shortSwordStam = new()
    {
        {"Stab", 1},
        {"kick", 0.8}
    };
    #endregion

    #region Dagger
    string daggerDesc = "Small dagger, less powerful normal attacks, but has a slash attack. Increases stamina by 0.8";
    Dictionary<string, int> daggerDamage = new()
    {
        {"Stab", 50},
        {"Kick", 40},
        {"Slash", 70}
    };
    Dictionary<string, double> daggerStam = new()
    {
        {"Stab", 1},
        {"kick", 0.8},
        {"slash", 1.4}
    };
    #endregion

    #endregion

    #region Medium weapons

    #region Longsword
    string longswordDesc = "Longsword\nA standard longsword.";
    Dictionary<string, int> longswordDamage = new()
    {
        {"Stab", 60},
        {"Kick", 40}
    };
    Dictionary<string, double> longswordStam = new()
    {
        {"Stab", 1},
        {"Kick", 0.8}
    };
    #endregion

    #region Pike
    string pikeDesc = "A pike, a long stick with a sharp metal tip. Allows you to attack while dodging, at the cost of more stamina. Also a bit cowardly.";
    Dictionary<string, int> PikeDamage = new()
    {
        {"Stab", 55},
        {"Kick", 40},
        {"Dodgestab", 20}
    };
    Dictionary<string, double> PikeStam = new()
    {
        {"Stab", 1},
        {"Kick", 0.8},
        {"Dodgestab", 1.4}
    };
    #endregion

    #endregion

    #region Heavy weapons

    #region Mace
    string maceDesc = "A heavy and powerful mace. Has a poweful but tiring overhead attack.";
    Dictionary<string, int> maceDamage = new()
    {
        {"Slam", 75},
        {"Kick", 45},
        {"Overhead", 90}
    };
    Dictionary<string, double> maceStam = new()
    {
        {"Slam", 0.5},
        {"Kick", 0.4},
        {"Overhead", 1.2}
    };
    #endregion

    #region Halberd
    string halberdDesc = "";
    Dictionary<string, int> halberdDamage = new()
    {
        {"Chop", 75},
        {"Kick", 40}
    };
    Dictionary<string, double> halberdStam = new()
    {
        {"Slam", 0.5},
        {"Kick", 0.4}
    };
    #endregion

    #endregion

    #endregion

    #region Armor

    #region Light armor
    string lightLeatherManicaDesc = "A leather manica, covers the arm. Light and mobile, moderate protection. +60 AHP, -0.4 stamina.";
    string lightMetalManicaDesc = "A metal manica. Heavy, but still mobile. +80 AHP, -0.8 stamina.";
    Dictionary<string, int> lightArmorAHP = new()
    {
        {"Leather manica", 60},
        {"Metal manica", 80}
    };
    Dictionary<string, double> lightArmorStamDeb = new()
    {
        {"Leather manica", 0.4},
        {"Metal manica", 0.8}
    };
    Dictionary<string, double> lightArmorDodgeMult = new()
    {
        {"Leather manica", 1.0},
        {"Metal manica", 1.0}
    };
    #endregion

    #region Medium armor
    string mediumMetalManicaDesc = "A metal manica, covers the arm. Heavy, but still mobile. +80 AHP, -0.8 stamina.";
    string mediumMetalBreastplateDesc = "A metal breastplate, covers the front of the torso. +100 AHP, -0.8 stamina, 0.9x dodge mult.";
    Dictionary<string, int> mediumArmorAHP = new()
    {
        {"Metal manica", 80},
        {"Metal breastplate", 100}
    };
    Dictionary<string, double> mediumArmorStamDeb = new()
    {
        {"Metal manica", 0.8},
        {"Metal breastplate", 0.8}
    };
    Dictionary<string, double> mediumArmorDodgeMult = new()
    {
        {"Metal manica", 1.0},
        {"Metal chestplate", 0.9}
    };
    #endregion

    #region Heavy armor
    string heavyMetalManicaDesc = "A metal manica. Protects the arm. +100 AHP, -0.2 stamina, 0.9x dodge chance.";
    string heavyBreastplateDesc = "A metal breastplate. Protects the fron of the torso. +120 AHP, -0.4 stamina, 0.8x dodge chance.";
    string heavyBreastplateAndManicaDesc = "A metal breastplate, paired with a metal manica. Protects the front of the torso, and the arm. +160 AHP, -0.6 stamina, 0.7x dodge chance.";
    Dictionary<string, int> heavyArmorAHP = new()
    {
        {"Metal manica", 100},
        {"Metal breastplate", 120},
        {"Metal breastplate with manica", 160}
    };
    Dictionary<string, double> heavyArmorStamDeb = new()
    {
        {"Metal manica", 0.2},
        {"Metal breastplate", 0.4},
        {"Metal breastplate with manica", 0.6}
    };
    Dictionary<string, double> heavyArmorDodgeMult = new()
    {
        {"Metal manica", 0.9},
        {"Metal breastplate", 0.8},
        {"Metal breastplate with manica", 0.7}
    };
    #endregion

    #endregion
    private static void Main(string[] args)
    {
        //gameplay lightly inspired by your only move is hustle (players pick their move without knowing the others and the moves play out at the same time, leading to you needing to predict what you think the enemy will do.)

    }
}