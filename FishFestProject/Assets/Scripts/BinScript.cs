using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinScript : MonoBehaviour
{
    public Boolean isOpened = false;
    RaycastHit2D hit;
    Camera cam;
    SoundScript soundScript;

    public Sprite openSprite;
    public Sprite closedSprite;

    public Boolean isOccupied = false;
    public float occupiedTimer = 0f;
    public float occupationDelay = 3f;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        soundScript = GetComponent<SoundScript>();
    }

 
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("fish") & isOpened & !isOccupied)
        {
            soundScript.playSound();
            Destroy(collision.gameObject);
            isOccupied = true;
            GetComponent<SpriteRenderer>().color = Color.gray;
        }


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(isOccupied)
        {
            soundScript.playSound(2);
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
                            soundScript.playSound(1);
                            GetComponent<SpriteRenderer>().sprite = closedSprite;
                            isOpened = false;
                        }
                        else
                        {
                            soundScript.playSound(1);   
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
