using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    public float AnimDuration = .3f;
    public float AnimTime = .3f;

    public float AnimSpeed;

    public float Duration = 30f;
    public float time = 30f;

    public bool endOfTime = false;

    public Image slider;

    public OrdersHandler OH;

    public float DifficultyIncrese;// how much time goes down every increse in difficulty
    // Start is called before the first frame update
    void Start()
    {
        OH = GameObject.Find("Tredmills").GetComponent<OrdersHandler>();
        time -= OH.Difficulty * DifficultyIncrese;
        Duration -= OH.Difficulty * DifficultyIncrese;
    }

    // Update is called once per frame
    void Update()
    {

        Animate();

        slider.fillAmount = time / Duration;

        time -= Time.deltaTime;
        if (time < 0) endOfTime = true; 
    }

    public void Animate()
    {
        if (AnimTime > AnimDuration/2) transform.position += new Vector3(0, Time.deltaTime * AnimSpeed);
        if (AnimTime <= AnimDuration / 2) transform.position -= new Vector3(0, Time.deltaTime * AnimSpeed);

        AnimTime -= Time.deltaTime;
        if (AnimTime < 0) AnimTime = AnimDuration;
    }
}
