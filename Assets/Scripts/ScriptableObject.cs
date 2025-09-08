using UnityEngine;

[CreateAssetMenu(menuName = "Shop/Item")]
public class ShopItem : ScriptableObject {
    public string itemName;
    public Sprite icon; // optional for UI
}
