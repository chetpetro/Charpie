using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour{
    public int openingDirection;
    // 1 --> need bottom door
    // 2 --> need top door
    // 3 --> need left door
    // 4 --> need right door

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    public float waitTime = 4f;

    private void Start() {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>(); // Get the RoomTemplates Object
        Invoke("Spawn", 0.1f); // Call the Spawn function with a short delay --> delay allows to check if collisions are present and allows object to be deleted
    }

    void Spawn(){
        if(spawned == false) {
            if (openingDirection == 1) {
                // need to spawn bottom door
                rand = Random.Range(0, templates.bottomRooms.Length); // Chooses a random index in the cooresponding RoomTemplate list
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation); // Spawn a new room
            } else if (openingDirection == 2) {
                // need to spawn top door
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            } else if (openingDirection == 3) {
                // need to spawn left door
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            } else if (openingDirection == 4) {
                // need to spawn right door
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }

    // Function is automatically ran by Rigidbody if a spawn point is colliding with something
    void OnTriggerEnter2D(Collider2D other) {
        // Check if one spawnpoint is colliding with another spawnpoint 
        if(other.CompareTag("SpawnPoint")) {
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false) {
                // Spawn walls blocking off opening
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
