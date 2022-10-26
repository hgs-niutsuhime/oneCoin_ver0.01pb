using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogScript : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FirstHomeRoom()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 position = player.transform.position;
        position.x = position.x + 2;
        position.y = position.y + 3;

        rigidbody2d.MovePosition(position);
    }
}
