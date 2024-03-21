using System;
using System.Linq;
using HarmonyLib;
using RimWorld;
using Verse;

namespace EndgameBuildings;

[StaticConstructorOnStartup]
public class EGB_OnDefsLoaded
{
    static EGB_OnDefsLoaded()
    {
        ApplySettingsToDefs();
    }

    public static void ApplySettingsToDefs()
    {
        AccessTools.Field(typeof(CompProperties_Power), "basePowerConsumption").SetValue(
            DefDatabase<ThingDef>.GetNamed("SE_FusionReactor").comps.OfType<CompProperties_Power>().First(),
            -Math.Abs(EGB_Settings.Settings.HT_ReactorOutput));
        var named = DefDatabase<ThingDef>.GetNamed("FirefoamPopperMKII");
        named.comps.OfType<CompProperties_Explosive>().First().explosiveRadius =
            EGB_Settings.Settings.HT_FireFoamPopperRadius;
        named.specialDisplayRadius = EGB_Settings.Settings.HT_FireFoamPopperRadius;
    }
}