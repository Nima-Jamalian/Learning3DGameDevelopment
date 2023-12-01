namespace characterControllerSystems
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class FPSCharacterController : MonoBehaviour
    {
        private CharacterController characterController;
        [SerializeField] private float playerSpeed = 5;
        [SerializeField] private float jumpPower = 5;
        [SerializeField] private float pushPower = 2f;
        private readonly float gravity = -9.81f;
        private float yDirection = 0;
        
        [SerializeField] private float mouseSensivity = 2f;
        private float mouseYRotation;
        // Start is called before the first frame update
        void Start()
        {
            characterController = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            CharacterMovement();
            CameraRotation();
            CursorEnableCheck();
        }

        private void CharacterMovement()
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
            
            //Change direction to face the rotation of the object
            velocity = transform.TransformDirection(velocity);
            
            //Movement
            characterController.Move(velocity * Time.deltaTime);
            //characterController.SimpleMove(direction * playerSpeed);
        }

        private void CameraRotation()
        {
            float mouseX = Input.GetAxis("Mouse X");
            Vector3 newRotationX = transform.localEulerAngles;
            newRotationX.y += mouseX * mouseSensivity;
            transform.localEulerAngles = newRotationX;
            
            float mouseY = Input.GetAxis("Mouse Y");
            mouseYRotation -= mouseY * mouseSensivity;
            mouseYRotation = ClampAngle(mouseYRotation, -89, 89);
            Camera.main.transform.localRotation = Quaternion.Euler(mouseYRotation, 0, 0);
        }
        
        private float ClampAngle(float Angle, float min, float max)
        {
            if(Angle < -360f)
            {
                Angle += 360f;
            }
            if(Angle > 360f)
            {
                Angle -= 360f;
            }
            return Mathf.Clamp(Angle,min,max);
        }
        
        private void CursorEnableCheck()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.transform.CompareTag("MoveObject"))
            {
                Rigidbody rigidbody = hit.collider.attachedRigidbody;

                if (rigidbody == null || rigidbody.isKinematic)
                {
                    return;
                }
            
                Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
                rigidbody.velocity = pushDirection * pushPower;
            }
        }
    }
}

