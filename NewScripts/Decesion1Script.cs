using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Decesion1Script : MonoBehaviour {
    public AudioClip trueClip;
    public AudioClip wrongClip;
    public GameObject decesion1Image;
    public GameObject mapImage;
    public GameObject player;
    public Image loader;
    float totalTime = 2.0f;
    float timeRightGo;
    float timeWrongGo;
    float timeRight;
    float timeWrong;
    float scriptTime;
    float rightAudioPlayTime;
    bool gvrStatusWrong;
    bool gvrStatusRight;
    int rightAudioCount;
    int falseAudioCount;

    // Use this for initialization
    void Start () {

        AudioSource audio1 = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame

	void Update () {
        scriptTime = scriptTime + Time.deltaTime;
        if (gvrStatusWrong)
        {
            timeWrong = timeWrong + Time.deltaTime;
            loader.fillAmount = timeWrong / totalTime;
            timeWrongGo = timeWrong;

            if (timeWrongGo > 1.9 & falseAudioCount == 0)
            {
                PlayThisAudioStatement(wrongClip);
                falseAudioCount = 1;
                GvrOff();
            }
        }

        if (gvrStatusRight)
        {
            timeRight = timeRight + Time.deltaTime;
            loader.fillAmount = timeRight / totalTime;
            timeRightGo = timeRight;


            if (timeRightGo > 1.9 & rightAudioCount == 0)
            {
                PlayThisAudioStatement(trueClip);
                rightAudioPlayTime = scriptTime; 
                rightAudioCount = 1;
                loader.fillAmount = 0;
                GvrOff();


            }

        }


        if(scriptTime > rightAudioPlayTime + trueClip.length & rightAudioCount == 1)
        {
            decesion1Image.SetActive(false);
            mapImage.SetActive(true);
            player.GetComponent<NewMainGame>().enabled = true;

        }

        /*
        if (timeRightGo > 1.9 & rightAudioCount == 0)
        {
            PlayThisAudioStatement(trueClip);
            decesion1Image.SetActive(false);
            rightAudioCount = 1;
            loader.fillAmount = 0; 
        }

        if (timeWrongGo > 1.9 & falseAudioCount == 0)
        {
            PlayThisAudioStatement(wrongClip);
            falseAudioCount = 1;
        }

        */
    }


    public void GvrOnWrong()
    {
        gvrStatusWrong = true;
    }

    public void GvrOnRight()
    {
        gvrStatusRight = true;
    }

    public void GvrOff()
    {
        gvrStatusRight = gvrStatusWrong = false;
        loader.fillAmount = 0;
        timeRight = timeWrong = 0;
        timeRightGo = timeRightGo = 0;
        falseAudioCount = 0;
    }


    void PlayThisAudioStatement(AudioClip clip)
    {
        PlayAudio clipPlayer = new PlayAudio();
        clipPlayer = GameObject.FindWithTag("Player").GetComponent<PlayAudio>();
        clipPlayer.PlayThisAudioClip(clip);
    }


}
