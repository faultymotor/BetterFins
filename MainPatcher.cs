using System.Reflection;
using Harmony;

namespace BetterFins
{
    public class MainPatcher
    {
        public static void Patch()
        {
            AerogelFins._SMLPatchHelper();
            
            var harmony = HarmonyInstance.Create("io.github.brokenmotor.betterfins");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}