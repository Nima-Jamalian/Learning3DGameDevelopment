using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EulerRotation : MonoBehaviour
{
    [SerializeField] public Vector3 objectRot;

    [SerializeField] public Vector3 anglesToRotate;
    // Start is called before the first frame update
    void Start()
    {
        //transform.Rotate(new Vector3(1,0,0),90);
        objectRot = new Vector3(objectRot.x % 360, objectRot.y % 360, objectRot.z % 360);
        transform.eulerAngles = objectRot;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = objectRot;
        objectRot += anglesToRotate * Time.deltaTime;
        objectRot = new Vector3(objectRot.x % 360, objectRot.y % 360, objectRot.z % 360);
        //transform.Rotate(new Vector3(0,0,1),90 * Time.deltaTime);
    }
}
