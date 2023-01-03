using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int playerHeath;
    public int playerCoins;
    public int playerDamage;
    public float coinMultiplyer; 
    public float playerMovementSpeed;
    public int maxHealth;
    public float shotDelayReset;
    public HealthBar healthBar;

    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        healthBar.SetHealth(playerHeath);
        if(playerHeath <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
