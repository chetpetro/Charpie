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
        roomEnemies = GameObject.FindGameObjectWithTag("Enemies").GetComponent<RoomEnemies>();
        roomEnemies.enemyCount = Random.Range(4, 9);
        for (int i = 0; i < roomEnemies.enemyCount; i++) {
            int spawnIndex = Random.Range(0, 16);
            int enemyIndex = Random.Range(0, enemyList.Length);

            Debug.Log("Spawned");
            Instantiate(enemyList[enemyIndex], enemyPoints[spawnIndex].transform.position, enemyPoints[spawnIndex].transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            doors.SetActive(true);
            mask.SetActive(false);
            beenTriggered= true;

            if (enemyPoints.Length == 0) {
                enemiesSpawned= true;
            }

            if (!enemiesSpawned) {
                spawnEnemies();
                enemiesSpawned = true;
            }

        }

    }

    private void Update()
    {
        roomEnemies = GameObject.FindGameObjectWithTag("Enemies").GetComponent<RoomEnemies>();
        if (roomEnemies.enemyCount > 0)
        {
            enemiesCreated = true;
        }

        if(roomEnemies.enemyCount < 1 && enemiesCreated)
        {
            doors.SetActive(false);
            if (beenTriggered)
            {
                trigger.SetActive(false);
            }

        }
    }

}