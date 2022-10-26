using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;

public class WillYouSave : MonoBehaviour
{
    int month;

    public AdvEngine Engine { get { return this.engine ?? (this.engine = FindObjectOfType<AdvEngine>() as AdvEngine); } }
    [SerializeField]
    AdvEngine engine;

    // Start is called before the first frame update
    void Start()
    {
        month = GoHome.nextMonth;
        Engine.JumpScenario("WillYouSave");
        GoHome.nextMonth++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
