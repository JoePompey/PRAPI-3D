using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    //Variables for movement.
    [SerializeField] private float Speed = 5f;
    [SerializeField] private float MouseSensitivity = 2f; 
    private Vector3 MoveDirection;
    private float RotationY;
    //.

    PlayerInput InputForPlayer;
    InputAction MoveAction;
    InputAction LookAction;

    //Fires at start.
    private void Start()
    {
        //Gets inputs.
        InputForPlayer = GetComponent<PlayerInput>();
        MoveAction = InputForPlayer.actions.FindAction("Move");
        LookAction = InputForPlayer.actions.FindAction("Look");
        //.
    }
    //.

    //Fires every frame.
    void Update()
    {
        //Fires movement and rotation.
        HandleMovement();
        HandleRotation();
        //.
    }
    //.

    //Movement calculations and firing.
    private void HandleMovement()
    {
        //Gets direction character should move in.
        Vector2 MoveVector = MoveAction.ReadValue<Vector2>();
        MoveDirection = new Vector3(MoveVector.y, 0f, MoveVector.x * -1);
        //.

        //Moves in direction calculated above.
        transform.Translate(MoveDirection * Speed *  Time.deltaTime);
        //.
    }
    //.

    //Rotation calculations and firing.
    private void HandleRotation()
    {
        //Gets mouse movement and converts to a rotation.
        Vector2 LookVector = LookAction.ReadValue<Vector2>();
        RotationY += LookVector.x * MouseSensitivity;
        //.

        //Rotates character.
        transform.rotation = Quaternion.Euler(0f, RotationY, 0f);
        //.
    }
    //.
}
