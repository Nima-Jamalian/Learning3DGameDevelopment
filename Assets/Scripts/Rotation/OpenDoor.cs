using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private float openRotation, closeRotation;

    [SerializeField] private float speed = 5f;

    [SerializeField] private bool isOpening = false;
    // Update is called once per frame
    void Update()
    {
        Vector3 cuurentRotation = transform.rotation.eulerAngles;
        if (isOpening)
        {
            if (cuurentRotation.y < openRotation)
            {
                transform.eulerAngles = Vector3.Lerp(cuurentRotation, new Vector3(cuurentRotation.x, openRotation, cuurentRotation.x), speed * Time.deltaTime);
            }
        }
        else
        {
            if (cuurentRotation.y > closeRotation)
            {
                transform.eulerAngles = Vector3.Lerp(cuurentRotation, new Vector3(cuurentRotation.x, closeRotation, cuurentRotation.x), speed * Time.deltaTime);
            }
        }
    }

    public void OnOpenDoorButtonClick()
    {
        isOpening = !isOpening;
    }

}
