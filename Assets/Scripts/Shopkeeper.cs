using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shopkeeper : BaseSeller, iDay
{
    [SerializeField] private int inventoryCount;
    void Start()
    {
        DayController.Instance.AddObjectToDayList(this);
        //SelectNewItems();
    }

    //--- change the items in the shop at the begining of the day
    public void NewDayStarted()
    {
        print("Shop");
        SelectNewItems();
    }

    private void SelectNewItems()
    {
        items.Clear();
        for (int i = 0; i < inventoryCount; i++)
        {
            items.Add(shop.allItems[Random.Range(0, shop.allItems.Length)]);
        }
    }
}
