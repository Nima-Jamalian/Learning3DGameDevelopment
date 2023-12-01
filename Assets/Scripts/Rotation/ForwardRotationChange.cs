namespace rotation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ForwardRotationChange : MonoBehaviour
    {
        [Range(0, 360f)] [SerializeField] private float x, y, z;
        private Quaternion targetRotation;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y - 90, transform.eulerAngles.z);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + 90, transform.eulerAngles.z);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                targetRotation = Quaternion.Euler(transform.eulerAngles.x -90, transform.eulerAngles.y , transform.eulerAngles.z);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                targetRotation = Quaternion.Euler(transform.eulerAngles.x +90, transform.eulerAngles.y , transform.eulerAngles.z);
            }
        }
        
    }
}

