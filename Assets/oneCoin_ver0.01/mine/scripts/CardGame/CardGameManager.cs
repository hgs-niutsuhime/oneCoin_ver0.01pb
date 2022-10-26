using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using Random = UnityEngine.Random;

public class CardGameManager : MonoBehaviour
{
    CardGameSceneManager cgsm;

    public int turn;
    private int step;
    string[] cardNameArr = new string[0];
    int[] cardNumberArr = new int[0];
    private int numOfP0Cards = 5;
    private int numOfP1Cards = 5;
    private int numOfP2Cards = 5;
    private int numOfP3Cards = 5;
    private int cardNumber;
    private int bougaiNumber;
    public Text text;
    public Button button;
    [SerializeField] private Text text0;
    [SerializeField] private Text text1;
    [SerializeField] private Text text2;
    [SerializeField] private Text text3;
    [SerializeField] private Text textFor0;
    [SerializeField] private Text textFor1;
    [SerializeField] private Text textFor2;
    [SerializeField] private Text textFor3;
    [SerializeField] private GameObject alert;
    [SerializeField] private Text alertText;
    [SerializeField] private GameObject kakunin;
    [SerializeField] private Text kakuninText;
    [SerializeField] private GameObject kaiten;
    [SerializeField] private Text funamoriText;
    [SerializeField] private Text bougaiText;
    private int numOfCards0 = 0;
    private int numOfCards1 = 0;
    private int numOfCards2 = 0;
    private int numOfCards3 = 0;
    private bool waiting = false;
    public int cardA = -1;
    public int cardB = -1;
    private int kaitenLorR = 0;
    private int moveFunamori = 0;
    private int moveBougai = 0;
    private int komaPosition = 6;
    public Material komaMaterial;
    public Material TMaterial;

    [SerializeField] private Text cardTextA;
    [SerializeField] private Text cardTextB;
    [SerializeField] private GameObject check;

    List<int> p0Cards;
    List<int> p1Cards;
    List<int> p2Cards;
    List<int> p3Cards;
    List<int> yamahuda;
    List<int> suteba;
    List<int> ba;

    Sprite[] cardsSprite;

    private int clickedCard;

    RandomShuffleCard randomShuffleCard;
    SetUpCircle setUpCircle;

    List<int> shuffleList;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject;
        gameObject = GameObject.Find("SceneManager");
        cgsm = gameObject.GetComponent<CardGameSceneManager>();

        Array.Resize(ref cardNameArr, cgsm.numberOfPlayer);
        cardsSprite = Resources.LoadAll<Sprite>("CardsNumber");

        randomShuffleCard = this.GetComponent<RandomShuffleCard>();

        GameObject gameobject1;
        gameobject1 = GameObject.Find("CardsPlayer0");
        setUpCircle = gameobject1.GetComponent<SetUpCircle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GetClickedObject();
            TurnManager();
        }
    }

    public void cardsSeiri()
    {
        shuffleList = new List<int>();
        int a = 0;

        //shuffuleList[0]=1→cards[0]は数値1
        //player0は、通し番号0のカードを所持している

        for(int i = 0; i < 48; i++)
        {
            if(randomShuffleCard.cards[i] > 36)
            {
                shuffleList.Add(3);
            }
            else if (randomShuffleCard.cards[i] > 24)
            {
                shuffleList.Add(2);
            }
            else if (randomShuffleCard.cards[i] > 12)
            {
                shuffleList.Add(1);
            }
            else
            {
                shuffleList.Add(0);
            }
        }

        p0Cards = new List<int>();
        p1Cards = new List<int>();
        p2Cards = new List<int>();
        p3Cards = new List<int>();
        yamahuda = new List<int>();
        suteba = new List<int>();
        ba = new List<int>();

        for (int i = 0; i < 6; i++)
        {
            p0Cards.Add(i);
        }


        for (int i = 6; i < 12; i++)
        {
            p1Cards.Add(i);
        }

        if (cgsm.numberOfPlayer == 3)
        {
            for (int i = 12; i < 18; i++)
            {
                p2Cards.Add(i);
            }
        }
        else if (cgsm.numberOfPlayer == 4)
        {
            for (int i = 12; i < 18; i++)
            {
                p2Cards.Add(i);
            }
            for (int i = 18; i < 24; i++)
            {
                p3Cards.Add(i);
            }
        }

        if(cgsm.numberOfPlayer == 2)
        {
            for(int i = 12; i < 48; i++)
            {
                yamahuda.Add(i);
            }
        }
        else if (cgsm.numberOfPlayer == 3)
        {
            for(int i = 18; i < 48; i++)
            {
                yamahuda.Add(i);
            }
        }
        else if (cgsm.numberOfPlayer == 4)
        {
            for(int i = 24; i < 48; i++)
            {
                yamahuda.Add(i);
            }
        }
    }

    void TurnManager()
    {
        if(waiting == true)
        {
            if (turn == 0)
            {
                if (step == 0)
                {
                    step++;
                    waiting = false;

                } else if (step == 1)
                {
                    funamoriAi();
                    text.text = "妨害ターンの相手がカードを１枚出しました\n回転の方向を決めてください";
                    kaiten.SetActive(true);
                    step = 2;
                    waiting = false;

                } else if(step == 2)
                {
                    string a = "";
                    if (kaitenLorR == -1)
                    {
                        a = "反時計回り";
                    }
                    else
                    {
                        a = "時計回り";
                    }

                    text.text = a + "に" + moveFunamori + "\n妨害として反時計回りに" + bougaiNumber + "進みます";
                    step = 3;
                    waiting = false;
                    StartCoroutine("wait");

                } else if(step == 3)
                {
                    komaMove();
                    waiting = false;
                    turn = 1;
                    step = 0;
                    text.text = "次はあなたが妨害ターンです";
                    StartCoroutine("wait");
                }
            }
            else if(turn == 1)
            {
                if(step == 0)
                {
                    waiting = false;
                    int a = Random.Range(1, 3);
                    text.text = "相手が" + a + "枚カードを出しました。\nカードを１枚出してください。";
                }
            }
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        waiting = true;
    }

    public void funamori()
    {
        if(step == 0)
        {
            StartCoroutine("funamori1");
            lookAtCards(-1);
            text.text = "カードを１枚か２枚出してください";
            waiting = true;

        } else if(step == 1)
        {
            lookAtCards(-1);

        } else if(step == 2)
        {

        }
    }

    private void komaMove()
    {
        string a = "Koma" + komaPosition;
        GameObject gameObject = GameObject.Find(a);
        gameObject.GetComponent<Renderer>().material = TMaterial;

        if(kaitenLorR == -1)
        {
            komaPosition = komaPosition + moveFunamori + bougaiNumber;
        }
        else
        {
            komaPosition = komaPosition - moveFunamori + bougaiNumber;
        }

        if(komaPosition > 12)
        {
            komaPosition = komaPosition - 12;
        }
        else if(komaPosition < 1)
        {
            komaPosition = komaPosition + 12;
        }
        string b = "Koma" + komaPosition;
        GameObject gameObject1 = GameObject.Find(b);
        gameObject1.GetComponent<Renderer>().material = komaMaterial;
    }

    public void Bougai()
    {

    }

    void GetClickedObject()
    {
        GameObject clickedGameObject;
        string clickedName;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        clickedGameObject = null;
        clickedName = null;
        cardNumberArr = new int[0];
        int i = 0;


        Vector3 screen_point = Input.mousePosition;
        Plane plane = new Plane(Vector3.forward, Vector3.zero);
        Vector3 hitPoint = new Vector3(0, 0, 0);

        if (plane.Raycast(ray, out float enter))
        {
            hitPoint = ray.GetPoint(enter);
        }

        Collider2D[] colliderArr = Physics2D.OverlapPointAll(hitPoint);

        foreach (Collider2D collider in colliderArr)
        {
            if (colliderArr.Length > 0)
            {
                clickedGameObject = collider.transform.gameObject;
                clickedName = clickedGameObject.name;
            }

            string a = (clickedName.Replace("cards", ""));
            string[] b = a.Split('_');

            cardNumber = int.Parse(b[1]);
            Array.Resize(ref cardNumberArr, i + 1);

            cardNumberArr[i] = cardNumber;

            i++;

        }

        if (cardNumberArr.Length > 0)
        {
            clickedCard = cardNumberArr.Max();
        }
    }

    IEnumerator funamori1()
    {
        GameObject gameObject = (GameObject)Resources.Load("Card");
        int i = numOfP0Cards + 1;
        numOfP0Cards = numOfP0Cards + 1;
        Vector3 vector3 = Vector3.zero;

        int j = numOfP0Cards + numOfP1Cards + 1;

        GameObject gameObject1 = (GameObject)Instantiate(gameObject, vector3, Quaternion.identity);
        GameObject gameObject2 = GameObject.Find("CardsPlayer0");
        gameObject1.transform.parent = gameObject2.transform;
        gameObject1.name = "cardsP0_" + i;
        SpriteRenderer spriteRenderer = gameObject1.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = i;

        if (randomShuffleCard.cards[j] < 12)
        {
            spriteRenderer.sprite = cardsSprite[0];
        }
        else if (randomShuffleCard.cards[j] < 24)
        {
            spriteRenderer.sprite = cardsSprite[1];
        }
        else if (randomShuffleCard.cards[j] < 36)
        {
            spriteRenderer.sprite = cardsSprite[2];
        }
        else if (randomShuffleCard.cards[j] < 48)
        {
            spriteRenderer.sprite = cardsSprite[3];
        }

        yield return null;

        setUpCircle.Deploy();
        setUpCircle.Deploy1();

    }

    private void funamoriAi()
    {

        GameObject gameObject = GameObject.Find("cardsP1_" + numOfP1Cards);
        if (randomShuffleCard.cards[numOfP1Cards] < 12)
        {
            bougaiNumber = 0;
        }
        else if (randomShuffleCard.cards[numOfP1Cards] < 24)
        {
            bougaiNumber = 1;
        }
        else if (randomShuffleCard.cards[numOfP1Cards] < 36)
        {
            bougaiNumber = 2;
        }
        else if (randomShuffleCard.cards[numOfP1Cards] < 48)
        {
            bougaiNumber = 3;
        }

        Destroy(gameObject);
        setUpCircle.Deploy1();

    }

    public void decide()
    {
        if (cardA == -1)
        {
            alert.SetActive(true);
            alertText.text = "カードを１枚は選んでください";

        }
        else
        {
            kakunin.SetActive(true);
            kakuninText.text = "これでいいですか？";
        }
    }

    public void kakuninYes()
    {

        int a = 0;
        int b = 0;
        
        if(b != -1)
        {
            moveFunamori = cardA + cardB;
        }
        else
        {
            moveFunamori = cardA;
        }

        for (int i = 0; i < numOfP0Cards + 1; i++)
        {
            string nameOfCard = "cardsP0_" + i;
            GameObject gameObject = GameObject.Find(nameOfCard);
            GameObject gameObject1 = GameObject.Find("HandOutCards");
            if(gameObject.transform.parent == gameObject1.transform)
            {
                Destroy(gameObject);
                a++;

            } else
            {
                gameObject.name = "cardsP0_" + b;
                b++;
            }
        }

        numOfP0Cards = numOfP0Cards - a;

        setUpCircle.Deploy();
        kakunin.SetActive(false);

        cardA = -1;
        cardB = -1;
        cardTextA.text = "";
        cardTextB.text = "";

        waiting = true;

    }

    public void kakuninNo()
    {
        kakunin.SetActive(false);
        kakuninText.text = "";
        cardA = -1;
        cardB = -1;
        lookAtCards(-1);

        cardTextA.text = "";
        cardTextB.text = "";

        GameObject gameObject = GameObject.Find("HandOutCards");
        GameObject gameObject1 = GameObject.Find("CardsPlayer0");

        for (int i = 0; i < numOfP0Cards + 1; i++)
        {
            string nameOfCard = "cardsP0_" + i;
            GameObject gameObject2 = GameObject.Find(nameOfCard);
            gameObject2.transform.parent = gameObject1.transform;
        }

    }

    public void kaitenLeft()
    {
        text.text = "駒を反時計回りに動かします";
        waiting = true;
        kaitenLorR = -1;
        kaiten.SetActive(false);
        waiting = true;
    }

    public void kaitenRight()
    {
        text.text = "駒を時計回りに動かします";
        waiting = true;
        kaitenLorR = 1;
        kaiten.SetActive(false);
        waiting = true;
    }

    public void clickAlertPanel()
    {
        alert.SetActive(false);
        alertText.text = "";
        cardA = -1;
        cardB = -1;
        lookAtCards(-1);

        cardTextA.text = "";
        cardTextB.text = "";

        GameObject gameObject = GameObject.Find("HandOutCards");
        GameObject gameObject1 = GameObject.Find("CardsPlayer0");

        for(int i = 0; i < numOfP0Cards+1; i++)
        {
            string nameOfCard = "cardsP0_" + i;
            GameObject gameObject2 = GameObject.Find(nameOfCard);
            gameObject2.transform.parent = gameObject1.transform;
        }

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

        for (int i = 0; i < numOfP0Cards+1 ; i++)
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
                    lookAtCards(-1);
                    return;

                }
                else if (a == 1 && sprite == "CardsNumber_1")
                {
                    GameObject gameObject2 = GameObject.Find("HandOutCards");
                    gameObject1.transform.parent = gameObject2.transform;
                    lookAtCards(-1);
                    return;

                }
                else if (a == 2 && sprite == "CardsNumber_2")
                {
                    GameObject gameObject2 = GameObject.Find("HandOutCards");
                    gameObject1.transform.parent = gameObject2.transform;
                    lookAtCards(-1);
                    return;

                }
                else if (a == 3 && sprite == "CardsNumber_3")
                {
                    GameObject gameObject2 = GameObject.Find("HandOutCards");
                    gameObject1.transform.parent = gameObject2.transform;
                    lookAtCards(-1);
                    return;
                }
            }

        }

    }

    public void lookAtCards(int a)
    {
        numOfCards0 = 0;
        numOfCards1 = 0;
        numOfCards2 = 0;
        numOfCards3 = 0;

        for (int i = 0; i < numOfP0Cards + 1; i++)
        {
            String nameOfCard = "cardsP0_" + i;
            GameObject gameObject = GameObject.Find("CardsPlayer0");
            Transform transform = gameObject.transform.Find(nameOfCard);

            if (transform != null)
            {
                GameObject gameObject1 = transform.gameObject;

                SpriteRenderer spriteRenderer = gameObject1.GetComponent<SpriteRenderer>();
                string sprite = spriteRenderer.sprite.name;

                if (sprite == "CardsNumber_0")
                {
                    numOfCards0++;

                }
                else if (sprite == "CardsNumber_1")
                {
                    numOfCards1++;

                }
                else if (sprite == "CardsNumber_2")
                {
                    numOfCards2++;

                }
                else if (sprite == "CardsNumber_3")
                {
                    numOfCards3++;

                }
            }

        }

        if (a == -1)
        {

        }
        else if (a == 0 && numOfCards0 > 0)
        {
            numOfCards0 = numOfCards0 - 1;

        }
        else if (a == 1 && numOfCards1 > 0)
        {
            numOfCards1 = numOfCards1 - 1;

        }
        else if (a == 2 && numOfCards2 > 0)
        {
            numOfCards2 = numOfCards2 - 1;

        }
        else if (a == 3 && numOfCards3 > 0)
        {
            numOfCards3 = numOfCards3 - 1;

        }
        else
        {
            alert.SetActive(true);
            alertText.text = "カードを持っていません。";
        }

        string c0 = "×" + numOfCards0;
        string c1 = "×" + numOfCards1;
        string c2 = "×" + numOfCards2;
        string c3 = "×" + numOfCards3;

        textFor0.text = c0;
        textFor1.text = c1;
        textFor2.text = c2;
        textFor3.text = c3;
    }
}
