using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodCharacterController : MonoBehaviour
{
    [SerializeField] GameObject mouseCursor;
    [SerializeField] float rotation = 0;
    [SerializeField] float speed = 3;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] Transform laserSpawnPoint;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotation();
        Shooting();
        UpdateMouseCursorPosition();
    }

    void Movement() {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
    
    void Rotation() {
        //Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector3.forward);
    }

    void Shooting() {
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(laserPrefab, laserSpawnPoint.position, transform.rotation);
        }
    }

    void UpdateMouseCursorPosition()
    {
        mouseCursor.transform.position = Input.mousePosition;
    }
    
    private void OnApplicationFocus(bool focus)
    {
        if(focus == true) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        } else {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
