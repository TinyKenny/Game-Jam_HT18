using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerBehaviour : MonoBehaviour {

    private float RotationSpeed = 150.0f;
    private float MovementSpeed = 2.0f;
    private float MovementRange = 1.0f;
    private static float MovementDirection = 1.0f;
    private static Vector3 Position = new Vector3(0.0f, 0.0f, 0.0f);
    private static Quaternion Rotation = new Quaternion();

	// Use this for initialization
	void Start () {
        UpdatePosition();
        UpdateRotation();
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(new Vector3(1.0f, 0.5f, 0.1f) * RotationSpeed * Time.deltaTime);
        UpdatePosition();
        UpdateRotation();
	}

    private void UpdatePosition()
    {
        Position += new Vector3(0.0f, 1.0f, 0.0f) * MovementSpeed * MovementDirection * Time.deltaTime;
        transform.localPosition = Position;
        if (transform.localPosition.y > MovementRange)
        {
            MovementDirection = -1.0f;
        }
        else if (transform.localPosition.y < 0.0f)
        {
            MovementDirection = 1.0f;
        }
    }

    private void UpdateRotation()
    {
        transform.rotation = Rotation;
        transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f) * RotationSpeed * Time.deltaTime);
        Rotation = transform.rotation;
    }
}
