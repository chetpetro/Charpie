// Script Written By: Chet

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoor : MonoBehaviour
{
    private RoomEnemies roomEnemies;
    private RoomTemplates roomTemplates;
    private UpdateGraph updateGraph;
    public GameObject startRoom;
    public PlayerStats playerStats;
    private bool isFixed = false;

    private void Start() {
        roomEnemies = FindObjectOfType<RoomEnemies>();
        roomTemplates = FindObjectOfType<RoomTemplates>();
        updateGraph = FindObjectOfType<UpdateGraph>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    private void Update() {
        // Delete random empty room
        if (!isFixed) {
            for (int i = roomTemplates.rooms.Count - 1; i >= 1; i--) {
                if (roomTemplates.rooms[i].transform.position == Vector3.zero && roomTemplates.rooms[i].name == "Empty Room(Clone)") {
                    Destroy(roomTemplates.rooms[i]);
                    isFixed = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Player") {
            if (roomEnemies.enemyCount < 1) {
                // Destroy all rooms
                for(int i = roomTemplates.rooms.Count-1; i >= 0; i--) {
                    Destroy(roomTemplates.rooms[i]);
                }
                roomTemplates.rooms.Clear();

                isFixed = false;

                // Spawn Default room
                Instantiate(startRoom, Vector3.zero, startRoom.transform.rotation);

                // Reset player
                collision.gameObject.transform.position = Vector3.zero;

                // destroy door
                Destroy(gameObject);

                // Update modifier
                playerStats.levelNumber += 1;
                if(playerStats.levelNumber > 3)
                {
                    SceneManager.LoadScene(3);
                }

                // Update Graphs Timing
                updateGraph.waitTime = 3f;
                updateGraph.updated = false;

            }
        }
    }
}
