using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepTowardsPrasad : MonoBehaviour {


    public GameObject player;
    public GameObject playerTarget1;
    public GameObject playerTarget2;
    public Image gazeImageTest;
    public float gazeTime = 0.0f;
    public float totalTime = 2.0f;
    public float timeToGo;
    bool gvrStatus;
    public float speed = 2; 
    // Use this for initialization
    void Start () {
        player.transform.position = playerTarget1.transform.position; 
	}
	
	// Update is called once per frame
	void Update () {

        if (gvrStatus)
        {
            timeToGo = timeToGo + Time.deltaTime;
            gazeTime = gazeTime + Time.deltaTime;
            gazeImageTest.fillAmount = gazeTime / totalTime;
        }


        if (timeToGo > 1.9)
        {
            MoveSubstep();
        }
	}

    public void GvrOn()
    {
        gvrStatus = true;
    }

    public void GvrOf()
    {
        gvrStatus = false;
        gazeTime = 0.0f;
        gazeImageTest.fillAmount = 0;

    }

    public void MoveSubstep()
    {
        MoveScriptAB substep0 = new MoveScriptAB() ;
        Vector3 initPos = player.transform.position;
        Vector3 targetPos = playerTarget2.transform.position;
        substep0.MoveObject(player , initPos , targetPos , speed);

    }

}
