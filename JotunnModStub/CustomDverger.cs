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
using System.Reflection;

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
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), null);

        }

        private void LoadAssets()
        {
            dvergers = AssetUtils.LoadAssetBundleFromResources("dvergerasset", typeof(ItemSlotLib).Assembly);

        }


        private void LoadYellowE()
        {
            
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
        [HarmonyPostfix]
        static void PrefabPostfix(ref ZNetScene __instance)
        {
                GameObject dvergerYellow = __instance.GetPrefab("$customdvergeryellowearly");
            ItemSlotLib.ApplyCustomSlotItem(dvergerYellow, "Dverger");

                GameObject dvergerblack = __instance.GetPrefab("$customdvergerblackearly");
            ItemSlotLib.ApplyCustomSlotItem(dvergerblack, "Dverger");
            
                GameObject dvergerred = __instance.GetPrefab("$customdvergerred");
            ItemSlotLib.ApplyCustomSlotItem(dvergerred, "Dverger");
            
                GameObject dvergerwhite= __instance.GetPrefab("$customdvergerwhite");
            ItemSlotLib.ApplyCustomSlotItem(dvergerwhite, "Dverger");
            
                GameObject dvergerpurple = __instance.GetPrefab("$customdvergerpurple");
            ItemSlotLib.ApplyCustomSlotItem(dvergerblack, "Dverger");
    

        }

        // to here 

    }
}