using Verse;

namespace EndgameBuildings;

public class EGB_SettingsData : ModSettings
{
    public float HtFireFoamPopperRadius = 24.9f;

    public int HtReactorOutput = 25000;
    public int HtResearchCost = 5000;

    public override void ExposeData()
    {
        Scribe_Values.Look(ref HtResearchCost, "HT_ResearchCost", HtResearchCost);
        Scribe_Values.Look(ref HtReactorOutput, "HT_ReactorPowerOutput", HtReactorOutput);
        Scribe_Values.Look(ref HtFireFoamPopperRadius, "HT_FireFoamPopperRadius", HtFireFoamPopperRadius);
        base.ExposeData();
    }
}