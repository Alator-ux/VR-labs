using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    float secondsLeft;

    bool started;

    public Action EverySecondAction;
    public Action OnTimeLeft;

    int previousSeconds;

    public static Timer Instance { get; private set; }

    public int SecondsLeft { get => previousSeconds; }
    
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }else if(Instance != this)
        {
            Destroy(gameObject);
        }
        previousSeconds = Mathf.FloorToInt(secondsLeft + 0.9f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            return;
        }
        if(secondsLeft == 0f)
        {
            OnTimeLeft?.Invoke();
            return;
        }
        secondsLeft = Mathf.Max(secondsLeft - Time.deltaTime, 0);
        int currentSeconds = Mathf.FloorToInt(secondsLeft + 0.9f);
        if(previousSeconds != currentSeconds)
        {
            EverySecondAction?.Invoke();
        }
        previousSeconds = currentSeconds;
    }

    public void StartTimer()
    {
        started = true;
    }
    public void StopTimer()
    {
        started = false;
    }
}
