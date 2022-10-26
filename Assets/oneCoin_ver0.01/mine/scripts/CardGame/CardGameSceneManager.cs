using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class CardGameSceneManager : MonoBehaviour
{
    public int step;

    public GameObject startPanel;
    public GameObject mainPanel;
    public Text text;
    public string myWakusei;
    public int numberOfPlayer;
    public GameObject cam;

    public int otherWakusei1num;
    public string otherWakusei1;
    public int otherWakusei2num;
    public string otherWakusei2;
    public int oya;

    private GameObject go1;
    private GameObject go2;

    private GameObject playerCard;
    Sprite[] cardsSpritesWakusei;
    Sprite[] cardsSprite;

    Material myMaterial;
    Material otherMaterial1;
    Material komaMaterial;

    public SpriteRenderer spriteRenderer;
    RandomShuffleCard randomShuffleCard;
    MeshRenderer meshRenderer;
    CardGameManager cardGameManager;
    SetUpCircle setUpCircle;

    // Start is called before the first frame update

    void Start()
    {
        myMaterial = (Material)Resources.Load("RedMaterial");
        otherMaterial1 = (Material)Resources.Load("BlueMaterial");
        komaMaterial = (Material)Resources.Load("WhiteMaterial");

        cardGameManager = this.GetComponent<CardGameManager>();
        GameObject gameobject;
        gameobject = GameObject.Find("CardsPlayer0");
        setUpCircle = gameobject.GetComponent<SetUpCircle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (step == 2)
            {
                changeMaterial(myWakusei, myMaterial);
                step = 3;
                HandOutCards();
                randomShuffleCard = this.GetComponent<RandomShuffleCard>();
                randomShuffleCard.ShuffleCards();

            } else if (step == 3)
            {
                cardGameManager.cardsSeiri();
                OpenCards();

                if (otherWakusei1num == 0)
                {
                    otherWakusei1 = "sui";

                }
                else if (otherWakusei1num == 1)
                {
                    otherWakusei1 = "kin";

                }
                else if (otherWakusei1num == 2)
                {
                    otherWakusei1 = "ka";

                }
                else if (otherWakusei1num == 3)
                {
                    otherWakusei1 = "moku";

                }
                else if (otherWakusei1num == 4)
                {
                    otherWakusei1 = "do";

                }

                changeMaterial(otherWakusei1, otherMaterial1);

                cardsSpritesWakusei = Resources.LoadAll<Sprite>("CardsWakusei");
                GameObject gameObject = GameObject.Find("CardWakusei_" + otherWakusei1num);
                spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = cardsSpritesWakusei[otherWakusei1num];

                if (otherWakusei1num == 0)
                {
                    otherWakusei1 = "水星";

                }
                else if (otherWakusei1num == 1)
                {
                    otherWakusei1 = "金星";

                }
                else if (otherWakusei1num == 2)
                {
                    otherWakusei1 = "火星";

                }
                else if (otherWakusei1num == 3)
                {
                    otherWakusei1 = "木星";

                }
                else if (otherWakusei1num == 4)
                {
                    otherWakusei1 = "土星";

                }

                text.text = "相手の守護惑星は" + otherWakusei1 + "です。";

                step = 4;

            }
            else if (step == 4)
            {
                GameObject gameObject2 = GameObject.Find("WakuseiParent");
                Destroy(gameObject2);

                int a = numberOfPlayer;
                string b = "";
                int rnd = Random.Range(0, a);

                if (numberOfPlayer == 2)
                {
                    if (rnd == 0)
                    {
                        b = "先攻";
                        oya = 0;
                    }
                    else if (rnd == 1)
                    {
                        b = "後攻";
                        oya = 1;
                    }
                }

                text.text = "あなたは" + b + "です";

                step = 5;

            }
            else if (step == 5)
            {
                ReadyGame();

                setUpCircle.DoDeploy();

                text.text = "Game Start!";

                step = 6;
            }
            else if (step == 6)
            {
                if(oya == 0)
                {
                    cardGameManager.turn = 0;
                    cardGameManager.funamori();
                }

                if(oya == 1)
                {
                    cardGameManager.turn = 0;
                    cardGameManager.funamori();

//                    cardGameManager.turn = 1;
//                    cardGameManager.Bougai();
                }
                step = 7;
            }
        }
        
    }

    public void GameStart()
    {
        startPanel.SetActive(false);
        mainPanel.SetActive(true);
        text.text = "カードを１枚選んでください";
    }

    public void HandOutCards()
    {
        cardsSprite = Resources.LoadAll<Sprite>("CardsNumber");
        GameObject gameObject = (GameObject)Resources.Load("Card");
        Vector2 vector2 = new Vector2(0.0f, -5.0f);
        Vector3 vector3 = new Vector3(0.0f, 0.0f, 90.0f);

        for(int i = 0; i < 6; i++)
        {
            GameObject gameObject2 = (GameObject)Instantiate(gameObject, vector2, Quaternion.identity);
            GameObject gameObject4 = (GameObject)Instantiate(gameObject, Vector2.zero, Quaternion.identity);
            GameObject gameObject3 = GameObject.Find("CardsPlayer0");
            GameObject gameObject5 = GameObject.Find("CardsPlayer1");
            gameObject2.transform.parent = gameObject3.transform;
            gameObject4.transform.parent = gameObject5.transform;
            gameObject2.name = "cardsP0_" + i;
            gameObject4.name = "cardsP1_" + i;
            spriteRenderer = gameObject2.GetComponent<SpriteRenderer>();
            SpriteRenderer spriteRenderer2 = gameObject4.GetComponent<SpriteRenderer>();
            spriteRenderer.sortingOrder = i;
            spriteRenderer2.sortingOrder = i;
            spriteRenderer.sprite = cardsSprite[4];
            spriteRenderer2.sprite = cardsSprite[4];
        }

    }

    public void OpenCards()
    {

        for (int i = 0; i < 6; i++)
        {
            playerCard = GameObject.Find("cardsP0_" + i);
            spriteRenderer = playerCard.GetComponent<SpriteRenderer>();
            randomShuffleCard = this.GetComponent<RandomShuffleCard>();

            if (randomShuffleCard.cards[i] < 12)
            {
                spriteRenderer.sprite = cardsSprite[0];

            }
            else if (randomShuffleCard.cards[i] < 24)
            {
                spriteRenderer.sprite = cardsSprite[1];

            }
            else if (randomShuffleCard.cards[i] < 36)
            {
                spriteRenderer.sprite = cardsSprite[2];

            }
            else if (randomShuffleCard.cards[i] < 48)
            {
                spriteRenderer.sprite = cardsSprite[3];
            }
        }

    }

    public void ReadyGame()
    {
        GameObject gameObject = GameObject.Find("KomaParent");
        GameObject gameObject2 = gameObject.transform.Find("Koma6").gameObject;
        gameObject2.GetComponent<Renderer>().material = komaMaterial;

        Camera.main.orthographic = false;
        cam.transform.rotation = Quaternion.Euler(-30, 0, 0);
        cam.transform.position = new Vector3(0, -5, -7);
    }

    public void step2(string a)
    {
        text.text = "あなたの守護惑星は" + a + "です。";
        step = 2;

    }

    public void changeMaterial(string a, Material b)
    {
        GameObject gameObject = GameObject.Find("ShugoWakusei");

        if (a == "sui")
        {
            go1 = gameObject.transform.Find("Suisei1").gameObject;
            go2 = gameObject.transform.Find("Suisei2").gameObject;

        }
        else if (a == "kin")
        {
            go1 = gameObject.transform.Find("Kinsei1").gameObject;
            go2 = gameObject.transform.Find("Kinsei2").gameObject;

        }
        else if (a == "ka")
        {
            go1 = gameObject.transform.Find("Kasei1").gameObject;
            go2 = gameObject.transform.Find("Kasei2").gameObject;

        }
        else if (a == "moku")
        {
            go1 = gameObject.transform.Find("Mokusei1").gameObject;
            go2 = gameObject.transform.Find("Mokusei2").gameObject;

        }
        else if (a == "do")
        {
            go1 = gameObject.transform.Find("Dosei1").gameObject;
            go2 = gameObject.transform.Find("Dosei2").gameObject;

        }

        go1.GetComponent<Renderer>().material = b;
        go2.GetComponent<Renderer>().material = b;
    }

}
