using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    private UpdateGraph updateGraph;
    public GameObject loadingScreen;
    // Start is called before the first frame update
    void Start()
    {
        updateGraph = GameObject.FindWithTag("A*").GetComponent<UpdateGraph>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!updateGraph.updated)
        {
            loadingScreen.SetActive(true);
        }
        else if (updateGraph.updated)
        {
            loadingScreen.SetActive(false);
        }
    }
}
