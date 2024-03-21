using Mlie;
using UnityEngine;
using Verse;

namespace EndgameBuildings;

public class EGB_Settings : Mod
{
    private const float MAX_FIREFOAM_POPPER_RADIUS = 56f;
    public static EGB_SettingsData Settings;
    private static string currentVersion;

    public EGB_Settings(ModContentPack content)
        : base(content)
    {
        Settings = GetSettings<EGB_SettingsData>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(inRect);
        var buffer = Settings.HT_ResearchCost.ToString();
        listing_Standard.TextFieldNumericLabeled("EGB_HTResearchCost".Translate(), ref Settings.HT_ResearchCost,
            ref buffer, 0f, 100000f);
        listing_Standard.Gap();
        var buffer2 = Settings.HT_ReactorOutput.ToString();
        listing_Standard.TextFieldNumericLabeled("EGB_HTReactorOutput".Translate(), ref Settings.HT_ReactorOutput,
            ref buffer2, 1f, 999999f);
        listing_Standard.Gap();
        var buffer3 = Settings.HT_FireFoamPopperRadius.ToString();
        listing_Standard.TextFieldNumericLabeled(
            "EGB_HT_FireFoamPopperRadius".Translate() + Settings.HT_FireFoamPopperRadius.ToString(),
            ref Settings.HT_FireFoamPopperRadius, ref buffer3, 1f, MAX_FIREFOAM_POPPER_RADIUS);
        listing_Standard.Gap();
        Settings.HT_FireFoamPopperRadius =
            listing_Standard.Slider(Settings.HT_FireFoamPopperRadius, 1f, MAX_FIREFOAM_POPPER_RADIUS);
        EGB_OnDefsLoaded.ApplySettingsToDefs();
        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("EGB_CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
        base.DoSettingsWindowContents(inRect);
    }

    public override string SettingsCategory()
    {
        return "EGB_SettingsCategory".Translate();
    }
}