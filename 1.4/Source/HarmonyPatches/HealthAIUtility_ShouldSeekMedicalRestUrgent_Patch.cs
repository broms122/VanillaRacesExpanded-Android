﻿using HarmonyLib;
using RimWorld;
using Verse;

namespace VREAndroids
{
    [HarmonyPatch(typeof(HealthAIUtility), "ShouldSeekMedicalRestUrgent")]
    public static class HealthAIUtility_ShouldSeekMedicalRestUrgent_Patch
    {
        public static void Postfix(Pawn pawn, ref bool __result)
        {
            if (pawn.health.hediffSet.GetFirstHediffOfDef(VREA_DefOf.VREA_NeutroLoss) != null)
            {
                __result = true;
            }
        }
    }
}
