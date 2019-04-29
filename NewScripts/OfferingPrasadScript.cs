using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class OfferingPrasadScript : MonoBehaviour {

    public Image loader;
    public GameObject[] prasadF = new GameObject[4];
    public GameObject[] prasadT = new GameObject[4];
    public float speed;
    float totalTime = 2;
    float gvrTime;
    float gvrTimeGo;
    bool gvrStatus;
    int i;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gvrStatus)
        {
            gvrTime = gvrTime + Time.deltaTime;
            loader.fillAmount = gvrTime / totalTime; 
        }

        if (gvrTime > 2)
        {
            gvrTimeGo = gvrTime;
        }

        if (gvrTimeGo > 2)
        {
            Vector3 prasadPos = prasadT[i].transform.position;
            prasadF[i].transform.position = prasadPos;

            i = i + 1;

            gvrTimeGo = 0;
            Gvroff();
            loader.fillAmount = 0; 
        }
	}


    public void GvrOn()
    {
        gvrStatus = true; 
    }
    public void Gvroff()
    {
        gvrStatus = false;
        gvrTime = 0;
        loader.fillAmount = 0;
    }
}
