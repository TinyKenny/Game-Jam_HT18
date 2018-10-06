using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/BaseState")]
public class BaseState : State {
    private PlayerController _controller;

    private Transform transform { get { return _controller.transform; } }
    private Vector3 TargetDestination { get { return _controller.TargetDestination; } }

    public override void Initialize(Controller owner)
    {
        _controller = (PlayerController)owner;
    }

    public override void Enter()
    {
        //Debug.Log("Entering Base State");
        ClearTargetDestination();
    }

    public override void Update()
    {
        CheckForInput();
        if (Vector3.Distance(transform.position, TargetDestination) > MathHelper.FloatEpsilon)
        {
            _controller.TransitionTo<MovingState>();
            return;
        }
    }

    public override void Exit()
    {
        //Debug.Log("Exiting Base State");
    }

    private void CheckForInput()
    {
        _controller.CheckForInput();
    }

    private void CheckInput()
    {
        
    }

    private void ClearTargetDestination()
    {
        _controller.ClearTargetDestination();
    }
}
