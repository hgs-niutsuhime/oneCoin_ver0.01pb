using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChoiceWakusei : MonoBehaviour
{

    RandomShuffleCard randomShuffleCard;
    private Sprite sprite;
    public SpriteRenderer spriteRenderer;
    CardGameSceneManager cgsm;

    private string wakusei;
    private string anotherWakusei;
    private List<int> cardList2 = new List<int>();
    private List<int> cards = new List<int>();
    const int cardNumbers = 5;

    Sprite[] cardsSprites;

    // Start is called before the first frame update
    void Start()
    {
        for (int k = 0; k < cardNumbers; k++)
        {
            cardList2.Add(k);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Choice(int a)
    {
        GameObject gameObject = GameObject.Find("WakuseiParent");
        Destroy(gameObject.GetComponent<HorizontalLayoutGroup>());

        while (cardList2.Count > 0)
        {
            int randomIndex = Random.Range(0, cardList2.Count);
            int ransu = cardList2[randomIndex];
            cardList2.RemoveAt(randomIndex);
            cards.Add(ransu);
        }

        int i = 0;

        int anotherI = cards[0];
        if (anotherI == a)
        {
            anotherI = cards[1];
        }

        for(int j = 0; j < 5; j++)
        {
            GameObject gameObject2 = GameObject.Find("CardWakusei_" + i);
            Destroy(gameObject2.GetComponent<EventTrigger>());

            if(a != i)
            {
                if(anotherI != i)
                {
                    GameObject gameObject3 = GameObject.Find("CardWakusei_" + i);
                    Destroy(gameObject3);
                }
            }
            i++;
        }

        GameObject gameObject4 = GameObject.Find("SceneManager");
        randomShuffleCard = gameObject4.GetComponent<RandomShuffleCard>();

        cardsSprites = Resources.LoadAll<Sprite>("CardsWakusei");
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = cardsSprites[randomShuffleCard.cardsWakusei[a]];


        int b;
        b = randomShuffleCard.cardsWakusei[a];

        int c;
        c = anotherI;

        cgsm = gameObject4.GetComponent<CardGameSceneManager>();
        if(b == 0)
        {
            cgsm.myWakusei = "sui";
            wakusei = "…¯";

        } else if(b == 1)
        {
            cgsm.myWakusei = "kin";
            wakusei = "‹à¯";

        } else if(b == 2)
        {
            cgsm.myWakusei = "ka";
            wakusei = "‰Î¯";

        } else if(b == 3)
        {
            cgsm.myWakusei = "moku";
            wakusei = "–Ø¯";

        } else if(b == 4)
        {
            cgsm.myWakusei = "do";
            wakusei = "“y¯";

        }
        else
        {
            Debug.Log("error:˜f¯‚Ì”’l‚ª‘z’èŠO‚Å‚·");
        }

        cgsm.otherWakusei1num = c;

        cgsm.step2(wakusei);

    }
}
