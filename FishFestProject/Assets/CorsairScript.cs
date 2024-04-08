using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorsairScript : MonoBehaviour
{

    public Sprite OpenHand;
    public Sprite Grab;

    Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (FindIfHolding())
            GetComponent<SpriteRenderer>().sprite = Grab;
        else GetComponent<SpriteRenderer>().sprite = OpenHand;
    }

    public bool FindIfHolding()
    {
        GameObject[] Fish = GameObject.FindGameObjectsWithTag("fish");
        foreach(GameObject fishObject in Fish)
        {
            if (fishObject.GetComponent<FishDragScript>().isMouseDown)
                return true;
        }

        return false;
    }
}
