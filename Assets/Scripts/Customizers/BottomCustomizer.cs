using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomCustomizer : MonoBehaviour
{

    /*
     
    INSPECTOR VARIABLES -------------------------------------------------------------------------------------------
     
    */

    [Header("Sprite To Change")]
    public SpriteRenderer bottomSprite;

    [Header("Pixel Sprite To Change")]
    public BodyManager bodyManagerUp;
    public BodyManager bodyManagerDown;
    public BodyManager bodyManagerLeft;
    public BodyManager bodyManagerRight;

    [Header("Scriptable Object")]
    public SO_CharacterBody characterBody;
    public SO_Player player;

    [Header("Game Objects")]
    public GameObject bottomGameObject;
    public GameObject onePieceGameObject;

    [Header("Bottoms")]
    public List<Sprite> bottomOptions = new List<Sprite>();

    [Header("Sprite Bottoms")]
    public List<SO_BodyPart> spriteBottomOptions = new List<SO_BodyPart>();

    [Header("Color Button Game Objects")]
    public List<GameObject> bottomColorButtons = new List<GameObject>();

    [Header("Color Button Images")]
    public List<Sprite> bottomColorButtonImages = new List<Sprite>();

    //Variables need to be public for manipulation from body customizer 
    [System.NonSerialized] public string bottomGender = "Female";
    [System.NonSerialized] public string bottomSize = "Body2";
    [System.NonSerialized] public string spriteBottomSize = "Medium";
    string bottomStyle = "Jeans";
    string bottomColor = "Denim";
    private string[] currentColors = new string[6] { "AcidWash", "Black", "Denim", "COLOR3", "COLOR4", "COLOR5" };




    /*
     
    MASTER LISTS FOR INDEX LOOKUP -------------------------------------------------------------------------------------------
     
    */






    private static List<string> bottomMasterList = new List<string>()
        {
            "Female_Body1_Jeans-AcidWash",
            "Female_Body1_Jeans-Black",
            "Female_Body1_Jeans-Denim",
            "Female_Body2_Jeans-AcidWash",
            "Female_Body2_Jeans-Black",
            "Female_Body2_Jeans-Denim",
            "Female_Body4_Jeans-AcidWash",
            "Female_Body4_Jeans-Black",
            "Female_Body4_Jeans-Denim",
            "Female_Body5_Jeans-AcidWash",
            "Female_Body5_Jeans-Black",
            "Female_Body5_Jeans-Denim",

        };

    private static List<string> spriteBottomMasterList = new List<string>()
        {
            "Large_Jeans-AcidWash",
            "Large_Jeans-Black",
            "Large_Jeans-Denim",
            "Medium_Jeans-AcidWash",
            "Medium_Jeans-Black",
            "Medium_Jeans-Denim"


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





    public void SetBottom()
    {

        string bottomCode = bottomGender + "_" + bottomSize + "_" + bottomStyle + "-" + bottomColor;
        string spriteBottomCode = spriteBottomSize + "_" + bottomStyle + "-" + bottomColor;

        int bottomIndex = bottomMasterList.BinarySearch(bottomCode);
        int spriteBottomIndex = spriteBottomMasterList.BinarySearch(spriteBottomCode);

        bottomSprite.sprite = bottomOptions[bottomIndex];
        player.bottom = bottomOptions[bottomIndex];

        characterBody.characterBodyParts[3].bodyPart = spriteBottomOptions[spriteBottomIndex];
        bodyManagerUp.SetCharacterBodyClips();
        bodyManagerDown.SetCharacterBodyClips();
        bodyManagerLeft.SetCharacterBodyClips();
        bodyManagerRight.SetCharacterBodyClips();

    }

    public void colorButton0()
    {
        bottomColor = currentColors[0];
        SetJeans();
        SetBottom();
    }

    public void colorButton1()
    {
        bottomColor = currentColors[1];
        SetJeans();
        SetBottom();
    }

    public void colorButton2()
    {
        bottomColor = currentColors[2];
        SetJeans();
        SetBottom();
    }

    public void colorButton3()
    {
        bottomColor = currentColors[3];
        SetJeans();
        SetBottom();
    }

    public void colorButton4()
    {
        bottomColor = currentColors[4];
        SetJeans();
        SetBottom();
    }

    public void colorButton5()
    {
        bottomColor = currentColors[5];
        SetJeans();
        SetBottom();
    }






    public void SetJeans()
    {

        if (onePieceGameObject.activeInHierarchy == true)
        {
            bottomGameObject.SetActive(true);
            onePieceGameObject.SetActive(false);
        }
        else
        {
            bottomGameObject.SetActive(true);
        }

        for (int i = 0; i < 6; i++)
        {
            bottomColorButtons[i].SetActive(jeans.activeButtons[i]);
        }

        for (int i = 0; i < 6; i++)
        {
            int bottomColorIndex = colorMasterList.BinarySearch(jeans.bottomColors[i]);

            if (bottomColorIndex < 0)
            {
                continue;
            }

            currentColors[i] = jeans.bottomColors[i];

            Button currentButton = bottomColorButtons[i].GetComponent<Button>();
            currentButton.image.overrideSprite = bottomColorButtonImages[bottomColorIndex];
        }


        for (int i = 0; i < 6; i++)
        {
            if (bottomStyle == "Jeans")
            {
                break;
            }
            else if (jeans.activeButtons[i] == true)
            {
                bottomColor = jeans.bottomColors[i];
                break;
            }
            else
            {
                Debug.Log("THERE IS NO DEFAULT??");
            }
        }

        bottomStyle = "Jeans";

        SetBottom();

    }



    /*

    BOTTOM CLASSES -------------------------------------------------------------------------------------------

    */



    public class Jeans
    {
        public string bottomName = "Jeans";
        public bool[] activeButtons = new bool[] { true, true, true, false, false, false };
        public string[] bottomColors = new string[] { "AcidWash", "Black", "Denim", "COLOR3", "COLOR4", "COLOR5" };
    }

    Jeans jeans = new Jeans();






}
