using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//--- contolling the money in the bank
public class Bank : MonoBehaviour, iDay
{

    [SerializeField]
    private int Balance;
    [SerializeField] 
    private Player player;


    [Header("UI")]

    [SerializeField]
    private TextMeshProUGUI balanceText;
    [SerializeField]
    private TMP_InputField withdrawField;
    [SerializeField]
    private TMP_InputField depositField;
    [SerializeField]
    private TextMeshProUGUI imvestmentText;
    void Start()
    {
        DayController.Instance.AddObjectToDayList(this);
        balanceText.text = Balance.ToString() + "$";
    }

    //--- increase money on new day
    public void NewDayStarted()
    {
        int investment = (Balance * 10 / 100);
        Balance += investment;
        imvestmentText.text = investment.ToString() + "$";
        balanceText.text = Balance.ToString() + "$";
    }

    //---- check current balance when withdrawing
    public void CheckBalanceLimit()
    {
        if (withdrawField.text.Length <= 0)
            return;

        if (int.Parse(withdrawField.text) > Balance ) {
            withdrawField.text = Balance.ToString();
        }
        else if (int.Parse(withdrawField.text) < 0)
        {
            withdrawField.text = "0";
        }
    }

    //--- check players coins when depositing
    public void CheckPlayersBalance()
    {
        if (depositField.text.Length <= 0)
            return;

        if (int.Parse(depositField.text) > player.CheckCoins())
        {
            depositField.text = player.CheckCoins().ToString();
        }
        else if (int.Parse(depositField.text) < 0)
        {
            withdrawField.text = "0";
        }
    }

    public void DepositCoins()
    {
        if (depositField.text.Length < 0)
            return;

        player.MakeTransaction(-int.Parse(depositField.text));
        Balance += int.Parse(depositField.text);
        balanceText.text = Balance.ToString() + "$";
        depositField.text = "";
    }

    public void WithdrawCoins()
    {
        if (withdrawField.text.Length < 0)
            return;

        player.MakeTransaction(int.Parse(withdrawField.text));
        Balance -= int.Parse(withdrawField.text);
        balanceText.text = Balance.ToString() + "$";
        withdrawField.text = "";
    }

    //---- clear all fields when closing the bank's panel
    public void ClearTextFields()
    {
        withdrawField.text = "";
        depositField.text = "";
    }
}
