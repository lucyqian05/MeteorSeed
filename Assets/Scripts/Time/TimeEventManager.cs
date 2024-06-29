using static DateAndTime.TimeManager;
using DateAndTime;
using UnityEngine;
using System;

public class TimeEventManager : MonoBehaviour
{
    public event Action OnDayChanged;

    public void OnEnable()
    {
        TimeManager.OnDateTimeChanged += DayChangeCounter;
    }

    public void OnDisable()
    {
        TimeManager.OnDateTimeChanged += DayChangeCounter;
    }

    private void DayChangeCounter(TimeManager.DateTime dateTime)
    {
        int currentDay = 1;

        if (currentDay != dateTime.Date)
        {
            currentDay = dateTime.Date;
            OnDayChanged?.Invoke();
        }
    }
}
