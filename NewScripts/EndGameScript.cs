using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class EndGameScript : MonoBehaviour {


    public Image loader;
    public GameObject gameScene;
    public GameObject selectGameScene;
    public GameObject endPos;
    public GameObject player; 
    float gvrTime;
    float totalTime = 2;
    float gvrTimeGo;
    bool gvrStatus; 


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gvrStatus)
        {
            gvrTime = gvrTime + Time.deltaTime;
            loader.fillAmount = gvrTime / totalTime;
            if (gvrTime > 2)
            {
                gvrTimeGo = gvrTime;
            }
        }

        if (gvrTimeGo > 2)
        {
            gameScene.SetActive(false);
            selectGameScene.SetActive(true);
            GvrOff();
            player.transform.position = endPos.transform.position; 
        }
	}


    public void GvrOn()
    {
        gvrStatus = true; 
    }

    public void GvrOff()
    {
        gvrStatus = false;
        loader.fillAmount = 0;
        gvrTime = 0;
        gvrTimeGo = 0; 

    }
}
