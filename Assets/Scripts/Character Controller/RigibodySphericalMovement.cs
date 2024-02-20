using System;

namespace characterControllerSystems
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    
    public class RigibodySphericalMovement : MonoBehaviour
    { 
        [SerializeField] private float speed = 5;
        private Rigidbody rb;
        private Vector3 direction;
        private float magnitude;
        private float gravity = -100f;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))* speed * Time.deltaTime;
        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + transform.TransformDirection(direction));

            Vector3 gravityUp = (transform.position).normalized;
            rb.AddForce(gravityUp * gravity);
            
            Vector3 localUp = transform.up;
            Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * transform.rotation;
            transform.rotation = targetRotation;
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }
    }
}

/*
    [SerializeField] private float speed = 4f;
   private Rigidbody rb;
   
   private float horizontalInput, verticalInput;
   // Start is called before the first frame update
   void Start()
   {
   rb = GetComponent<Rigidbody>();
   }
   
   // Update is called once per frame
   void Update()
   {
   horizontalInput = Input.GetAxis("Horizontal");
   verticalInput = Input.GetAxis("Vertical");
   }
   
   private void FixedUpdate()
   {
   Vector3 origin = Vector3.zero;
   Quaternion horizontalQuaternion = Quaternion.AngleAxis(-horizontalInput * speed * Time.deltaTime, Vector3.up);
   Quaternion verticalQuaternion = Quaternion.AngleAxis(verticalInput * speed * Time.deltaTime, Vector3.right);
   
   Quaternion q = horizontalQuaternion * verticalQuaternion;
   rb.MovePosition(q * (rb.transform.position - origin) + origin);
   } 
*/

