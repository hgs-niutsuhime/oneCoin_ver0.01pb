using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;
using Cinemachine;

public class FSceneManager : MonoBehaviour
{
    public AdvEngine Engine { get { return this.engine ?? (this.engine = FindObjectOfType<AdvEngine>() as AdvEngine); } }
    [SerializeField]
    AdvEngine engine;

    CinemachineVirtualCamera virtualCamera;

    bool start = true;

    Transform trf;

    // Start is called before the first frame update
    void Start()
    {
        if(start == true)
        {
            CreatePlayer();
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatePlayer()
    {
        GameObject camera = GameObject.Find("CM vcam1");
        virtualCamera = camera.GetComponent<CinemachineVirtualCamera>();
        
        GameObject mukimu = (GameObject)Resources.Load("Mukimu");
        GameObject obj;
        GameObject playerParent = GameObject.Find("PlayerParent");

        obj = Instantiate(mukimu, new Vector2(-1.0f, -3.5f), Quaternion.identity);
        obj.transform.parent = playerParent.transform;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        trf = player.gameObject.GetComponent<Transform>();

        virtualCamera.Follow = trf;
    }
}
