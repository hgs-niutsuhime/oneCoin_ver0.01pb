using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerLoad : MonoBehaviour
{
    public static bool sceneMove;

    CinemachineVirtualCamera virtualCamera;
    Transform trf;

    GameObject data;
    Transform target;

    public Vector2 vector2;

    // Start is called before the first frame update
    void Start()
    {
        if (sceneMove == true)
        {
            PlayerCreate();
            int currentMonth = GoHome.nextMonth;
            string a = currentMonth.ToString();
            string currentScene = "Month" + a;
            data = GameObject.Find("Data");
            target = data.transform.Find(currentScene);
            target.gameObject.SetActive(true);
        }


    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayerCreate()
    {
        GameObject camera = GameObject.Find("CM vcam1");
        virtualCamera = camera.GetComponent<CinemachineVirtualCamera>();

        GameObject mukimu = (GameObject)Resources.Load("Mukimu");
        GameObject obj;
        GameObject playerParent = GameObject.Find("PlayerParent");

//        obj = Instantiate(mukimu, new Vector2(SceneMove.playerX, SceneMove.playerY), Quaternion.identity);
//        obj.transform.parent = playerParent.transform;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        trf = player.gameObject.GetComponent<Transform>();

        virtualCamera.Follow = trf;
    }

    public void PlaterCreate2()
    {
        GameObject camera = GameObject.Find("CM vcam1");
        virtualCamera = camera.GetComponent<CinemachineVirtualCamera>();

        GameObject mukimu = (GameObject)Resources.Load("Mukimu");
        GameObject obj;
        GameObject playerParent = GameObject.Find("PlayerParent");

        obj = Instantiate(mukimu, new Vector2(vector2.x, vector2.y), Quaternion.identity);
        obj.transform.parent = playerParent.transform;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        trf = player.gameObject.GetComponent<Transform>();

        virtualCamera.Follow = trf;
    }
}
