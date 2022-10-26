using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Utage;


public class Menu : MonoBehaviour
{

    public AdvEngine Engine { get { return this.engine ?? (this.engine = FindObjectOfType<AdvEngine>() as AdvEngine); } }
    [SerializeField]
    AdvEngine engine;

    public static bool gameStart = true;

    // Start is called before the first frame update
    void Start()
    {
        if(gameStart == true)
        {
//            SceneManager.LoadScene("TitleMenu", LoadSceneMode.Additive);
            gameStart = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.X))
        {
            string[] allActiveScene = new string[0];
            for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCount; i++)
            {

                string sceneName = UnityEngine.SceneManagement.SceneManager.GetSceneAt(i).name;
                Array.Resize(ref allActiveScene, i + 1);
                allActiveScene[i] = sceneName;

            }
            
            if (0 < Array.IndexOf(allActiveScene, "MenuScene"))
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }

        }
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Additive);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        MukimuController controller = player.GetComponent<MukimuController>();
        Animator animation = player.GetComponent<Animator>();
        animation.SetFloat("Speed", 0);
        controller.enabled = false;
    }

    public void CloseMenu()
    {
        SceneManager.UnloadSceneAsync("MenuScene");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        MukimuController controller = player.GetComponent<MukimuController>();
        controller.enabled = true;
    }
}
