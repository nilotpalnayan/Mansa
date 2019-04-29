using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SelectGameScript : MonoBehaviour {


    public GameObject gameScene;
    public AudioSource audioSource; 
    public GameObject selectGameScene;
    public GameObject player;
    public Image loader;
    public GameObject playerPos; 
    float gvrtime;
    float totalTime = 2;
    float gvrTimeGo;
    bool gvrStatus; 
	// Use this for initialization
	void Start () {
        player.GetComponent<NewMainGame>().enabled  = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (gvrTimeGo < 2)
        {
            audioSource.Pause();
        }

        if (gvrStatus)
        {
            gvrtime = gvrtime + Time.deltaTime;
            loader.fillAmount = gvrtime / totalTime; 
        }


        if (gvrtime > 2)
        {
            gvrTimeGo = gvrtime; 
        }


        if (gvrTimeGo > 2)
        {
            gameScene.SetActive(true);
            selectGameScene.SetActive(false);
            player.GetComponent<NewMainGame>().enabled = true;
            loader.fillAmount = 0;
            GvrOff();
        }

		
	}


    public void GvrOn()
    {
        gvrStatus = true; 
    }


    public void GvrOff()
    {
        gvrStatus = false;
        gvrtime = 0;
        loader.fillAmount = 0; 
    }
}
