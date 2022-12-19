using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy1Movement : MonoBehaviour
{
    public float maxSpeed;
    public float minSpeed;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<AIPath>().maxSpeed = Random.Range(minSpeed, maxSpeed);
    }

}
