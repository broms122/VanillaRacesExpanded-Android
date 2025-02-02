﻿using HarmonyLib;
using RimWorld;
using System;
using Verse;

namespace VREAndroids
{
    [HarmonyPatch(typeof(FoodUtility), "WillEat_NewTemp", new Type[] { typeof(Pawn), typeof(ThingDef), typeof(Pawn), typeof(bool), typeof(bool) })]
    public static class FoodUtility_WillEat_ThingDef_Patch
    {
        public static void Postfix(ref bool __result, Pawn p, ThingDef food)
        {
            if (p.IsAndroid())
            {
                __result = false;
            }
        }
    }
}
