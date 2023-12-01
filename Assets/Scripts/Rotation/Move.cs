namespace rotation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Move : MonoBehaviour
    {
        private float min = 2f;

        private float max = 3f;
        // Start is called before the first frame update
        void Start()
        {
            min=transform.position.y;
            max=transform.position.y+2;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position =new Vector3( transform.position.x,Mathf.PingPong(Time.time*2,max-min)+min, transform.position.z);
        }
    } 
}

