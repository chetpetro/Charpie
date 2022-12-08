using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotation : MonoBehaviour
{
    Quaternion InitRot;

    private void Start()
    {
        InitRot = transform.rotation;
    }

    private void Update()
    {
        if(gameObject.transform.parent == null)
        {
            InitRot = transform.rotation;
        }
    }

    private void LateUpdate()
    {
        if(gameObject.transform.parent != null)
        {
            transform.rotation = InitRot;
        }
    }
}
