using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideSetTeleport : MonoBehaviour {

    // Use this for initialization
    public GameObject teleport ;
    public bool state = true; 

    public void ToggleCheck () {
        Invoke("ToggleGuide", 2);
	}
	
	// Update is called once per frame


    public void ToggleGuide()
    {
        if (state)
        {
            teleport.SetActive(false);
            state = false;
            Debug.Log("jai shri ram");
        }
        else
        {
            teleport.SetActive(true);
            state = true;
        }
    }
}
