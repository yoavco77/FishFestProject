using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinScript : MonoBehaviour
{
    public Boolean isOpened = false;
    RaycastHit2D hit;
    Camera cam;

    public Sprite openSprite;
    public Sprite closedSprite;

    public Boolean isOccupied = false;
    public float occupiedTimer = 0f;
    public float occupationDelay = 3f;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

 
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("fish") & isOpened & !isOccupied)
        {
            Destroy(collision.gameObject);
            isOccupied = true;
            GetComponent<SpriteRenderer>().color = Color.gray;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isOccupied)
        {
            occupationTimer();
        }


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
                            GetComponent<SpriteRenderer>().sprite = closedSprite;
                            isOpened = false;
                        }
                        else
                        {
                            GetComponent<SpriteRenderer>().sprite = openSprite;
                            isOpened = true;
                        }

                }
            }
        }

    }

    public void occupationTimer()
    {
        occupiedTimer += Time.deltaTime;

        if (occupiedTimer > occupationDelay)
        {
            isOccupied = false;
            occupiedTimer = 0f;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
