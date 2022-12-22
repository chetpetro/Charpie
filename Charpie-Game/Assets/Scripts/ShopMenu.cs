using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour {

    private PlayerStats playerStats;
    public int[] powerups = {0,0,0};

    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        powerups[0] = Random.Range(0, 5);
        powerups[1] = Random.Range(0, 5);
        while (powerups[1] == powerups[0]) powerups[1] = Random.Range(0, 5);
        powerups[2] = Random.Range(0, 5);
        while (powerups[2] == powerups[1] || powerups[2] == powerups[0]) powerups[2] = Random.Range(0, 5);
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
        // 0 = Increased Health
        // 1 = Increased Damage
        // 2 = Fire rate
        // 3 = Speed
        // 4 = coin
        if (powerups[buttonNumber] == 0)
        {

        }
    }

}
