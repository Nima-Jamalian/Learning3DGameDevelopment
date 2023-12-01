using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningRotation : MonoBehaviour
{

    [Range(0,360)]
    public float xAngle, yAngle, zAngle;

    [SerializeField] private bool worldSpace, selfSpace;
    void Update()
    {
        if (worldSpace == true)
        {
            transform.Rotate(xAngle * Time.deltaTime, yAngle * Time.deltaTime, zAngle * Time.deltaTime, Space.World);
        }
        else
        {
            transform.Rotate(xAngle*Time.deltaTime, yAngle*Time.deltaTime, zAngle*Time.deltaTime, Space.Self);
        }
    }
}
