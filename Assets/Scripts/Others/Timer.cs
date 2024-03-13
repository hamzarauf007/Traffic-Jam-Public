using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float duration = 30f;
    
    private float remainingTime;
    private bool isRunning = false;
    
    private void OnEnable()
    {
        GameEvents.OnStartGame += StartTimer;
    }

    private void OnDisable()
    {
        GameEvents.OnStartGame -= StartTimer;
    }

    private void Update()
    {
        if (isRunning)
        {
            remainingTime -= Time.deltaTime;
            
            if (remainingTime <= 0)
            {
                TimerCompleted();
            }
        }
    }

    private void StartTimer()
    {
        remainingTime = duration;
        isRunning = true;
    }
    
    private void TimerCompleted()
    {
        isRunning = false;
        remainingTime = 0; 
        GameEvents.GameEnded();
    }
    
    public string GetFormattedRemainingTime()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(remainingTime);
        return $"Time: {timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
    }
}