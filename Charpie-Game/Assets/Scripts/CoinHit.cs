using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHit : MonoBehaviour
{
    private PlayerStats playerStats;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        if (collision.gameObject.name == "Player")
        {
            playerStats.playerCoins += (int) Mathf.Round(Random.Range(10, 25) * playerStats.coinMultiplyer) ;
            Destroy(gameObject);
        }
    }
}
