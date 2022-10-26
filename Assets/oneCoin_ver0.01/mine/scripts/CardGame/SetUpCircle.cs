using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpCircle : MonoBehaviour
{

    private Vector3 _center = new Vector3(-10.0f, -10.0f, -14.0f);
    private Vector3 _axis = new Vector3(30.0f, 0, 0);

    Vector3 viewPosition = Vector3.zero;

    private IEnumerator Dep;

    private void Start()
    {
        Dep = Deploy2ie();
    }

    private void Update()
    {
    }

    public void DoDeploy()
    {
        StartCoroutine(Dep);
    }

    IEnumerator Deploy2ie()
    {
        int Dis = 3;

        float X;
        float Z;
        float rotY;

        List<GameObject> childList = new List<GameObject>();
        foreach (Transform child in transform)
        {
            childList.Add(child.gameObject);
        }


        float angleDiff = 90f / (float)childList.Count;
        float angleDiff2 = angleDiff;

        yield return null;

        for (int i = 0; i < childList.Count; i++)
        {
            angleDiff = angleDiff - angleDiff2;

            X = Dis * Mathf.Sin(angleDiff * Mathf.PI / 180f);
            Z = Dis * Mathf.Cos(angleDiff * Mathf.PI / 180f);

            childList[i].transform.rotation = Quaternion.Euler(-30f, 0, angleDiff);

            childList[i].transform.position = new Vector3(-X-6.5f, Z-5 ,-1f);
        }

    }

    public void Deploy()
    {
        int Dis = 3;

        float X;
        float Z;
        float rotY;

        List<GameObject> childList = new List<GameObject>();
        foreach (Transform child in transform)
        {
            childList.Add(child.gameObject);
        }

        float angleDiff = 90f / (float)childList.Count;
        float angleDiff2 = angleDiff;

        for (int i = 0; i < childList.Count; i++)
        {
            angleDiff = angleDiff - angleDiff2;

            X = Dis * Mathf.Sin(angleDiff * Mathf.PI / 180f);
            Z = Dis * Mathf.Cos(angleDiff * Mathf.PI / 180f);

            childList[i].transform.rotation = Quaternion.Euler(-30f, 0, angleDiff);

            childList[i].transform.position = new Vector3(-X - 6.5f, Z - 5, -1f);
        }
    }

    public void Deploy1()
    {
        float Dis = -2.5f;

        float X;
        float Z;
        float rotY;

        GameObject gameObject = GameObject.Find("CardsPlayer1");

        List<GameObject> childList = new List<GameObject>();
        foreach (Transform child in gameObject.transform)
        {
            childList.Add(child.gameObject);
        }


        float angleDiff = 90f / ((float)childList.Count - 1f);
        float angleDiff2 = angleDiff;

        for (int i = 0; i < childList.Count; i++)
        {
            angleDiff = angleDiff - angleDiff2;

            X = Dis * Mathf.Sin(angleDiff * Mathf.PI / 180f);
            Z = Dis * Mathf.Cos(angleDiff * Mathf.PI / 180f);

            childList[i].transform.rotation = Quaternion.Euler(-30f, 0, angleDiff);

            childList[i].transform.position = new Vector3(-X + 8f, Z + 5f, -1f);
        }
    }
}
