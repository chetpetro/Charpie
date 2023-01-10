using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinText : MonoBehaviour
{
    private TMPro.TextMeshProUGUI mText;
    private PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        mText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the UI element to match the current amount of coins the player has
        mText.text = playerStats.playerCoins.ToString();
    }
}
