using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Harmony;
using UnityEngine;

namespace BetterFins
{
    internal static class _
    {
        public const float Patch_FinsMultiplier = 1.015f;
        public const float Patch_UltraGlideFinsMultiplier = 1.035f;
        public const float Patch_AerogelFinsMultiplier = 1.05f;
    }
    
    [HarmonyPatch(typeof(UnderwaterMotor))]
    [HarmonyPatch("UpdateMove")]
    internal class PlayerControllerPatcher
    {
        [HarmonyPostfix]
        public static void Postfix(UnderwaterMotor __instance)
        {
            TechType techTypeInFootSlot = Inventory.main.equipment.GetTechTypeInSlot("Foots");

            if (techTypeInFootSlot == TechType.Fins)
            {
                __instance.rb.velocity *= _.Patch_FinsMultiplier;
            } 
            else if (techTypeInFootSlot == TechType.UltraGlideFins)
            {
                __instance.rb.velocity *= _.Patch_UltraGlideFinsMultiplier;
            } 
            else if (techTypeInFootSlot == AerogelFins._GetTechType())
            {
                __instance.rb.velocity *= _.Patch_AerogelFinsMultiplier;
            }
        }
    }
}