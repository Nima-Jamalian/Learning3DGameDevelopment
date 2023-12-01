using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardMousePosition : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        transform.LookAt(mousePosition);
    }
}
