using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<ShopManager> items = new List<ShopManager>();

    // Method to purchase an item
    public void PurchaseItem(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            // Implement your purchase logic here
            Debug.Log("Purchased item: " + items[index].itemName);
        }
        else
        {
            Debug.LogWarning("Invalid item index: " + index);
        }
    }
}


