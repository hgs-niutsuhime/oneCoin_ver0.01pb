using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utage;

public class GoHome : MonoBehaviour
{

    public AdvEngine Engine { get { return this.engine ?? (this.engine = FindObjectOfType<AdvEngine>() as AdvEngine); } }
    [SerializeField]
    AdvEngine engine;

    public string homeScenario;

    public static int nextMonth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Engine.JumpScenario(homeScenario);
        if (Engine.IsEndScenario == true)
        {
            SceneManager.LoadScene("NextMonth", LoadSceneMode.Additive);
        }

//        SceneMove.playerX = 5;
//        SceneMove.playerY = -3;

        PlayerLoad.sceneMove = true;
    }

}
