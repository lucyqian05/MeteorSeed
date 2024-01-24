using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopCustomizer : MonoBehaviour
{
    /*
     
    INSPECTOR VARIABLES -------------------------------------------------------------------------------------------
     
    */

    [Header("Portrait Sprite To Change")]
    public SpriteRenderer topSprite;

    [Header("Pixel Sprite To Change")]
    public BodyManager bodyManagerUp;
    public BodyManager bodyManagerDown;
    public BodyManager bodyManagerLeft;
    public BodyManager bodyManagerRight;

    [Header("Scriptable Objects")]
    public SO_CharacterBody characterBody;
    public SO_Player player;

    [Header("Tops")]
    public List<Sprite> topOptions = new List<Sprite>();

    [Header("Sprite Tops")]
    public List<SO_BodyPart> spriteTopOptions = new List<SO_BodyPart>();

    [Header("Color Button Game Objects")]
    public List<GameObject> topColorButtons = new List<GameObject>();

    [Header("Color Button Images")]
    public List<Sprite> topColorButtonImages = new List<Sprite>();

    //Variables need to be public for manipulation from body customizer 
    [System.NonSerialized] public string topGender = "Female";
    [System.NonSerialized] public string topSize = "Body2";
    [System.NonSerialized] public string spriteTopSize = "Medium"; 
    private string topStyle = "DressShirt";
    private string topColor = "White";
    private string[] currentColors = new string[6] { "Black", "BlackWatch", "BuffaloCheck", "White", "COLOR4", "COLOR5" };





    /*
     
    MASTER LISTS FOR INDEX LOOKUP -------------------------------------------------------------------------------------------
     
    */





    private static List<string> topMasterList = new List<string>()
        {
            "Female_Body1_DressShirt-Black",
            "Female_Body1_DressShirt-BlackWatch",
            "Female_Body1_DressShirt-BuffaloCheck", 
            "Female_Body1_DressShirt-White",
            "Female_Body1_Shirt-Black",
            "Female_Body1_Shirt-White",
            "Female_Body2_DressShirt-Black",
            "Female_Body2_DressShirt-BlackWatch",
            "Female_Body2_DressShirt-BuffaloCheck",
            "Female_Body2_DressShirt-White",
            "Female_Body2_Shirt-Black",
            "Female_Body2_Shirt-White",
            "Female_Body4_DressShirt-Black",
            "Female_Body4_DressShirt-BlackWatch",
            "Female_Body4_DressShirt-BuffaloCheck",
            "Female_Body4_DressShirt-White",
            "Female_Body4_Shirt-Black",
            "Female_Body4_Shirt-White",
            "Female_Body5_DressShirt-Black",
            "Female_Body5_DressShirt-BlackWatch",
            "Female_Body5_DressShirt-BuffaloCheck",
            "Female_Body5_DressShirt-White",
            "Female_Body5_Shirt-Black",
            "Female_Body5_Shirt-White"
        };

    private static List<string> spriteTopMasterList = new List<string>()
        {
            "Large_DressShirt-Black",
            "Large_DressShirt-BlackWatch",
            "Large_DressShirt-BuffaloCheck",
            "Large_DressShirt-White",
            "Large_Shirt-Black",
            "Large_Shirt-White",
            "Medium_DressShirt-Black",
            "Medium_DressShirt-BlackWatch",
            "Medium_DressShirt-BuffaloCheck",
            "Medium_DressShirt-White",
            "Medium_Shirt-Black",
            "Medium_Shirt-White"
        };

    private static List<string> colorMasterList = new List<string>()
        {
            "Black",
            "BlackWatch",
            "BuffaloCheck",
            "White"
        };





    /*
     
    FUNCTIONS FOR THE BUTTONS -------------------------------------------------------------------------------------------
     
    */


    // UPDATES THE SPRITE IMAGE
    public void SetTop()
    {
        string topCode = topGender + "_" + topSize + "_" + topStyle + "-" + topColor;
        string spriteTopCode = spriteTopSize + "_" + topStyle + "-" + topColor;

        int topIndex = topMasterList.BinarySearch(topCode);
        int spriteTopIndex = spriteTopMasterList.BinarySearch(spriteTopCode);

        topSprite.sprite = topOptions[topIndex];
        player.top = topOptions[topIndex];

        characterBody.characterBodyParts[4].bodyPart = spriteTopOptions[spriteTopIndex];
        bodyManagerUp.SetCharacterBodyClips();
        bodyManagerDown.SetCharacterBodyClips();
        bodyManagerLeft.SetCharacterBodyClips();
        bodyManagerRight.SetCharacterBodyClips();

    }



    public void colorButton0()
    {
        topColor = currentColors[0];
        SetTop();
    }

    public void colorButton1()
    {
        topColor = currentColors[1];
        SetTop();
    }

    public void colorButton2()
    {
        topColor = currentColors[2];
        SetTop();
    }

    public void colorButton3()
    {
        topColor = currentColors[3];
        SetTop();
    }

    public void colorButton4()
    {
        topColor = currentColors[4];
        SetTop();
    }

    public void colorButton5()
    {
        topColor = currentColors[5];
        SetTop();
    }










    //SETS COLOR BUTTONS AND SHIRT STYLE
    public void SetShirt()
    {
        //SETS THE BUTTONS AS ACTIVE OR INACTIVE
        for (int i = 0; i < 6; i++)
        {
            topColorButtons[i].SetActive(shirt.activeButtons[i]);
        }

        //UPDATES THE COLOR FOR THE BUTTONS IF THEY ARE ON THE LIST OF COLORS. ALSO UPDATES THE COLOR LOOKUP ARRAY FOR BUTTONS
        for (int i = 0; i < 6; i++)
        {
            int topColorIndex = colorMasterList.BinarySearch(shirt.topColors[i]);

            if (topColorIndex < 0)
            {
                continue;
            }

            currentColors[i] = shirt.topColors[i];

            Button currentButton = topColorButtons[i].GetComponent<Button>();
            currentButton.image.overrideSprite = topColorButtonImages[topColorIndex];
        }


        //SETS DEFAULT COLOR IF BUTTON IS CLICKED
        for (int i = 0; i < 6; i++)
        {
            if (topStyle == "Shirt")
            {
                break;
            }
            else if (shirt.activeButtons[i] == true)
            {
                topColor = shirt.topColors[i];
                break;
            } 
            else
            {
                Debug.Log("THERE IS NO DEFAULT??");
            }
        }
       
        topStyle = "Shirt";

        SetTop();

    }



    public void SetDressShirt()
    {
        for (int i = 0; i < 6; i++)
        {
            topColorButtons[i].SetActive(dressshirt.activeButtons[i]);
        }


        for (int i = 0; i < 6; i++)
        {
            int topColorIndex = colorMasterList.BinarySearch(dressshirt.topColors[i]);

            if (topColorIndex < 0)
            {
                continue;
            }

            currentColors[i] = dressshirt.topColors[i];

            Button currentButton = topColorButtons[i].GetComponent<Button>();
            currentButton.image.overrideSprite = topColorButtonImages[topColorIndex];
        }


        for (int i = 0; i < 6; i++)
        {
            if (topStyle == "DressShirt")
            {
                break; 
            }

            else if (dressshirt.activeButtons[i] == true)
            {
                topColor = dressshirt.topColors[i];
                break;
            }

            else
            {
                Debug.Log("THERE IS NO DEFAULT??");
            }
        }

        topStyle = "DressShirt";

        SetTop();

    }








    /*

    TOP CLASSES -------------------------------------------------------------------------------------------

    */



    public class Shirt
    {
        public string topName = "Shirt";
        public bool[] activeButtons = new bool[] { true, true, false, false, false, false };
        public string[] topColors = new string[] { "Black", "White", "COLOR2", "COLOR3", "COLOR4", "COLOR5" };
    }

    Shirt shirt = new Shirt();


    public class DressShirt
    {
        public string topName = "DressShirt";
        public bool[] activeButtons = new bool[] { true, true, true, true, false, false };
        public string[] topColors = new string[] { "Black", "BlackWatch", "BuffaloCheck", "White", "COLOR4", "COLOR5" };
    }

    DressShirt dressshirt = new DressShirt();



}