using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMenus : MonoBehaviour
{

    public List<GameObject> Menus = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        SetMenu(0);
    }

    public void SetMenu(int index)
    {
        for (int i = 0; i < Menus.Count; i++)
        {
            if(i != index)
            {
                Menus[i].SetActive(false);
            }
            else
            {
                Menus[i].SetActive(true);
            }
        }
    }
}
