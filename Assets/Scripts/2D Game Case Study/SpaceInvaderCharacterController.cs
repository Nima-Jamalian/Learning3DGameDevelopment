using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceInvaderCharacterController : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float objectScaleUnit;
    [SerializeField] float worldSizeHeight, worldSizeWidth = 0f;
    [SerializeField] GameObject laserPrefab;
    // Start is called before the first frame update
    void Start()
    {
        worldSizeHeight = Camera.main.orthographicSize;
        worldSizeWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement() {
        //Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * speed * Time.deltaTime);
        //Looping Around Screen
        if (transform.position.x >= worldSizeWidth + objectScaleUnit)
        {
            transform.position = new Vector3(-worldSizeWidth - objectScaleUnit, transform.position.y, 0);
        }
        else if (transform.position.x <= -worldSizeWidth - objectScaleUnit)
        {
            transform.position = new Vector3(worldSizeWidth + objectScaleUnit, transform.position.y, 0);
        }
        //Clamp Y 
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -worldSizeHeight + objectScaleUnit, 0), 0);
    }

    void Shooting() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(laserPrefab, transform.position, Quaternion.identity);
        }
    }
}
