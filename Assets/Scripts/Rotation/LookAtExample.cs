using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtExample : MonoBehaviour
{
    [SerializeField] private Transform targest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(targest,Vector3.up);
    }
}
