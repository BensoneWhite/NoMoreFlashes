namespace NoMoreFlashes.Changes.FlareBombModify;

public class FlareBombModify
{
    //TODO:
    //Make the flarebomb disappear once is used without having to override the entire sound all after hitting something

    public static void Apply()
    {
        On.FlareBomb.Update += FlareBomb_Update;
    }

    private static void FlareBomb_Update(On.FlareBomb.orig_Update orig, FlareBomb self, bool eu)
    {
        orig(self, eu);

        if (Hooks.NoFlashes)
            self.flashAplha = 0f;
    }
}