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
        //there shouldn't really be much happening here
        Exit(); //please change this...
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
