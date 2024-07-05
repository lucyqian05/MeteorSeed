using static DateAndTime.TimeManager;
using DateAndTime;
using UnityEngine;
using System;

public class TimeEventManager : MonoBehaviour
{
    public event Action OnDayChanged;

    private int currentDay = 0;

    public void OnEnable()
    {
        TimeManager.OnDateTimeChanged += DayChangeCounter;
    }

    public void OnDisable()
    {
        TimeManager.OnDateTimeChanged -= DayChangeCounter;
    }

    private void DayChangeCounter(TimeManager.DateTime dateTime)
    {
        int timeManagerDate = dateTime.Date;

        if (currentDay != timeManagerDate)
        {
            currentDay = timeManagerDate;
            OnDayChanged?.Invoke();
        }
    }
}
