namespace NoMoreFlashes.Changes.FlareBombModify;

public class FlareBombModify
{
    public static void Apply()
    {
        On.FlareBomb.Update += FlareBomb_Update;
        //On.FlareBomb.DrawSprites += FlareBomb_DrawSprites;
    }

    //Make the flarebomb disappear once is used
    private static void FlareBomb_DrawSprites(On.FlareBomb.orig_DrawSprites orig, FlareBomb self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
    {
        orig(self, sLeaser, rCam, timeStacker, camPos);

        if(self.CollideWithTerrain)
        {
            sLeaser.sprites[0].isVisible = false;
        }
    }

    private static void FlareBomb_Update(On.FlareBomb.orig_Update orig, FlareBomb self, bool eu)
    {
        orig(self, eu);

        self.flashAplha = 0f;
    }
}