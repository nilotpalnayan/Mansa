using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMainGame : MonoBehaviour {

    public GameObject endGameCanvas; 
    public AudioClip statement1;
    public AudioClip statement2;
    public AudioClip statement3;
    public AudioClip statement4;
    public AudioClip statement5;
    public AudioClip statement6;
    public AudioClip statement7;
    public AudioClip statement8;
    public AudioClip ganeshBhagwanAudio; 
    public float gameTime;
    public float speed;
    public float pauseTime = 0.0f;
    float statement3Time;
    float statement5Time;
    float statement6Time;
    int subStepToTemple;
    int rotateCount;
    //public AudioSource firstStatement;
    int statementCount = 0;
    public GameObject player;
    public GameObject guide;
    public GameObject guideTarget1;
    public GameObject guideTarget2;
    public GameObject guideTarget3;
    public GameObject guideTarget4; 
    public GameObject playerTarget1;
    public GameObject playerTarget2;
    public GameObject playerTarget3;
    public GameObject playerTarget4;
    public GameObject templeGate;
    public GameObject finalTarget; 
    public GameObject teleportImage1;
    public GameObject[] artifact = new GameObject[4];
    public GameObject[] prasad = new GameObject[4];
    public GameObject step2TeleportImage;
    public GameObject step3TeleportImage;
    public GameObject decesion1Image;
    public GameObject mapToTemple; 
    public Image loadingImage;
    public GameObject mapImage;
    public bool[] state = new bool[4];
    public bool[] statePrasad = new bool[4];
    public GameObject[] map = new GameObject[4];
    public bool[] mapStatus = new bool[4];
    public GameObject[] playerTargetTemple = new GameObject[3];
    public AudioClip[] audioMap = new AudioClip[4];
    int numActiveMap; 




    // Use this for initialization
    void Start () {

        gameObject.GetComponent<AudioSource>();
        decesion1Image.SetActive(false);
        step3TeleportImage.SetActive(false);
        mapImage.SetActive(false);
        endGameCanvas.SetActive(false);


    }

    // Update is called once per frame
    void Update () {

        gameTime = gameTime + Time.deltaTime;


        if (statementCount == 0)
        {
            player.GetComponent<SelectGameScript>().enabled = false; 
            PlayThisAudioStatement(statement1);
            //Invoke("StatementPlay" , 2);
            statementCount = statementCount + 1;
        }

        if (gameTime > statement1.length & statementCount == 1 & rotateCount == 0)
        {
            guide.transform.Rotate(0, 180, 0, Space.Self);
            rotateCount = 1;
        }

        if (gameTime > statement1.length  & statementCount == 1)
        {
            MoveScriptAB teleport = new MoveScriptAB();
            Vector3 initGuide1 = guide.transform.position;
            Vector3 guideTargetPos1 = guideTarget1.transform.position;
            teleport.MoveObject(guide , initGuide1 , guideTargetPos1 , speed);

            gameObject.GetComponent<NewGazeScript>().enabled = true;
            teleportImage1.SetActive(true);
        }

        Vector3 guidePosition = guide.transform.position;
        Vector3 guideTargetPosition = guideTarget1.transform.position;
        float distanceGuideArtifact = Vector3.Distance(guidePosition, guideTargetPosition);

        if (distanceGuideArtifact < 0.5 & rotateCount == 1)
        {
            guide.transform.Rotate(0, 180, 0, Space.Self);
            rotateCount = 2;
        }


        //guide reached at the position of artifact
        //gazeImage foot appeared on the screen


        //statement 1 played
        //Guide reached near artifact
        //player reached near artifact
        //coding for: if player distance less than minDistanceArtifact than play statement 2 and statementCount is equal to 2 


        Vector3 playerPosition = player.transform.position;
        Vector3 playerTargetPosition = playerTarget1.transform.position;
        float distancePlayerArtifact = Vector3.Distance(playerPosition , playerTargetPosition);
        Debug.Log(distancePlayerArtifact);


        if (distancePlayerArtifact < 0.5 & statementCount == 1 )
        {

            pauseTime = pauseTime + Time.deltaTime;
            // play statement 2 - give instructions to choose artifact ; 
            if (pauseTime > 2)
            {
                PlayThisAudioStatement(statement2);
                statementCount = statementCount + 1; 
            }
        }

        // statement two complete now user has to choose artifact


        if (statementCount == 2)
        {

            for (int i = 0; i < 4; i++)
            {
                state[i] = !artifact[i].activeInHierarchy;
            }

            if (state[0] & state[1] & state[2] & state[3])
            {
                loadingImage.fillAmount = 0.0f;
                PlayThisAudioStatement(statement3);
                statementCount = statementCount + 1;
                Debug.Log(statementCount);
                statement3Time = gameTime; 

            }
        }

        if (statementCount == 3 & gameTime - (statement3Time + statement3.length) > 2 & rotateCount == 2) 
        {
            guide.transform.Rotate(0, 180, 0, Space.Self);
            rotateCount = 3;
        }


        Vector3 guide2Position = guide.transform.position;
        Vector3 guide2TargetPosition = guideTarget2.transform.position;
        float distanceGuide2Artifact = Vector3.Distance(guide2Position, guide2TargetPosition);

        if (distanceGuide2Artifact < 0.5 & rotateCount == 3)
        {
            guide.transform.Rotate(0, 180, 0, Space.Self);
            rotateCount = 4;
        }



        if (statementCount == 3 & gameTime - (statement3Time + statement3.length) > 2)
        {
            MoveScriptAB teleportGuide2 = new MoveScriptAB();
            Vector3 initialGuidePos = guide.transform.position;
            Vector3 guideTargetPos2 = guideTarget2.transform.position;
            teleportGuide2.MoveObject(guide , initialGuidePos , guideTargetPos2 , speed);

            step2TeleportImage.SetActive(true);

            player.GetComponent<StepTowardsPrasad>().enabled = true;
            player.GetComponent<NewGazeScript>().enabled = false; 

        }




        if (statementCount == 3)
        {
            Vector3 playerPos = player.transform.position;
            Vector3 targetPos = playerTarget2.transform.position;

            if (Vector3.Distance(targetPos , playerPos) < 0.05)
            {
                PlayThisAudioStatement(statement4);
                statementCount = 4;
            }
        }

        // statement 3 played, now user has to move towards temple 


        if (statementCount == 4)
        {
            for (int i = 0; i < 4; i++)
            {
                statePrasad[i] = !prasad[i].activeInHierarchy;
            }

            if (statePrasad[0] & statePrasad[1] & statePrasad[2] & statePrasad[3])
            {
                PlayThisAudioStatement(statement5);
                statementCount = 5;
                statement5Time = gameTime;
            }
        }


        // code to move guide from Prasad to 1st corner 

        if (statementCount == 5 & gameTime - (statement5Time + statement5.length) > 2 & subStepToTemple != 1 & rotateCount == 4)
        {
            guide.transform.Rotate(0, 180, 0, Space.Self);
            rotateCount = 5;
            Debug.Log("guide rotating " + rotateCount + "times");
        }



        if (statementCount == 5 & gameTime - (statement5Time + statement5.length) > 2 & subStepToTemple != 1 & rotateCount == 5)
        {

            MoveScriptAB teleportGuide3 = new MoveScriptAB();
            Vector3 initialGuidePos = guide.transform.position;
            Vector3 guideTargetPos3 = guideTarget3.transform.position;
            teleportGuide3.MoveObject(guide, initialGuidePos, guideTargetPos3, speed);

            step3TeleportImage.SetActive(true);

            player.GetComponent<StepTowardsPrasad>().enabled = false;
            player.GetComponent<StepToTemple1>().enabled = true;

            // code to move guide from corner1 to nect position


            Vector3 initGuide = guide.transform.position;
            Vector3 subStepGuide = guideTarget3.transform.position;




            if (Vector3.Distance(initGuide, subStepGuide) < 0.05)
            {

                Debug.Log("guide has reached the corner");
                decesion1Image.SetActive(true);

            }


            Vector3 initPlayer1 = player.transform.position;
            Vector3 finalPlayer1 = playerTarget3.transform.position;

            if (Vector3.Distance(initPlayer1 , finalPlayer1)< 0.05)
            {
                PlayThisAudioStatement(statement6);
                statementCount = 6;
                subStepToTemple = 1;
            }
        }


        if (statementCount == 6)
        {
            Vector3 initPlayer = player.transform.position;
            Vector3 targetPlayer = templeGate.transform.position;
            if (Vector3.Distance(initPlayer , targetPlayer)< 0.5)
            {
                PlayThisAudioStatement(ganeshBhagwanAudio);
                statementCount = 7; 
            }
        }

        if (statementCount == 7)
        {

            Vector3 initPlayer = player.transform.position;
            Vector3 targetPlayer = finalTarget.transform.position;
            if (Vector3.Distance(initPlayer, targetPlayer) < 0.05)
            {
                mapToTemple.SetActive(false); 
                PlayThisAudioStatement(statement7);
                statementCount = 8;
                endGameCanvas.SetActive(true);

            }
        }


    }


    //update function done





    void PlayThisAudioStatement(AudioClip clip)
    {

        Debug.Log("pauseTime");

        PlayAudio statement2player = new PlayAudio();
        statement2player = GameObject.FindWithTag("Player").GetComponent<PlayAudio>();
        statement2player.PlayThisAudioClip(clip);
    }


    /*
    void StatementPlay()
    {
        PlayAudio playFirstStatement = new PlayAudio();
        playFirstStatement.PlayThisAudio(firstStatement);
        Debug.Log("statementPlay working");
    }
    */
}
