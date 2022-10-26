using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandOutCard : MonoBehaviour
{

    public int cardA = -1;
    public int cardB = -1;

    [SerializeField] private Text cardTextA;
    [SerializeField] private Text cardTextB;
    [SerializeField] private GameObject check;
    [SerializeField] private GameObject alert;
    [SerializeField] private Text alertText;

    CardGameManager cardGameManager;

    // Start is called before the first frame update
    void Start()
    {
        cardGameManager = this.GetComponent<CardGameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void decide()
    {
        if(cardA == -1)
        {
            alert.SetActive(true);
            alertText.text = "カードを１枚は選んでください";
        }
    }

    public void clickAlertPanel()
    {
        alert.SetActive(false);
        alertText.text = "";
        cardA = -1;
        cardB = -1;
        cardGameManager.lookAtCards(-1);

        cardTextA.text = "";
        cardTextB.text = "";

        GameObject gameObject = GameObject.Find("HandOutCards");
        GameObject gameObject1 = GameObject.Find("CardsPlayer0");

    }

    public void clickCardButton(int a)
    {
        string b = a.ToString();

        if (cardA == -1)
        {
            cardTextA.text = b;
            cardA = a;

        }
        else
        {
            if (cardB == -1)
            {
                cardTextB.text = b;
                cardB = a;

            }
            else
            {
                alert.SetActive(true);
                alertText.text = "これ以上カードは出せません";
            }
        }

        cardGameManager.lookAtCards(a);


        for (int i = 0; i < 6; i++)
        {
            string nameOfCard = "cardsP0_" + i;
            GameObject gameObject = GameObject.Find("CardsPlayer0");
            Transform transform = gameObject.transform.Find(nameOfCard);

            if (transform != null)
            {
                GameObject gameObject1 = transform.gameObject;
                SpriteRenderer spriteRenderer = gameObject1.GetComponent<SpriteRenderer>();
                string sprite = spriteRenderer.sprite.name;

                if (a == 0 && sprite == "CardsNumber_0")
                {
                    GameObject gameObject2 = GameObject.Find("HandOutCards");
                    gameObject1.transform.parent = gameObject2.transform;
                    return;

                }
                else if (a == 1 && sprite == "CardsNumber_1")
                {
                    GameObject gameObject2 = GameObject.Find("HandOutCards");
                    gameObject1.transform.parent = gameObject2.transform;
                    return;

                }
                else if (a == 2 && sprite == "CardsNumber_2")
                {
                    GameObject gameObject2 = GameObject.Find("HandOutCards");
                    gameObject1.transform.parent = gameObject2.transform;
                    return;

                }
                else if (a == 3 && sprite == "CardsNumber_3")
                {
                    GameObject gameObject2 = GameObject.Find("HandOutCards");
                    gameObject1.transform.parent = gameObject2.transform;
                    return;
                }
            }

        }

    }
    
}
