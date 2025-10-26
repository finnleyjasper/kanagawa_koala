using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerBar : MonoBehaviour
{
    public Slider slider;
    public float sliderTimer;
    public bool stopTimer = false;

    void Start()
    {
        slider.maxValue = sliderTimer;
        slider.value = sliderTimer;

        // REMOVE WHEN FINISHED - this should get called from a game manager or scene manager or something
        StartTimer();
    }

    public void StartTimer()
    {
        StartCoroutine(StartTimerTicker());
    }

    IEnumerator StartTimerTicker()
    {
        while (!stopTimer)
        {
            sliderTimer -= Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            if (sliderTimer <= 0)
            {
                stopTimer = true;
            }

            if (!stopTimer)
            {
                slider.value = sliderTimer;
            }
        }
    }

}
