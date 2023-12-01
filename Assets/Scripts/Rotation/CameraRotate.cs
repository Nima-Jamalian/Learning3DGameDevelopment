namespace rotation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CameraRotate : MonoBehaviour
    {
        [SerializeField] private Transform objectToRotateAround;

        [SerializeField] private float radius = 4f;

        [SerializeField] private float sensitivity = 8;
        // Start is called before the first frame update
        void Start()
        {
            //locking the Cursor
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            //Option: Change radius (distance of camera to object) using mouse scroll wheel.
            radius += Input.mouseScrollDelta.y;
            
            transform.position = objectToRotateAround.position - (transform.forward * radius);
            //Rate up and down (Vector up/Y Axis) of object based on Mouse X position
            transform.RotateAround(objectToRotateAround.position,Vector3.up, Input.GetAxis("Mouse X") * sensitivity);
            //Rate left and right (transform.right) of object based on Mouse X position
            transform.RotateAround(objectToRotateAround.position,transform.right,Input.GetAxis("Mouse Y") * sensitivity);
            
            //Press the space bar to apply no locking to the Cursor
            if (Input.GetKey(KeyCode.Space))
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    } 
}

