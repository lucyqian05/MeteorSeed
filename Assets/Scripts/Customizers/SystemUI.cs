using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class SystemUI : MonoBehaviour
{

    public int nameLen;
    public GameObject warningBoxes;
    public GameObject nameNeededWarning;
    public GameObject finalWarning;
    public GameObject playerNameInput;
    public GameObject playerNameTMPro;



    //Grabs the SO_Player and checks if name is finalized. Used to issue final warning and switch out game objects
    public SO_Player player; 



    public void Warnings()
    {
        if (nameLen == 0 && player.isName == false)
        {
            warningBoxes.SetActive(true);
            nameNeededWarning.SetActive(true);
            finalWarning.SetActive(false); 

        }
        else if (player.isName == false) 
        {
            warningBoxes.SetActive(true);
            nameNeededWarning.SetActive(false);
            finalWarning.SetActive(true);
        } 
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }




    public void closeWindow()
    {

        warningBoxes.SetActive(false);
        nameNeededWarning.SetActive(false);
        finalWarning.SetActive(false);

    }



    public void PlayGame()
    {
 
        player.isName = true; 

    }



    public void JournalOpen()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }



    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }



    public void PreviousScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }



    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }



    public void QuitGame ()
    {
        Application.Quit();
    }

}
