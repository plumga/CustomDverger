using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using HarmonyLib;

namespace CustomDverger
{
	[HarmonyPatch]
	public class Patches
	{
		[HarmonyPatch(typeof(ItemDrop.ItemData), "IsEquipable")]
		[HarmonyPostfix]
		private static void IsEquipablePostfix(ref bool __result, ref ItemDrop.ItemData __instance)
		{
			__result = __result || ItemSlotLib.IsCustomSlotItem(__instance);
		}

		[HarmonyPatch(typeof(Humanoid), "Awake")]
		[HarmonyPostfix]
		private static void HumanoidEntryPostfix(ref Humanoid __instance)
		{
			ItemSlotLib.customSlotItemData[__instance] = new Dictionary<string, ItemDrop.ItemData>();
		}

		[HarmonyPatch(typeof(Player), "Load")]
		[HarmonyPostfix]
		private static void InventoryLoadPostfix(ref Player __instance)
		{
			foreach (ItemDrop.ItemData equipedtem in __instance.m_inventory.GetEquipedtems())
			{
				if (ItemSlotLib.IsCustomSlotItem(equipedtem))
				{
					string customSlotName = ItemSlotLib.GetCustomSlotName(equipedtem);
					ItemSlotLib.SetSlotItem(__instance, customSlotName, equipedtem);
				}
			}
		}

		[HarmonyPatch(typeof(Humanoid), "EquipItem")]
		[HarmonyPostfix]
		private static void EquipItemPostfix(ref bool __result, ref Humanoid __instance, ItemDrop.ItemData item, bool triggerEquipEffects = true)
		{
			if (__result && ItemSlotLib.IsCustomSlotItem(item))
			{
				string customSlotName = ItemSlotLib.GetCustomSlotName(item);
				if (ItemSlotLib.IsSlotOccupied(__instance, customSlotName))
				{
					__instance.UnequipItem(ItemSlotLib.GetSlotItem(__instance, customSlotName), triggerEquipEffects);
				}
				ItemSlotLib.SetSlotItem(__instance, customSlotName, item);
				if (__instance.IsItemEquiped(item))
				{
					item.m_equiped = true;
				}
				__instance.SetupEquipment();
				if (triggerEquipEffects)
				{
					__instance.TriggerEquipEffect(item);
				}
				__result = true;
			}
		}

		[HarmonyPatch(typeof(Humanoid), "UnequipItem")]
		[HarmonyPostfix]
		private static void UnequipItemPostfix(ref Humanoid __instance, ItemDrop.ItemData item, bool triggerEquipEffects = true)
		{
			if (ItemSlotLib.IsCustomSlotItem(item))
			{
				string customSlotName = ItemSlotLib.GetCustomSlotName(item);
				if (item == ItemSlotLib.GetSlotItem(__instance, customSlotName))
				{
					ItemSlotLib.SetSlotItem(__instance, customSlotName, null);
				}
				__instance.UpdateEquipmentStatusEffects();
			}
		}

		[HarmonyPatch(typeof(Humanoid), "IsItemEquiped")]
		[HarmonyPostfix]
		private static void IsItemEquipedPostfix(ref bool __result, ref Humanoid __instance, ItemDrop.ItemData item)
		{
			if (ItemSlotLib.IsCustomSlotItem(item))
			{
				string customSlotName = ItemSlotLib.GetCustomSlotName(item);
				bool flag = ItemSlotLib.DoesSlotExist(__instance, customSlotName) && ItemSlotLib.GetSlotItem(__instance, customSlotName) == item;
				__result |= flag;
			}
		}

		[HarmonyPatch(typeof(Humanoid), "GetEquipmentWeight")]
		[HarmonyPostfix]
		private static void GetEquipmentWeightPostfix(ref float __result, ref Humanoid __instance)
		{
			foreach (string key in ItemSlotLib.customSlotItemData[__instance].Keys)
			{
				if (ItemSlotLib.IsSlotOccupied(__instance, key))
				{
					__result += ItemSlotLib.GetSlotItem(__instance, key).m_shared.m_weight;
				}
			}
		}

		[HarmonyPatch(typeof(Humanoid), "UnequipAllItems")]
		[HarmonyPostfix]
		private static void UnequipAllItemsPostfix(ref Humanoid __instance)
		{
			foreach (string item in ItemSlotLib.customSlotItemData[__instance].Keys.ToList())
			{
				if (ItemSlotLib.IsSlotOccupied(__instance, item))
				{
					__instance.UnequipItem(ItemSlotLib.GetSlotItem(__instance, item), triggerEquipEffects: false);
				}
			}
		}

		[HarmonyPatch(typeof(Humanoid), "GetSetCount")]
		[HarmonyPostfix]
		private static void GetSetCountPostfix(ref int __result, ref Humanoid __instance, string setName)
		{
			foreach (string item in ItemSlotLib.customSlotItemData[__instance].Keys.ToList())
			{
				if (ItemSlotLib.IsSlotOccupied(__instance, item) && ItemSlotLib.GetSlotItem(__instance, item).m_shared.m_setName == setName)
				{
					__result++;
				}
			}
		}

		public static HashSet<StatusEffect> GetStatusEffectsFromCustomSlotItems(Humanoid __instance)
		{
			HashSet<StatusEffect> hashSet = new HashSet<StatusEffect>();
			foreach (string key in ItemSlotLib.customSlotItemData[__instance].Keys)
			{
				if (ItemSlotLib.IsSlotOccupied(__instance, key))
				{
					if ((bool)ItemSlotLib.GetSlotItem(__instance, key).m_shared.m_equipStatusEffect)
					{
						StatusEffect equipStatusEffect = ItemSlotLib.GetSlotItem(__instance, key).m_shared.m_equipStatusEffect;
						hashSet.Add(equipStatusEffect);
					}
					if (__instance.HaveSetEffect(ItemSlotLib.GetSlotItem(__instance, key)))
					{
						StatusEffect setStatusEffect = ItemSlotLib.GetSlotItem(__instance, key).m_shared.m_setStatusEffect;
						hashSet.Add(setStatusEffect);
					}
				}
			}
			return hashSet;
		}

		[HarmonyPatch(typeof(Humanoid), "UpdateEquipmentStatusEffects")]
		[HarmonyTranspiler]
		private static IEnumerable<CodeInstruction> UpdateEquipmentStatusEffectsTranspiler(IEnumerable<CodeInstruction> instructions)
		{
			List<CodeInstruction> codes = instructions.ToList();
			if (codes[0].opcode != OpCodes.Newobj || codes[1].opcode != OpCodes.Stloc_0)
			{
				throw new Exception("CustomSlotItemLib Transpiler injection point NOT found!! Game has most likely updated and broken this mod!");
			}
			yield return codes[0];
			yield return codes[1];
			yield return new CodeInstruction(OpCodes.Ldloc_0);
			yield return new CodeInstruction(OpCodes.Ldarg_0);
			yield return CodeInstruction.Call(typeof(Patches), "GetStatusEffectsFromCustomSlotItems");
			yield return CodeInstruction.Call(typeof(HashSet<StatusEffect>), "UnionWith");
			for (int i = 2; i < codes.Count; i++)
			{
				yield return codes[i];
			}
		}
	}
}
