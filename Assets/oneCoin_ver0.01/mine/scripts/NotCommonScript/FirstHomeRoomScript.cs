using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;

public class FirstHomeRoomScript : MonoBehaviour
{

    public AdvEngine Engine { get { return this.engine ?? (this.engine = FindObjectOfType<AdvEngine>() as AdvEngine); } }
    [SerializeField]
    AdvEngine engine;

    private static bool firstEvent;
    GameObject canvas;

    private Vector2 vector2;

    // Start is called before the first frame update
    void Start()
    {
        if(firstEvent == false)
        {
            Debug.Log(firstEvent);

            //            PlayerLoad pl = GetComponent<PlayerLoad>();
            //            pl.PlaterCreate2();

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            vector2 = new Vector2(-9.0f, -3.5f);
            player.transform.position = vector2;
            Engine.JumpScenario("FirstHomeRoom");
            firstEvent = true;
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        MukimuController controller = other.GetComponent<MukimuController>();

        if (controller != null)
        {
            Engine.JumpScenario("StartHomeRoom1");
        }
    }
*/
}
