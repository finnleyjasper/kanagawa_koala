using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerBar : MonoBehaviour
{
    public Slider slider;
    public float sliderTimer;
    public bool timerStopped = false;

    void Start()
    {
        slider.maxValue = sliderTimer;
        slider.value = sliderTimer;
    }

    public void StartTimer()
    {
        StartCoroutine(StartTimerTicker());
    }

    IEnumerator StartTimerTicker()
    {
        while (!timerStopped)
        {
            sliderTimer -= Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            if (sliderTimer <= 0)
            {
                timerStopped = true;
            }

            if (!timerStopped)
            {
                slider.value = sliderTimer;
            }
        }
    }

}
