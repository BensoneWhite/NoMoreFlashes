namespace NoMoreFlashes.Changes.ZapCoilsModify;

public class ZapCoilsModify
{
    public static void Apply()
    {
        On.ZapCoil.DrawSprites += ZapCoil_DrawSprites;
        On.ZapCoil.TriggerZap += ZapCoil_TriggerZap;

        On.ZapCoil.ZapFlash.DrawSprites += ZapFlash_DrawSprites;
        On.ZapCoil.ZapFlash.Update += ZapFlash_Update;
    }

    private static void ZapFlash_Update(On.ZapCoil.ZapFlash.orig_Update orig, ZapCoil.ZapFlash self, bool eu)
    {
        orig(self, eu);
        if (Hooks.NoFlashes)
            self.lightsource?.Destroy();
    }

    private static void ZapCoil_TriggerZap(On.ZapCoil.orig_TriggerZap orig, ZapCoil self, Vector2 zapContact, float massRad)
    {
        orig(self, zapContact, massRad);

        if (Hooks.NoFlashes)
        {
            self.turnedOffCounter = 0;
            self.disruption = -1f;
        }
    }

    private static void ZapFlash_DrawSprites(On.ZapCoil.ZapFlash.orig_DrawSprites orig, ZapCoil.ZapFlash self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
    {
        orig(self, sLeaser, rCam, timeStacker, camPos);

        if (Hooks.NoFlashes)
        {
            for (int i = 0; i < sLeaser.sprites.Length; i++) { }

            sLeaser.sprites[0].isVisible = false;
            sLeaser.sprites[0].alpha = 0f;
            sLeaser.sprites[1].isVisible = false;
            sLeaser.sprites[1].alpha = 0.3f;
        }
    }

    private static void ZapCoil_DrawSprites(On.ZapCoil.orig_DrawSprites orig, ZapCoil self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
    {
        orig(self, sLeaser, rCam, timeStacker, camPos);

        if (Hooks.NoFlashes)
            sLeaser.sprites[0].alpha = 0.3f;
    }
}