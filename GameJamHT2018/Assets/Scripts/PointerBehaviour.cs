using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerBehaviour : MonoBehaviour {

    private float OriginalHeight;
    private float RotationSpeed = 1.0f;
    private float MovementSpeed = 1.0f;
    private float MovementRange = 1.0f;

	// Use this for initialization
	void Start () {
        OriginalHeight = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(1.0f, 0.5f, 0.1f) * RotationSpeed * Time.deltaTime);
        transform.Translate(new Vector3(0.0f, 1.0f, 0.0f) * MovementSpeed * Time.deltaTime);
	}
}
