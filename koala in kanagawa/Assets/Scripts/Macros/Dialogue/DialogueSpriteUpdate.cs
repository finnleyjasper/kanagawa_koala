using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "DialogueSpriteUpdate", menuName = "DialogueSprite", order = 2)]
public class DialogueSpriteUpdate : ScriptableObject
{
    public string tag; // head, leftArm, rightArm, body
    public Sprite sprite;

}
