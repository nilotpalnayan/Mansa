using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {


    public GameObject target;
    public GameObject player;


	// Use this for initialization
	void Start () {
        player.transform.position = target.transform.position; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
