using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using UnityEngine;

namespace SubnauticaSpeed 
{
    public class AerogelFins : Equipable 
    {
        private static readonly AerogelFins Main = new AerogelFins();

        public AerogelFins() : base("AerogelFins", "Aerogel Fins",
            "Advanced construction utilizes lighter materials to enhance swim speed considerably by comparison to swims constructed with inferior materials.")
        {
            //OnFinishedPatching += AdditionalPatching;
        }

        public override CraftTree.Type FabricatorType { get; } = CraftTree.Type.Workbench;
        public override TechGroup GroupForPDA { get; } = TechGroup.Personal;
        public override TechCategory CategoryForPDA { get; } = TechCategory.Equipment;
        public override EquipmentType EquipmentType { get; } = EquipmentType.Foots;
        
        public override string[] StepsToFabricatorTab
        {
            get;
        } = new[] {"Personal", "Equipment"};

        public override GameObject GetGameObject()
        {
            var prefab = CraftData.GetPrefabForTechType(TechType.Compass);

            return Object.Instantiate(prefab);
        }

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData
            {
                craftAmount = 1,
                Ingredients =
                {
                    new Ingredient(TechType.UltraGlideFins, 1),
                    new Ingredient(TechType.Aerogel, 1),
                    new Ingredient(TechType.Benzene, 1)
                }
            };
        }

        public static void _SMLPatchHelper()
        {
            Main.Patch();
        }

        public static TechType _GetTechType()
        {
            return Main.TechType;
        }
    }
}