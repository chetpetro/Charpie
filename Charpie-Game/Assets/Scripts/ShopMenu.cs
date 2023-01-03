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
        if(playerStats.playerCoins >= healthCost && playerStats.playerHeath < playerStats.maxHealth)
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
            if (playerStats.playerCoins < 200) {
                return;
            }

            playerStats.playerHeath += 2;
            playerStats.maxHealth += 2;
            playerStats.playerCoins -= 200;
        }

        if (powerups[buttonNumber] == 1) {
            if (playerStats.playerCoins < 200) {
                return;
            }
            playerStats.playerCoins -= 200;
            playerStats.playerDamage += 1;
        }

        if (powerups[buttonNumber] == 2) {
            if (playerStats.playerCoins < 200) {
                return;
            }
            playerStats.playerCoins -= 200;
            playerStats.shotDelayReset -= playerStats.shotDelayReset * 0.3f;
        }

        if (powerups[buttonNumber] == 3) {
            if (playerStats.playerCoins < 200) {
                return;
            }
            playerStats.playerCoins -= 200;
            playerStats.playerMovementSpeed += 1;
        }

        if (powerups[buttonNumber] == 4) {
            if (playerStats.playerCoins < 200) {
                return;
            }
            playerStats.playerCoins -= 200;
            playerStats.coinMultiplyer += 0.3f;
        }


    }

}
