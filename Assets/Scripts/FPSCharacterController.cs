using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSCharacterController : MonoBehaviour
{
    private CharacterController characterController;

    [SerializeField] private float playerSpeed = 5;
    [SerializeField] private float jumpPower = 5;
    private float gravity = -9.81f;

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
        
        //Gravity
        yDirection += gravity * Time.deltaTime;

        if (characterController.isGrounded)
        {
            //Rest yDirection
            yDirection = -0.5f;
            
            //Jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yDirection = jumpPower;
            }  
        }
  
        //Velocity
        Vector3 velocity = direction * playerSpeed;
        velocity.y = yDirection;
        
        //Movement
        characterController.Move(velocity * Time.deltaTime);
        //characterController.SimpleMove(direction * playerSpeed);
    }
}
