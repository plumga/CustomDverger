using System.Collections.Generic;
using UnityEngine;

namespace CustomDverger
{
	public static class ItemSlotLib
	{
		public static readonly Dictionary<Humanoid, Dictionary<string, ItemDrop.ItemData>> customSlotItemData = new Dictionary<Humanoid, Dictionary<string, ItemDrop.ItemData>>();

		public static string GetCustomSlotName(ItemDrop.ItemData item)
		{
			return item.m_dropPrefab.GetComponent<CustomSlotItem>().m_slotName;
		}

		public static bool IsCustomSlotItem(ItemDrop.ItemData item)
		{
			if (item != null && (bool)item.m_dropPrefab)
			{
				return item.m_dropPrefab.GetComponent<CustomSlotItem>();
			}
			return false;
		}

		public static ItemDrop.ItemData GetPrefabItemData(Humanoid humanoid, string slotName)
		{
			if (!DoesSlotExist(humanoid, slotName))
			{
				return null;
			}
			return customSlotItemData[humanoid][slotName].m_dropPrefab.GetComponent<ItemDrop>().m_itemData;
		}

		public static ItemDrop.ItemData GetSlotItem(Humanoid humanoid, string slotName)
		{
			if (DoesSlotExist(humanoid, slotName))
			{
				return customSlotItemData[humanoid][slotName];
			}
			return null;
		}

		public static void SetSlotItem(Humanoid humanoid, string slotName, ItemDrop.ItemData item)
		{
			customSlotItemData[humanoid][slotName] = item;
		}

		public static bool DoesSlotExist(Humanoid humanoid, string slotName)
		{
			if (customSlotItemData[humanoid] != null)
			{
				return customSlotItemData[humanoid].ContainsKey(slotName);
			}
			return false;
		}

		public static bool IsSlotOccupied(Humanoid humanoid, string slotName)
		{
			if (customSlotItemData[humanoid] != null && customSlotItemData[humanoid].ContainsKey(slotName))
			{
				return customSlotItemData[humanoid][slotName] != null;
			}
			return false;
		}

		public static void ApplyCustomSlotItem(GameObject prefab, string slotName)
		{
			if (!prefab.GetComponent<CustomSlotItem>())
			{
				prefab.AddComponent<CustomSlotItem>();
			}
			prefab.GetComponent<CustomSlotItem>().m_slotName = slotName;
			prefab.GetComponent<ItemDrop>().m_itemData.m_shared.m_itemType = ItemDrop.ItemData.ItemType.None;
		}
	}
}
