using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject cannonPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           GameObject myCannon = Instantiate(cannonPrefab, transform.position, quaternion.identity);
           myCannon.GetComponent<Rigidbody>().AddForce(transform.forward  * 3500);
        }
    }
}
