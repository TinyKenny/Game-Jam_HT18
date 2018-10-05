using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/StunnedState")]
public class StunnedState : State {
    private PlayerController _controller;

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
        Debug.Log("Entering Stunned State");
    }

    public override void Update()
    {
        //there shouldn't really be much happening here...
    }

    public override void Exit()
    {
        Debug.Log("Exiting Stunned State");
    }
}
