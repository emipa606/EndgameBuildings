using Verse;

namespace EndgameBuildings;

public class EGB_SettingsData : ModSettings
{
    public float HT_FireFoamPopperRadius = 24.9f;

    public int HT_ReactorOutput = 25000;
    public int HT_ResearchCost = 5000;

    public override void ExposeData()
    {
        Scribe_Values.Look(ref HT_ResearchCost, "HT_ResearchCost", 5000);
        Scribe_Values.Look(ref HT_ReactorOutput, "HT_ReactorPowerOutput", 25000);
        Scribe_Values.Look(ref HT_FireFoamPopperRadius, "HT_FireFoamPopperRadius", 24.9f);
        base.ExposeData();
    }
}
