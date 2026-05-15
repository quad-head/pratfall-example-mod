using Godot;

public static class ModEntry
{
    public static void ModInit()
    {
        GD.Print("Mod initialized!");
        GD.Print($"Game Version: {Game.Version.GetVersion()}");
    }

    public static void ModDestroy()
    {
        GD.Print("Mod destroyed!");
    }
}