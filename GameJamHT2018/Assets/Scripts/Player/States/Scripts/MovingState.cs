using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/MovingState")]
public class MovingState : State {
    private PlayerController _controller;

    private Transform transform { get { return _controller.transform; } }
    private Vector3 TargetDestination { get { return _controller.TargetDestination; } }
    private Vector3 Velocity { get { return _controller.Velocity; } set { _controller.Velocity = value; } }
    private Vector3 PreviousPosition;

    public override void Initialize(Controller owner)
    {
        _controller = (PlayerController)owner;
    }

    public override void Enter()
    {
        //Debug.Log("Entering Moving State");
        PreviousPosition = transform.position;
    }

    public override void Update()
    {
        if(Input.GetKeyDown(KeyCode.S) || Vector3.Distance(transform.position, TargetDestination) < MathHelper.FloatEpsilon) //Something...
        {
            _controller.TransitionTo<BaseState>();
            return;
        }
        UpdateTargetDestination();
        UpdateMovement();
        transform.Translate(Velocity, Space.World);
        Velocity = new Vector3(0.0f, 0.0f, 0.0f);
        if(Vector3.Distance(transform.position, PreviousPosition) < MathHelper.FloatEpsilon)
        {
            _controller.TransitionTo<BaseState>();
            return;
        }
        PreviousPosition = transform.position;
    }

    public override void Exit()
    {
        Velocity = new Vector3(0.0f, 0.0f, 0.0f);
        //Debug.Log("Exiting Moving State");
    }

    private void UpdateMovement()
    {
        Vector3 MovementStep = Vector3.MoveTowards(transform.position, TargetDestination, _controller.MaxSpeed * Time.deltaTime);
        Vector3 Movement = MovementStep - transform.position;
        Movement = new Vector3(Movement.x, 0.0f, Movement.z);
        Velocity += Movement;
    }

    private void UpdateTargetDestination()
    {
        _controller.UpdateTargetDestination();
    }
}