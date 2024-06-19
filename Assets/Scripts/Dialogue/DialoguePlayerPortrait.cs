using UnityEngine;
using UnityEngine.UI; 

public class DialoguePlayerPortrait : MonoBehaviour
{
    //This scriptable object holds all the sprites used for the player portrait
    [Header("Player Portrait Scriptable Object")]
    public SO_Player player;

    [Header("Portrait Game Objects")]
    public GameObject accessories;
    public GameObject body;
    public GameObject bottom;
    public GameObject eyes;
    public GameObject eyebrows;
    public GameObject hairBack;
    public GameObject hairFront;
    public GameObject mouth;
    public GameObject nose;
    public GameObject onePiece;
    public GameObject top;


    void Update()
    {
        
        if(player.portraitChanged)
        {

            UpdatePlayerPortrait();
            player.portraitChanged = false; 

        }

        
        

    }


    void UpdatePlayerPortrait()
    {
        accessories.GetComponent<Image>().sprite = player.accessories;
        body.GetComponent<Image>().sprite = player.body;
        bottom.GetComponent<Image>().sprite = player.bottom;
        eyes.GetComponent<Image>().sprite = player.eyes;
        eyebrows.GetComponent<Image>().sprite = player.eyebrows;
        hairBack.GetComponent<Image>().sprite = player.hairBack;
        hairFront.GetComponent<Image>().sprite = player.hairFront;
        mouth.GetComponent<Image>().sprite = player.mouth;
        nose.GetComponent<Image>().sprite = player.nose;
        onePiece.GetComponent<Image>().sprite = player.onePiece;
        top.GetComponent<Image>().sprite = player.top;
    }


}
