using System.Reflection;
using Harmony;

namespace SubnauticaSpeed
{
    public class MainPatcher
    {
        public static void Patch()
        {
            AerogelFins._SMLPatchHelper();
            var harmony = HarmonyInstance.Create("io.github.brokenmotor.subnauticaspeed");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}