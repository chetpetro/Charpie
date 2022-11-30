using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEntry : MonoBehaviour
{
    public GameObject doors;
    public GameObject trigger;
    public GameObject mask;
    public int enemyCount;
    private bool beenTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            doors.SetActive(true);
            mask.SetActive(false);
            beenTriggered= true;
        }

    }

    private void Update()
    {
        if(enemyCount < 1)
        {
            doors.SetActive(false);
            if (beenTriggered)
            {
                trigger.SetActive(false);
            }

        }
    }
}