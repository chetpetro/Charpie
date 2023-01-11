using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D Rb;
    public GameObject[] enemy;
    private Vector3 lastVelocity;
    private int bounceCount;

    private PlayerStats playerStats;
    

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        lastVelocity = Rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check to see what a bullet is colliding with
        if (collision.gameObject.name == "Player")
        {
            // If it is colliding with the player, destory it and damage the player
            Destroy(gameObject);
            playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
            playerStats.playerHeath -= 1;
            FindObjectOfType<AudioManager>().Play("PlayerHurt");
        }
        else
        {
            // If it is a wall, make the bullet bounce off of the wall
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            FindObjectOfType<AudioManager>().Play("BulletBounce");

            Rb.velocity = direction * Mathf.Max(speed, 0f);
            bounceCount += 1;

            if (bounceCount > 10)
            {
                // Destroy the bullet if it has bounced 10 times
                Destroy(gameObject);
            }
        }

    }
}
