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

    // hp: hit points   ap: armor points    cowardice: how cowardly you are     bravery: how agressive you are    favor: crowd mood
    int hpP1;
    int apP1;
    int cowardiceP1;
    int braveryP1;
    int favorP1;

    // Ditto, but for player 2 or ai.
    int hpP2;
    int apP2;
    int cowardiceP2;
    int braveryP2;
    int favorP2;
    #endregion

    #region Gladiators

    #endregion
    private static void Main(string[] args)
    {

    }
}