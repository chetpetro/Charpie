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
        Debug.Log("hit");
        if (collision.gameObject.tag == "Bullet")
        {
            health -= playerStats.playerDamage;

            if (health < 1)
            {
                roomEnemies.enemyCount -= 1;
                Instantiate(coin, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
