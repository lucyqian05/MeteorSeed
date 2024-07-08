using static DateAndTime.TimeManager;
using DateAndTime;
using UnityEngine;
using System;

public class TimeEventManager : MonoBehaviour
{
    public event Action OnDayChanged;

    private int currentDay = 0;

    public string currentSeason = "none";

    public void OnEnable()
    {
        TimeManager.OnDateTimeChanged += DayChangeCounter;
        TimeManager.OnDateTimeChanged += SeasonChange;
    }

    public void OnDisable()
    {
        TimeManager.OnDateTimeChanged -= DayChangeCounter;
    }

    private void SeasonChange(TimeManager.DateTime dateTime)
    {
        string season = dateTime.DateInSeasonToString();

        if (currentSeason == "none")
        {
            currentSeason = season;
        }
        else if (currentSeason != season)
        {
            currentSeason = season;
        }
    }

    private void DayChangeCounter(TimeManager.DateTime dateTime)
    {
        int timeManagerDate = dateTime.Date;

        if(currentDay == 0)
        {
            currentDay = timeManagerDate;
            return;
        }

        if (currentDay != timeManagerDate)
        {
            currentDay = timeManagerDate;
            OnDayChanged?.Invoke();
        }
    }
}
