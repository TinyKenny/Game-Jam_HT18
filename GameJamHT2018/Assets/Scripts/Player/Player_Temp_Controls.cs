using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Temp_Controls : MonoBehaviour { //this only exists to test the camera script

    private float movementSpeed = 5.0f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

		if (Mathf.Abs(horizontalMovement) >= 0.0f || Mathf.Abs(verticalMovement) >= 0.0f)
        {
            transform.Translate(new Vector3(horizontalMovement, 0.0f, verticalMovement) * movementSpeed * Time.deltaTime);
        }
	}
}
