using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public int health;
    private RoomEnemies roomEnemies;
    private PlayerStats playerStats;
    public GameObject coin;
    public float hitSpeed;

    private void Start()
    {
        roomEnemies = GameObject.FindGameObjectWithTag("Enemies").GetComponent<RoomEnemies>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if an enemy is colliding with a bullet
        if (collision.gameObject.tag == "Bullet")
        {
            // If it is, reduce the health of the enemy by the damage of the player
            health -= playerStats.playerDamage;
            FindObjectOfType<AudioManager>().Play("EnemyHurt");

            if (health < 1)
            {
                // If the enemy has no health, kill the enemy and have it drop a coin where it died
                roomEnemies.enemyCount -= 1;
                Instantiate(coin, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
