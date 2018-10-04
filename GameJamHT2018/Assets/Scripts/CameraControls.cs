using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {

    public Transform player;

    private bool hasPlayer = true;
    private Vector3 distanceFromPlayer = new Vector3(0.0f, 0.0f, 10.0f);

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
        if (hasPlayer)
        {
            transform.position = player.position - distanceFromPlayer;
        }
	}

    void testThingy()
    {
        Debug.Log("Testing!");
        return;
    }
}
