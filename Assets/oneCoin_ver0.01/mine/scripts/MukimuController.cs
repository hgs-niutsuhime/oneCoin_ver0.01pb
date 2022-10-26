using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;

public class MukimuController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    public float conversation;
    
    public AdvEngine Engine { get { return this.engine ?? (this.engine = FindObjectOfType<AdvEngine>() as AdvEngine); } }
    [SerializeField]
    AdvEngine engine;
    
    float dis;
    GameObject[] tag1_Objects;

    Animator animator;
    Vector2 lookDirection = new Vector2(0, 1);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        tag1_Objects = GameObject.FindGameObjectsWithTag("NPC");
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }


        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);


        if (Input.GetButtonUp("Conversation"))
        {
            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Debug.Log(tag1_Objects[i]);
            }
        }
        

        /*
                if (!Npc == false)
                {
                    Vector2 posNpc = Npc.transform.position;
                    Vector2 posPlayer = transform.position;
                    dis = Vector2.Distance(posNpc, posPlayer);

                    if (Mathf.Abs(dis) < 2)
                    {
                        if (Input.GetButtonUp("Conversation"))
                        {
                            NpcConversation conversation = Npc.GetComponent<NpcConversation>();
                            StartCoroutine(conversation.ConversationToNpc());
                        }
                    }


                }
        */

    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
//        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);


    }

}
