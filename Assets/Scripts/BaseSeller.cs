using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---- base class for player and shopkeeper
public class BaseSeller : MonoBehaviour
{
    public List<Item> items;
    public List<ItemButton> itemButtons;
    [SerializeField] protected Shop shop;

    public void AddNewItem(Item newItem)
    {
        items.Add(newItem);
    }

    public void RefereshInventory()
    {
        items.Clear();
        for (int i = 0; i < itemButtons.Count; i++)
        {
            items.Add(itemButtons[i].item);
        }
        itemButtons.Clear();
    }

    public void RemoveItem(ItemButton removedItem)
    {
        print("remove item");
        itemButtons.Remove(removedItem);
        Destroy(removedItem.gameObject);
    }
}
