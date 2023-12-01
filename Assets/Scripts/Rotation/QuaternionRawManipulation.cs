using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionRawManipulation : MonoBehaviour
{
    //x^2 + y^2 + z^2 + w^2 = 1
    [Range(0,1)]
    [SerializeField] private float x, y, z, w;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion(x,y,z,w);
    }
}
