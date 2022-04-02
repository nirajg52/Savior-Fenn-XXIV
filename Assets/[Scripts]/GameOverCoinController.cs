using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverCoinController : MonoBehaviour
{
    public TextMeshProUGUI CoinText;
    public int coins;

    void Start()
    {
        coins = GameHandler.coins;
    }

    // Update is called once per frame
    void Update()
    {
        CoinText.text = "Coins Collected: " + coins;
    }
}
