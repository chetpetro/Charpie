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

    public float waitTimeSet;
    private float waitTime;

    private void Start()
    {
        waitTime = waitTimeSet;
    }


    private void Update(){
        if(waitTime <= 0){
            if (rooms.Count > 40){
                for (int i = 0; i < rooms.Count; i++){
                    Destroy(rooms[i]);
                    // remove index from list *********************
                }
                waitTime = waitTimeSet;
                Instantiate(startRoom, transform.position, Quaternion.identity);
            }
        }
        else{
            waitTime -= Time.deltaTime;
        }
    }
}

