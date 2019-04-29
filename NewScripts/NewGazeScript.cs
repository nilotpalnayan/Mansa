using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGazeScript : MonoBehaviour {

    public GameObject teleportImage;
    public Image newGazeImage;
    public GameObject player;
    public float gazeTime = 0.0f;
    public float totalTime = 2.0f;
    public float speed;
    public float teleportPauseCounter;
    public int teleportCounter = 0 ;
    public bool gvrStatus;
    public int stepPlayerTeleport;
    public GameObject targetPlayer1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!gvrStatus & teleportCounter == 1)
        {
            teleportPauseCounter = 2; 
        }


        if (gvrStatus) 
        {
            gazeTime = gazeTime + Time.deltaTime;
            teleportPauseCounter = teleportPauseCounter + Time.deltaTime;
            newGazeImage.fillAmount = gazeTime / totalTime;
        }


        if (teleportPauseCounter > 1.9 & teleportPauseCounter < 3.5)
        {
            TeleportPlayerAtoB();
            teleportCounter = 1;
        }

    }


    //update over


    public void GvrOn()
    {
        gvrStatus = true; 
    }

    public void GvrOf()
    {
        gvrStatus = false;
        gazeTime = 0.0f;
        newGazeImage.fillAmount = 0;

    }


    public void TeleportPlayerAtoB()
    {
        Vector3 initPosPlayer1 = player.transform.position;
        Vector3 targetPosPlayer1 = targetPlayer1.transform.position;
        MoveScriptAB teleportPlayer1 = new MoveScriptAB();
        teleportPlayer1.MoveObject(player, initPosPlayer1, targetPosPlayer1, speed);
    }


   


}
