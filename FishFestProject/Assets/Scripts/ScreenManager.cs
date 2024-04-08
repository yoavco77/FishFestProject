using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenManager : MonoBehaviour
{
    public OrdersHandler OH;
    float elapsedTime1 = 0;


    int HighScore = 0;

    public TMP_Text HighScoreText;
    public GameObject EndGameScreen;
    CanvasGroup EndGameScreenCG;

    [Space()]
    public float EndingDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        EndGameScreen.SetActive(false);
        EndGameScreenCG = EndGameScreen.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OH.Money > HighScore) HighScore = OH.Money;
        if (OH.Money < 0)
        {
            HighScoreText.text = "HIGH SCORE: " + HighScore + "$";
            Invoke("fadeOut", EndingDelay);
        }
    }


 
    public void fadeOut()
    {
        EndGameScreen.SetActive(true);
        elapsedTime1 += Time.deltaTime;
        if (elapsedTime1 <= 1)
            EndGameScreenCG.alpha = Mathf.Lerp(0, 1, quadraticEaseOut1(elapsedTime1));
        float quadraticEaseOut1(float t)
        {
            return t;
        }
    }
}
