﻿using HarmonyLib;
using RimWorld;
using System.Linq;
using Verse;

namespace VREAndroids
{
    [HarmonyPatch(typeof(MedicalRecipesUtility), "SpawnThingsFromHediffs")]
    public static class MedicalRecipesUtility_SpawnThingsFromHediffs_Patch
    {
        public static bool shouldCheck;
        public static bool Prefix(Pawn pawn, BodyPartRecord part, IntVec3 pos, Map map)
        {
            if (pawn.IsAndroid())
            {
                SpawnThingsFromHediffs(pawn, part, pos, map);
                return false;
            }
            return true;
        }

        public static void SpawnThingsFromHediffs(Pawn pawn, BodyPartRecord part, IntVec3 pos, Map map)
        {
            if (!pawn.health.hediffSet.GetNotMissingParts().Contains(part))
            {
                return;
            }
            foreach (Hediff item in pawn.health.hediffSet.hediffs.Where((Hediff x) => x.Part == part))
            {
                if (item is Hediff_AndroidReactor reactor)
                {
                    pawn.TrySpawnWaste(pos, map);
                }
                else if (item.def.spawnThingOnRemoved != null)
                {
                    GenSpawn.Spawn(item.def.spawnThingOnRemoved, pos, map);
                }
            }
        }
    }
}
