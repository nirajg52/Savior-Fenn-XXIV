using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinSceneCoinController : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI CoinText;
    private int coins = 0;

    

    // Update is called once per frame
    void Update()
    {
        CoinText.text = "Coins Collected: " + coins;
    }
}
