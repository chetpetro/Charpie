using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    // Store player stats
    public int playerHeath;
    public int playerCoins;
    public int playerDamage;
    public float coinMultiplyer; 
    public float playerMovementSpeed;
    public int maxHealth;
    public float shotDelayReset;
    public HealthBar healthBar;
    public bool inShop = false;

    void Start()
    {
        // Set the max health of the healthbar
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        // call the update function of setting the health of the healthbar
        healthBar.SetHealth(playerHeath);

        // Reload the scene if the player dies
        if (playerHeath <= 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
