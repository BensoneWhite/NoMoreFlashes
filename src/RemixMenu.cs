namespace NoMoreFlashes;

public class RemixMenu : OptionInterface
{
    public static Configurable<bool> FlashBang;
    public static Configurable<bool> Zappier;
    public static Configurable<bool> ElectricSprites;
    public static Configurable<bool> ScreenShake;
    public static Configurable<float> ScreenShakeValue;

    public RemixMenu()
    {
        FlashBang = config.Bind("FlashBang", false);
        Zappier = config.Bind("Zappier", false);
        ElectricSprites = config.Bind("ElectricSprites", false);
        ScreenShake = config.Bind("ScreenShake", false);
        ScreenShakeValue = config.Bind("ScreenShakeValue", 0.1f, new ConfigAcceptableRange<float>(0.1f, 1f));
    }

    public override void Initialize()
    {
        OpTab opTab1 = new(this, Translate("Options"));
        Tabs = [opTab1];
        OpContainer tab1Container = new(new Vector2(0f, 0f));
        opTab1.AddItems([tab1Container]);
        opTab1.AddItems(
        [
            new OpCheckBox(FlashBang, 10f, 540f),
            new OpLabel(45f, 540f, "Enable the Flashbangs", false),

            new OpCheckBox(Zappier, 10f, 500f),
            new OpLabel(45f, 500f, "Enable the Zaps from Zapcoil", false),

            new OpCheckBox(ElectricSprites, 10f, 420f),
            new OpLabel(45f, 420f, "Enable the Electric death sprites", false),

            new OpCheckBox(ScreenShake, 10f, 380f),
            new OpLabel(45f, 380f, "Enable the default ScreenShake", false),

            new OpUpdown(ScreenShakeValue, new Vector2(10f, 340f), 50f, 1),
            new OpLabel(70f, 340f, "ScreenShake streght", false)
        ]);
    }
}