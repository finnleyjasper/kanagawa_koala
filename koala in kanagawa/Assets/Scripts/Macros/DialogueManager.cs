using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    private List<string> dialogue = new List<string>();
    private int currentDialogueIndex = 0;

    private GameObject canvas;
    private TMP_Text uiText;

    public bool dialogueActive = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        canvas = GameObject.Find("DialogueCanvas");
        uiText = canvas.GetComponentInChildren<TMP_Text>();
    }

    public void AddDialogue(List<string> newDialogue)
    {
        dialogue.Clear();

        foreach (string dialogueItem in newDialogue)
        {
            dialogue.Add(dialogueItem);
        }
    }

    public void StartDialogue()
    {
        if (dialogue.Count < 1)
        {
            Debug.LogError("No dialogue is loaded!");
            return;
        }
        else
        {
            dialogueActive = true;
            uiText.text = dialogue[currentDialogueIndex];
        }
    }

    private void OnMouseDown()
    {
        if (dialogueActive)
        {
            ShowNextLine();
        }
    }

    private void ShowNextLine()
    {
        if (!dialogueActive)
        {
            dialogueActive = true;
        }

        uiText.text = dialogue[currentDialogueIndex];
        currentDialogueIndex += 1;

        if (currentDialogueIndex > dialogue.Count)
        {
           EndDialogue();
        }
    }

    public void EndDialogue()
    {
        dialogueActive = false;
        dialogue.Clear();
        currentDialogueIndex = 0;

    }

}
