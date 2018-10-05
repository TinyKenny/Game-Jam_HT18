using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/MovingState")]
public class MovingState : State {
    private PlayerController _controller;

    private Camera Cam { get { return _controller.Cam; } }
    private Transform transform { get { return _controller.transform; } }
    private Vector3 TargetDestination { get { return _controller.TargetDestination; } set { _controller.TargetDestination = value; } }
    private GameObject TargetDestinationMarker { get { return _controller.TargetDestinationMarker; } set { _controller.TargetDestinationMarker = value; } }
    private GameObject DestinationMarkerPrefab { get { return _controller.DestinationMarkerPrefab; } set { _controller.DestinationMarkerPrefab = value; } }
    private Vector3 Velocity { get { return _controller.Velocity; } set { _controller.Velocity = value; } }

    public override void Initialize(Controller owner)
    {
        _controller = (PlayerController)owner;
    }

    public override void Enter()
    {
        Debug.Log("Entering Moving State");
    }

    public override void Update()
    {
        if(Vector3.Distance(transform.position, TargetDestination) < MathHelper.FloatEpsilon)
        {
            _controller.TransitionTo<BaseState>();
            return;
        }
        UpdateTargetDestination();
        UpdateMovement();

        transform.Translate(Velocity);
    }

    public override void Exit()
    {
        Debug.Log("Exiting Moving State");
    }

    private void UpdateMovement()
    {
        Vector3 MovementStep = Vector3.MoveTowards(transform.position, TargetDestination, _controller.MaxSpeed * Time.deltaTime);
        Velocity = MovementStep - transform.position;
    }


    private void UpdateTargetDestination()
    {
        _controller.UpdateTargetDestination();
    }


    /*
    private void UpdateTargetDestination()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 MousePos = Input.mousePosition;
            Ray ray = Cam.ScreenPointToRay(MousePos);
            RaycastHit Hit;
            Physics.Raycast(ray, out Hit);

            TargetDestination = new Vector3(Hit.point.x, Hit.point.y + 1.0f, Hit.point.z);
            CreateDestinationMarker();
        }
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
    */
}
