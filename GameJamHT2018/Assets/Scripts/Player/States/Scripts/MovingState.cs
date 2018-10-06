using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/MovingState")]
public class MovingState : State {
    private PlayerController _controller;

    private Transform transform { get { return _controller.transform; } }
    private Vector3 TargetDestination { get { return _controller.TargetDestination; } }
    private Vector3 Velocity { get { return _controller.Velocity; } set { _controller.Velocity = value; } }
    private float MaxSpeed { get { return _controller.MaxSpeed; } }
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
        //PreviousPosition = transform.position;

        if(Input.GetKeyDown(KeyCode.S) || Vector3.Distance(transform.position, TargetDestination) < MathHelper.FloatEpsilon) //Something...
        {
            _controller.TransitionTo<BaseState>();
            return;
        }
        CheckForInput();
        UpdateMovement();
        transform.Translate(Velocity, Space.World);
        //Velocity = new Vector3(0.0f, 0.0f, 0.0f);
        /*
        if(Vector3.Distance(transform.position, PreviousPosition) < MathHelper.FloatEpsilon)
        {
            transform.position = PreviousPosition;
            _controller.TransitionTo<BaseState>();
            return;
        }
        */
        PreviousPosition = transform.position;
    }

    public override void Exit()
    {
        Velocity = new Vector3(0.0f, 0.0f, 0.0f);
        //Debug.Log("Exiting Moving State");
    }

    private void UpdateMovement()
    {
        Vector3 MovementStep = Vector3.MoveTowards(transform.position, TargetDestination, MaxSpeed * Time.deltaTime);
        Vector3 Movement = MovementStep - transform.position;
        Movement = new Vector3(Movement.x, 0.0f, Movement.z);
        Velocity = Movement;
    }

    private void CheckForInput()
    {
        _controller.CheckForInput();
    }

    /*
    private bool CheckCollision()
    {
        RaycastHit[] hits = _controller.DetectHits();
        if (hits.Length == 0)
        {
            //Debug.Log("wow!");
            return false;
        }

        
        foreach(RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("Player"))
            {
                continue;
            }
            Debug.Log(hit.collider);
            Debug.Log(hit.point);
            Debug.Log(hit.distance);

            Instantiate(_controller.DestinationMarkerPrefab, hit.point, Quaternion.identity);

            return true;
        }
        

        //Debug.Log("huh...");
        return false;
    }
    */
}