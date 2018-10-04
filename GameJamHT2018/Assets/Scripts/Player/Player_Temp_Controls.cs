using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Temp_Controls : MonoBehaviour { //this only exists to test the camera script

    public LayerMask groundLayer;
    public GameObject destinationMarkerPrefab;

    private float movementSpeed = 5.0f;
    private Vector3 targetDestination;
    private GameObject targetDestinationMarker;


	// Use this for initialization
	void Start () {
        targetDestination = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Camera cam = Camera.main;
            Vector2 mousePos = Input.mousePosition;

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, groundLayer);
            Debug.Log(hit.point);
            targetDestination = new Vector3(hit.point.x, transform.position.y, hit.point.z);

            transform.LookAt(targetDestination);

            targetDestinationMarker = Instantiate(destinationMarkerPrefab, targetDestination, Quaternion.identity);
        }

        if (Vector3.Distance(transform.position, targetDestination) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetDestination, movementSpeed * Time.deltaTime);
        } else if (targetDestinationMarker != null)
        {
            Destroy(targetDestinationMarker);
        }
	}
}
