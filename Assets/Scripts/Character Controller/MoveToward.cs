namespace characterControllerSystems
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class MoveToward : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        private bool canMove = false;
        private Vector3 targetPosition;
        [SerializeField] private GameObject posSelectReticle;
        private bool showPoseSelectReticle = false;
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
                        canMove = true;
                        targetPosition = new Vector3(hitInfo.point.x, transform.position.y, hitInfo.point.z);
                        Debug.Log(targetPosition);
                        showPoseSelectReticle = true;
                    }
                    else
                    {
                        showPoseSelectReticle = false;
                    }
                }
            }
            
            if (Input.GetMouseButtonDown(0) && showPoseSelectReticle == true)
            {
                posSelectReticle.transform.position = new Vector3(targetPosition.x,0,targetPosition.z);
                posSelectReticle.SetActive(true);
                StartCoroutine(hidePosSelectReticle());
            }
            
            IEnumerator hidePosSelectReticle()
            {
                yield return new WaitForSeconds(0.1f);
                showPoseSelectReticle = false;
                posSelectReticle.SetActive(false);
            }
            
            
            if (Vector3.Distance(transform.position, targetPosition) == 0)
            {
                canMove = false;
            }

            if (canMove == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition , speed * Time.deltaTime);
                transform.LookAt(targetPosition);
            }


        }
    }
}

