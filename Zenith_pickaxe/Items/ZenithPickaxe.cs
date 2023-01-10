using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Zenith_pickaxe.Dusts;
using Zenith_pickaxe.Projectiles;

namespace Zenith_pickaxe.Items
{
    internal class ZenithPickaxe : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zenith pickaxe");
			Tooltip.SetDefault("BREAK THEM ALL!!!\nUse change mod key to change pickaxe mod");
		}

		public override void SetDefaults()
		{
			Item.width = 25;
			Item.height = 25;
			Item.scale = 4f;

			Item.damage = 50;
			Item.DamageType = DamageClass.Melee;
			Item.knockBack = 6;

			Item.useTime = 3;
			Item.useAnimation = 3;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shootSpeed = 20;

			Item.value = 19405980;
			Item.rare = ModContent.RarityType<GodlyRarity>();
			Item.pick = 5000;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<ZenithDust>());
			}
		}

		public override void HoldItem(Player player)
		{
			if (!ZPlayer.pickaxeMod)
			{
				Item.shoot = ProjectileID.None;
				Item.tileBoost = 50;
				Item.useStyle = ItemUseStyleID.Swing;
				Item.noMelee = false;
				Item.useTime = 3;
				Item.useAnimation = 3;
				Item.UseSound = SoundID.Item1;
			}
			else
			{
				Item.shoot = ModContent.ProjectileType<ZenithProjectile>();
				Item.tileBoost = -6;
				Item.useStyle = ItemUseStyleID.Shoot;
				Item.noMelee = true;
				Item.useTime = 6;
				Item.useAnimation = 6;
				Item.UseSound = SoundID.Item8;
			}
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
			string s = " (Normal mod)";
            if (ZPlayer.pickaxeMod)
            {
				s = " (Ultimate mod)";
            }
			tooltips[0].Text = "Zenith pickaxe" + s;
        }
    }
}
