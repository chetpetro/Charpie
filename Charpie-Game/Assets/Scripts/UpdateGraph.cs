using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateGraph : MonoBehaviour
{

    public float waitTime = 3f;
    public bool updated = false;


    // After the map has generated, update the graphs of the map so the A* pathfinding algroithm can work
    void Update(){
        if(waitTime < 0){
            if (!updated){
                AstarPath.active.Scan();
                updated = true;
            }
        }
        else{
            waitTime -= Time.deltaTime;
        }
    }
}
