using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    [SerializeField] private List<DialogueLine> koalaDialogue;

    void Start()
    {
        DialogueManager.Instance.AddDialogue(koalaDialogue);
        GameObject koala = GameObject.Find("head");
        DialogueManager.Instance.StartDialogue(koala);
    }

    void Update()
    {
        if (!DialogueManager.Instance.dialogueActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                int nextSceneIndex = currentSceneIndex + 1;

                if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
                {
                    nextSceneIndex = 0;
                }

                SceneManager.LoadScene(nextSceneIndex);
            }
        }
    }
}
