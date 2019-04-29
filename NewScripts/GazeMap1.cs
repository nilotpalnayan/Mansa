using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeMap1 : MonoBehaviour {

    public Image loader;
    float gvrTime;
    float gvrTimeGo;
    float totalTime = 2.0f;
    public float speed = 0.05f; 
    bool gvrStatus;
    int numActiveMap;
    public GameObject player; 
    public GameObject[] mapImage = new GameObject[5] ;
    public GameObject[] playerTarget = new GameObject[5];
    int i = 0; 




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
        Debug.Log("gvrTime is " + gvrTimeGo);


        if (gvrTimeGo > 2)
        {

            mapImage[i].SetActive(false);
            player.GetComponent<StepToTemple2>().enabled = false;

            Vector3 playerPos = player.transform.position;
            // Vector3 targetPos = playerTarget[i].transform.position;
            /*if (Vector3.Distance(playerPos, targetPos) < 0.5)
            {
                i = i + 1;
            }
            */

            Vector3 targetPosNew = playerTarget[i].transform.position;

            MoveScriptAB teleportPlayerToTemple = new MoveScriptAB();
            teleportPlayerToTemple.MoveObject(player, playerPos, targetPosNew, speed);

            GvrOff();
            loader.fillAmount = 0;

            gvrStatus = false;
            Debug.Log("destance is " + Vector3.Distance(playerPos, targetPosNew));


            if (Vector3.Distance(playerPos, targetPosNew) < 0.5)
            {
                Debug.Log("kill gvrTimego");
                gvrTimeGo = 0;
                i = i + 1;
            }


        }

    }


    public void GvrOn()
    {
        gvrStatus = true;
    }

    public void GvrOff()
    {
        gvrStatus = false;
        gvrTime = 0;
    }

}
