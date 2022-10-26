using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShuffleCard : MonoBehaviour
{

    private List<int> cardList = new List<int>();
    private List<int> cardList2 = new List<int>();
    public List<int> cardsWakusei = new List<int>();
    public List<int> cards = new List<int>();
    const int cardNumbersWakusei = 5;
    const int cardNumbers = 48;

    // Start is called before the first frame update
    void Start()
    {
        IntializeCardList();
    }

    void IntializeCardList()
    {
        for(int i = 0; i < cardNumbersWakusei; i++)
        {
            cardList.Add(i);
        }

        for (int i = 0; i < cardNumbers; i++)
        {
            cardList2.Add(i);
        }
    }

    void Update()
    {


    }

    public void ShuffleWakusei()
    {
        while(cardList.Count > 0)
        {
            int randomIndex = Random.Range(0, cardList.Count);
            int ransu = cardList[randomIndex];
            cardList.RemoveAt(randomIndex);
            cardsWakusei.Add(ransu);
        }
    }

    public void ShuffleCards()
    {
        while (cardList2.Count > 0)
        {
            int randomIndex = Random.Range(0, cardList2.Count);
            int ransu = cardList2[randomIndex];
            cardList2.RemoveAt(randomIndex);
            cards.Add(ransu);
        }
    }


}
