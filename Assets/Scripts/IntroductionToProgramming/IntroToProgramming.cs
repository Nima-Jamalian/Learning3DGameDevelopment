using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroToProgramming : MonoBehaviour
{
    private int age = 28;

    private float height = 183.5f;

    private string name = "Nima";

    private char nameInitials = 'n';

    private bool isAlive = true;

    [SerializeField] private float default_health = 100f;

    private float health = 0;

    // Start is called before the first frame update
    void Start()
    {
        health = default_health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
