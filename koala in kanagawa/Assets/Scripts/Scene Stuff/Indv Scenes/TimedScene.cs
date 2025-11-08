using UnityEngine;

public class TimedScene : MonoBehaviour
{
    private TimerBar timerBar;

    void Awake()
    {
        try
        {
            timerBar = GameObject.Find("TimerBar").GetComponent<TimerBar>();
            timerBar.StartTimer();
        }
        catch
        {
            Debug.LogWarning("No TimerBar could be found in this scene. Everything will now break.");
        }
    }

    void Update()
    {
        if (timerBar.timerStopped)
        {
            GameManager.Instance.LoadNextScene();
        }
    }

}
