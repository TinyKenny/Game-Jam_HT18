using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller {

    //#86d1dc

    public float MaxSpeed = 5.0f;
    public Vector3 Velocity;
    public LayerMask MovementLayers;
    public CapsuleCollider Collider;
    /*
    public LayerMask CollisionLayers;
    public float Gravity;
    public float GroundCheckDistance;
    public float InputMagnitudeToMove;
    public MinMaxFloat SlopeAngles;
    */


    public Camera Cam;
    public GameObject DestinationMarkerPrefab;
    public Vector3 TargetDestination;
    public GameObject TargetDestinationMarker;
    public Vector3 AttackDirection;
    //public float AttackSpeed = 1.0f; //attacks per second
    public float AttackTimer = 0.0f;
    public GameObject ProjectilePrefab;

    void Start () {
        Cam = Camera.main;
        TargetDestination = transform.position;
        Collider = GetComponent<CapsuleCollider>();
	}

    public void UpdateAttackTimer()
    {
        AttackTimer -= Time.deltaTime;
        if (AttackTimer < 0.0f)
        {
            AttackTimer = 0.0f;
        }
    }

    public void CheckForInput()
    {
        ClearAttackDirection();
        if (Input.GetMouseButton(0))
        {
            Vector2 MousePos = Input.mousePosition;
            Ray ray = Cam.ScreenPointToRay(MousePos);
            RaycastHit Hit;
            Physics.Raycast(ray, out Hit, Mathf.Infinity, MovementLayers, QueryTriggerInteraction.UseGlobal);

            if (Hit.collider.CompareTag("Ground"))
            {
                Vector3 Target = new Vector3(Hit.point.x, transform.position.y, Hit.point.z);
                SetTargetDestination(Target);
                transform.LookAt(TargetDestination);
            }

            
            if (Hit.collider.CompareTag("Enemy"))
            {
                SetAttackDirection(Hit.transform.position);
            }
            

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Vector3 Target = new Vector3(Hit.point.x, transform.position.y, Hit.point.z);
                SetAttackDirection(Target);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            ClearTargetDestination();
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

    private void SetAttackDirection(Vector3 Target)
    {
        ClearTargetDestination();
        AttackDirection = (Target - transform.position).normalized;
        transform.LookAt(Target);
    }
    
    private void ClearAttackDirection()
    {
        AttackDirection = new Vector3(0.0f, 0.0f, 0.0f);
    }
    /*
    public RaycastHit[] DetectHits(bool addGroundCheck = false)
    {
        Vector3 Direction = Velocity.normalized;
        //float distance = Velocity.magnitude * Time.deltaTime;
        float distance = MaxSpeed * Time.deltaTime;
        Vector3 position1 = transform.position + Collider.center + Vector3.up * (-Collider.height * 0.5f + Collider.radius);
        Vector3 Position2 = position1 + Vector3.up * (Collider.height - Collider.radius * 2);
        Debug.Log(position1);
        //List<RaycastHit> hits = Physics.CapsuleCastAll(position1, Position2, Collider.radius, Direction, distance);
        RaycastHit[] hitsArray = Physics.CapsuleCastAll(position1, Position2, Collider.radius, Direction, distance);
        List<RaycastHit> hits = new List<RaycastHit>();
        foreach (RaycastHit hit in hitsArray)
        {
            hits.Add(hit);
        }
        RaycastHit[] groundHits = Physics.CapsuleCastAll(position1, Position2, Collider.radius, Vector3.down, 1.0f);
        for(int i = 0; i < hits.Count; i++)
        {
            RaycastHit safetyHit;
            Physics.Linecast(transform.position + Collider.center, hits[i].point, out safetyHit);
            if (safetyHit.collider != null)
            {
                hits[i] = safetyHit;
            }
        }
        return hits.ToArray();
    }
    */
    
}
