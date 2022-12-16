using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopZone : MonoBehaviour
{
    public GameObject shopUi;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            shopUi.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            shopUi.SetActive(false);
        }
    }
}
