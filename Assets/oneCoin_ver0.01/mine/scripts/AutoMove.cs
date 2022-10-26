using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;

public class AutoMove : MonoBehaviour
{
    public AdvEngine Engine { get { return this.engine ?? (this.engine = FindObjectOfType<AdvEngine>() as AdvEngine); } }
    [SerializeField]
    AdvEngine engine;

    public string characterMove;

    float horizontal;
    float vertical;

    GameObject player;
    GameObject Npc1;
    GameObject Npc2;
    GameObject Npc3;

    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void CharacterMove(string a)
    {
        if (a == "NazoNoBasho1")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Vector2 position = rigidbody2d.position;
            position.y = -1;

            rigidbody2d.MovePosition(position);
        }
    }
}
