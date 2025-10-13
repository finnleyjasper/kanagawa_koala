using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    private List<DialogueLine> dialogue = new List<DialogueLine>();
    private int currentDialogueIndex = 0;

    private GameObject canvas;
    private TMP_Text uiText;

    public bool dialogueActive = false;
    public GameObject activeSpeaker; // set in StartDialogue -- reset to null in enddialogue() -- JUST THE HEAD???

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
        // FIND UI STUFF
        canvas = GameObject.Find("DialogueCanvas");
        uiText = canvas.GetComponentInChildren<TMP_Text>();
    }

    public void AddDialogue(List<DialogueLine> newDialogue)
    {
        dialogue.Clear();

        foreach (DialogueLine dialogueLine in newDialogue)
        {
            dialogue.Add(dialogueLine);
        }
    }

    public void StartDialogue(GameObject activeSpeaker) // called once when dialogue is started
    {
        if (dialogue.Count < 0)
        {
            Debug.LogError("No dialogue is loaded!");
            return;
        }
        else
        {
            Debug.Log("Dialogue started");

            dialogueActive = true;
            SpriteRenderer expressionSpriteRenderer = activeSpeaker.GetComponent<SpriteRenderer>();
            dialogue[currentDialogueIndex].Show(uiText, expressionSpriteRenderer);
            currentDialogueIndex += 1;
        }

        // make sure there is an active speaker maybe is a good idea
        if (dialogueActive && activeSpeaker == null)
        {
            Debug.LogError("Dialogue is active but no active speaker is set");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (dialogueActive)
            {
                ShowNextLine();
            }
        }
    }

    private void ShowNextLine()
    {
        if (!dialogueActive) // p sure this isnt needed?? oh well?
        {
            dialogueActive = true;
        }

        dialogue[currentDialogueIndex].Show(uiText, activeSpeaker.GetComponent<SpriteRenderer>());
        currentDialogueIndex += 1;

        if (currentDialogueIndex >= dialogue.Count)
        {
           EndDialogue();
        }
    }

    public void EndDialogue()
    {
        Debug.Log("Dialogue ended");

        dialogueActive = false;
        dialogue.Clear();
        currentDialogueIndex = 0;

        activeSpeaker = null;

    }

}
