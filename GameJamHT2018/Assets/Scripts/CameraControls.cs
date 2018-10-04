using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {

    public Transform player;

    private bool hasPlayer = true;
    private float distanceFromPlayer = 10.0f;
    [Range(0.0f, 1.0f)]
    public float angle = 0.0f;


    private Vector3 temp_distanceFromPlayer = new Vector3(0.0f, 0.0f, 10.0f);

	// Use this for initialization
	void Start () {
		if (player == null)
        {
            hasPlayer = false;
            Debug.LogError("Camera does not have an object to track");
        }
        testThingy();
	}
	
	// Update is called once per frame
	void Update () {
        if (hasPlayer)
        {
            //transform.position = player.position - temp_distanceFromPlayer;
            transform.position = player.position - new Vector3(0.0f, -distanceFromPlayer * angle, distanceFromPlayer * (1.0f - angle));
            transform.LookAt(player);
        }
        Debug.Log(Vector3.Distance(transform.position, player.position));
	}

    void testThingy()
    {
        Debug.Log("Testing!");
        return;
    }
}
