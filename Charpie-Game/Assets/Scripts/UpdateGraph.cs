using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateGraph : MonoBehaviour
{

    private float waitTime = 3f;
    private bool updated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
