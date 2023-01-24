// Script Written By: Liam & Chet

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEntry : MonoBehaviour
{
    public GameObject doors;
    public GameObject trigger;
    public GameObject mask;
    public int enemynumber;
    private bool beenTriggered = false;
    private bool enemiesSpawned = false;

    public GameObject[] enemyPoints;
    public GameObject[] enemyList;
    private bool enemiesCreated = false;

    private RoomEnemies roomEnemies;

    public void spawnEnemies() {
        // Spawn 4-8 enemies in random locations in the room when the player eneters
        roomEnemies = GameObject.FindGameObjectWithTag("Enemies").GetComponent<RoomEnemies>();
        roomEnemies.enemyCount = Random.Range(4, 9);

        // loop through enemy spawning depending on how many random enemies should spawn
        for (int i = 0; i < roomEnemies.enemyCount; i++) {
            int spawnIndex = Random.Range(0, enemyPoints.Length);
            int enemyIndex = Random.Range(0, enemyList.Length);

            Debug.Log("Spawned");
            // Spawn the enemies
            Instantiate(enemyList[enemyIndex], enemyPoints[spawnIndex].transform.position, enemyPoints[spawnIndex].transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // Close doors, hide mask and clear bullets when the player enters the room 
            doors.SetActive(true);
            mask.SetActive(false);
            beenTriggered= true;

            clearBullets();

            // Say enemies cleared if no spawn points in room (Shop)
            if (enemyPoints.Length == 0) {
                enemiesSpawned = true;
            }

            if (!enemiesSpawned) {
                // Start spawning enemies if spawning has not started
                spawnEnemies();
                enemiesSpawned = true;
            }

        }

    }

    private void clearBullets()
    {
        var bullets = GameObject.FindGameObjectsWithTag("Bullet");

        // Delete all of the bullets spawned 
        foreach(var bullet in bullets)
        {
            Destroy(bullet); 
        }
    }

    private void Update()
    {
        roomEnemies = GameObject.FindGameObjectWithTag("Enemies").GetComponent<RoomEnemies>();
        if (roomEnemies.enemyCount > 0){
            // Enemies have been created
            enemiesCreated = true;
        }

        if(roomEnemies.enemyCount < 1 && enemiesCreated)
        {
            // If enemies have been created and there are no enemies, open the doors and disable the trigger
            doors.SetActive(false);
            if (beenTriggered)
            {
                trigger.SetActive(false);
            }

        }
    }

}