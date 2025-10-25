
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

[CreateAssetMenu(fileName = "DialogueLine", menuName = "Dialogue", order = 1)]
public class DialogueLine : ScriptableObject
{
    [SerializeField] private string text;
    [SerializeField] private DialogueSpriteUpdate[] newSprites;

    public bool shown = false;

    public void Start()
    {
        newSprites = new DialogueSpriteUpdate[0];
    }

    // Updates text and sprite parsed in
    public void Show(TMP_Text uiText, DialogueGameObject speaker)
    {
        shown = true;
        uiText.text = text;

        if (newSprites.Length > 0)
        {
            speaker.UpdateSprites(newSprites);
        }
    }

    public string Text
    {
        get { return text; }
    }
}
