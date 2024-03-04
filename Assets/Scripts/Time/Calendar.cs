using UnityEngine;

public class Calendar : MonoBehaviour
{

    public GameObject calendar;
    public GameObject[] seasons;


    private int currentSeason = 0; 

    public void OpenCalendar()
    {
        calendar.SetActive(true); 
    }


    public void CloseCalendar()
    {
        calendar.SetActive(false);
    }



    public void NextSeason()
    {

        for (int i = 0; i < 4; i++)
        {
            seasons[i].SetActive(false); 
        }

        
        if (currentSeason < 3)
        {
            
            currentSeason = currentSeason + 1;            
            seasons[currentSeason].SetActive(true);

        } 
        else
        {
            currentSeason = 0;
            seasons[currentSeason].SetActive(true);
        }
        

    }

    public void PreviousSeason()
    {

        for (int i = 0; i < 4; i++)
        {
            seasons[i].SetActive(false);
        }

        if (currentSeason == 0)
        {

            currentSeason = 3;
            seasons[currentSeason].SetActive(true);

        }
        else
        {
            currentSeason = currentSeason - 1;
            seasons[currentSeason].SetActive(true);
        }

    }


}
