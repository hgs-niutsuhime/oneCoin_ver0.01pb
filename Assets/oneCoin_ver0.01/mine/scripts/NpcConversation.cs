using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;

public class NpcConversation : MonoBehaviour
{
    public AdvEngine Engine { get { return this.engine ?? (this.engine = FindObjectOfType<AdvEngine>() as AdvEngine); } }
    [SerializeField]
    AdvEngine engine;
    public string conver1;
    public string conver2;
    public string conver3;


    public IEnumerator ConversationToNpc()
    {
        Engine.JumpScenario(conver1);
        yield return null;
    }
}
