namespace NoMoreFlashes.Changes.RainCycleShakeModify;

public class RainCycleShakeModify
{
    public static void Apply()
    {
        On.RainCycle.Update += RainCycle_Update;
    }

    private static void RainCycle_Update(On.RainCycle.orig_Update orig, RainCycle self)
    {
        orig(self);

        self.world.game.globalRain.ScreenShake = 0.1f;
        self.world.game.globalRain.MicroScreenShake = 0.1f;
    }
}