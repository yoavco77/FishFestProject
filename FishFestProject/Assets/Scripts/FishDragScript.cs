using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDragScript : MonoBehaviour
{
    Camera cam;
    private bool isMouseDown = false;
    private Vector3 mousePosition;
    private RaycastHit2D hit;
    // Update is called once per frame

    private void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }


    void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(mousePosition, transform.right, 0.5f);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject) // fixed bug with multipul objects [checking for object insted of checking for the tag]
                {
                    isMouseDown = true;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
        }

        if (isMouseDown)
        {
            Vector3 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;
            transform.position = Vector3.Slerp(transform.position, mouseWorldPos, Time.deltaTime * 30f);


        }
    }

    public void Hold()
    {
        isMouseDown = true;
    }

}
