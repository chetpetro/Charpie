using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateGraph : MonoBehaviour
{

    public float waitTime = 3f;
    public bool updated = false;

    private RoomTemplates roomTemplates;
    public GameObject door;


    private void Start()
    {
        roomTemplates = FindObjectOfType<RoomTemplates>();
    }


    // After the map has generated, update the graphs of the map so the A* pathfinding algroithm can work
    void Update(){
        if(waitTime < 0){
            if (!updated){
                AstarPath.active.Scan();
                updated = true;


                for(int i = 1; i < roomTemplates.rooms.Count; i++)
                {
                    if(roomTemplates.rooms[roomTemplates.rooms.Count - i].name != "Empty Room(Clone)")
                    {
                        Instantiate(door, roomTemplates.rooms[roomTemplates.rooms.Count - i].transform.position, roomTemplates.rooms[roomTemplates.rooms.Count - i].transform.rotation);
                        break;
                    }
                }
            }
        }
        else{
            waitTime -= Time.deltaTime;
        }
    }
}
