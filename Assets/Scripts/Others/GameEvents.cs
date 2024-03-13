using System;
using UnityEngine;

public abstract class GameEvents
{
    public static event Action<int> OnScoreChanged;
    public static event Action OnStartGame;
    public static event Action OnTimeComplete;
    public static event Action<string, GameObject> OnMoneyCollected;
    public static event Action<GameObject> OnTrafficCarHit;
    
    public static void ScoreChanged(int score)
    {
        OnScoreChanged?.Invoke(score);
    }

    public static void MoneyCollected(string tag, GameObject obj)
    {
        OnMoneyCollected?.Invoke(tag, obj);
    }

    public static void TrafficCarHit(GameObject obj)
    {
        OnTrafficCarHit?.Invoke(obj);
    }
    
    public static void GameStarted()
    {
        OnStartGame?.Invoke();
    }
    
    public static void GameEnded()
    {
        OnTimeComplete?.Invoke();
    }
}
