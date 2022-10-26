using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using DG.Tweening;

public class MmoChat : MonoBehaviour
{
    int whoI = 0;
    int textJ = 0;
    int hori = 300;

    public List<string[]> csvDatas = new List<string[]>();

    public GameObject[] respawns;

    // Start is called before the first frame update
    void Start()
    {
        TextAsset csv = Resources.Load("MmoTest") as TextAsset;
        StringReader reader = new StringReader(csv.text);
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            for (int i = 0; i < csvDatas.Count; i++)
            {
                for (int j = 0; j < csvDatas[i].Length; j++)
                {
                    Debug.Log("csvDatas[" + i + "][" + j + "] = " + csvDatas[i][j]);
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.V))
        {
            GameObject helpMenu = GameObject.Find("Button1(Clone)");
//            helpMenu.transform.DOMove(new Vector2(7f, 0f), 3f);
        }

    }

    public void ToCreateButton()
    {
        GameObject button = (GameObject)Resources.Load("Button1");
        GameObject objA;
        GameObject objB;
        GameObject playerParentA = GameObject.Find("ButtonParent");
        GameObject playerParentB = GameObject.Find("ButtonParent");

        objA = Instantiate(button, new Vector2(-200, 0), Quaternion.identity);
        objB = Instantiate(button, new Vector2(0, 0), Quaternion.identity);
        objA.transform.SetParent(playerParentA.transform);
        objB.transform.SetParent(playerParentB.transform);
        objA.transform.localPosition = new Vector2(0, 0);
        objB.transform.localPosition = new Vector2(150, 0);
        objA.GetComponentInChildren<Text>().text = csvDatas[whoI][textJ];
        objB.GetComponentInChildren<Text>().text = csvDatas[whoI][textJ+1];
        whoI++;
        textJ = 0;
        objA.tag = "Commented";
        objB.tag = "Commented";
//        GameObject buttonClone = GameObject.Find("Content");
//        buttonClone.GetComponent<ForDotWeen>().ChatUpper();

        respawns = GameObject.FindGameObjectsWithTag("Commented");
        foreach (GameObject respawn in respawns)
        {
            Vector2 position = respawn.transform.position;
            position.y = position.y + 40.0f;
            respawn.transform.position = position;

        }

        var rtf = playerParentA.GetComponent<RectTransform>();
        hori += 40;
        // ècï˚å¸ÇÃÉTÉCÉY
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, hori);

    }
}
