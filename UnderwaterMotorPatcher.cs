using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Harmony;
using UnityEngine;

namespace SubnauticaSpeed
{
     /**
        IL Instructions from UnderwaterMotor.AlterMaxSpeed(float32 inMaxSpeed)
        
        IL_0000: ldarg.1
        IL_0001: stloc.0
        IL_0002: ldsfld    class Inventory Inventory::main
        IL_0007: stloc.1
        IL_0008: ldloc.1
        IL_0009: callvirt  instance class Equipment Inventory::get_equipment()
        IL_000E: stloc.2
        IL_000F: ldloc.1
        IL_0010: callvirt  instance class ItemsContainer Inventory::get_container()
        IL_0015: stloc.3
        IL_0016: ldloc.2
        IL_0017: ldstr     "Tank"
        IL_001C: callvirt  instance valuetype TechType Equipment::GetTechTypeInSlot(string)
        IL_0021: stloc.s   V_4
        IL_0023: ldloc.s   V_4
        IL_0025: ldc.i4    528
        IL_002A: bgt.s     IL_0040

        IL_002C: ldloc.s   V_4
        IL_002E: ldc.i4    503
        IL_0033: beq.s     IL_005E

        IL_0035: ldloc.s   V_4
        IL_0037: ldc.i4    528
        IL_003C: beq.s     IL_0068

        IL_003E: br.s      IL_007A

        IL_0040: ldloc.s   V_4
        IL_0042: ldc.i4    803
        IL_0047: beq.s     IL_0054

        IL_0049: ldloc.s   V_4
        IL_004B: ldc.i4    804
        IL_0050: beq.s     IL_0072

        IL_0052: br.s      IL_007A

        IL_0054: ldloc.0
        IL_0055: ldc.r4    0.10625
        IL_005A: sub
        IL_005B: stloc.0
        IL_005C: br.s      IL_007A

        IL_005E: ldloc.0
        IL_005F: ldc.r4    0.425
        IL_0064: sub
        IL_0065: stloc.0
        IL_0066: br.s      IL_007A

        IL_0068: ldloc.0
        IL_0069: ldc.r4    0.5
        IL_006E: sub
        IL_006F: stloc.0
        IL_0070: br.s      IL_007A

        IL_0072: ldloc.0
        IL_0073: ldc.r4    0.6375
        IL_0078: sub
        IL_0079: stloc.0

        IL_007A: ldloc.3
        IL_007B: ldc.i4    804
        IL_0080: callvirt  instance int32 ItemsContainer::GetCount(valuetype TechType)
        IL_0085: stloc.s   V_5
        IL_0087: ldloc.0
        IL_0088: ldloc.s   V_5
        IL_008A: conv.r4
        IL_008B: ldc.r4    1.275
        IL_0090: mul
        IL_0091: sub
        IL_0092: stloc.0
        IL_0093: ldloc.0
        IL_0094: ldc.r4    2
        IL_0099: bge.un.s  IL_00A1

        IL_009B: ldc.r4    2
        IL_00A0: stloc.0

        IL_00A1: ldloc.2
        IL_00A2: ldstr     "Body"
        IL_00A7: callvirt  instance valuetype TechType Equipment::GetTechTypeInSlot(string)
        IL_00AC: stloc.s   V_6
        IL_00AE: ldloc.s   V_6
        IL_00B0: ldc.i4    522
        IL_00B5: bne.un.s  IL_00C9

        IL_00B7: ldc.r4    2
        IL_00BC: ldloc.0
        IL_00BD: ldc.r4    1
        IL_00C2: sub
        IL_00C3: call      float32 [UnityEngine.CoreModule]UnityEngine.Mathf::Max(float32, float32)
        IL_00C8: stloc.0

        IL_00C9: ldc.r4    1
        IL_00CE: stloc.s   V_7
        IL_00D0: ldloca.s  V_7
        IL_00D2: call      void Utils::AdjustSpeedScalarFromWeakness(float32&)
        IL_00D7: ldloc.0
        IL_00D8: ldloc.s   V_7
        IL_00DA: mul
        IL_00DB: stloc.0
        IL_00DC: ldloc.2
        IL_00DD: ldstr     "Foots"
        IL_00E2: callvirt  instance valuetype TechType Equipment::GetTechTypeInSlot(string)
        IL_00E7: stloc.s   V_8
        IL_00E9: ldloc.s   V_8
        IL_00EB: ldc.i4    502
        IL_00F0: beq.s     IL_00FD

        IL_00F2: ldloc.s   V_8
        IL_00F4: ldc.i4    805
        IL_00F9: beq.s     IL_0107

        IL_00FB: br.s      IL_010F

        IL_00FD: ldloc.0
        IL_00FE: ldc.r4    1.5
        IL_0103: add
        IL_0104: stloc.0
        IL_0105: br.s      IL_010F

        IL_0107: ldloc.0
        IL_0108: ldc.r4    2.5
        IL_010D: add
        IL_010E: stloc.0

        IL_010F: ldloc.1
        IL_0110: callvirt  instance class PlayerTool Inventory::GetHeldTool()
        IL_0115: ldnull
        IL_0116: call      bool [UnityEngine.CoreModule]UnityEngine.Object::op_Equality(class [UnityEngine.CoreModule]UnityEngine.Object, class [UnityEngine.CoreModule]UnityEngine.Object)
        IL_011B: brfalse.s IL_0125

        IL_011D: ldloc.0
        IL_011E: ldc.r4    1
        IL_0123: add
        IL_0124: stloc.0

        IL_0125: ldarg.0
        IL_0126: call      instance class [UnityEngine.CoreModule]UnityEngine.GameObject [UnityEngine.CoreModule]UnityEngine.Component::get_gameObject()
        IL_012B: callvirt  instance class [UnityEngine.CoreModule]UnityEngine.Transform [UnityEngine.CoreModule]UnityEngine.GameObject::get_transform()
        IL_0130: callvirt  instance valuetype [UnityEngine.CoreModule]UnityEngine.Vector3 [UnityEngine.CoreModule]UnityEngine.Transform::get_position()
        IL_0135: ldfld     float32 [UnityEngine.CoreModule]UnityEngine.Vector3::y
        IL_013A: ldsfld    class Ocean Ocean::main
        IL_013F: callvirt  instance float32 Ocean::GetOceanLevel()
        IL_0144: ble.un.s  IL_014E

        IL_0146: ldloc.0
        IL_0147: ldc.r4    1.3
        IL_014C: mul
        IL_014D: stloc.0

        IL_014E: ldc.r4    1
        IL_0153: stloc.s   V_9
        IL_0155: ldsfld    class Player Player::main
        IL_015A: callvirt  instance string Player::GetBiomeString()
        IL_015F: ldstr     "wreck"
        IL_0164: call      bool [mscorlib]System.String::op_Equality(string, string)
        IL_0169: brfalse.s IL_0172

        IL_016B: ldc.r4    0.5
        IL_0170: stloc.s   V_9

        IL_0172: ldarg.0
        IL_0173: ldarg.0
        IL_0174: ldfld     float32 UnderwaterMotor::currentWreckSpeedMultiplier
        IL_0179: ldloc.s   V_9
        IL_017B: ldc.r4    0.3
        IL_0180: call      float32 [UnityEngine.CoreModule]UnityEngine.Time::get_deltaTime()
        IL_0185: mul
        IL_0186: call      float32 ['Assembly-CSharp-firstpass']UWE.Utils::Slerp(float32, float32, float32)
        IL_018B: stfld     float32 UnderwaterMotor::currentWreckSpeedMultiplier
        IL_0190: ldloc.0
        IL_0191: ldarg.0
        IL_0192: ldfld     float32 UnderwaterMotor::currentWreckSpeedMultiplier
        IL_0197: mul
        IL_0198: stloc.0
        IL_0199: ldloc.0
        IL_019A: ret
     */
    
    [HarmonyPatch(typeof(UnderwaterMotor))]
    [HarmonyPatch("AlterMaxSpeed")]
    internal class UnderwaterMotorPatcher
    {
        // [HarmonyTranspiler]
        // public static IEnumerable<CodeInstruction> _AlterMaxSpeed(IEnumerable<CodeInstruction> instructions)
        // {
        //     if (Inventory.main.equipment.GetTechTypeInSlot("Foot") != AerogelFins._GetTechType()) return instructions;
        //     
        //     bool foundFins = false;
        //     List<CodeInstruction> codes = instructions.ToList();
        //
        //     for (var i = 0; i < codes.Count; i++)
        //     {
        //         CodeInstruction instruct = codes[i];
        //
        //         if (!foundFins)
        //         {
        //             // Targeting IL_00D, onset of 'Foots' check
        //             if (instruct != null && (instruct.opcode == OpCodes.Ldstr && instruct.operand as string == "Foots"))
        //             {
        //                 foundFins = true;
        //             }
        //         }
        //         else
        //         {
        //             // Targeting IL_00FE, default value 1.5 set when UltraGlideFins not found
        //             if (instruct != null && (instruct.opcode == OpCodes.Ldc_R4 && Math.Abs((float) instruct.operand - 1.5) < 0.1))
        //             {
        //                 codes.RemoveAt(i);
        //                 
        //                 // Set max speed of regular fins to 15.0
        //                 codes.Insert(i, new CodeInstruction(OpCodes.Ldc_R4, (float) 15.0));
        //                 break;
        //             }
        //         }
        //     }
        //
        //     return codes.AsEnumerable();
        // }

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