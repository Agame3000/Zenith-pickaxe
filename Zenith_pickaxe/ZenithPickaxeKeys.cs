using Terraria.ModLoader;

namespace Zenith_pickaxe
{
    public class ZenithPickaxeKeys : ModSystem
    {
        public static ModKeybind ChagePickaxeMod { get; private set; }

        public override void Load()
        {
            ChagePickaxeMod = KeybindLoader.RegisterKeybind(Mod, "Change pickaxe mod", Microsoft.Xna.Framework.Input.Keys.Q);
        }

        public override void Unload()
        {
            ChagePickaxeMod = null;
        }
    }
}
