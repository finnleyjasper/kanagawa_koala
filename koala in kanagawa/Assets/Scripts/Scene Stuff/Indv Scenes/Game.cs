using UnityEngine;

public class Game : TimedScene
{
    void Start()
    {
        GameManager.Instance.currentSceneType = GameManager.SceneType.Game;
    }

}
