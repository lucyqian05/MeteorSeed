using System;
using UnityEngine;

namespace DateAndTime
{
    public class TimeManager : MonoBehaviour
    {
        [Header("Date & Time Settings")]
        [Range(1, 20)]
        public int dateInMonth;
        [Range(1, 6)]
        public int season;
        [Range(1, 99)]
        public int year;
        [Range(0, 24)]
        public int hour;
        [Range(0, 6)]
        public int minutes;

        private DateTime dateTime;

        [Header("Tick Settings")]
        public int TickSecondsIncreased = 10;
        public float TimeBetweenTicks = 1;
        private float currentTimeBetweenTicks = 0;

        public static Action<DateTime> OnDateTimeChanged;

        private void Awake()
        {
            dateTime = new DateTime(dateInMonth + 1, season, year, hour, minutes * 10);
        }

        private void Start()
        {
            OnDateTimeChanged?.Invoke(dateTime);
        }

        private void Update()
        {
            currentTimeBetweenTicks += Time.deltaTime;

            if (currentTimeBetweenTicks >= TimeBetweenTicks)
            {
                currentTimeBetweenTicks = 0;
                Tick();
            }
        }

        private void Tick()
        {
            AdvanceTime();
        }

        private void AdvanceTime()
        {
            dateTime.AdvanceMinutes(TickSecondsIncreased);
            OnDateTimeChanged?.Invoke(dateTime);
        }

        [Serializable]
        public struct DateTime
        {
            #region Fields
            private Days day;
            private int date;
            private int year;

            private int hour;
            private int minutes;

            private Season season;

            private int totalNumDays;
            private int totalNumWeeks;
            #endregion

            #region Properties
            public Days Day => day;
            public int Date => date;
            public int Hour => hour;
            public int Minutes => minutes;
            public Season Season => season;
            public int Year => year;
            public int TotalNumDays => totalNumDays;
            public int TotalNumWeeks => totalNumWeeks;
            public int CurrentWeek => TotalNumWeeks % 24 == 0 ? 24 : TotalNumWeeks % 24;
            #endregion

            #region Constructors
            public DateTime(int date, int season, int year, int hour, int minutes)
            {
                day = (Days)(date % 5);
                if (day == 0) day = (Days)5;
                this.date = date;
                this.season = (Season)season;
                this.year = year;

                this.hour = hour;
                this.minutes = minutes;

                totalNumDays = date + 20 * (int)this.season + 120 * (year - 1);

                totalNumWeeks = 1 + totalNumDays / 5;
            }
            #endregion

            #region Time Advancement 
            public void AdvanceMinutes(int SecondsToAdvanceBy)
            {
                if (minutes + SecondsToAdvanceBy >= 60)
                {
                    minutes = (minutes + SecondsToAdvanceBy) % 60;
                    AdvanceHour();
                }
                else
                {
                    minutes += SecondsToAdvanceBy;
                }
            }

            private void AdvanceHour()
            {
                if (hour + 1 == 24)
                {
                    hour = 0;
                    AdvanceDay();
                }
                else
                {
                    hour++;
                }
            }

            private void AdvanceDay()
            {
                day++;

                if (day > (Days)5)
                {
                    day = (Days)1;
                    totalNumWeeks++;
                }

                date++;

                if (date % 21 == 0)
                {
                    AdvanceSeason();
                    date = 1;
                }
                totalNumDays++;
            }

            private void AdvanceSeason()
            {
                if (Season == Season.Jubilee)
                {
                    season = Season.Freshbud;
                    AdvanceYear();
                }
                else season++;
            }

            private void AdvanceYear()
            {
                date = 1;
                year++;
            }
            #endregion

            #region Bool Checks
            public bool IsNight()
            {
                return hour > 18 || hour < 6;
            }

            public bool IsMorning()
            {
                return hour > 12 && hour <= 12;
            }

            public bool IsAfternoon()
            {
                return hour > 12 && hour < 18;
            }

            public bool IsWeekend()
            {
                return day > Days.Aria ? true : false;
            }

            public bool IsParticularDay(Days _day)
            {
                return day == _day;
            }
            #endregion

            #region Key Dates 

            public DateTime NewYearsDay(int year)
            {
                if (year == 0) year = 1;
                return new DateTime(1, 0, year, 6, 0);
            }

            #endregion

            #region Start Of Season 
            //public DateTime StartOfSeason(int season, int year)
            //{
            //    return new DateTime(1, season, year, 6, 0);
            //}

            //public DateTime StartOfFreshbud(int year)
            //{
            //    StartOfSeason(0, year);
            //}

            //public DateTime StartOfBloom(int year)
            //{
            //    StartOfSeason(1, year);
            //}

            //public DateTime StartOfGlowlush(int year)
            //{
            //    StartOfSeason(2, year);
            //}

            //public DateTime StartOfSparktip(int year)
            //{
            //    StartOfSeason(3, year);
            //}
            //public DateTime StartOfCrisp(int year)
            //{
            //    StartOfSeason(4, year);
            //}

            //public DateTime StartOfJubilee(int year)
            //{
            //    StartOfSeason(5, year);
            //}
            #endregion

            #region To Strings 
            public override string ToString()
            {
                return $"Date: {DateToString()} Season: {season} Time: {TimeToString()} " +
                    $"\nTotalDays: {totalNumDays} | Total Weeks: {TotalNumWeeks}";
            }

            public string TimeToString()
            {
                return $"{hour.ToString("D2")}:{minutes.ToString("D2")}";
            }

            public string DateToString()
            {
                return $"{Day} {Date} {Year.ToString("D2")}";
            }

            public string DateInMonthToString()
            {
                return $"{Day}";
            }

            public string DayToString()
            {
                return $"{Date}";
            }
            #endregion

        }


        [Serializable]
        public enum Days
        {
            NULL = 0,
            Agni = 1,
            Biyo = 2,
            Erde = 3,
            Aria = 4,
            Spirit = 5
        }

        [Serializable]
        public enum Season
        {
            Freshbud = 1,
            Bloom = 2,
            Glowlush = 3,
            Sparktip = 4,
            Crisp = 5,
            Jubilee = 6
        }
    }
}