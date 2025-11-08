using UnityEngine;
using System.Collections.Generic;
using System;
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

    // seperated into two states so the last line can stay visible even if dialogue isnt "active"
    public bool dialogueActive = false; // actively providing new dialogue - more to see
    public bool dialogueVisible = false; // if the window is still up

    public DialogueGameObject activeSpeaker; // set in StartDialogue

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

    private void FindCanvasUI()
    {
        try
        {
            // FIND UI STUFF
            canvas = GameObject.Find("DialogueCanvas");
            uiText = canvas.GetComponentInChildren<TMP_Text>();
        }
        catch
        {
            Debug.Log("DialogueUI could not be found");
        }
    }

    public void AddDialogue(List<DialogueLine> newDialogue)
    {
        dialogue.Clear();

        foreach (DialogueLine dialogueLine in newDialogue)
        {
            //DEBUGGING -- Debug.Log("Added dialogue line: " + dialogueLine.text);
            dialogue.Add(dialogueLine);
        }
    }

    public void StartDialogue(DialogueGameObject newActiveSpeaker) // called once when dialogue is started
    {
        FindCanvasUI();

        activeSpeaker = newActiveSpeaker;

        if (dialogue.Count < 0)
        {
            Debug.LogError("No dialogue is loaded!");
            return;
        }
        else
        {
            Debug.Log("Dialogue started");

            dialogueActive = true;
            dialogueVisible = true;

            Debug.Log("UI text is" + uiText.gameObject.name);
            Debug.Log("ActiveSpeaker is" + uiText.gameObject.name);

            dialogue[currentDialogueIndex].Show(uiText, activeSpeaker);
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

            if (!dialogueActive && dialogueVisible)
            {
                CloseDialogue();
            }
        }
    }

    private void ShowNextLine()
    {
        dialogue[currentDialogueIndex].Show(uiText, activeSpeaker);
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
    }

    public void CloseDialogue()
    {
        Debug.Log("Dialogue closed");

        dialogue.Clear();
        currentDialogueIndex = 0;

        activeSpeaker = null;
        dialogueVisible = false;
    }

}
