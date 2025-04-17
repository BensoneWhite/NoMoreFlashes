namespace NoMoreFlashes.Changes.ElectricDeathModify;

public class ElectricDeathModify
{
    public static void Apply()
    {
        On.ElectricDeath.DrawSprites += ElectricDeath_DrawSprites;

        On.ElectricDeath.SparkFlash.DrawSprites += SparkFlash_DrawSprites;

        On.ElectricDeath.LightFlash.Draw += LightFlash_Draw;

        On.CentipedeGraphics.Update += CentipedeGraphics_Update;
    }

    private static void CentipedeGraphics_Update(On.CentipedeGraphics.orig_Update orig, CentipedeGraphics self)
    {
        orig(self);

        if(self.lightSource != null)
        {
            self.lightSource.setAlpha = 0.25f;
        }
    }

    private static void LightFlash_Draw(On.ElectricDeath.LightFlash.orig_Draw orig, ElectricDeath.LightFlash self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
    {
        orig(self, sLeaser, rCam, timeStacker, camPos);

        if (Hooks.NoFlashes)
        {
            sLeaser.sprites[self.sprite].alpha = 0f;
            sLeaser.sprites[self.sprite].isVisible = false;
        }
    }

    private static void SparkFlash_DrawSprites(On.ElectricDeath.SparkFlash.orig_DrawSprites orig, ElectricDeath.SparkFlash self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
    {
        orig(self, sLeaser, rCam, timeStacker, camPos);

        if (Hooks.NoFlashes)
        {
            for (int i = 0; i < sLeaser.sprites.Length; i++)
            {
                sLeaser.sprites[i].isVisible = false;
                sLeaser.sprites[i].alpha = 0f;
            }
        }
    }

    private static void ElectricDeath_DrawSprites(On.ElectricDeath.orig_DrawSprites orig, ElectricDeath self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
    {
        orig(self, sLeaser, rCam, timeStacker, camPos);

        if (Hooks.NoFlashes)
        {
            for (int i = 0; i < sLeaser.sprites.Length; i++)
            {
                sLeaser.sprites[i].isVisible = false;
                sLeaser.sprites[i].alpha = 0f;
            }
        }
    }
}