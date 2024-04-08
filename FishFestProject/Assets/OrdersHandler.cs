using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrdersHandler : MonoBehaviour
{

    public FishingScript FS;
    public int WhenToAddSardine = 10;
    public GameObject Sardine;

    public TMP_Text ScoreText;

    public List<OrderScript> Tredmills = new List<OrderScript>();

    public int Money = 0;

    public int Difficulty = 1;
    public float DifficultyOrderChanceIncrease;// how much chance to increse
    public float DifficultyIncreaseDelay = 10f;//every 10 seconds increase difficulty
    float GameTime;

    float LooseScreenDelay = 1;
    float LooseScreenDelayTimer = 0;
    public GameObject YouLooseScreen;
    private void Update()
    {
        
        GameTime += Time.deltaTime;
        if(GameTime > DifficultyIncreaseDelay)
        {
            GameTime = 0;
            Difficulty++;
            if (Difficulty % WhenToAddSardine == 0) FS.fishTypes.Add(Sardine);// add sardine
            foreach(OrderScript OS in Tredmills)
            {
                OS.OrderChance += DifficultyOrderChanceIncrease;// more orders
            }
        }

        
    }



    public void UpdateScore()
    {
        ScoreText.text = Money + "$";
    }
}
