namespace NoMoreFlashes;

[BepInPlugin(GUID: MOD_ID, Name: MOD_NAME, Version: VERSION)]
public class Plugin : BaseUnityPlugin
{
    public const string AUTHORS = "BensoneWhite";
    public const string MOD_ID = "BensoneWhite.NoMoreFlashes";
    public const string MOD_NAME = "NoMoreFlashes";
    public const string VERSION = "1.2.1";

    public bool IsInit;

    public static void DebugWarning(object ex) => Logger.LogWarning(ex);

    public static void DebugError(object ex) => Logger.LogError(ex);

    public static new ManualLogSource Logger;

    public static RemixMenu optionsMenuInstance;

    public void OnEnable()
    {
        try
        {
            Logger = base.Logger;
            
            On.RainWorld.OnModsInit += RainWorld_OnModsInit;

            DebugWarning($"{MOD_NAME} is loading... {VERSION}");
        }
        catch (Exception e)
        {
            DebugError(e);
        }
    }

    private void RainWorld_OnModsInit(On.RainWorld.orig_OnModsInit orig, RainWorld self)
    {
        orig(self);

        try
        {
            if (IsInit) return;
            IsInit = true;

            Hooks.Init();

            MachineConnector.SetRegisteredOI(MOD_ID, optionsMenuInstance = new RemixMenu());
        }
        catch (Exception ex)
        {
            DebugError(ex);
        }
    }
}