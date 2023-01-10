using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Zenith_pickaxe.Dusts;

namespace Zenith_pickaxe.Projectiles
{
    internal class ZenithProjectile : ModProjectile
    {
		public override void SetDefaults()
		{
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.scale = 2.6f;

			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.damage = 30;

			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.timeLeft = 120;
		}

        public override void OnSpawn(IEntitySource source)
        {
			Projectile.frame = Main.rand.Next(17);
		}

        public override void AI()
		{
			Projectile.velocity *= 0.96f;
			Projectile.rotation += 0.2f;
			Projectile.alpha = 255 - (int)(Projectile.timeLeft / 120f * 255);
			if (Main.rand.NextBool(10))
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<ZenithDust>(), Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f, Projectile.alpha + 50, Scale: 0.6f);
			}

			int _x = (int)(Projectile.Center.X / 16f - 2);
			int _y = (int)(Projectile.Center.Y / 16f - 2);
			for(int x = _x; x < _x + 4; x++)
            {
				for(int y = _y; y < _y + 4; y++)
                {
					Tile tile = Main.tile[x, y];
                    if (tile.HasTile)
                    {
						WorldGen.KillTile(x, y);
                    }
				}
            }
		}

		public override bool PreDraw(ref Color lightColor)
		{
			SpriteEffects spriteEffects = SpriteEffects.None;

			Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);

			int frameHeight = texture.Height / 17;
			int startY = frameHeight * Projectile.frame;

			Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);

			Vector2 origin = sourceRectangle.Size() / 2f;

			float offsetX = 20f;
			origin.X = (float)(Projectile.spriteDirection == 1 ? sourceRectangle.Width - offsetX : offsetX);

			Color drawColor = Projectile.GetAlpha(lightColor);
			Main.EntitySpriteDraw(texture,
				Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
				sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);

			return false;
		}
	}
}
