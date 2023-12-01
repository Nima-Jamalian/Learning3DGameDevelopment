namespace rotation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class RotateToWard : MonoBehaviour
    {
        [SerializeField] private float speed = 20f;

        [SerializeField] private Vector3 mouseScreenPosition;
        [SerializeField] private Vector3 mouseWorldPosition;
        [SerializeField] private Camera camera;
        // Start is called before the first frame update
        void Start()
        {
 
        }

        // Update is called once per frame
        void Update()
        {
            mouseScreenPosition = Input.mousePosition;
            mouseScreenPosition.z = camera.nearClipPlane + 1;
            mouseWorldPosition = camera.ScreenToWorldPoint(mouseScreenPosition);
            Vector3 direction =  mouseWorldPosition - transform.position;
            Quaternion desiredRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z),Vector3.up);
            //transform.rotation = desiredRotation;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, speed * Time.deltaTime);
        }
    }
}

