using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinScript : MonoBehaviour
{
    public Boolean isOpened = false;
    RaycastHit2D hit;
    Camera cam;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fish") & isOpened)
        {
            Destroy(collision.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            hit = Physics2D.Raycast(mousePos, transform.right);
            if(hit.collider != null)
            {
                Debug.Log("hello");
                if (hit.collider.gameObject.CompareTag("bin"))
                {
                    if (isOpened)
                    {
                        isOpened = false;
                    }
                    else
                    {
                        isOpened = true;
                    }
                }
            }
        }
    }
}
