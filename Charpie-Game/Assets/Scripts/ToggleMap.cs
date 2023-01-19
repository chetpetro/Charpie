using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMap : MonoBehaviour
{
    public GameObject miniMap;
    public GameObject bigMap;
    public GameObject miniMapBg;
    public GameObject bigMapBg;
    public GameObject miniMapBorder;
    public GameObject bigMapBorder;

    // Update is called once per frame
    void Start()
    {
        bigMap.SetActive(false);
        bigMapBg.SetActive(false);
        bigMapBorder.SetActive(false);
    }

    void Update()
    {
        // If the player presses m open the map and disable the minimap
        if (Input.GetKeyDown("m"))
        {
            miniMap.SetActive(false);
            miniMapBg.SetActive(false);
            miniMapBorder.SetActive(false);
            bigMap.SetActive(true);
            bigMapBg.SetActive(true);
            bigMapBorder.SetActive(true);
        }
        // disable the big map when m is release and show the minimap
        if (Input.GetKeyUp("m"))
        {
            miniMapBg.SetActive(true);
            miniMap.SetActive(true);
            miniMapBorder.SetActive(true);
            bigMap.SetActive(false);
            bigMapBg.SetActive(false);
            bigMapBorder.SetActive(false);
        }
    }
}
