using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionRotation : MonoBehaviour
{
    public Vector3 objectRot;

    public Vector3 anglesToRotate;
    // Start is called before the first frame update
    void Start()
    {
        //objectRot = new Vector3(objectRot.x % 360, objectRot.y % 360, objectRot.z % 360);
        Quaternion rotationX = Quaternion.AngleAxis(objectRot.x, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(objectRot.y, Vector3.up);
        Quaternion rotationZ = Quaternion.AngleAxis(objectRot.z, Vector3.forward);
        //Combine rotations in a specific order
        /*
         * When you multiply two quaternions, the order matters.
         * Quaternion multiplication is not commutative, meaning that the result depends
         * on the order in which you multiply the quaternions. T
         * he multiplication of quaternions in Unity follows a left-to-right order.
         * What we want to achieve is to apply Z first then x and then y
         * so the order of rotation should Y*X*Z
         */
        Quaternion finalRotation = rotationY * rotationX * rotationZ;
        transform.rotation = finalRotation;
    }
  
    // Update is called once per frame
    void Update()
    {
        Quaternion rotationX = Quaternion.AngleAxis(anglesToRotate.x * Time.deltaTime, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(anglesToRotate.y  * Time.deltaTime, Vector3.up);
        Quaternion rotationZ = Quaternion.AngleAxis(anglesToRotate.z  * Time.deltaTime, Vector3.forward);
        //Combine rotations in a specific order
        Quaternion finalRotation = rotationY * rotationX * rotationZ;
        transform.rotation = finalRotation  * transform.rotation;
        //objectRot = new Vector3(objectRot.x % 360, objectRot.y % 360, objectRot.z % 360);
    }
}
