namespace NoMoreFlashes;

public class Hooks
{
    public static void Init()
    {
        On.RainCycle.Update += RainCycle_Update;

        On.FlareBomb.DrawSprites += FlareBomb_DrawSprites;
        On.FlareBomb.Update += FlareBomb_Update;
        On.FlareBomb.HitSomething += FlareBomb_HitSomething;

        On.ZapCoil.DrawSprites += ZapCoil_DrawSprites;
        On.ZapCoil.InitiateSprites += ZapCoil_InitiateSprites;
        On.ZapCoil.AddToContainer += ZapCoil_AddToContainer;

        On.GreenSparks.GreenSpark.DrawSprites += GreenSpark_DrawSprites;

        On.ZapCoil.ZapFlash.DrawSprites += ZapFlash_DrawSprites;
        On.ZapCoil.ZapFlash.InitiateSprites += ZapFlash_InitiateSprites;

        On.ElectricDeath.InitiateSprites += ElectricDeath_InitiateSprites;
        On.ElectricDeath.DrawSprites += ElectricDeath_DrawSprites;

        On.ElectricDeath.SparkFlash.InitiateSprites += SparkFlash_InitiateSprites;
        On.ElectricDeath.SparkFlash.DrawSprites += SparkFlash_DrawSprites;

        On.ElectricDeath.LightFlash.Draw += LightFlash_Draw;

        On.UnderwaterShock.Flash.InitiateSprites += Flash_InitiateSprites;
    }

    private static void Flash_InitiateSprites(On.UnderwaterShock.Flash.orig_InitiateSprites orig, UnderwaterShock.Flash self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam)
    {
        orig(self, sLeaser, rCam);
        sLeaser.sprites[0].isVisible = false;
    }

    private static void SparkFlash_DrawSprites(On.ElectricDeath.SparkFlash.orig_DrawSprites orig, ElectricDeath.SparkFlash self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
    {
        orig(self, sLeaser, rCam, timeStacker, camPos);
        sLeaser.sprites[0].isVisible = false;
    }

    private static void LightFlash_Draw(On.ElectricDeath.LightFlash.orig_Draw orig, ElectricDeath.LightFlash self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
    {
        orig(self, sLeaser, rCam, timeStacker, camPos);
        sLeaser.sprites[0].isVisible = false;
    }

    private static void SparkFlash_InitiateSprites(On.ElectricDeath.SparkFlash.orig_InitiateSprites orig, ElectricDeath.SparkFlash self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam)
    {
        orig(self, sLeaser, rCam);
        sLeaser.sprites[0].isVisible = false;
        sLeaser.sprites[1].isVisible = false;
        sLeaser.sprites[2].isVisible = false;
    }

    private static void ElectricDeath_DrawSprites(On.ElectricDeath.orig_DrawSprites orig, ElectricDeath self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
    {
        orig(self, sLeaser, rCam, timeStacker, camPos);
        sLeaser.sprites[0].isVisible = false;
        sLeaser.sprites[1].isVisible = false;
    }

    private static void ElectricDeath_InitiateSprites(On.ElectricDeath.orig_InitiateSprites orig, ElectricDeath self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam)
    {
        orig(self, sLeaser, rCam);
        sLeaser.sprites[0].isVisible = true;
        sLeaser.sprites[1].isVisible = false;
        sLeaser.sprites[2].isVisible = false;
    }

    private static void ZapFlash_InitiateSprites(On.ZapCoil.ZapFlash.orig_InitiateSprites orig, ZapCoil.ZapFlash self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam)
    {
        orig(self, sLeaser, rCam);
        sLeaser.sprites[0].isVisible = false;
        sLeaser.sprites[1].isVisible = false;
    }

    private static void ZapFlash_DrawSprites(On.ZapCoil.ZapFlash.orig_DrawSprites orig, ZapCoil.ZapFlash self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
    {
        orig(self, sLeaser, rCam, timeStacker, camPos);
        sLeaser.sprites[0].isVisible = false;
        sLeaser.sprites[1].isVisible = false;
    }

    private static void GreenSpark_DrawSprites(On.GreenSparks.GreenSpark.orig_DrawSprites orig, GreenSparks.GreenSpark self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
    {
        orig(self, sLeaser, rCam, timeStacker, camPos);
        sLeaser.sprites[0].isVisible = false;
    }

    private static void ZapCoil_AddToContainer(On.ZapCoil.orig_AddToContainer orig, ZapCoil self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, FContainer newContatiner)
    {
        orig(self, sLeaser, rCam, newContatiner);
        sLeaser.sprites[0].alpha = 0f;
    }

    private static void ZapCoil_InitiateSprites(On.ZapCoil.orig_InitiateSprites orig, ZapCoil self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam)
    {
        orig(self, sLeaser, rCam);
        sLeaser.sprites[0].isVisible = false;
    }

    private static void ZapCoil_DrawSprites(On.ZapCoil.orig_DrawSprites orig, ZapCoil self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
    {
        orig(self, sLeaser, rCam, timeStacker, camPos);
        sLeaser.sprites[0].isVisible = true;
    }

    private static void RainCycle_Update(On.RainCycle.orig_Update orig, RainCycle self)
    {
        orig(self);
        self.world.game.globalRain.ScreenShake = 0.15f;
        self.world.game.globalRain.MicroScreenShake = 0.15f;
    }

    private static bool FlareBomb_HitSomething(On.FlareBomb.orig_HitSomething orig, FlareBomb self, SharedPhysics.CollisionResult result, bool eu)
    {
        orig(self, result, eu);

        if (self.CollideWithTerrain)
        {
            self.burning = 0.899f;
            return orig(self, result, eu);
        }

        return orig(self, result, eu);
    }

    private static void FlareBomb_Update(On.FlareBomb.orig_Update orig, FlareBomb self, bool eu)
    {
        orig(self, eu);
        self.flashAplha = 0f;
    }

    private static void FlareBomb_DrawSprites(On.FlareBomb.orig_DrawSprites orig, FlareBomb self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
    {
        orig(self, sLeaser, rCam, timeStacker, camPos);
        self.flashAplha = 0f;
    }
}