using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonChracterControllerRootMotion : MonoBehaviour
{
    private CharacterController characterController;

    [SerializeField] private float playerSpeed = 5;
    private readonly float gravity = -9.81f;

    private float yDirection = 0;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Direction / Input
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        float inputMagnitue = Mathf.Clamp01(direction.magnitude);
        //Gravity
        yDirection += gravity * Time.deltaTime;
        

        //Velocity
        Vector3 velocity = direction * playerSpeed;
        velocity.y = yDirection;

        //Movement
        characterController.Move(velocity * Time.deltaTime);
        //characterController.SimpleMove(direction * playerSpeed);
    }
}
