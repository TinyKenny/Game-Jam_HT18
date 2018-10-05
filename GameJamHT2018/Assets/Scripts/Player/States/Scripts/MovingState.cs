using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/MovingState")]
public class MovingState : State {
    private PlayerController _controller;

    private Transform transform { get { return _controller.transform; } }
    private Vector3 TargetDestination { get { return _controller.TargetDestination; } }
    private Vector3 Velocity { get { return _controller.Velocity; } set { _controller.Velocity = value; } }

    public override void Initialize(Controller owner)
    {
        _controller = (PlayerController)owner;
    }

    public override void Enter()
    {
        //Debug.Log("Entering Moving State");
    }

    public override void Update()
    {
        if(Vector3.Distance(transform.position, TargetDestination) < MathHelper.FloatEpsilon || Input.GetKeyDown(KeyCode.S)) //Something...
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
        Velocity = new Vector3(0.0f, 0.0f, 0.0f);
        //Debug.Log("Exiting Moving State");
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
}