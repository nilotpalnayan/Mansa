using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepToTemple2 : MonoBehaviour {

    public Image loader;
    public GameObject player;
    public GameObject playerTarget4;
    public float totalTime = 2.0f;
    public float gvrTime;
    public float timeGo;
    public float speed;
    bool gvrStatus;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (gvrStatus)
        {
            gvrTime = gvrTime + Time.deltaTime;
            timeGo = gvrTime;
            loader.fillAmount = gvrTime / totalTime;
        }

        if (timeGo > 2)
        {
            loader.fillAmount = 0;
            player.GetComponent<StepToTemple1>().enabled = false;
            MoveScriptAB moveToTemple2 = new MoveScriptAB();
            Vector3 playerPos = player.transform.position;
            Vector3 targetpos = playerTarget4.transform.position;
            moveToTemple2.MoveObject(player, playerPos, targetpos, speed);
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
