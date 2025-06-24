using Mlie;
using UnityEngine;
using Verse;

namespace EndgameBuildings;

public class EGB_Settings : Mod
{
    private const float MaxFirefoamPopperRadius = 56f;
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
        var buffer = Settings.HtResearchCost.ToString();
        listing_Standard.TextFieldNumericLabeled("EGB_HTResearchCost".Translate(), ref Settings.HtResearchCost,
            ref buffer, 0f, 100000f);
        listing_Standard.Gap();
        var buffer2 = Settings.HtReactorOutput.ToString();
        listing_Standard.TextFieldNumericLabeled("EGB_HTReactorOutput".Translate(), ref Settings.HtReactorOutput,
            ref buffer2, 1f, 999999f);
        listing_Standard.Gap();
        var buffer3 = Settings.HtFireFoamPopperRadius.ToString();
        listing_Standard.TextFieldNumericLabeled(
            "EGB_HT_FireFoamPopperRadius".Translate() + Settings.HtFireFoamPopperRadius.ToString(),
            ref Settings.HtFireFoamPopperRadius, ref buffer3, 1f, MaxFirefoamPopperRadius);
        listing_Standard.Gap();
        Settings.HtFireFoamPopperRadius =
            listing_Standard.Slider(Settings.HtFireFoamPopperRadius, 1f, MaxFirefoamPopperRadius);
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