using Terraria;
using Terraria.GameInput;
using Terraria.Audio;
using Terraria.ModLoader;
using Zenith_pickaxe.Items;
using Terraria.ID;

namespace Zenith_pickaxe
{
    public class ZPlayer : ModPlayer
    {
        public static bool pickaxeMod;

        public override void Initialize()
        {
            pickaxeMod = false;
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if(ZenithPickaxeKeys.ChagePickaxeMod.JustPressed && Player.whoAmI == Main.myPlayer && !Player.CCed && Player.HasItem(ModContent.ItemType<ZenithPickaxe>()))
            {
                SoundEngine.PlaySound(SoundID.Item101);
                pickaxeMod = !pickaxeMod;
            }
        }
    }
}
