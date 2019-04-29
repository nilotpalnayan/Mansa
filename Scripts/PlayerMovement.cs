using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float playerSpeed;

    private CharacterController playerController; 

	// Use this for initialization
	void Start () {
        playerController = GetComponent<CharacterController>(); 
	}

    // Update is called once per frame


    private void Update()
    {

        MovePlayer();
    }

    public void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0.0f, vertical);
        Vector3 velocity = direction * playerSpeed;
        velocity = Camera.main.transform.TransformDirection(velocity);
        velocity.y = velocity.y - 10.0f;
        playerController.Move(velocity * Time.deltaTime);


    }
}
