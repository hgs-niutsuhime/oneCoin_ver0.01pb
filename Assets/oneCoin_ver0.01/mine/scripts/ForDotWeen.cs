using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using DG.Tweening;

public class ForDotWeen : MonoBehaviour
{
    public GameObject respawnPrefab;
    public GameObject[] respawns;

    int i;
    Vector2 defaultScale = Vector2.zero;

    GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        i = 1;
        button = (GameObject)Resources.Load("Button1");
        defaultScale = button.transform.lossyScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

/*
    public void ChatUpper()
    {
        Vector2 vector2;
        GameObject gameObject = GameObject.Find("Content");
        vector2 = gameObject.transform.localScale;
        gameObject.transform.localPosition = new Vector2(300, -150);
        vector2.y = vector2.y + i;
        gameObject.transform.localScale = vector2;

        Vector2 lossScale = transform.lossyScale;
        Vector2 scale = transform.localScale;

        respawns = GameObject.FindGameObjectsWithTag("Commented");
        foreach (GameObject respawn in respawns)
        {
            respawn.transform.DOLocalMove(new Vector2(0, 10), 1f).SetRelative(true);
            respawn.transform.localScale = new Vector2(1, defaultScale.y / lossScale.y);
        }
    }
*/

    public void ChatUpper()
    {
        Vector2 vector2;
        GameObject gameObject = GameObject.Find("Content");
        vector2 = gameObject.transform.localScale;
        gameObject.transform.localPosition = new Vector2(300, -150);
        vector2.y = vector2.y + i;
        gameObject.transform.localScale = vector2;

//        Vector2 lossScale = transform.lossyScale;
//        Vector2 scale = transform.localScale;

        respawns = GameObject.FindGameObjectsWithTag("Commented");
        foreach (GameObject respawn in respawns)
        {
            Vector2 position = respawn.transform.position;
            position.y = position.y - 3.0f;
        }
    }
}
