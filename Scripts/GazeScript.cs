using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeScript : MonoBehaviour {


    public Image gazeImage;
    public float totaltime = 1.7f;
    bool gvrStatus;
    float gvrTimer = 0.0f; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (gvrStatus)
        {
            gvrTimer = gvrTimer + Time.deltaTime;
            gazeImage.fillAmount = gvrTimer / totaltime;
            Debug.Log(gvrTimer);
            Debug.Log("Gvr entered");
        }
    }

    public void GvrOn()
    {
        gvrStatus = true; 
    }

    public void GvrOf()
    {
        gvrStatus = false;
        gvrTimer = 0.0f;
        gazeImage.fillAmount = 0;

    }
}
