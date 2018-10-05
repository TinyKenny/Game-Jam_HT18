using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller {

    //#86d1dc

    public float MaxSpeed = 5.0f;
    public Vector3 Velocity;
    public LayerMask PlayerLayer;
    /*
    public LayerMask CollisionLayers;
    public float Gravity;
    public Collider collider;
    public float GroundCheckDistance;
    public float InputMagnitudeToMove;
    public MinMaxFloat SlopeAngles;
    */


    public Camera Cam;
    public GameObject DestinationMarkerPrefab;
    public Vector3 TargetDestination;
    public GameObject TargetDestinationMarker;

    void Start () {
        Cam = Camera.main;
        TargetDestination = transform.position;
	}

    public void UpdateTargetDestination()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 MousePos = Input.mousePosition;
            Ray ray = Cam.ScreenPointToRay(MousePos);
            RaycastHit Hit;
            Physics.Raycast(ray, out Hit, PlayerLayer);

            Debug.Log(Hit.collider);

            Vector3 Target = new Vector3(Hit.point.x, Hit.point.y + 1.0f, Hit.point.z);
            SetTargetDestination(Target);
        }
    }

    public void SetTargetDestination(Vector3 Target)
    {
        TargetDestination = Target;
        CreateDestinationMarker();
    }

    private void DestroyDestinationMarker()
    {
        if (TargetDestinationMarker != null)
        {
            Destroy(TargetDestinationMarker);
        }
    }

    private void CreateDestinationMarker()
    {
        DestroyDestinationMarker();
        TargetDestinationMarker = Instantiate(DestinationMarkerPrefab, TargetDestination, Quaternion.identity);
    }

    public void ClearTargetDestination()
    {
        SetTargetDestination(transform.position);
        DestroyDestinationMarker();
    }
}
