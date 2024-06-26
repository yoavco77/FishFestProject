using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    public string Type;

    public List<Sprite> States = new List<Sprite>();// the sprite of each state of the fish
    public List<ActionScript> Recepie = new List<ActionScript>();
    public int RecepieIndex = 0;

    public void Awake()
    {
        switch (Type)
        {
            case "Salmon":
                Recepie.Add(GameObject.Find("CuttingBoard").GetComponent<CutScript>());
                Recepie.Add(GameObject.Find("SushiStation").GetComponent<SushiScript>());
                Recepie.Add(GameObject.Find("PlateStation").GetComponent<PlateScript>());
                break;
            case "Carp":
                Recepie.Add(GameObject.Find("CuttingBoard").GetComponent<CutScript>());
                Recepie.Add(GameObject.Find("GrillStation").GetComponent<GrillScript>());
                Recepie.Add(GameObject.Find("PlateStation").GetComponent<PlateScript>());
                break;
            case "PufferFish":
                Recepie.Add(GameObject.Find("TickleStation").GetComponent<TickleScript>());
                Recepie.Add(GameObject.Find("GrillStation").GetComponent<GrillScript>());
                Recepie.Add(GameObject.Find("PlateStation").GetComponent<PlateScript>());
                break;
            case "BlobFish":
                Recepie.Add(GameObject.Find("TickleStation").GetComponent<TickleScript>());
                break;
            default:
                break;
        }
    }
    public void UpdateSprite()
    {
        GetComponent<SpriteRenderer>().sprite = States[RecepieIndex];
        if(Type == "Salmon" || Type == "Carp")// set smaller hit box
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }

        if (Type == "PufferFish")// set smaller hit box
        {
            GetComponent<CircleCollider2D>().enabled = true;
        }
    }
}
