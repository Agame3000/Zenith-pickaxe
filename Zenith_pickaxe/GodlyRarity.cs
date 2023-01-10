using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Zenith_pickaxe
{
    internal class GodlyRarity : ModRarity
    {
		public override int GetPrefixedRarity(int offset, float valueMult)
		{
			return Type;
		}

        public override Color RarityColor => CosmicColor();

        public Color CosmicColor()
        {
            float k = (float)(Math.Sin(Main.timeForVisualEffects / 120) + 1) / 2;
			Color rainbow = rainbowColor(k * 7);
			Color white = new Color(255, 255, 255);
			Color color1 = Color.White;
			Color color2 = Color.White;

			int i = (int)Math.Floor(k * 2);
            switch (i)
            {
				case 0:
					color1 = white;
					color2 = rainbow;
					break;
				case 1:
					color1 = rainbow;
					color2 = white;
					break;
            }

            return Color.Lerp(color1, color2, k * 2 - i);
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
