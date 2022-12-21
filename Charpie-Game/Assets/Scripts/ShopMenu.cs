using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour {

    private PlayerStats playerStats;
    public int[] powerups = {0, 1, 2, 3, 4};

    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

    }


    public void BuyHealth()
    {
        int healthCost = 100;
        if(playerStats.playerCoins >= healthCost)
        {
            playerStats.playerCoins -= healthCost;
            playerStats.playerHeath += 1;
        }
    }

    public void ShopButton(int buttonNumber)
    {
        
    }

}
