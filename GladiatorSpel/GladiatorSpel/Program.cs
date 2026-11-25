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

    // Ditto, but for player 2 or ai.
    int hPP2;
    int aHPP2;
    double cowardiceP2;
    double braveryP2;
    double favorP2;
    int gadgetP2;

    //Only used for AI matches. Used for keeping track of which classes the player and AI are playing
    int aiGladiator;
    int playerGladiator;

    //Cowardice and Bravery are used for predicting moves for AI, and affects crowd favor.
    #endregion

    #region Gladiators
    Dictionary<int, int> gladiatorHP = new()
    {
        {0, 125},
        {1, 175},
        {2, 250}
    };

    Dictionary<int, int> gladiatorMobility = new()
    {
        {0, 20},
        {1, 12},
        {2, 5}
    };

    Dictionary<int, string> gladiatorNameAndPlaystyle = new()
    {
        {0, "Light\nHigh damage, nimble, and very fragile. More dodging. Glass cannon."},
        {1, "Medium\nModerate damage, moderate mobility, moderate health. More gadgets. Jack of all trades."},
        {2, "Heavy\nHigh damage, low mobility, high health. More defense. The wall."}
    };
    #endregion

    #region Gadgets

    //After gadgets are triggered they take two rounds to recharge unless stated otherwise (subject to change)

    #region LightGadgets
    string doubleOrNothing = "Double or nothing!\nActive\nDo two attacks, but for each one that gets blocked or dodged you take 10 damage";
    string a = "temp";
    string f = "temp";
    #endregion

    #region MediumGadgets
    string starfinger = "Poke!\nActive\nPoke your enemy in the eye, their accuracy is halved for their next attack.";
    string b = "temp";
    string c = "temp";
    string d = "temp";
    string e = "temp";
    #endregion

    #region HeavyGadgets
    string hookNChainDesc = "Hook n' chain!\nActive.\nPull your opponent towards you with a hook on a chain. Opponent is unable to dodge next attack, but so are you.";
    string rampItUpDesc = "Ramp it up!\nPassive\nThe less hp you have, the harder you hit. Health percantage subtracted from a multiplier and rounded down.";
    string breakthrough = "Breakthrough!\nActive\nBreak through shields, bypass AHP. Builds up when your hits are blocked, usable after two hits blocked. Does not stack. No cooldown.";
    //By no cooldown I mean no three round cooldown, due to the condition for using it
    #endregion

    #endregion
    private static void Main(string[] args)
    {
        //gameplay lightly inspired by your only move is hustle (players pick their move without knowing the others and the moves play out at the same time, leading to you needing to predict what you think the enemy will do.)

    }
}