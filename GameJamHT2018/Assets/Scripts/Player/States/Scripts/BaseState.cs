using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/BaseState")]
public class BaseState : State {
    private PlayerController _controller;

    private Camera Cam { get { return _controller.Cam; } }
    private Transform transform { get { return _controller.transform; } }
    private Vector3 TargetDestination { get { return _controller.TargetDestination; } set { _controller.TargetDestination = value; } }
    private GameObject TargetDestinationMarker { get { return _controller.TargetDestinationMarker; } set { _controller.TargetDestinationMarker = value; } }
    private GameObject DestinationMarkerPrefab { get { return _controller.DestinationMarkerPrefab; } set { _controller.DestinationMarkerPrefab = value; } }

    public override void Initialize(Controller owner)
    {
        _controller = (PlayerController)owner;
    }

    public override void Enter()
    {
        Debug.Log("Entering Base State");
        TargetDestination = transform.position;
    }

    public override void Update()
    {
        UpdateTargetDestination();
        if (Vector3.Distance(transform.position, TargetDestination) > MathHelper.FloatEpsilon)
        {
            _controller.TransitionTo<MovingState>();
            return;
        }

    }

    public override void Exit()
    {
        Debug.Log("Exiting Base State");
    }

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
        if(TargetDestinationMarker != null)
        {
            Destroy(TargetDestinationMarker);
        }
    }

    private void CreateDestinationMarker()
    {
        DestroyDestinationMarker();
        TargetDestinationMarker = Instantiate(DestinationMarkerPrefab, TargetDestination, Quaternion.identity);
    }
}
