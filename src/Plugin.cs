namespace NoMoreFlashes;

[BepInPlugin(GUID: MOD_ID, Name: MOD_NAME, Version: VERSION)]
class Plugin : BaseUnityPlugin
{
    public const string AUTHORS = "BensoneWhite";
    public const string MOD_ID = "BensoneWhite.NoMoreFlashes";
    public const string MOD_NAME = "NoMoreFlashes";
    public const string VERSION = "1.2.1";

    public bool IsInit;

    public static void LogWarning(object ex) => Logger.LogWarning(ex);

    public static void LogError(object ex) => Logger.LogError(ex);

    public static new ManualLogSource Logger;

    public static RemixMenu optionsMenuInstance;

    public void OnEnable()
    {
        try
        {
            Logger = base.Logger;
            
            On.RainWorld.OnModsInit += RainWorld_OnModsInit;

            LogWarning($"{MOD_NAME} is loading... {VERSION}");
        }
        catch (Exception e)
        {
            LogError(e);
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
            LogError(ex);
        }
    }
}