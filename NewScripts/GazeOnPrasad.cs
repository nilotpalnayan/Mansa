using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeOnPrasad : MonoBehaviour {

    public Image loader;
    bool gvrStatus;
    public float totalTime = 2.0f;
    public float gvrTime;
    int prasadPickCounter; 

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (gvrStatus)
        {
            gvrTime = gvrTime + Time.deltaTime;
            loader.fillAmount = gvrTime / totalTime;

            if (gvrTime > 2.0f)
            {
                gameObject.SetActive(false);
                loader.fillAmount = 0;
                gvrStatus = false;
                GvrOf();

                /*
                Destroy(GetComponent<Renderer>());
                gameObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
                prasadPickCounter = prasadPickCounter + 1;
                Debug.Log(prasadPickCounter);
                */               
            }
        }

	}


    public void GvrOn()
    {
        gvrStatus = true;
    }
    public void GvrOf()
    {
        gvrStatus = false;
        gvrTime = 0;
        loader.fillAmount = 0;
    }
}
