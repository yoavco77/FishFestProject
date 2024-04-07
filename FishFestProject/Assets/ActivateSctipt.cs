using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSctipt : MonoBehaviour
{

    public bool Active = true;

    RaycastHit2D hit;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
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
                if (hit.collider.gameObject == this.gameObject)// check if the mouse is on THIS object
                {

                    Invoke(methodToInvoke, delay);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        CheckForClick("Activate", 0);
    }

    public void Activate()
    {
        Active = !Active;
    }
}
