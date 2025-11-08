using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    [SerializeField] private List<DialogueLine> koalaDialogue;

    void Awake()
    {
        DialogueManager.Instance.AddDialogue(koalaDialogue);

        DialogueGameObject koala = GameObject.Find("koala").GetComponent<DialogueGameObject>();

        DialogueManager.Instance.StartDialogue(koala);
    }

    void Update()
    {
        if (!DialogueManager.Instance.dialogueVisible)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.Instance.currentSceneType = GameManager.SceneType.Instruction;
                GameManager.Instance.LoadNextScene();
            }
        }
    }
}
