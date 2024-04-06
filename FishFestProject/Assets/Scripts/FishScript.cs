using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
   public class fish
    {
        private string type;
        private Color color;
        
        public fish()
        {
            type = "";
            color = Color.white;
        }
        
        public void setColor(Color color)
        {
            this.color = color;
        }

        public string getType()
        {
            return type;
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
