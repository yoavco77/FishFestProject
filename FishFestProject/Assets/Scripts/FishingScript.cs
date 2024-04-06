using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingScript : MonoBehaviour
{
    public List<string> fishTypes = new List<string>();
    RaycastHit2D hit;
    Camera cam;
    void Start()
    {
        cam = GameObject.FindWithTag("Camera").GetComponent<Camera>();
    }

    
    void Update()
    {
        
        // Checking if there was a click of a mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Definimg the position of the mouse
            Vector3 mousePos = cam.WorldToScreenPoint(Input.mousePosition);
            mousePos.z = 0;
            // casting a ray cast and then checking whether it hit something and if it did if it was a puddle
             hit = Physics2D.Raycast(mousePos, transform.right,0.5f);
            if(hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("puddle"))
                {
                    // Call the random fish spawn function
                }
            }
        }
    
    
    }
    
    GameObject createFish()
    {
        GameObject fish = new GameObject();
        // We'll use the Random function to decide what type the fish will be
        // with every number representing a uniqe fish
        int fishTypeIndex = 0;
        fish.AddComponent<SpriteRenderer>();
        SpriteRenderer sr = fish.GetComponent<SpriteRenderer>();
        
        fishTypeIndex = Random.Range(0, fishTypes.Count);
        fish.name = "fish";
        fish.tag = fishTypes[fishTypeIndex];
        






        return fish;
    }

}
