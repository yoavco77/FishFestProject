using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimate : MonoBehaviour
{
    public float AnimDuration = .3f;
    public float AnimTime = .3f;

    public float AnimSpeed;

    // Update is called once per frame
    void Update()
    {
        Animate();
    }
    public void Animate()
    {
        if (AnimTime > AnimDuration / 2) transform.position += new Vector3(0, Time.deltaTime * AnimSpeed);
        if (AnimTime <= AnimDuration / 2) transform.position -= new Vector3(0, Time.deltaTime * AnimSpeed);

        AnimTime -= Time.deltaTime;
        if (AnimTime < 0) AnimTime = AnimDuration;
    }
}
