using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    [SerializeField]
    private List<string> koalaDialogue = new List<string> {
        "G'day!",
        "My name is Koala.",
        "Thank goodness you're here...",
        "Life in Japan is quite different from my home down under.",
        "I could use the extra help getting through the day!",
        "Let's go!!!"};

    void Start()
    {
        DialogueManager.Instance.AddDialogue(koalaDialogue);
        DialogueManager.Instance.StartDialogue();
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
