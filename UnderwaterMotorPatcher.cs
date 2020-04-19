using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Harmony;
using UnityEngine;

namespace BetterFins
{
    [HarmonyPatch(typeof(UnderwaterMotor))]
    [HarmonyPatch("AlterMaxSpeed")]
    internal class UnderwaterMotorPatcher
    {
        [HarmonyPostfix]
        public static void _Postfix(UnderwaterMotor __instance)
        {
            __instance.forwardMaxSpeed = 200.0f;
        }
    }

     [HarmonyPatch(typeof(PlayerController))]
     [HarmonyPatch("SetMotorMode")]
     internal class PlayerControllerPatcher
     {
         [HarmonyPostfix]
         public static void _Postfix(PlayerController __instance)
         {
             __instance.underWaterController.forwardMaxSpeed = 200.0f;
         }
     }
}