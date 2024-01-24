using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnePieceCustomizer : MonoBehaviour
{
    /*
     
    INSPECTOR VARIABLES -------------------------------------------------------------------------------------------
     
    */

    [Header("Sprite To Change")]
    public SpriteRenderer onePieceSprite;

    [Header("Pixel Sprite To Change")]
    public BodyManager bodyManagerUp;
    public BodyManager bodyManagerDown;
    public BodyManager bodyManagerLeft;
    public BodyManager bodyManagerRight;

    [Header("Character Body Scriptable Object")]
    public SO_CharacterBody characterBody;
    public SO_Player player;

    [Header("Game Objects")]
    public GameObject bottomGameObject;
    public GameObject onePieceGameObject;

    [Header("One Piece")]
    public List<Sprite> onePieceOptions = new List<Sprite>();

    [Header("Sprite OnePieces")]
    public List<SO_BodyPart> spriteOnePieceOptions = new List<SO_BodyPart>();

    [Header("Color OnePiece Game Objects")]
    public List<GameObject> onePieceColorButtons = new List<GameObject>();

    [Header("Color Button Images")]
    public List<Sprite> onePieceColorButtonImages = new List<Sprite>();

    //Variables need to be public for manipulation from body customizer 
    [System.NonSerialized] public string onePieceGender = "Female";
    [System.NonSerialized] public string onePieceSize = "Body2";
    [System.NonSerialized] public string spriteOnePieceSize = "Medium";
    string onePieceStyle = "Overalls";
    string onePieceColor = "Denim";
    private string[] currentColors = new string[6] { "AcidWash", "Black", "Denim", "COLOR3", "COLOR4", "COLOR5" };




    /*
     
    MASTER LISTS FOR INDEX LOOKUP -------------------------------------------------------------------------------------------
     
    */






    private static List<string> onePieceMasterList = new List<string>()
        {
            "Female_Body1_Overalls-AcidWash",
            "Female_Body1_Overalls-Black",
            "Female_Body1_Overalls-Denim",
            "Female_Body2_Overalls-AcidWash",
            "Female_Body2_Overalls-Black",
            "Female_Body2_Overalls-Denim",
            "Female_Body4_Overalls-AcidWash",
            "Female_Body4_Overalls-Black",
            "Female_Body4_Overalls-Denim",
            "Female_Body5_Overalls-AcidWash",
            "Female_Body5_Overalls-Black",
            "Female_Body5_Overalls-Denim"

        };

    private static List<string> spriteOnePieceMasterList = new List<string>()
        {
            "Large_Overalls-AcidWash",
            "Large_Overalls-Black",
            "Large_Overalls-Denim",
            "Medium_Overalls-AcidWash",
            "Medium_Overalls-Black",
            "Medium_Overalls-Denim"

        };


    private static List<string> colorMasterList = new List<string>()
        {
            "AcidWash",
            "Black",
            "Denim"
        };






    /*
     
    FUNCTIONS FOR THE BUTTONS -------------------------------------------------------------------------------------------
     
    */





    public void SetOnePiece()
    {

        string onePieceCode = onePieceGender + "_" + onePieceSize + "_" + onePieceStyle + "-" + onePieceColor;
        string spriteOnePieceCode = spriteOnePieceSize + "_" + onePieceStyle + "-" + onePieceColor;

        int onePieceIndex = onePieceMasterList.BinarySearch(onePieceCode);
        int spriteOnePieceIndex = spriteOnePieceMasterList.BinarySearch(spriteOnePieceCode);

        onePieceSprite.sprite = onePieceOptions[onePieceIndex];
        player.onePiece = onePieceOptions[onePieceIndex];


        characterBody.characterBodyParts[3].bodyPart = spriteOnePieceOptions[spriteOnePieceIndex];
        bodyManagerUp.SetCharacterBodyClips();
        bodyManagerDown.SetCharacterBodyClips();
        bodyManagerLeft.SetCharacterBodyClips();
        bodyManagerRight.SetCharacterBodyClips();

    }

    public void colorButton0()
    {
        onePieceColor = currentColors[0];
        SetOveralls();
        SetOnePiece();
    }

    public void colorButton1()
    {
        onePieceColor = currentColors[1];
        SetOveralls();
        SetOnePiece();
    }

    public void colorButton2()
    {
        onePieceColor = currentColors[2];
        SetOveralls();
        SetOnePiece();
    }

    public void colorButton3()
    {
        onePieceColor = currentColors[3];
        SetOveralls();
        SetOnePiece();
    }

    public void colorButton4()
    {
        onePieceColor = currentColors[4];
        SetOveralls();
        SetOnePiece();
    }

    public void colorButton5()
    {
        onePieceColor = currentColors[5];
        SetOveralls();
        SetOnePiece();
    }






    public void SetOveralls()
    {

        if (bottomGameObject.activeInHierarchy == true)
        {
            bottomGameObject.SetActive(false);
            onePieceGameObject.SetActive(true);
        }
        else
        {
            onePieceGameObject.SetActive(true);
        }


        for (int i = 0; i < 6; i++)
        {
            onePieceColorButtons[i].SetActive(overalls.activeButtons[i]);
        }

        for (int i = 0; i < 6; i++)
        {
            int onePieceColorIndex = colorMasterList.BinarySearch(overalls.onePieceColors[i]);

            if (onePieceColorIndex < 0)
            {
                continue;
            }

            currentColors[i] = overalls.onePieceColors[i];

            Button currentButton = onePieceColorButtons[i].GetComponent<Button>();
            currentButton.image.overrideSprite = onePieceColorButtonImages[onePieceColorIndex];
        }


        for (int i = 0; i < 6; i++)
        {
            if (onePieceStyle == "Overalls")
            {
                break;
            }
            else if (overalls.activeButtons[i] == true)
            {
                onePieceColor = overalls.onePieceColors[i];
                break;
            }
            else
            {
                Debug.Log("THERE IS NO DEFAULT??");
            }
        }

        onePieceStyle = "Overalls";

        SetOnePiece();

    }



    /*

    BOTTOM CLASSES -------------------------------------------------------------------------------------------

    */



    public class Overalls
    {
        public string bottomName = "Overalls";
        public bool[] activeButtons = new bool[] { true, true, true, false, false, false };
        public string[] onePieceColors = new string[] { "AcidWash", "Black", "Denim", "COLOR3", "COLOR4", "COLOR5" };
    }

    Overalls overalls = new Overalls();





}
