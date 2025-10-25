using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueGameObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer head;
    [SerializeField] private SpriteRenderer body;
    [SerializeField] private SpriteRenderer leftArm;
    [SerializeField] private SpriteRenderer rightArm;

    public void UpdateSprites(DialogueSpriteUpdate[] newSprites)
    {
        foreach (DialogueSpriteUpdate newSprite in newSprites)
        {
            switch (newSprite.tag)
            {
                case "head":
                    head.sprite = newSprite.sprite;
                    break;
                case "leftArm":
                    leftArm.sprite = newSprite.sprite;
                    break;
                case "rightArm":
                    rightArm.sprite = newSprite.sprite;
                    break;
                case "body":
                    body.sprite = newSprite.sprite;
                    break;
            }
        }
    }

}
