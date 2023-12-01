using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundExample : MonoBehaviour
{
    [SerializeField] private GameObject target;

    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Spin the object around the target at 20 degrees/second.
        transform.RotateAround(target.transform.position,Vector3.up,speed*Time.deltaTime);
    }
}
