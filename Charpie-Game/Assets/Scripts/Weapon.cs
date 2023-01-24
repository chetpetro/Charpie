// Script Written By: Liam

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    public PlayerStats playerStats;

    private void Start() {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }
    public void Fire()
    {
        // Create bullet when gun is fired and not in shop
        if (!playerStats.inShop) {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
            // Finds the audio in set of arrays and plays the audio when requirement is met
            FindObjectOfType<AudioManager>().Play("GunShot");
        }
    }
}
