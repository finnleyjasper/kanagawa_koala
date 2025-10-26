using UnityEngine;

public class SceneManagerr : MonoBehaviour // two r's so unity doesnt yell at me
{
    public static SceneManagerr Instance;
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


}
