using NoMoreFlashes.Changes.EchoModify;
using NoMoreFlashes.Changes.ElectricDeathModify;
using NoMoreFlashes.Changes.FlareBombModify;
using NoMoreFlashes.Changes.UnderWaterModify;
using NoMoreFlashes.Changes.ZapCoilsModify;

namespace NoMoreFlashes;

public class Hooks
{
    //NoFlashes bool is for testing and comparing
    public static bool NoFlashes = true;
    public static bool Flashes = false;

    public static void Init()
    {
        FlareBombModify.Apply();

        ZapCoilsModify.Apply();

        UnderWaterModify.Apply();

        ElectricDeathModify.Apply();

        EchoModify.Apply();

        On.RainWorld.Update += RainWorld_Update;
    }

    private static void RainWorld_Update(On.RainWorld.orig_Update orig, RainWorld self)
    {
        orig(self);

        // Crtl+Alt+F
        bool ctrlFlash = Input.GetKey(KeyCode.LeftControl);
        bool FKeyFlash = Input.GetKey(KeyCode.F);

        // Crtl+Alt+N
        bool ctrlNoFlash = Input.GetKey(KeyCode.LeftControl);
        bool NNoFlash = Input.GetKey(KeyCode.N);

        if (ctrlFlash && FKeyFlash && !Flashes)
        {
            Flashes = true;
            NoFlashes = false;

            Plugin.DebugWarning(Flashes
                ? "Flashes are now Enabled"
                : "Flashes are Disabled");
        }

        if(ctrlNoFlash && NNoFlash && !NoFlashes)
        {
            Flashes = false;
            NoFlashes = true;

            Plugin.DebugWarning(Flashes
                ? "Flashes are now Enabled"
                : "Flashes are Disabled");
        }
    }
}