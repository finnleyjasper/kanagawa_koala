using UnityEngine;

public class InstructionScene : TimedScene
{
    void Start()
    {
        GameManager.Instance.currentSceneType = GameManager.SceneType.Instruction;
    }
}
