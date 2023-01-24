// Script Written By: Jordan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    //This is a variable that both clouds have that determines their movement speed
    public float cloudRate;




    // Update is called once per frame
    void Update()
    {
        //This moves the clouds
        gameObject.transform.position = new Vector3 (gameObject.transform.position.x + cloudRate, gameObject.transform.position.y, gameObject.transform.position.z );

        //This brings the clouds back to the left after they go off screen
        if (gameObject.transform.position.x >= 2600)
        {
            gameObject.transform.position = new Vector3(Random.Range(-400, -300), Random.Range(600, 700), gameObject.transform.position.z);
       
        }
    }
}
