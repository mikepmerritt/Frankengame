using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementReset : MonoBehaviour
{
    public Image CountdownImage;
    public static event Action<bool> CountdownFinish;
    private void OnEnable()
    {
        CaptivateChecker.CountDown += CountStart;
    }
    private void OnDisable()
    {
        CaptivateChecker.CountDown -= CountStart;
    }
    private void CountStart(float timer)
    {
        Captivate.Distracted = true;
        StartCoroutine(Countdown(timer));
    }//counts down when distracted.
    IEnumerator Countdown(float timer)
    {
        float countdown = timer;
        CountdownImage.enabled = true;
        while (countdown > 0)
        {
            yield return new WaitForSeconds(1);
            countdown--;
            CountdownImage.fillAmount = ((countdown / timer));
            //Debug.Log(countdown / timer);
        }//reduces countdown image for visual feedback.
        yield return new WaitForSeconds(1);
        CountdownFinish.Invoke(true);
        CountdownImage.enabled = false;
        Captivate.Distracted = false;
    }//after countdown is complete, returns to original rotation.
}