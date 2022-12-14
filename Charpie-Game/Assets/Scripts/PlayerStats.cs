using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int playerHeath;
    public int playerCoins;
    public HealthBar healthBar;

    void Start()
    {
        healthBar.SetMaxHealth(playerHeath);
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
