using HarmonyLib;
using MelonLoader;

namespace GearToolbox
{
    internal class SettingsPatches
    {
        [HarmonyPatch] // ModComponent patch of gear spawns
        class ManageSpawnsToolbox
        {
            public static System.Reflection.MethodBase TargetMethod()
            {
                var type = AccessTools.TypeByName("ModComponent.Mapper.ZipFileLoader");
                return AccessTools.FirstMethod(type, method => method.Name.Contains("TryHandleTxt"));
            }
            public static bool Prefix(string zipFilePath, string internalPath, ref string text, ref bool __result)
            {
                if (zipFilePath.EndsWith("AHandyToolbox.modcomponent"))
                {
                    string fileName = internalPath.Replace("gear-spawns/", "").Replace(".txt", "");           

                    if (Settings.instance.noBattery && fileName == "Batteries")
                    {
                        MelonLogger.Msg(ConsoleColor.DarkYellow, "Skipping based on settings: " + fileName);
                        text = "";
                    }

                    if (Settings.instance.noRifle && fileName == "BrokenRifle")
                    {
                        MelonLogger.Msg(ConsoleColor.DarkYellow, "Skipping based on settings: " + fileName);
                        text = "";
                    }

                    if (Settings.instance.noCeramic && fileName == "CeramicShards")
                    {
                        MelonLogger.Msg(ConsoleColor.DarkYellow, "Skipping based on settings: " + fileName);
                        text = "";
                    }

                    if (Settings.instance.noPaper && fileName == "CrumpledPaper")
                    {
                        MelonLogger.Msg(ConsoleColor.DarkYellow, "Skipping based on settings: " + fileName);
                        text = "";
                    }

                    if (Settings.instance.noElectronics && fileName == "ElectronicParts")
                    {
                        MelonLogger.Msg(ConsoleColor.DarkYellow, "Skipping based on settings: " + fileName);
                        text = "";
                    }

                    if (Settings.instance.noGlass && fileName == "GlassShards")
                    {
                        MelonLogger.Msg(ConsoleColor.DarkYellow, "Skipping based on settings: " + fileName);
                        text = "";
                    }

                    if (Settings.instance.noGunParts && fileName == "GunParts")
                    {
                        MelonLogger.Msg(ConsoleColor.DarkYellow, "Skipping based on settings: " + fileName);
                        text = "";
                    }

                    if (Settings.instance.noNNB && fileName == "NutsNBolts")
                    {
                        MelonLogger.Msg(ConsoleColor.DarkYellow, "Skipping based on settings: " + fileName);
                        text = "";
                    }

                    if (Settings.instance.noNNBB && fileName == "NutsNBoltsBox")
                    {
                        MelonLogger.Msg(ConsoleColor.DarkYellow, "Skipping based on settings: " + fileName);
                        text = "";
                    }

                    if (Settings.instance.noPlastic && fileName == "ScrapPlastic")
                    {
                        MelonLogger.Msg(ConsoleColor.DarkYellow, "Skipping based on settings: " + fileName);
                        text = "";
                    }

                    if (Settings.instance.noString && fileName == "StringBundle")
                    {
                        MelonLogger.Msg(ConsoleColor.DarkYellow, "Skipping based on settings: " + fileName);
                        text = "";
                    }

                    if (Settings.instance.noTape && fileName == "TapeRoll")
                    {
                        MelonLogger.Msg(ConsoleColor.DarkYellow, "Skipping based on settings: " + fileName);
                        text = "";
                    }

                    if (Settings.instance.noTarp && fileName == "TarpSheet")
                    {
                        MelonLogger.Msg(ConsoleColor.DarkYellow, "Skipping based on settings: " + fileName);
                        text = "";
                    }
                }

                return true;
            }
        }
    }
}

