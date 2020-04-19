using Harmony;

namespace SubnauticaSpeed
{
    [HarmonyPatch(typeof(Player))]
    [HarmonyPatch("Update")]
    internal class PlayerPatcher
    {
        [HarmonyPostfix]
        public static void _Postfix()
        {
            // Affect speed here
        }
    }
}