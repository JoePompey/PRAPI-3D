using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    //Variables for movement.
    [SerializeField] private float Speed = 5f;
    [SerializeField] private float MouseSensitivity = 2f; 
    private Vector3 MoveDirection;
    private float RotationY;
    //.

    //Fires every frame.
    void Update()
    {
        HandleMovement();
        HandleRotation();
    }
    //.

    //Movement calculations and firing.
    private void HandleMovement()
    {
        //Gets direction character should move in and normalises so diagonals aren't faster.
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        MoveDirection = new Vector3(Horizontal, 0f, Vertical).normalized;
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
        float MouseX = Input.GetAxis("Mouse X");
        RotationY += MouseX * MouseSensitivity;
        //.

        //Rotates character.
        transform.rotation = Quaternion.Euler(0f, RotationY, 0f);
        //.
    }
    //.
}
