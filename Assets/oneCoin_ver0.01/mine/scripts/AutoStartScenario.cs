using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utage;
using UtageExtensions;

public class AutoStartScenario: MonoBehaviour
{

    public AdvEngine Engine { get { return this.engine ?? (this.engine = FindObjectOfType<AdvEngine>() as AdvEngine); } }
    public AdvEngine engine;

    public AdvEngine advEngine;

    public bool start;

    public string scenarioName;

    // Start is called before the first frame update
    void Start()
    {

        if(start == true)
        {
            if(scenarioName != null)
            {
                scenarioStart();
                start = false;
            }
            
        }

        {
            //���[�h�ς݂̃V�[���ł���΁A���O�ŕʃV�[�����擾�ł���
            Scene scene = SceneManager.GetSceneByName("managerScene");

            //GetRootGameObjects�ŁA���̃V�[���̃��[�gGameObjects
            //�܂�A�q�G�����L�[�̍ŏ�ʂ̃I�u�W�F�N�g���擾�ł���
            foreach (var rootGameObject in scene.GetRootGameObjects())
            {
                if (engine != null)
                {
                    //GameManager�����������̂�
                    //gameManager�̃X�R�A���擾
                    Debug.Log(engine);
                    break;
                }
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scenarioStart()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            MukimuController controller = player.GetComponent<MukimuController>();
            controller.enabled = false;
        }
        advEngine.JumpScenario(scenarioName);
    }
}
