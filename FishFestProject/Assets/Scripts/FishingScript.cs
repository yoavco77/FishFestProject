using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingScript : MonoBehaviour
{


   

    public List<GameObject> fishTypes = new List<GameObject>();
    RaycastHit2D hit;
    Camera cam;
    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    
    void Update()
    {
        CheckForClick("createFish", 0);
    
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
                if (hit.collider.gameObject.CompareTag(gameObject.tag))// check if the mouse is on THIS object
                {

                    // Call the random fish spawn function    //Guy: "you can use Instantiate insted"

                    Invoke(methodToInvoke, delay);
                }
            }
        }
    }



    public void createFish()
    {
        // create the object
        GameObject NewFish = Instantiate(fishTypes[Random.Range(0, fishTypes.Count)], transform.position, Quaternion.identity);

        NewFish.GetComponent<FishDragScript>().Hold();
    }

}
