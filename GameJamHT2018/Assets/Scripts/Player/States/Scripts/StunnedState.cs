using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/StunnedState")]
public class StunnedState : State {
    private PlayerController _controller;

    public override void Initialize(Controller owner)
    {
        _controller = (PlayerController)owner;
    }

    public override void Enter()
    {
        Debug.Log("Entering Stunned State");
        ClearTargetDestination();
    }

    public override void Update()
    {
        _controller.UpdateAttackTimer();
        //there shouldn't really be much happening here
        if (true) //please change this...
        {
            _controller.TransitionTo<BaseState>();
            return;
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Stunned State");
    }

    private void ClearTargetDestination()
    {
        _controller.ClearTargetDestination();
    }
}
