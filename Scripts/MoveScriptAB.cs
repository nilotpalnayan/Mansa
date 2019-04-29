using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScriptAB : MonoBehaviour {

    // Use this for initialization
    public GameObject player;
    public GameObject playerTarget1;
	
    public void MoveObject(GameObject gb , Vector3 start , Vector3 target  ,float speed)
    {

        float distanceAB = Vector3.Distance(target, start);

        if (distanceAB > 0.5)
        {
            gb.transform.position = Vector3.MoveTowards(start, target, speed);
        }

    }
}
