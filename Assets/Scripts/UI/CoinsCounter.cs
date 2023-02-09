using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    private int allCoins;
    private int currentCoins;

    public int CurrentCoins { get => currentCoins; }

    private void Start()
    {
        allCoins = PlayerPrefs.GetInt("allCoins"); 
        coinsText.text = allCoins.ToString();
    }

    public void GetCoins(int coins)
    {
        currentCoins += coins;
        coinsText.text = (allCoins + currentCoins).ToString();
    }

    public void SaveCoins()
    {
        PlayerPrefs.SetInt("allCoins", allCoins += currentCoins);
    }
}
