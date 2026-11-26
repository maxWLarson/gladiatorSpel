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

    // hp: hit points   ahp: armor points    cowardice: how cowardly you are     bravery: how agressive you are    favor: crowd mood    gadget: which gadget the player is using
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
        {"Medium", 3},
        {"Heavy", 2}
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
    string slamDesc = "Slam!\nActive\nSlam into and shove your opponent, their stance is broken, unable to dodge next turn. Deals 1 damage.";
    string oneFootInTheGrave = "One foot in the grave!\nPassive\nYour damage starts out half as effective, but ramps up to 1.2x when at 60% HP. At 20% HP your damage multiplier becomes 2.5x, but your stamina is halved.";
    #endregion

    #region HeavyGadgets
    string hookNChainDesc = "Hook n' chain!\nActive.\nPull your opponent towards you with a hook on a chain. Opponent is unable to dodge next attack, but so are you.";
    string rampItUpDesc = "Ramp it up!\nPassive\nThe less hp you have, the harder you hit. Health percantage subtracted from a multiplier and rounded down, starts at 0.8 mult.";
    string breakthroughDesc = "Breakthrough!\nActive\nBreak through shields, bypass AHP. Builds up when your hits are blocked, usable after two hits blocked. Does not stack. No cooldown.";
    //By no cooldown I mean no three round cooldown, due to the condition for using it
    #endregion

    #endregion

    #region Weapons

    #region Light weapons

    #region Short sword
    string shortSwordDesc = "Standard short sword, nothing special.";
    Dictionary<string, int> shortSwordAttacks = new()
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
    Dictionary<string, int> daggerAttacks = new()
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

    #region
    #endregion

    #region
    #endregion

    #endregion

    #endregion

    #region Armor
    #endregion
    private static void Main(string[] args)
    {
        //gameplay lightly inspired by your only move is hustle (players pick their move without knowing the others and the moves play out at the same time, leading to you needing to predict what you think the enemy will do.)

    }
}