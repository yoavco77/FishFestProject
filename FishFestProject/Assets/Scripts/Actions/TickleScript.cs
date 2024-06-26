using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickleScript : ActionScript
{
    RaycastHit2D hit;
    Camera cam;
    SoundScript soundScript;
    SpriteRenderer spriteRenderer;
    public Boolean isOccupied = false;
    public float occupiedTimer = 0f;
    public float occupationDelay = 3f;
    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        soundScript= GetComponent<SoundScript>();

    }

    // Update is called once per frame
    void Update()
    {

        if (isOccupied)
        {
            occupationTimer();
        }

        CheckForClick("Act", 0);
    }

    public void CheckForClick(string methodToInvoke, float delay)// invokes the method with the name if THIS object is clicked
    {
        // Checking if there was a click of a mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Definimg the position of the mouse
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            // casting a ray cast and then checking whether it hit something and if it did if it was a puddle
            hit = Physics2D.Raycast(mousePos, transform.right, 0.01f);
            if (hit.collider != null)
            {
                Debug.Log("yaySushi");
                if (hit.collider.gameObject == this.gameObject)// check if the mouse is on THIS object
                {

                    Invoke(methodToInvoke, delay);
                }
            }
        }
    }
    public override void Act()
    {
        GameObject[] fishs = GameObject.FindGameObjectsWithTag("fish");// find all fish
        if (fishs.Length != 0)
        {
            GameObject closestFish = fishs[0];// find closest Fish
            foreach (GameObject GO in fishs)
            {
                if (Vector3.Distance(this.transform.position, GO.transform.position) < Vector3.Distance(this.transform.position, closestFish.transform.position))
                {
                    closestFish = GO;
                }
            }

            FishScript closestFishScript = closestFish.GetComponent<FishScript>();

            if (closestFishScript.Recepie[closestFishScript.RecepieIndex] == this & !isOccupied)// do the action only if it needs to be done
            {
                closestFish.GetComponent<FishScript>().RecepieIndex++;// next state
                closestFish.GetComponent<FishScript>().UpdateSprite();
                isOccupied = true;
                spriteRenderer.color = Color.gray;
                soundScript.playSound();
            }
            else if (isOccupied)
            {
                soundScript.playSound(1);
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
            spriteRenderer.color = Color.white;
        }
    }
}
