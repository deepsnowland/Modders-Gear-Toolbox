using Il2Cpp;
using HarmonyLib;
using UnityEngine;
using Il2CppSteamworks;

namespace GearToolbox
{
    internal class Patches
    {
        [HarmonyPatch(typeof(Panel_Inventory), nameof(Panel_Inventory.Initialize))]
        internal class ToolBoxInitialization
        {
            private static void Postfix(Panel_Inventory __instance)
            {
                TBFunctionalities.InitializeMTB(__instance.m_ItemDescriptionPage);
            }
        }
        [HarmonyPatch(typeof(ItemDescriptionPage), nameof(ItemDescriptionPage.UpdateGearItemDescription))]
        internal class UpdateDismantleGunButton
        {
            private static void Postfix(ItemDescriptionPage __instance, GearItem gi)
            {
                if (__instance != InterfaceManager.GetPanel<Panel_Inventory>()?.m_ItemDescriptionPage) return;
                TBFunctionalities.gunItem = gi?.GetComponent<GearItem>();
                if (gi != null && ToolboxUtils.IsGun(gi.name) == true && Settings.instance.noDismantle == false)
                {
                    TBFunctionalities.SetDismantleGunActive(true);
                }
                else
                {
                    TBFunctionalities.SetDismantleGunActive(false);
                }
            }
        }
        [HarmonyPatch(typeof(ItemDescriptionPage), nameof(ItemDescriptionPage.UpdateGearItemDescription))]
        internal class UpdateReplenishSKButton
        {
            private static void Postfix(ItemDescriptionPage __instance, GearItem gi)
            {
                if (__instance != InterfaceManager.GetPanel<Panel_Inventory>()?.m_ItemDescriptionPage) return;
                TBFunctionalities.sewingKit = gi?.GetComponent<GearItem>();
                if (gi != null && gi.name == "GEAR_SewingKit" && Settings.instance.noReplenish == false)
                {
                    TBFunctionalities.SetReplenishSkActive(true);
                }
                else
                {
                    TBFunctionalities.SetReplenishSkActive(false);
                }
            }
        }
        [HarmonyPatch(typeof(RadialObjectSpawner), "GetNextPrefabToSpawn")]
        internal class AddFlint
        {
            private static void Postfix(RadialObjectSpawner __instance, ref GameObject __result)
            {
                if (__instance != null && ToolboxUtils.flint != null && __instance.name.Contains("RadialSpawn_stone"))
                {
                    if (Utils.RollChance(Settings.instance.flintChance))
                    {
                        __result = ToolboxUtils.flint;
                    }
                }
            }
        }
        [HarmonyPatch(typeof(RadialObjectSpawner), "GetNextPrefabToSpawn")]
        internal class AddRock
        {
            private static void Postfix(RadialObjectSpawner __instance, ref GameObject __result)
            {
                if (__instance != null && ToolboxUtils.rock != null && __instance.name.Contains("RadialSpawn_stone"))
                {
                    if (Utils.RollChance(Settings.instance.rockChance))
                    {
                        __result = ToolboxUtils.rock;
                    }
                }
            }
        }
        [HarmonyPatch(typeof(Panel_BodyHarvest), "TransferMeatFromCarcassToInventory")]
        internal class HarvestBones
        {
            private static void Postfix(Panel_BodyHarvest __instance)
            {
                GearItem thisMeat = __instance.m_BodyHarvest.m_MeatPrefab.GetComponent<GearItem>();
                float harvestAmount = __instance.m_MenuItem_Meat.m_HarvestAmount;
                int bones = 0;
                bool msgAdded = false;
                if (harvestAmount > 0 && Settings.instance.noBones == false)
                {
                    if (thisMeat.name.ToLowerInvariant().Contains("ptarmigan") || thisMeat.name.ToLowerInvariant().Contains("rabbit") || thisMeat.name.ToLowerInvariant().Contains("bird"))
                    {
                        bones = 1;
                    }
                    else if (thisMeat.name.ToLowerInvariant().Contains("wolf") || thisMeat.name.ToLowerInvariant().Contains("deer"))
                    {
                        bones = 2;
                    }
                    else if (thisMeat.name.ToLowerInvariant().Contains("bear") || thisMeat.name.ToLowerInvariant().Contains("moose") || thisMeat.name.ToLowerInvariant().Contains("orca"))
                    {
                        bones = 1;
                    }

                    for (int i = 1; i <= harvestAmount; i++)
                    {
                        for (int j = 1; j <= bones; j++)
                        {
                            GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolboxUtils.bones, 1, 1f, PlayerManager.InventoryInstantiateFlags.None);
                            if (!msgAdded)
                            {
                                msgAdded = true;
                                string message = string.Concat(new object[] { ToolboxUtils.bones.DisplayName, " (", bones, ")" });
                                GearMessage.AddMessage(ToolboxUtils.bones.name, Localization.Get("GAMEPLAY_Harvested"), message, false, true);
                            }
                        }
                    }
                }
            }
        }
    }
}

