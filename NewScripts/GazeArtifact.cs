using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeArtifact : MonoBehaviour {


    public float gazeTimer;
    public bool gvrStatusArtifact;
    public Image loadingImage;
    float totalTime = 2.0f; 


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gvrStatusArtifact)
        {
            gazeTimer = gazeTimer + Time.deltaTime;
            loadingImage.fillAmount = gazeTimer / totalTime;

            if (gazeTimer > 2)
            {
                gameObject.SetActive(false);
                Debug.Log("GameObject is active " + gameObject.activeInHierarchy);
                loadingImage.fillAmount = 0;
                GvrOffArtifact();
            }

        }


    }


    public void GvrOnArtifact()
    {
        gvrStatusArtifact = true;

    }


    public void GvrOffArtifact()
    {
        gvrStatusArtifact = false;
        gazeTimer = 0.0f;
        loadingImage.fillAmount = 0.0f; 
    }


}
