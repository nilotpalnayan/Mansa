using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour {

    AudioSource statementPlayer;
    // Use this for initialization
    void Start()
    {
        statementPlayer= gameObject.GetComponent<AudioSource>(); 
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayThisAudioClip(AudioClip audio)
    {
        statementPlayer.PlayOneShot(audio , 1.0f);
    }

    public void PlayThisAudio(AudioSource audio1)
    {
        audio1.Play();
        Debug.Log("function working");
    }
}
