using UnityEngine;

//--- item scriptable object to easily create new items to add to the shop
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    public string name;
    public Sprite image;
    public int price;
}