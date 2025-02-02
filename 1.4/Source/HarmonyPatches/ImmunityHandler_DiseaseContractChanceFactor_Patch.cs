﻿using HarmonyLib;
using System;
using Verse;

namespace VREAndroids
{
    [HarmonyPatch(typeof(ImmunityHandler), "DiseaseContractChanceFactor", 
        new Type[] { typeof(HediffDef), typeof(HediffDef), typeof(BodyPartRecord)}, 
        new ArgumentType[] { ArgumentType.Normal, ArgumentType.Out, ArgumentType.Normal})]
    public static class ImmunityHandler_DiseaseContractChanceFactor_Patch
    {
        public static void Postfix(ref float __result, ImmunityHandler __instance, HediffDef diseaseDef, ref HediffDef immunityCause, BodyPartRecord part = null)
        {
            if (__instance.pawn.HasActiveGene(VREA_DefOf.VREA_SyntheticImmunity) && Utils.AndroidCanCatch(diseaseDef) is false)
            {
                immunityCause = null;
                __result = 0f;
            }
        }
    }
}
