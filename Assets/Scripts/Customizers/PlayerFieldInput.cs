using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerFieldInput : MonoBehaviour
{

    [Header("Reaction Group")]
    public SO_Player so_Player; 
    public GameObject characterGenUI;
    public TMP_Text finalName;

    //This is to switch out the player input field for the final text
    public GameObject nameInputField;
    public GameObject playerFinalName; 


    private int nameLength;
    private SystemUI systemUI; 
    


    void Start()
    {

        systemUI = characterGenUI.GetComponent<SystemUI>();

        if (so_Player.isName == true)
        {

            playerFinalName.SetActive(true);
            nameInputField.SetActive(false);
            finalName.text = so_Player.playerName;

        }


    }



    public void setPlayerName(string name)
    {
        //Sets Player Name in the player game object
        so_Player.playerName = name;

        //Used for the game start to tell if there's a valid name
        nameLength = name.Length;
        systemUI.nameLen = nameLength;

    }

    public void setPlayerPronouns(int value)
    {

        if (value == 0)
        {
            so_Player.subjectivePronoun = "they";
            so_Player.objectivePronoun = "them";
            so_Player.possessivePronoun = "theirs";
            so_Player.reflexivePronoun = "themselves";
        } 
        else if (value == 1)
        {
            so_Player.subjectivePronoun = "she";
            so_Player.objectivePronoun = "her";
            so_Player.possessivePronoun = "hers";
            so_Player.reflexivePronoun = "herself";
        }
        else
        {
            so_Player.subjectivePronoun = "he";
            so_Player.objectivePronoun = "him";
            so_Player.possessivePronoun = "his";
            so_Player.reflexivePronoun = "himself";
        }

    }



}
