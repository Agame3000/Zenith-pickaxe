using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Zenith_pickaxe.Items;

namespace Zenith_pickaxe
{
    internal class Recipes : ModSystem
    {
        public static RecipeGroup GoldenPickaxe;
        public static RecipeGroup DemonPickaxe;
        public static RecipeGroup AdamantPickaxe;
        public static RecipeGroup FragmentPickaxe;

        public override void Unload()
        {
            GoldenPickaxe = null;
            AdamantPickaxe = null;
            FragmentPickaxe = null;
        }

        public override void AddRecipeGroups()
        {
            GoldenPickaxe = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.GoldPickaxe)}",
                ItemID.GoldPickaxe, ItemID.PlatinumPickaxe);
            DemonPickaxe = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.NightmarePickaxe)}",
                ItemID.NightmarePickaxe, ItemID.DeathbringerPickaxe);
            AdamantPickaxe = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.AdamantitePickaxe)}",
                ItemID.AdamantitePickaxe, ItemID.TitaniumPickaxe);
            FragmentPickaxe = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.SolarFlarePickaxe)}",
                ItemID.SolarFlarePickaxe, ItemID.StardustPickaxe, ItemID.NebulaPickaxe, ItemID.VortexPickaxe);

            RecipeGroup.RegisterGroup("ZenithPickaxe:GoldPickaxe", GoldenPickaxe);
            RecipeGroup.RegisterGroup("ZenithPickaxe:NightmarePickaxe", DemonPickaxe);
            RecipeGroup.RegisterGroup("ZenithPickaxe:AdamantitePickaxe", AdamantPickaxe);
            RecipeGroup.RegisterGroup("ZenithPickaxe:FragmentPickaxe", FragmentPickaxe);
        }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ModContent.ItemType<ZenithPickaxe>());

            recipe.AddIngredient(ItemID.CopperPickaxe)
                .AddIngredient(ItemID.CactusPickaxe)
                .AddIngredient(ItemID.FossilPickaxe)
                .AddRecipeGroup(GoldenPickaxe)
                .AddIngredient(ItemID.CnadyCanePickaxe)
                .AddIngredient(ItemID.ReaverShark)
                .AddIngredient(ItemID.BonePickaxe)
                .AddRecipeGroup(DemonPickaxe)
                .AddIngredient(ItemID.MoltenPickaxe)
                .AddRecipeGroup(AdamantPickaxe)
                .AddIngredient(ItemID.PickaxeAxe)
                .AddIngredient(ItemID.ChlorophytePickaxe)
                .AddIngredient(ItemID.SpectrePickaxe)
                .AddIngredient(ItemID.ShroomiteDiggingClaw)
                .AddIngredient(ItemID.Picksaw)
                .AddRecipeGroup(FragmentPickaxe)
                .AddIngredient(ItemID.LaserDrill)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
