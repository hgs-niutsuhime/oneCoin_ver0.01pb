using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;

public class UtageForCanvas : MonoBehaviour
{
    MukimuController mukimuController;
    public AdvEngine engine;

    void ResetConversation()
    {
        mukimuController.conversation = 0;
    }
}
