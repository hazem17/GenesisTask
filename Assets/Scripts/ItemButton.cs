using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//---- enum to diplay the owner of an item
public enum ItemOwner { Shopkeeper, Player}
//--- item button for inventory
public class ItemButton : MonoBehaviour
{
    public Item item;
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI priceText;
    public ItemOwner owner;
    Shop shop;

    public void InitItem(Item _item, ItemOwner _owner, Shop _shop) 
    {
        item = _item;
        itemImage.sprite = item.image;
        priceText.text = item.price.ToString();
        owner= _owner;
        shop = _shop;   
    }

    //--- called when pressing on the item
    public void SellItem()
    {
        shop.SellItemTo(this);
    }

    
}
