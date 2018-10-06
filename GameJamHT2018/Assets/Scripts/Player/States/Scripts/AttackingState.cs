using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/AttackingState")]
public class AttackingState : State {
    private PlayerController _controller;

    private float AttackSpeed = 1.0f; //attacks per second;
    private float TimeSinceAttack = 0.0f;

    private Transform transform { get { return _controller.transform; } }
    private Vector3 AttackDirection { get { return _controller.AttackDirection; } }
    private Vector3 TargetDestination { get { return _controller.TargetDestination; } }

    public override void Initialize(Controller owner)
    {
        _controller = (PlayerController)owner;
    }

    public override void Enter()
    {
        
    }

    public override void Update ()
    {
		if(AttackDirection.magnitude < MathHelper.FloatEpsilon)
        {
            if (Vector3.Distance(transform.position, TargetDestination) > MathHelper.FloatEpsilon)
            {
                _controller.TransitionTo<MovingState>();
                return;
            }
            _controller.TransitionTo<BaseState>();
            return;
        }

	}

    public override void Exit()
    {
        
    }

    private void CheckInput()
    {

    }
}
