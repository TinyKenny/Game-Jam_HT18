using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSD_Bob : MonoBehaviour {

    private float MovementSpeed = 0.5f;
    private float MovementRange = 0.5f;
    private static float MovementDirection = 1.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdatePosition();
	}

    private void UpdatePosition()
    {
        transform.localPosition += new Vector3(0.0f, 1.0f, 0.0f) * MovementSpeed * MovementDirection * Time.deltaTime;
        //transform.localPosition = Position;
        if (transform.localPosition.y > MovementRange)
        {
            MovementDirection = -1.0f;
        }
        else if (transform.localPosition.y < 0.0f)
        {
            MovementDirection = 1.0f;
        }
    }
}
