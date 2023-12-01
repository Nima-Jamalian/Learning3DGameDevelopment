using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBasedOnInput : MonoBehaviour
{
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Vertical"),0,(Input.GetAxis("Horizontal")*-1));
        transform.Rotate(direction*speed*Time.deltaTime,Space.Self);

    }
}
