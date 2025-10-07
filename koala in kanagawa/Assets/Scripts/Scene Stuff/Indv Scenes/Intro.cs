using UnityEngine;
using System.Collections.Generic;

public class Intro : MonoBehaviour
{

    void Start()
    {
        List<string> koalaDialogue = new List<string> {
        "G'day!",
        "My name is Koala.",
        "Thank goodness you're here...",
        "Life in Japan is quite different from my home down under.",
        "I could use the extra help getting through the day!",
        "Let's go!!!"};

        DialogueManager.Instance.AddDialogue(koalaDialogue);
        DialogueManager.Instance.StartDialogue();
    }
}
