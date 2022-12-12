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
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
            playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
            playerStats.playerHeath -= 1;
            
        }
        else
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            Rb.velocity = direction * Mathf.Max(speed, 0f);
            bounceCount += 1;

            if (bounceCount > 10)
            {
                Destroy(gameObject);
            }
        }

    }
}
