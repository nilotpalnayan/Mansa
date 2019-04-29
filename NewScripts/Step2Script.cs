using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step2Script : MonoBehaviour {


    public GameObject[] artifact = new GameObject[4];
    bool[] state = new bool[4];
    public AudioSource statement2; 

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update ()
    {
        for(int i = 0; i <4;  i++)
        {
            state[i] = !artifact[i].activeInHierarchy; 
        }

        if (state[0] & state[1] & state[2] & state[3])
        {
            //Statement2Play();
        }
    }


    void Statement2Play()
    {

        PlayAudio playFirstStatement = new PlayAudio();
        playFirstStatement.PlayThisAudio(statement2);
    }


}
