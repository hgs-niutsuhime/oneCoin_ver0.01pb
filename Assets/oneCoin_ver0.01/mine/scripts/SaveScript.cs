using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SaveScript : MonoBehaviour
{
    [SerializeField]
    public Vector2 myData;

    void OnClickEvent()
    {
        Vector2 myData = new Vector2();
        myData = transform.position;
        Debug.Log(myData);
    }
}
