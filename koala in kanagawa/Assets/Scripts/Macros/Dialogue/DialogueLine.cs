// sorry if this is redundent garbage future finn, i am drunk <3

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "DialogueLine", menuName = "Dialogue", order = 1)]
public class DialogueLine : ScriptableObject
{
    [SerializeField] private string text;
    [SerializeField] private Sprite expression;

    public bool shown = false;

    // Updates text and sprite parsed in
    public void Show(TMP_Text uiText, SpriteRenderer spriteRenderer)
    {
        shown = true;
        uiText.text = text;
        spriteRenderer.sprite = expression;
    }

    public string Text
    {
        get { return text; }
    }

    public Sprite DialogueSprite
    {
        get { return expression; }
    }
}
