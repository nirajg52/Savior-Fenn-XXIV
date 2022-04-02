using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public TextMeshProUGUI CoinText;
    public static int coins = 0;

    void Start()
    {
       // CoinText=GameObject.FindObjectOfType<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        CoinText.text = "Coins: " + coins;
    }
}
