using DateAndTime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static DateAndTime.TimeManager;

public class TimeUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timeText;

    [SerializeField]
    private TMP_Text dayInMonthText;

    [SerializeField]
    private TMP_Text dayText;

    [SerializeField]
    private SpriteRenderer seasonUI;

    [SerializeField]
    private List<Sprite> seasonBranch = new List<Sprite>();

    [SerializeField]
    private List<Sprite> weatherSprites = new List<Sprite>();

    private void OnEnable()
    {
        TimeManager.OnDateTimeChanged += UpdateDateTime;
    }

    private void OnDisable()
    {
        TimeManager.OnDateTimeChanged -= UpdateDateTime;
    }

    private void UpdateDateTime(DateTime dateTime)
    {
        timeText.text = dateTime.TimeToString();
        dayInMonthText.text = dateTime.DateInMonthToString();
        dayText.text = dateTime.DayToString();

        int seasonIndex = 1;

        for (int i = 0; i < listSeasons.Count; i++)
        {
            if (dateTime.Season.ToString() == listSeasons[i])
                seasonIndex = i;
        }


        seasonUI.sprite = seasonBranch[seasonIndex];

    }

    private List<string> listSeasons = new List<string>()
    {
        "Bloom",
        "Crisp",
        "Freshbud",
        "Glowlush",
        "Jubilee",
        "Sparktip"
    };
}
