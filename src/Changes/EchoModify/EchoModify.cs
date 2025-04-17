using RWCustom;

namespace NoMoreFlashes.Changes.EchoModify;

public class EchoModify
{
    public static void Apply()
    {
        On.Ghost.DrawSprites += Ghost_DrawSprites;
    }

    private static void Ghost_DrawSprites(On.Ghost.orig_DrawSprites orig, Ghost self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
    {
        orig(self, sLeaser, rCam, timeStacker, camPos);

        if (Hooks.NoFlashes)
        {
            sLeaser.sprites[self.DistortionSprite].alpha = 0f;
            sLeaser.sprites[self.DistortionSprite].isVisible = false;

            sLeaser.sprites[self.LightSprite].alpha = 0f;
            sLeaser.sprites[self.LightSprite].isVisible = false;

            float fading = Mathf.Lerp(self.lastFadeOut, self.fadeOut, timeStacker);
            sLeaser.sprites[self.FadeSprite].isVisible = fading > 0f;

            if (fading > 0f)
            {
                sLeaser.sprites[self.FadeSprite].alpha = Mathf.InverseLerp(0f, 0.2f, fading);
                float num5 = Custom.SCurve(Mathf.InverseLerp(0.5f, 1f, fading), 0.3f);
                sLeaser.sprites[self.FadeSprite].color = new Color(1f - num5, 1f - num5, 1f - num5, 0.1f);
            }
        }
    }
}