using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    Camera cam;
    Collider planeCollider;
    RaycastHit hit;
    Ray ray;

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        planeCollider = GameObject.Find("Plane").GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));
        ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == planeCollider)
                {
                    transform.position = Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime * 5);
                    transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
                }
            }
        }
    }
}
