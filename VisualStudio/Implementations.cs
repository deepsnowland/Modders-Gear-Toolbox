using GearToolbox;
using MelonLoader;

namespace ModNamespace;
internal sealed class Implementations : MelonMod
{
	public override void OnInitializeMelon()
	{
        MelonLoader.MelonLogger.Msg(System.ConsoleColor.Yellow, "Breaking down objects...");
        MelonLoader.MelonLogger.Msg(System.ConsoleColor.Yellow, "Distributing scrap materials...");
        MelonLoader.MelonLogger.Msg(System.ConsoleColor.Yellow, "Taperolling...");
        MelonLoader.MelonLogger.Msg(System.ConsoleColor.Green, "Gear Toolbox Loaded!");
        Settings.instance.AddToModSettings("Modders' Gear Toolbox");
    }
}
