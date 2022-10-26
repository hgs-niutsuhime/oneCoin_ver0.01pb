using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Utage;

public class GameStart : MonoBehaviour
{
    public AdvEngine Engine { get { return this.engine ?? (this.engine = FindObjectOfType<AdvEngine>() as AdvEngine); } }
    [SerializeField]
    AdvEngine engine;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        Debug.Log("a");
        SceneManager.LoadScene("FirstScene", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("TitleMenu");
        Engine.JumpScenario("first");
    }
}