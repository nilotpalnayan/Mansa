using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickPrasad : MonoBehaviour {



    public GameObject player;
    public GameObject playerTarget2;
    public AudioClip statement4;
    int statementCount = 4 ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = player.transform.position;
        Vector3 targetPos = playerTarget2.transform.position;

        if (Vector3.Distance(targetPos , playerPos) < 0.05 & statementCount == 4)
        {
            PlayThisAudioStatement(statement4);
            statementCount = 5;
        }
	}

    void PlayThisAudioStatement(AudioClip clip)
    {

        Debug.Log("pauseTime");

        PlayAudio statement4player = new PlayAudio();
        statement4player = GameObject.FindWithTag("Player").GetComponent<PlayAudio>();
        statement4player.PlayThisAudioClip(clip);
    }



}
