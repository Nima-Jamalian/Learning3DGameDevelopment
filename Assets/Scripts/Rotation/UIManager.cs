using System;
using Unity.VisualScripting;

namespace rotation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private EulerRotation eulerRotation;

        [SerializeField] private QuaternionRotation quaternionRotation;
        [SerializeField] private TMP_Text text;

        [SerializeField] private bool useEulerRotation;

        [SerializeField] private bool useQuaternionRotation;

        [SerializeField] private bool useQuaternionManipulation;
        // Start is called before the first frame update
        void Start()
        {
            if (useQuaternionRotation)
            {
                text.text = "Object Rotation = " + quaternionRotation.objectRot + "\n" + "Angles To Rotate= " + quaternionRotation.anglesToRotate;
            } else if (useEulerRotation)
            {
                text.text = "Object Rotation = " + eulerRotation.objectRot + "\n" + "Angles To Rotate= " + eulerRotation.anglesToRotate;
            }
        }
    }
}

