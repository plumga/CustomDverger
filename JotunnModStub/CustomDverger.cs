// JotunnModStub
// a Valheim mod skeleton using Jötunn
// 
// File:    JotunnModStub.cs
// Project: JotunnModStub

using BepInEx;
using UnityEngine;
using BepInEx.Configuration;
using Jotunn.Configs;
using Jotunn.Managers;
using Jotunn.Entities;
using Jotunn.Utils;
using CustomSlotItemLib;
using HarmonyLib;



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


        }


        private void LoadAssets()
        {
            dvergers = AssetUtils.LoadAssetBundleFromResources("dvergerasset", typeof(CustomDverger).Assembly);

        }


          [HarmonyLib.HarmonyPatch(typeof(ZNetScene), "Awake")]
          [HarmonyLib.HarmonyPostfix]
         static void PrefabPostfix(ref ZNetScene __instance)
         {
           GameObject facePrefab = __instance.GetPrefab("$customdvergeryellowearly");
           CustomSlotManager.ApplyCustomSlotItem(facePrefab, "face");
         }

        ///I give up on custom slots


        private void LoadYellowE()
        {
            var yellowefab = dvergers.LoadAsset<GameObject>("$customdvergeryellowearly");
                CustomSlotManager.ApplyCustomSlotItem(yellowefab, "face");
            var yellowe = new CustomItem(yellowefab, fixReference: true,
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
                });
            ItemManager.Instance.AddItem(yellowe);

        }

        private void LoadBlackE()
        {
            var blackefab = dvergers.LoadAsset<GameObject>("$customdvergerblackearly");
            //    CustomSlotManager.ApplyCustomSlotItem(blackfab, "wishbone");
            var blacke = new CustomItem(blackefab, fixReference: true,
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
                });
            ItemManager.Instance.AddItem(blacke);

        }


        private void LoadBlack()
        {
            var blackfab = dvergers.LoadAsset<GameObject>("$customdvergerblack");
        //    CustomSlotManager.ApplyCustomSlotItem(blackfab, "wishbone");
            var black = new CustomItem(blackfab, fixReference: true,
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
                });
            ItemManager.Instance.AddItem(black);

        }

        private void LoadDarkBlue()
        {
            var bluefab = dvergers.LoadAsset<GameObject>("$customdvergerdarkblue");

            var blue = new CustomItem(bluefab, fixReference: true,
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
            var greenfab = dvergers.LoadAsset<GameObject>("$customdvergergreen");
            
            var green = new CustomItem(greenfab, fixReference: true,
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
            var orangefab = dvergers.LoadAsset<GameObject>("$customdvergerorange");
     //       CustomSlotManager.ApplyCustomSlotItem(orangefab, "wishbone");
            var orange = new CustomItem(orangefab, fixReference: true,
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
            var purplefab = dvergers.LoadAsset<GameObject>("$customdvergerpurple");
     //       CustomSlotManager.ApplyCustomSlotItem(purplefab, "$customdvergerpurple");
            var purple = new CustomItem(purplefab, fixReference: true,
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
            var redfab = dvergers.LoadAsset<GameObject>("$customdvergerred");
     //       CustomSlotManager.ApplyCustomSlotItem(redfab, "$customdvergerred");
            var red = new CustomItem(redfab, fixReference: true,
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
            var whitefab = dvergers.LoadAsset<GameObject>("$customdvergerwhite");
     //       CustomSlotManager.ApplyCustomSlotItem(whitefab, "$customdvergerwhite");
            var white = new CustomItem(whitefab, fixReference: true,
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
            var yellowfab = dvergers.LoadAsset<GameObject>("$customdvergeryellow");
       //     CustomSlotManager.ApplyCustomSlotItem(yellowfab, "$customdvergeryellow");
            var yellow = new CustomItem(yellowfab, fixReference: true,
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


        

        // to here 

    }
}