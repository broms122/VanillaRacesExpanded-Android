﻿using HarmonyLib;
using RimWorld;
using Verse;

namespace VREAndroids
{
    [HarmonyPatch(typeof(Pawn_StoryTracker), "ExposeData")]
    public static class Pawn_StoryTracker_ExposeData_Patch
    {
        public static void Prefix(Pawn_StoryTracker __instance)
        {
            if (Scribe.mode == LoadSaveMode.PostLoadInit)
            {
                if (__instance.pawn != null && __instance.pawn.IsAndroid())
                {
                    __instance.pawn.ageTracker.RecalculateLifeStageIndex();
                }
            }
        }
    }
}
