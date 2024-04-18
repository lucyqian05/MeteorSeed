using DateAndTime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    private Weather weather;

    private void Update()
    {
        TimeManager.OnDateTimeChanged += GenerateWeather;
    }

    private void GenerateWeather(TimeManager.DateTime dateTime)
    {
        int weatherGenerator = 1;
        if (dateTime.Season == TimeManager.Season.Freshbud)
        {
            GenerateFreshbudWeather(weatherGenerator);
        }
    }

    private void GenerateFreshbudWeather(int weatherNumber)
    {
        if (weatherNumber > 0)
            weather = Weather.Sunny;
    }

    private void GenerateBloomWeather()
    {
        weather = Weather.Cloudy;
    }

    private void GenerateGlowlushWeather()
    {
        weather = Weather.Sunny;
    }

    private void GenerateSparktipWeather()
    {

    }

    private void GenerateCrispWeather()
    {

    }

    private void GenerateJubileeWeather()
    {

    }

    [Serializable]
    public enum Weather
    {
        Cloudy, 
        Fog,
        Rain,
        Snow,
        Sunny,
        Thunderstorm
    }
}
