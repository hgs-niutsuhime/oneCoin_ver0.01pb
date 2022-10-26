using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utage;
using Cysharp.Threading.Tasks;

public class SceneMove : MonoBehaviour
{
    public string nowScene;
    public string nextScene;

    public float playerPosX;
    public float playerPosY;
    public string playerMuki;
    public string autoStartScenario2;
    public string nextStage;

    AutoStartScenario autoStartScenario;

    public float playerX;
    public float playerY;
    public string playerDirection;
    public string scenario;
    public string nextStageData;

    /*
    public AdvEngine Engine { get { return this.engine ?? (this.engine = FindObjectOfType<AdvEngine>() as AdvEngine); } }
    [SerializeField]
    AdvEngine engine;
    */

    AdvEngine Engine { get { return engine ?? (engine = FindObjectOfType<AdvEngine>()); } }
    public AdvEngine engine;

    public void Start()
    {
        GameObject gameObject = GameObject.Find("Canvas");
        autoStartScenario = gameObject.GetComponent<AutoStartScenario>();
    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(nextScene , LoadSceneMode.Additive);
        var op = SceneManager.UnloadSceneAsync(nowScene);
        PlayerLoad.sceneMove = true;
        playerX = playerPosX;
        playerY = playerPosY;
        playerDirection = playerMuki;
        nextStageData = nextStage;
        scenario = autoStartScenario.scenarioName;
        if(scenario != "")
        {
            autoStartScenario.scenarioName = autoStartScenario2;
            autoStartScenario.start = true;
        }

        yield return op;
    }

    async UniTask AutoMoveSceneAsync(string myString, string myString2, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await SceneManager.LoadSceneAsync(myString, LoadSceneMode.Additive);
        await AutoUnloadAsync(myString2);
        if (autoStartScenario2 != "")
        {
            Engine.JumpScenario(scenario);
        }
        cancellationToken.ThrowIfCancellationRequested();
    }

    async UniTask AutoUnloadAsync(string a)
    {
        await SceneManager.UnloadSceneAsync(a);
    }
}
