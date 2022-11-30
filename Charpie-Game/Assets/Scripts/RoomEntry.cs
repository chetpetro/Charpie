using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEntry : MonoBehaviour
{
    public GameObject doors;
    public GameObject trigger;
    public GameObject mask;
    private EnemySpawnPoints enemySpawnPoints;
    private bool beenTriggered = false;
    private bool enemiesSpawned = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            doors.SetActive(true);
            mask.SetActive(false);
            beenTriggered= true;

            if (!enemiesSpawned)
            {
                enemySpawnPoints.spawnEnemies();
                enemiesSpawned = true;
            }
            
        }

    }

    private void Update()
    {
        if(enemySpawnPoints.enemyCount < 1)
        {
            doors.SetActive(false);
            if (beenTriggered)
            {
                trigger.SetActive(false);
            }

        }
    }
}