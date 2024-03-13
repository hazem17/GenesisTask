using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---- the shop gets all items (scriptable objects) from the resources folder
//---- the shop controls transactions between the player and the shopkeeper
public class Shop : MonoBehaviour
{
    [SerializeField] 
    private Player player;
    [SerializeField]
    private ItemButton itemPrefab;
    [SerializeField]
    private Shopkeeper selectedShopkeeper;
    public Item[] allItems;

    [Header("UI")]
    [SerializeField] private Transform shopkeeperInventory;
    [SerializeField] private Transform playerInventory;
    [SerializeField] private GameObject shopPanel;
    // Start is called before the first frame update
    void Start()
    {
        allItems = Resources.LoadAll<Item>("Items/");
    }

    //--- item was sold
    public void SellItemTo(ItemButton item)
    {
        if (item.owner == ItemOwner.Shopkeeper)
        {
            if (player.CheckCoins() >= item.item.price)
            {

                SpawnItem(item.item, ItemOwner.Player, playerInventory,
                player);
                player.MakeTransaction(-item.item.price);
                selectedShopkeeper.RemoveItem(item);
            }
        }
        else
        {
            SpawnItem(item.item, ItemOwner.Shopkeeper, shopkeeperInventory,
                selectedShopkeeper);
            player.MakeTransaction(item.item.price);
            player.RemoveItem(item);
        }
       
    }

    //--- spawn item and add it to any inventory
    private void SpawnItem(Item newItem, ItemOwner owner, Transform inventory, BaseSeller seller)
    {
        ItemButton itemBTN = Instantiate(itemPrefab, inventory);
        itemBTN.InitItem(newItem, owner, this);
        seller.itemButtons.Add(itemBTN);
    }

    public void OpenShop(Shopkeeper newShopkeeper)
    {
        selectedShopkeeper = newShopkeeper;
        for (int i = 0; i < selectedShopkeeper.items.Count; i++)
        {
            SpawnItem(selectedShopkeeper.items[i], ItemOwner.Shopkeeper, shopkeeperInventory,
                selectedShopkeeper);
        }

        for (int i = 0; i < player.items.Count; i++)
        {
            SpawnItem(player.items[i], ItemOwner.Player, playerInventory,
                player);
        }
        shopPanel.SetActive(true);
    }

    public void CloseShop()
    {
        selectedShopkeeper.RefereshInventory();
        player.RefereshInventory();

        DestroyChildren(shopkeeperInventory);
        DestroyChildren(playerInventory);
    }

    public void DestroyChildren(Transform target)
    {
        foreach (Transform child in target)
        {
            Destroy(child.gameObject);
        }
    }
}
