using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoints : MonoBehaviour
{
    public GameObject[] enemyPoints;
    public GameObject[] enemyList;
    public int enemyCount;

    public void spawnEnemies()
    {
        enemyCount = Random.Range(4,9);
        for(int i = 0; i < enemyCount; i++)
        {
            int spawnIndex = Random.Range(0, 16);
            int enemyIndex = Random.Range(0, enemyList.Length);

            Instantiate(enemyList[enemyIndex], enemyPoints[spawnIndex].transform.position, enemyPoints[spawnIndex].transform.rotation);

        }
    }
}
