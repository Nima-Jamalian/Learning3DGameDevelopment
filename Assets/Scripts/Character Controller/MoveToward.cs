namespace characterControllerSystems
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class MoveToward : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        private Camera camera;
        // Start is called before the first frame update
        void Start()
        {
            camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        }

        // Update is called once per frame
        void Update()
        {
            //Make Object move to the position of the mouse
            //transform.position = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2));

            if (Input.GetMouseButton(0))
            {
                Ray mouseRay = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(mouseRay, out RaycastHit hitInfo))
                {
                    if (hitInfo.transform.CompareTag("Ground"))
                    {
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(hitInfo.point.x,transform.position.y,hitInfo.point.z), speed * Time.deltaTime);
                        transform.LookAt(new Vector3(hitInfo.point.x,transform.position.y,hitInfo.point.z));
                    }
                }
            }
        }
    }
}

