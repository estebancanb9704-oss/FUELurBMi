using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShoppingListManager : MonoBehaviour {
    [System.Serializable]
    public class ItemEntry {
        public string itemName;   // Name of the item (e.g., "Bread")
        public Toggle toggle;     // Reference to the UI checkbox
    }

    [Header("Shopping List Items")]
    public List<ItemEntry> items; // Assign in Inspector

    /// <summary>
    /// Call this when the player collects an item.
    /// </summary>
    public void CollectItem(string itemName) {
        foreach (var entry in items) {
            if (entry.itemName == itemName) {
                if (!entry.toggle.isOn) {
                    entry.toggle.isOn = true; // ? check the box
                    Debug.Log("Collected: " + itemName);
                }
                return; // stop once we found it
            }
        }

        Debug.LogWarning("Item not found in shopping list: " + itemName);
    }
}
