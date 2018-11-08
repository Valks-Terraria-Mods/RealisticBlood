using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace RealisticBlood
{
    public class Player : ModPlayer
    {
        float redTimer = 0;

        public override void OnHitByProjectile(Projectile proj, int damage, bool crit) {
            redTimer = 1;
        }

        public override void OnHitByNPC(NPC npc, int damage, bool crit) {
            redTimer = 1;
        }

        public override void ModifyDrawInfo(ref PlayerDrawInfo drawInfo) {
            if (redTimer > 0) {
                Color playerColor = drawInfo.bodyColor;

                float bloodColor = redTimer;

                float red = playerColor.R / 255f;
                float green = playerColor.B / 255f;
                float blue = playerColor.G / 255f;

                
                if (Main.dayTime)
                {
                    drawInfo.bodyColor = new Color(Utils.Clamp((Math.Abs(bloodColor - 1)), 0f, red), Utils.Clamp((Math.Abs(bloodColor - 1)), 0f, green), Utils.Clamp((Math.Abs(bloodColor - 1)), 0f, blue));
                    drawInfo.legColor = new Color(Utils.Clamp((Math.Abs(bloodColor - 1)), 0f, red), Utils.Clamp((Math.Abs(bloodColor - 1)), 0f, green), Utils.Clamp((Math.Abs(bloodColor - 1)), 0f, blue));
                    drawInfo.faceColor = new Color(Utils.Clamp((Math.Abs(bloodColor - 1)), 0f, red), Utils.Clamp((Math.Abs(bloodColor - 1)), 0f, green), Utils.Clamp((Math.Abs(bloodColor - 1)), 0f, blue));
                }
                else {
                    drawInfo.bodyColor = new Color(Utils.Clamp(bloodColor, red, 1f), green, blue);
                    drawInfo.legColor = new Color(Utils.Clamp(bloodColor, red, 1f), green, blue);
                    drawInfo.faceColor = new Color(Utils.Clamp(bloodColor, red, 1f), green, blue);
                }
                

                player.immuneNoBlink = true;
                redTimer -= 0.02f;
            }
        }

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright) {
            if (redTimer > 0.8) {
                Dust.NewDust(player.position, player.width, player.height, 183);
            }
        }
    }
}
