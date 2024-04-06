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
                break;
            default:
                break;
        }
    }
    public void UpdateSprite()
    {
        GetComponent<SpriteRenderer>().sprite = States[RecepieIndex];
    }
}
