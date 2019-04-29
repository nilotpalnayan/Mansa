using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepToTemple1 : MonoBehaviour {


    public Image loader;
    bool gvrStatus;
    float totalTime = 2.0f;
    float gvrTime;
    float timeGo;
    int miniStepCounter; 
    public GameObject player;
    public float speed = 2;
    public GameObject[] playerTarget3 = new GameObject[2];

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


        if (gvrStatus)
        {
            gvrTime = gvrTime + Time.deltaTime;
            timeGo = gvrTime; 
            loader.fillAmount = gvrTime / totalTime;
        }

        if (timeGo > 2)
        {
            loader.fillAmount = 0; 
            MoveScriptAB moveToTemple1 = new MoveScriptAB();
            Vector3 playerPos = player.transform.position;
            Vector3 targetpos = playerTarget3[0].transform.position;
            moveToTemple1.MoveObject(player, playerPos, targetpos, speed);

        }


        Vector3 init = player.transform.position;
        Vector3 fin = playerTarget3[0].transform.position;
        Debug.Log(Vector3.Distance(init, fin));
        if(Vector3.Distance(init,  fin) < 0.5)
        {
            miniStepCounter = 1;
            Debug.Log(miniStepCounter);
            player.GetComponent<StepToTemple2>().enabled = true;
            player.GetComponent<StepToTemple1>().enabled = false;
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
    }
}
