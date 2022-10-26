using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class MenuPanelChange : MonoBehaviour
{
    public GameObject menu1;
    public GameObject save1;
    public GameObject load1;

    public Animator playerAnimator;

    public Text saveText;

    CinemachineVirtualCamera virtualCamera;
    Transform trf;

    public Text MonthData;

    // Start is called before the first frame update
    void Start()
    {
        MonthData.text = GoHome.nextMonth.ToString();
        menu1.SetActive(true);
        save1.SetActive(false);
        load1.SetActive(false);
    }

    // Update is called once per frame
    public void menu1View()
    {
        menu1.SetActive(true);
        save1.SetActive(false);
        load1.SetActive(false);
    }

    public void Save1View()
    {
        menu1.SetActive(false);
        save1.SetActive(true);
    }

    public void Load1View()
    {
        menu1.SetActive(false);
        load1.SetActive(true);
    }

    public void Save(int dataInt)
    {
        string strget = null;
        string[] allActiveScene = new string[0];
        for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCount; i++)
        {
            //読み込まれているシーンを取得し、その名前をログに表示
            string sceneName = UnityEngine.SceneManagement.SceneManager.GetSceneAt(i).name;
            Array.Resize(ref allActiveScene, i + 1);
            allActiveScene[i] = sceneName;
        }
        Vector2 position = GameObject.FindGameObjectWithTag("Player").transform.position;
        playerAnimator = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Animator>();
        strget = allActiveScene[1] + ",";
        strget = strget + position.x.ToString() + ",";
        strget = strget + position.y.ToString() + ",";
        strget = strget + playerAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name + ",";
        strget = strget + GoHome.nextMonth.ToString();
        Debug.Log(strget);
        string data = "Data" + dataInt.ToString();
        PlayerPrefs.SetString(data, strget);
        saveText.text = strget;
    }

    public async void Load(int dataInt)
    {
        string data = "Data" + dataInt.ToString();
        string s = PlayerPrefs.GetString(data, "Error");
        Debug.Log(s);
        var loadArr = s.Split(',');
        PlayerLoad.sceneMove = false;

        float playerPositionX = float.Parse(loadArr[1]);
        float playerPositionY = float.Parse(loadArr[2]);

        await AllSceneLoadAsync(loadArr[0]);

        GameObject alreadyMukimu = GameObject.FindGameObjectWithTag("Player");

        if (alreadyMukimu == null)
        { 
            GameObject mukimu = (GameObject)Resources.Load("Mukimu");
            GameObject obj;
            GameObject playerParent = GameObject.Find("PlayerParent");

            obj = Instantiate(mukimu, new Vector2(playerPositionX, playerPositionY), Quaternion.identity);
            obj.transform.parent = playerParent.transform;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        trf = player.gameObject.GetComponent<Transform>();
        GameObject camera = GameObject.Find("CM vcam1");
        virtualCamera = camera.GetComponent<CinemachineVirtualCamera>();
        virtualCamera.Follow = trf;

        playerAnimator = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Animator>();
        if (loadArr[3] == "MukimuBack")
        {
            playerAnimator.SetFloat("Look X", 0);
            playerAnimator.SetFloat("Look Y", -1);
        }
        if(loadArr[3] == "MukimuFront")
        {
            playerAnimator.SetFloat("Look X", 0);
            playerAnimator.SetFloat("Look Y", 1);
        }
        if(loadArr[3] == "MukimuIdleBack")
        {
            playerAnimator.SetFloat("Look X", 0);
            playerAnimator.SetFloat("Look Y", -1);
        }
        if (loadArr[3] == "MukimuIdleFront")
        {
            playerAnimator.SetFloat("Look X", 0);
            playerAnimator.SetFloat("Look Y", 1);
        }
        if (loadArr[3] == "MukimuIdleLeft")
        {
            playerAnimator.SetFloat("Look X", 1);
            playerAnimator.SetFloat("Look Y", 0);
        }
        if (loadArr[3] == "MukimuIdleRight")
        {
            playerAnimator.SetFloat("Look X", -1);
            playerAnimator.SetFloat("Look Y", 0);
        }
        if (loadArr[3] == "MukimuLeft")
        {
            playerAnimator.SetFloat("Look X", 1);
            playerAnimator.SetFloat("Look Y", 0);
        }
        if (loadArr[3] == "MukimuRight")
        {
            playerAnimator.SetFloat("Look X", -1);
            playerAnimator.SetFloat("Look Y", 0);
        }
        GameObject gO = GameObject.Find("Data");
        string targetMonth = "Month" + loadArr[4];
        GameObject target = gO.transform.Find(targetMonth).gameObject;
        target.gameObject.SetActive(true);
        GoHome.nextMonth = int.Parse(loadArr[4]);
    }

    async UniTask AllSceneLoadAsync(string currentScene, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await SceneManager.LoadSceneAsync("ManagerScene");
        await SceneManager.LoadSceneAsync(currentScene, LoadSceneMode.Additive);

        cancellationToken.ThrowIfCancellationRequested();
    }
    

}
