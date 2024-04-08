using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderScript : MonoBehaviour
{
    public OrdersHandler OH;

    private SoundScript soundScript;
    public float OrderChance = 0f;

    public float orderDelay = 3f;
    public float orderTimer = 0f;

    public List<GameObject> PossibleOrders = new List<GameObject>();

    public GameObject Order;
    [Space()]

    public GameObject Timer_Salmon;
    public GameObject Timer_Carp;
    public GameObject Timer_Puff;
    public GameObject Timer_Blob;
    [Space()]

    public GameObject Timer;
    public Transform TimerPos;
    // Start is called before the first frame update
    void Start()
    {
        soundScript = GetComponent<SoundScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<ActivateSctipt>().Active) GetComponent<Animator>().enabled = false;// dont move if not active
        else GetComponent<Animator>().enabled = true;

        OrderTimer();

        if (Timer.GetComponent<TimerScript>().endOfTime)
        {
            soundScript.playSound(1);

            OH.Money -= Random.Range(3, 5);

            OH.UpdateScore();

            DeleteOrder();

        }


    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (GetComponent<ActivateSctipt>().Active)
        {
            Debug.Log("GOOG");
            
            // if the order and collision are the same type he is finished the good
            if(collision.gameObject.GetComponent<FishScript>().Type == Order.GetComponent<FishScript>().Type && collision.gameObject.GetComponent<FishScript>().RecepieIndex == collision.gameObject.GetComponent<FishScript>().Recepie.Count)
            {
                
                soundScript.playSound();
                OH.Money += Random.Range(3, 5);
                Destroy(collision.gameObject);

                OH.UpdateScore();
            }
            else
            {
                Destroy(collision.gameObject);
                soundScript.playSound(1);
                OH.Money -= Random.Range(3, 5);

                OH.UpdateScore();
            }// if wrong fish


            DeleteOrder();
            
            //GenerateOrder();
        }
    }
    public void OrderTimer()
    {
        orderTimer += Time.deltaTime;

        if (orderTimer > orderDelay)
        {
            int n = Random.Range(0, 100);
            if (n < OrderChance && Order == null) GenerateOrder();

            orderTimer = 0f;
        }
    }


    public void DeleteOrder()
    {
        Destroy(Timer);
        Order = null;
    }
    public void GenerateOrder()
    {
        Order = PossibleOrders[Random.Range(0, PossibleOrders.Count)];
        FishScript OrderFishScript = Order.GetComponent<FishScript>();

        switch (OrderFishScript.Type)
        {
            case "Salmon":
                Debug.Log("YAY");
                Timer = Instantiate(Timer_Salmon, transform.position + new Vector3(0,1), Quaternion.identity);
                break;
            case "Carp":
                Debug.Log("YAY");
                Timer = Instantiate(Timer_Carp, transform.position + new Vector3(0, 1), Quaternion.identity);
                break;
            case "PufferFish":
                Timer = Instantiate(Timer_Puff, transform.position + new Vector3(0, 1), Quaternion.identity);
                break;
            case "BlobFish":
                Timer = Instantiate(Timer_Blob, new Vector3(1, 1), Quaternion.identity);
                break;

            default:
                break;
        }


    } 

}
