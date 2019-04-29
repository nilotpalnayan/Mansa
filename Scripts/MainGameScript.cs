using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameScript : MonoBehaviour {


    public GameObject guide;
    public GameObject player;
    public GameObject targetObject;
    public GameObject player1target; 
    public float speed;
    public int StatementCount = 0;
    public AudioSource firstStatement;
    private float gameTime;
    private float pause = 0.0f;
    public int rayCastDistance;
    private RaycastHit _hit;
	// Use this for initialization
	void Start () {
        firstStatement = gameObject.GetComponent<AudioSource>();
        	}
	
	// Update is called once per frame
	void Update () {

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        if(Physics.Raycast(ray, out _hit , rayCastDistance))
        {

        }

        gameTime = gameTime + Time.deltaTime; 
        pause = pause + Time.deltaTime; 

        if (StatementCount == 0 & pause > 2.0f)
        {
            PlayAudio playFirstAudio = new PlayAudio();
            playFirstAudio.PlayThisAudio(firstStatement);

            if (gameTime > firstStatement.clip.length)
            {
                StatementCount = 1;
                pause = 0.0f;
                Debug.Log("statement 1 complete");
            }


        }
        

        if(StatementCount == 1 & pause > 2.0f)
        {
            Debug.Log("Pause is " + pause);
            MoveScriptAB moveGuide = new MoveScriptAB();
            Vector3 init1Guide = guide.transform.position;
            Vector3 target1Guide = targetObject.transform.position;
            moveGuide.MoveObject(guide, init1Guide, target1Guide, speed);

            Vector3 init1Player = player.transform.position;
            Vector3 target1Player = player1target.transform.position;
            moveGuide.MoveObject(player, init1Player, target1Player, speed);

            gameObject.GetComponent<PlayerMovement>().enabled = true;
            ResetTime resetTime1 = new ResetTime();
            resetTime1.Reset(pause);
            Debug.Log("pause is " + pause);
        }


    }

}
