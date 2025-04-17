namespace NoMoreFlashes.Changes.UnderWaterModify;

public class UnderWaterModify
{
    public static void Apply()
    {
        On.UnderwaterShock.Flash.DrawSprites += Flash_DrawSprites;
    }

    private static void Flash_DrawSprites(On.UnderwaterShock.Flash.orig_DrawSprites orig, UnderwaterShock.Flash self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
    {
        orig(self, sLeaser, rCam, timeStacker, camPos);

        for (int i = 0; i < sLeaser.sprites.Length; i++) { }
            
        sLeaser.sprites[0].alpha = 0.03f;
    }
}