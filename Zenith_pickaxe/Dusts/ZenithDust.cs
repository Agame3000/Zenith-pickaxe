using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace Zenith_pickaxe.Dusts
{
    internal class ZenithDust : ModDust
    {
		double lastTime;
		double timeR;
		double timeC;
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 0.4f;
			dust.scale *= 3f;
		}

		public override bool Update(Dust dust)
		{
			double currentTime = Main.timeForVisualEffects / 60;
			double deltaTime = currentTime - lastTime;

			timeR += deltaTime * 3;
			timeC += deltaTime;
			if(timeR > 4)
            {
				timeR = 0;
            }
			if(timeC > 7)
            {
				timeC = 0.0000000001d;
            }
			Color col = rainbowColor((float)timeC);

			dust.color = col;
			dust.frame = currentRect((int)Math.Round(timeR));
			dust.rotation += dust.velocity.X * 0.15f;
			dust.scale *= 0.95f;

			float light = 0.8f * dust.scale;

			Lighting.AddLight(dust.position, light * (col.R / 255f), light * (col.G / 255f), light * (col.B / 255f));

			if (dust.scale < 0.000001f)
			{
				dust.active = false;
			}

			lastTime = currentTime;
			return false; // Return false to prevent vanilla behavior.
		}

		public Rectangle currentRect(int i)
        {
			const int width = 17;
			int y = width * i;
			return new Rectangle(0, y, width, width);
        }

		public Color rainbowColor(float f)
        {
			Color red = Color.Red;
			Color orange = Color.Orange;
			Color yellow = Color.Yellow;
			Color green = Color.Green;
			Color lblue = new Color(0, 255, 255);
			Color blue = Color.Blue;
			Color purple = Color.Purple;

			Color color1 = new Color();
			Color color2 = new Color();

			int i = (int)Math.Floor(f);
            switch (i)
            {
				case 0:
					color1 = red;
					color2 = orange;
					break;
				case 1:
					color1 = orange;
					color2 = yellow;
					break;
				case 2:
					color1 = yellow;
					color2 = green;
					break;
				case 3:
					color1 = green;
					color2 = lblue;
					break;
				case 4:
					color1 = lblue;
					color2 = blue;
					break;
				case 5:
					color1 = blue;
					color2 = purple;
					break;
				case 6:
					color1 = purple;
					color2 = red;
					break;
            }

			return Color.Lerp(color1, color2, f - i);
        }
	}
}
