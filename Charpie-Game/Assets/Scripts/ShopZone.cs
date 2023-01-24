// Script Written By: Liam

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopZone : MonoBehaviour
{
    public GameObject shopUi;
    private PlayerStats playerStats;

    private void Start() {
        shopUi.SetActive(false);
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player is colliding with the shop trigger, display the shop
        if (other.gameObject.tag == "Player"){
            shopUi.SetActive(true);
            playerStats.inShop = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // If the player is out of the shop, disable the shop
        if (other.gameObject.tag == "Player"){
            shopUi.SetActive(false);
            playerStats.inShop = false;
        }
    }
}
