using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public int health;
    private RoomEnemies roomEnemies;
    public GameObject coin;
    public float hitSpeed;

    private void Start()
    {
        roomEnemies = GameObject.FindGameObjectWithTag("Enemies").GetComponent<RoomEnemies>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1;

            if (health < 1)
            {
                roomEnemies.enemyCount -= 1;
                Instantiate(coin, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
