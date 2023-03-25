using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class Inventory : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public int maxItems = 5;
    public TextMeshProUGUI inventoryText;

    void Start()
    {
        UpdateInventoryText();
    }

    void UpdateInventoryText()
    {
        inventoryText.text = "Inventory: " + items.Count.ToString() + "/" + maxItems.ToString();
    }

    public void AddItem(GameObject item)
    {
        if (items.Count < maxItems)
        {
            items.Add(item);
            UpdateInventoryText();
        }
        else
        {
            Debug.Log("Inventory is full!");
        }
    }

    public void RemoveItem(GameObject item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            UpdateInventoryText();
        }
        else
        {
            Debug.Log("Item not found in inventory!");
        }
    }
}
