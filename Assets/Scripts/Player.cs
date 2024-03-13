using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : BaseSeller
{
    
    [SerializeField]
    private int coins = 1000;

    [SerializeField]
    private TextMeshProUGUI coinsText;
    // Start is called before the first frame update
    void Start()
    {
        coinsText.text = coins.ToString() + "$";
    }

    //--- check coins before purchases or deposits 
    public int CheckCoins()
    {
        return coins;
    }

    //---- change player's coins
    public void MakeTransaction(int amount)
    {
        coins += amount;
        coinsText.text = coins.ToString() + "$"; 
    }

}
