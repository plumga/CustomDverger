// JotunnModStub
// a Valheim mod skeleton using Jötunn
// 
// File:    JotunnModStub.cs
// Project: JotunnModStub

using System;
using BepInEx;
using UnityEngine;
using BepInEx.Configuration;
using HarmonyLib;
using Jotunn.Configs;
using Jotunn.Managers;
using Jotunn.Entities;
using Jotunn.Utils;
using CustomSlotItemLib;

namespace CustomDverger
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    internal class CustomDverger : BaseUnityPlugin
    {
        public const string PluginGUID = "com.plumga.CustomDverger";
        public const string PluginName = "CustomDverger";
        public const string PluginVersion = "0.0.1";
        private AssetBundle dvergers;


        private void Awake()
        {

            LoadAssets();
            //dvergers
            LoadYellowE();
            LoadBlackE();
            LoadBlack();
            LoadDarkBlue();
            LoadGreen();
            LoadOrange();
            LoadPurple();
            LoadRed();
            LoadWhite();
            LoadYellow();
            Harmony.CreateAndPatchAll(typeof(CustomDverger).Assembly);

        }

        private void CreateInventory(GameObject go, int height, int width)
        {
            if (go.GetComponent<Container>() != null) return;
            var cn = go.AddComponent<Container>();
            cn.m_height = height;
            cn.m_width = width;
            //this might not work I dont know for sure about the rootobjoverride
            cn.m_rootObjectOverride = Player.m_localPlayer.gameObject.GetComponent<ZNetView>();
        }

        private void Update()
        {
            if (Player.m_localPlayer == null || ZNetScene.instance == null )
                return;
            if (Player.m_localPlayer.IsItemEquiped(ZNetScene.instance.GetPrefab("dvergername").gameObject
                .GetComponent<ItemDrop>().m_itemData))
            {
                var light = ZNetScene.instance.GetPrefab("dvergernamegoeshere").GetComponent<Light>();
                
                light.color = Color.green;//POC to show you can alter color on the sceneupdate when the item is euqipped
                light.useColorTemperature = true;
                light.colorTemperature = 123;
            }
        }
        private void LoadAssets()
        {
            dvergers = AssetUtils.LoadAssetBundleFromResources("dvergerasset", typeof(CustomDverger).Assembly);

        }


        //  [HarmonyLib.HarmonyPatch(typeof(ZNetScene), "Awake")]
        //  [HarmonyLib.HarmonyPostfix]
        // static void PrefabPostfix(ref ZNetScene __instance)
        // {
        //   GameObject wishbonePrefab = __instance.GetPrefab("Wishbone");
        // CustomSlotManager.ApplyCustomSlotItem(wishbonePrefab, "wishbone");
        //}

        ///I give up on custom slots


        private void LoadYellowE()
        {
            //    CustomSlotManager.ApplyCustomSlotItem(blackfab, "wishbone");
            ItemManager.Instance.AddItem(new CustomItem(dvergers.LoadAsset<GameObject>("$customdvergeryellowearly"), fixReference: true,
                new ItemConfig
                {
                    Amount = 1,
                    CraftingStation = "piece_workbench",
                    RepairStation = "piece_workbench",
                    MinStationLevel = 1,
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Flint", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "Resin", Amount = 3, AmountPerLevel = 1}
                    }
                }));

        }

        private void LoadBlackE()
        {
            //    CustomSlotManager.ApplyCustomSlotItem(blackfab, "wishbone");
            ItemManager.Instance.AddItem(new CustomItem(dvergers.LoadAsset<GameObject>("$customdvergerblackearly"), fixReference: true,
                new ItemConfig
                {
                    Amount = 1,
                    CraftingStation = "piece_workbench",
                    RepairStation = "piece_workbench",
                    MinStationLevel = 1,
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Flint", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "Coal", Amount = 3, AmountPerLevel = 1}
                    }
                }));

        }


        private void LoadBlack()
        {
            //    CustomSlotManager.ApplyCustomSlotItem(blackfab, "wishbone");
            ItemManager.Instance.AddItem(new CustomItem(dvergers.LoadAsset<GameObject>("$customdvergerblack"), fixReference: true,
                new ItemConfig
                {
                    Amount = 1,
                    CraftingStation = "piece_workbench",
                    RepairStation = "piece_workbench",
                    MinStationLevel = 2,
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Silver", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "SurtlingCore", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "Crystal", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "Coal", Amount = 3}
                    }
                }));

        }

        private void LoadDarkBlue()
        {
            var blue = new CustomItem(dvergers.LoadAsset<GameObject>("$customdvergerdarkblue"), fixReference: true,
                new ItemConfig
                {
                    Amount = 1,
                    CraftingStation = "piece_workbench",
                    RepairStation = "piece_workbench",
                    MinStationLevel = 2,
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Silver", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "SurtlingCore", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "Crystal", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "Blueberries", Amount = 3}
                    }
                });
            ItemManager.Instance.AddItem(blue);

        }


        private void LoadGreen()
        {
            var green = new CustomItem(dvergers.LoadAsset<GameObject>("$customdvergergreen"), fixReference: true,
                new ItemConfig
                {
                    Amount = 1,
                    CraftingStation = "piece_workbench",
                    RepairStation = "piece_workbench",
                    MinStationLevel = 2,
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Silver", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "SurtlingCore", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "Crystal", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "Guck", Amount = 3}
                    }
                });
            ItemManager.Instance.AddItem(green);

        }

        private void LoadOrange()
        {
            //       CustomSlotManager.ApplyCustomSlotItem(orangefab, "wishbone");
            var orange = new CustomItem(dvergers.LoadAsset<GameObject>("$customdvergerorange"), fixReference: true,
                new ItemConfig
                {
                    Amount = 1,
                    CraftingStation = "piece_workbench",
                    RepairStation = "piece_workbench",
                    MinStationLevel = 2,
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Silver", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "SurtlingCore", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "Crystal", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "Carrot", Amount = 3}
                    }
                });
            ItemManager.Instance.AddItem(orange);

        }



        private void LoadPurple()
        {
            //       CustomSlotManager.ApplyCustomSlotItem(purplefab, "$customdvergerpurple");
            var purple = new CustomItem(dvergers.LoadAsset<GameObject>("$customdvergerpurple"), fixReference: true,
                new ItemConfig
                {
                    Amount = 1,
                    CraftingStation = "piece_workbench",
                    RepairStation = "piece_workbench",
                    MinStationLevel = 2,
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Silver", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "SurtlingCore", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "Crystal", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "Turnip", Amount = 3}
                    }
                });
            ItemManager.Instance.AddItem(purple);

        }



        private void LoadRed()
        {
            //       CustomSlotManager.ApplyCustomSlotItem(redfab, "$customdvergerred");
            var red = new CustomItem(dvergers.LoadAsset<GameObject>("$customdvergerred"), fixReference: true,
                new ItemConfig
                {
                    Amount = 1,
                    CraftingStation = "piece_workbench",
                    RepairStation = "piece_workbench",
                    MinStationLevel = 2,
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Silver", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "SurtlingCore", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "Crystal", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "Bloodbag", Amount = 3}
                    }
                });
            ItemManager.Instance.AddItem(red);

        }



        private void LoadWhite()
        {
            //       CustomSlotManager.ApplyCustomSlotItem(whitefab, "$customdvergerwhite");
            var white = new CustomItem(dvergers.LoadAsset<GameObject>("$customdvergerwhite"), fixReference: true,
                new ItemConfig
                {
                    Amount = 1,
                    CraftingStation = "piece_workbench",
                    RepairStation = "piece_workbench",
                    MinStationLevel = 2,
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Silver", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "SurtlingCore", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "Crystal", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "BoneFragments", Amount = 3}
                    }
                });
            ItemManager.Instance.AddItem(white);

        }



        private void LoadYellow()
        {
            //     
            var yellow = new CustomItem(dvergers.LoadAsset<GameObject>("$customdvergeryellow"), fixReference: true,
                new ItemConfig
                {
                    Amount = 1,
                    CraftingStation = "piece_workbench",
                    RepairStation = "piece_workbench",
                    MinStationLevel = 3,
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Silver", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "SurtlingCore", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "Crystal", Amount = 3, AmountPerLevel = 1},
                        new RequirementConfig { Item = "MushroomYellow", Amount = 3}
                    }
                });
            ItemManager.Instance.AddItem(yellow);

        }




        //note to self

        /// you will care about copying basically this chunk of code right here 
        // private void Bird_of_Paradise_Plant() //this is the function name you need to change it 
        // {
        //     var Bird_of_Paradise_Thing = dvergers.LoadAsset<GameObject>("custompiece_birdofparadise"); //this defines the prefab name in your uniy project 
        // you need to change planterthing and planter every time you copy this 
        //      var Bird_of_Paradise = new CustomPiece(Bird_of_Paradise_Thing,
        //          new PieceConfig
        //          {
        //              PieceTable = "_PlantitPieceTable",
        //               AllowedInDungeons = false,
        //               Requirements = new[]
        //              {
        //                 new RequirementConfig {Item = "Wood", Amount = 2, Recover = true}
        //            }
        //         });
        //     PieceManager.Instance.AddPiece(Bird_of_Paradise);
        //   }


        [HarmonyPatch(typeof(ZNetScene), "Awake")]
        static private class Prefabpatch
        {
            static void Postfix(ref ZNetScene __instance)
            {
                GameObject dvergerYellow = __instance.GetPrefab("$customdvergeryellow");
                CustomSlotManager.ApplyCustomSlotItem(dvergerYellow, "$customdvergeryellow");
            }
        }

        // to here 

    }
}