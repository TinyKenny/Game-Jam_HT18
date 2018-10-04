using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {

    public Transform player;
    [Range(-2.0f, 2.0f)]
    public float angle = 0.3f;
    public float distanceFromPlayer = 20.0f;

    private bool hasPlayer = true;

	// Use this for initialization
	void Start () {
		if (player == null)
        {
            hasPlayer = false;
            Debug.LogError("Camera does not have an object to track");
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}
    
    private void LateUpdate()
    {
        if (hasPlayer)
        {
            float radAngle = Mathf.PI * angle;
            transform.position = player.position - new Vector3(0.0f, -distanceFromPlayer * Mathf.Sin(radAngle), distanceFromPlayer * Mathf.Cos(radAngle));
            transform.LookAt(player);
        }
    }
}
