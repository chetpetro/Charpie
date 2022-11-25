using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;
    public GameObject startRoom;

    public List<GameObject> rooms;

    public float waitTime;

    private void Start()
    {
        waitTime = 3f;
    }
    private void Update(){
        if(waitTime <= 0){
            if (rooms.Count < 25){
                for (int i = rooms.Count-1; i >= 0; i--){
                    Destroy(rooms[i]);
                    rooms.Remove(rooms[i]);
                }
                waitTime = 3f;
                Instantiate(startRoom, transform.position, transform.rotation);
                rooms.Clear();
            }
        }
        else{
            waitTime -= Time.deltaTime;
        }
    }
}

