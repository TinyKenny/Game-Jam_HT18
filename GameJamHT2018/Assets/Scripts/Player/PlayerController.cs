using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller {

    //#86d1dc

    public float MaxSpeed = 5.0f;
    public LayerMask CollisionLayers;
    public float Gravity;
    public Collider collider;
    public Vector3 Velocity;
    public float GroundCheckDistance;
    public float InputMagnitudeToMove;
    public MinMaxFloat SlopeAngles;


    public Camera Cam;
    public GameObject DestinationMarkerPrefab;
    public Vector3 TargetDestination;
    public GameObject TargetDestinationMarker;

    void Start () {
        collider = GetComponent<CapsuleCollider>();
        Cam = Camera.main;
        TargetDestination = transform.position;
	}
}
