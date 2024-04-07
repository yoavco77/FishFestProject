using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float Duration = 10f;
    public float time = 10f;

    public bool endOfTime = false;

    public Image slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.fillAmount = time / Duration;

        time -= Time.deltaTime;
        if (time < 0) endOfTime = true; 
    }
}
